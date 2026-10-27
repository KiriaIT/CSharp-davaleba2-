using System;
using System.Windows.Forms;

namespace IfAmocanebi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // ===== ამოცანა 1: ორი რიცხვიდან უდიდესი =====
        private void btn1_Click(object sender, EventArgs e)
        {
            double a, b;
            double.TryParse(txt1A.Text, out a);
            double.TryParse(txt1B.Text, out b);

            if (a > b)
            {
                lblRes1.Text = "უდიდესია a = " + a;
            }
            else if (b > a)
            {
                lblRes1.Text = "უდიდესია b = " + b;
            }
            else
            {
                lblRes1.Text = "რიცხვები ტოლია";
            }
        }

        // ===== ამოცანა 2: ლუწი თუ კენტი =====
        private void btn2_Click(object sender, EventArgs e)
        {
            int n = (int)num2.Value;

            // % აბრუნებს ნაშთს. თუ 2-ზე გაყოფის ნაშთი 0-ია, რიცხვი ლუწია
            if (n % 2 == 0)
            {
                lblRes2.Text = n + " ლუწი რიცხვია";
            }
            else
            {
                lblRes2.Text = n + " კენტი რიცხვია";
            }
        }

        // ===== ამოცანა 3: დადებითი, უარყოფითი თუ ნული =====
        private void btn3_Click(object sender, EventArgs e)
        {
            double x;
            double.TryParse(txt3X.Text, out x);

            if (x > 0)
            {
                lblRes3.Text = "რიცხვი დადებითია";
            }
            else if (x < 0)
            {
                lblRes3.Text = "რიცხვი უარყოფითია";
            }
            else
            {
                lblRes3.Text = "რიცხვი ნულის ტოლია";
            }
        }

        // ===== ამოცანა 4: სამი რიცხვიდან უდიდესი და უმცირესი =====
        private void btn4_Click(object sender, EventArgs e)
        {
            double a, b, c;
            double.TryParse(txt4A.Text, out a);
            double.TryParse(txt4B.Text, out b);
            double.TryParse(txt4C.Text, out c);

            // ჯერ ვთვლით, რომ უდიდესი a-ა, მერე b-ს და c-ს ვადარებთ
            double max = a;
            if (b > max)
            {
                max = b;
            }
            if (c > max)
            {
                max = c;
            }

            double min = a;
            if (b < min)
            {
                min = b;
            }
            if (c < min)
            {
                min = c;
            }

            lblRes4.Text = "უდიდესი: " + max + "\nუმცირესი: " + min;
        }

        // ===== ამოცანა 5: კვადრატული განტოლება ax² + bx + c = 0 =====
        private void btn5_Click(object sender, EventArgs e)
        {
            double a, b, c;
            double.TryParse(txt5A.Text, out a);
            double.TryParse(txt5B.Text, out b);
            double.TryParse(txt5C.Text, out c);

            if (a == 0)
            {
                MessageBox.Show("a არ უნდა იყოს 0-ის ტოლი!");
                return;
            }

            double d = b * b - 4 * a * c; // დისკრიმინანტი

            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                lblRes5.Text = "D = " + d + "\nx1 = " + Math.Round(x1, 2) + "\nx2 = " + Math.Round(x2, 2);
            }
            else if (d == 0)
            {
                double x = -b / (2 * a);
                lblRes5.Text = "D = 0\nერთი ფესვი: x = " + Math.Round(x, 2);
            }
            else
            {
                lblRes5.Text = "D = " + d + "\nფესვები არ აქვს";
            }
        }

        // ===== ამოცანა 6: ნაკიანი წელი =====
        private void btn6_Click(object sender, EventArgs e)
        {
            int year = (int)num6.Value;

            // ნაკიანია: იყოფა 4-ზე და არ იყოფა 100-ზე, ან იყოფა 400-ზე
            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                lblRes6.Text = year + " ნაკიანი წელია (366 დღე)";
            }
            else
            {
                lblRes6.Text = year + " ნაკიანი წელი არ არის (365 დღე)";
            }
        }

        // ===== ამოცანა 7: სამკუთხედი =====
        private void btn7_Click(object sender, EventArgs e)
        {
            double a, b, c;
            double.TryParse(txt7A.Text, out a);
            double.TryParse(txt7B.Text, out b);
            double.TryParse(txt7C.Text, out c);

            // სამკუთხედი არსებობს, თუ ნებისმიერი ორი გვერდის ჯამი მესამეზე მეტია
            if (a + b > c && a + c > b && b + c > a)
            {
                string type;
                if (a == b && b == c)
                {
                    type = "ტოლგვერდა";
                }
                else if (a == b || b == c || a == c)
                {
                    type = "ტოლფერდა";
                }
                else
                {
                    type = "სხვადასხვაგვერდა";
                }

                lblRes7.Text = "სამკუთხედი არსებობს\nსახე: " + type + "\nპერიმეტრი: " + (a + b + c);
            }
            else
            {
                lblRes7.Text = "ასეთი სამკუთხედი არ არსებობს";
            }
        }

        // ===== ამოცანა 8: შეფასება ქულის მიხედვით =====
        // სლაიდერის გადაწევისას ქულა ეწერება ლეიბლში
        private void trk8_ValueChanged(object sender, EventArgs e)
        {
            lbl8Value.Text = trk8.Value.ToString();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            int score = trk8.Value;

            if (score >= 91)
            {
                lblRes8.Text = "A - ფრიადი";
            }
            else if (score >= 81)
            {
                lblRes8.Text = "B - ძალიან კარგი";
            }
            else if (score >= 71)
            {
                lblRes8.Text = "C - კარგი";
            }
            else if (score >= 61)
            {
                lblRes8.Text = "D - დამაკმაყოფილებელი";
            }
            else if (score >= 51)
            {
                lblRes8.Text = "E - საკმარისი";
            }
            else if (score >= 41)
            {
                lblRes8.Text = "FX - ვერ ჩააბარა";
            }
            else
            {
                lblRes8.Text = "F - ჩაიჭრა";
            }
        }

        // ===== ამოცანა 9: კალკულატორი =====
        private void btn9_Click(object sender, EventArgs e)
        {
            double a, b;
            double.TryParse(txt9A.Text, out a);
            double.TryParse(txt9B.Text, out b);

            if (rb9Plus.Checked)
            {
                lblRes9.Text = "a + b = " + (a + b);
            }
            else if (rb9Minus.Checked)
            {
                lblRes9.Text = "a - b = " + (a - b);
            }
            else if (rb9Mul.Checked)
            {
                lblRes9.Text = "a * b = " + (a * b);
            }
            else if (rb9Div.Checked)
            {
                if (b == 0)
                {
                    lblRes9.Text = "ნულზე გაყოფა არ შეიძლება!";
                }
                else
                {
                    lblRes9.Text = "a / b = " + Math.Round(a / b, 2);
                }
            }
        }

        // ===== ამოცანა 10: სხეულის მასის ინდექსი (BMI) =====
        private void btn10_Click(object sender, EventArgs e)
        {
            double w, h;
            double.TryParse(txt10W.Text, out w);
            double.TryParse(txt10H.Text, out h);

            if (w <= 0 || h <= 0)
            {
                MessageBox.Show("წონა და სიმაღლე 0-ზე მეტი უნდა იყოს!");
                return;
            }

            h = h / 100; // სანტიმეტრი -> მეტრი
            double bmi = Math.Round(w / (h * h), 1);

            if (bmi < 18.5)
            {
                lblRes10.Text = "BMI = " + bmi + "\nწონის ნაკლებობა";
            }
            else if (bmi < 25)
            {
                lblRes10.Text = "BMI = " + bmi + "\nნორმალური წონა";
            }
            else if (bmi < 30)
            {
                lblRes10.Text = "BMI = " + bmi + "\nჭარბი წონა";
            }
            else
            {
                lblRes10.Text = "BMI = " + bmi + "\nსიმსუქნე";
            }
        }

        // ===== ამოცანა 11: წყლის მდგომარეობა ტემპერატურით =====
        private void btn11_Click(object sender, EventArgs e)
        {
            double t;
            double.TryParse(txt11T.Text, out t);

            if (t <= 0)
            {
                lblRes11.Text = "ყინული (მყარი)";
            }
            else if (t < 100)
            {
                lblRes11.Text = "წყალი (თხევადი)";
            }
            else
            {
                lblRes11.Text = "ორთქლი (აირადი)";
            }
        }

        // ===== ამოცანა 12: კვირის დღე ნომრით =====
        private void btn12_Click(object sender, EventArgs e)
        {
            int n;
            int.TryParse(txt12N.Text, out n);

            if (n < 1 || n > 7)
            {
                lblRes12.Text = "შეიყვანეთ რიცხვი 1-დან 7-მდე!";
                return;
            }

            string day;
            if (n == 1)
            {
                day = "ორშაბათი";
            }
            else if (n == 2)
            {
                day = "სამშაბათი";
            }
            else if (n == 3)
            {
                day = "ოთხშაბათი";
            }
            else if (n == 4)
            {
                day = "ხუთშაბათი";
            }
            else if (n == 5)
            {
                day = "პარასკევი";
            }
            else if (n == 6)
            {
                day = "შაბათი";
            }
            else
            {
                day = "კვირა";
            }

            if (n >= 6)
            {
                lblRes12.Text = day + "\nდასვენების დღეა";
            }
            else
            {
                lblRes12.Text = day + "\nსამუშაო დღეა";
            }
        }

        // ===== ამოცანა 13: წელიწადის დრო =====
        private void btn13_Click(object sender, EventArgs e)
        {
            int month = dtp13.Value.Month; // თვის ნომერი არჩეული თარიღიდან (1-12)

            if (month == 12 || month == 1 || month == 2)
            {
                lblRes13.Text = "ზამთარი";
            }
            else if (month >= 3 && month <= 5)
            {
                lblRes13.Text = "გაზაფხული";
            }
            else if (month >= 6 && month <= 8)
            {
                lblRes13.Text = "ზაფხული";
            }
            else
            {
                lblRes13.Text = "შემოდგომა";
            }
        }

        // ===== ამოცანა 14: წერტილის მდებარეობა =====
        private void btn14_Click(object sender, EventArgs e)
        {
            double x, y;
            double.TryParse(txt14X.Text, out x);
            double.TryParse(txt14Y.Text, out y);

            // ჯერ ღერძებს ვამოწმებთ, რადგან 0 არც დადებითია, არც უარყოფითი
            if (x == 0 && y == 0)
            {
                lblRes14.Text = "კოორდინატთა სათავეშია";
            }
            else if (x == 0)
            {
                lblRes14.Text = "Y ღერძზეა";
            }
            else if (y == 0)
            {
                lblRes14.Text = "X ღერძზეა";
            }
            else if (x > 0 && y > 0)
            {
                lblRes14.Text = "I მეოთხედშია";
            }
            else if (x < 0 && y > 0)
            {
                lblRes14.Text = "II მეოთხედშია";
            }
            else if (x < 0 && y < 0)
            {
                lblRes14.Text = "III მეოთხედშია";
            }
            else
            {
                lblRes14.Text = "IV მეოთხედშია";
            }
        }

        // ===== ამოცანა 15: მაღაზიის ფასდაკლება =====
        private void btn15_Click(object sender, EventArgs e)
        {
            double sum;
            double.TryParse(txt15S.Text, out sum);

            if (sum <= 0)
            {
                MessageBox.Show("თანხა 0-ზე მეტი უნდა იყოს!");
                return;
            }

            int discount;
            if (sum >= 500)
            {
                discount = 15;
            }
            else if (sum >= 200)
            {
                discount = 10;
            }
            else if (sum >= 100)
            {
                discount = 5;
            }
            else
            {
                discount = 0;
            }

            // ბარათი არჩეულია (CheckBox მონიშნულია) -> კიდევ 5%
            if (chk15Card.Checked)
            {
                discount = discount + 5;
            }

            double pay = sum - sum * discount / 100;
            lblRes15.Text = "ფასდაკლება: " + discount + "%\nგადასახდელი: " + Math.Round(pay, 2) + " ლარი";
        }
    }
}
