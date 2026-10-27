using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace IfAmocanebi
{
    public partial class Form1 : Form
    {
        // მე-14 ამოცანის წერტილი (Panel-ზე დასახატად)
        double pointX, pointY;
        bool pointSet = false;

        public Form1()
        {
            InitializeComponent();
        }

        // TextBox-დან რიცხვის წაკითხვა. იღებს როგორც "2.5"-ს, ისე "2,5"-ს.
        // თუ ჩაწერილი არ არის რიცხვი, ველი წითლდება და ჩნდება შეტყობინება.
        private bool ReadNumber(TextBox tb, out double value)
        {
            string s = tb.Text.Trim().Replace(',', '.');
            if (double.TryParse(s, NumberStyles.Float, CultureInfo.InvariantCulture, out value))
            {
                tb.BackColor = SystemColors.Window;
                return true;
            }

            tb.BackColor = Color.MistyRose;
            tb.Focus();
            MessageBox.Show("შეიყვანეთ სწორი რიცხვი!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return false;
        }

        // რიცხვის ჩვენება მაქსიმუმ 4 ათწილადი ნიშნით
        private string Fmt(double x)
        {
            return Math.Round(x, 4).ToString();
        }

        // ===== ამოცანა 1: ორი რიცხვიდან უდიდესი =====
        private void btn1_Click(object sender, EventArgs e)
        {
            double a, b;
            if (!ReadNumber(txt1A, out a) || !ReadNumber(txt1B, out b))
                return;

            if (a > b)
                lblRes1.Text = "უდიდესია a = " + Fmt(a);
            else if (b > a)
                lblRes1.Text = "უდიდესია b = " + Fmt(b);
            else
                lblRes1.Text = "რიცხვები ტოლია:\na = b = " + Fmt(a);
        }

        // ===== ამოცანა 2: ლუწი თუ კენტი =====
        private void btn2_Click(object sender, EventArgs e)
        {
            int n = (int)num2.Value;
            string text;

            if (n % 2 == 0)
            {
                text = n + " ლუწი რიცხვია.";
                lblRes2.ForeColor = Color.SeaGreen;
            }
            else
            {
                text = n + " კენტი რიცხვია.";
                lblRes2.ForeColor = Color.DarkOrange;
            }

            if (n % 3 == 0)
                text += "\n" + n + " იყოფა 3-ზე უნაშთოდ.";
            else
                text += "\n" + n + " არ იყოფა 3-ზე (ნაშთი " + Math.Abs(n % 3) + ").";

            lblRes2.Text = text;
        }

        // ===== ამოცანა 3: დადებითი, უარყოფითი თუ ნული =====
        private void btn3_Click(object sender, EventArgs e)
        {
            double x;
            if (!ReadNumber(txt3X, out x))
                return;

            if (x > 0)
            {
                lblRes3.Text = x + " დადებითი რიცხვია.";
                lblRes3.ForeColor = Color.SeaGreen;
                pnl3.BackColor = Color.LimeGreen;
            }
            else if (x < 0)
            {
                lblRes3.Text = x + " უარყოფითი რიცხვია.";
                lblRes3.ForeColor = Color.Crimson;
                pnl3.BackColor = Color.Red;
            }
            else
            {
                lblRes3.Text = "რიცხვი ნულის ტოლია.";
                lblRes3.ForeColor = Color.RoyalBlue;
                pnl3.BackColor = Color.LightSkyBlue;
            }
        }

        // ===== ამოცანა 4: სამი რიცხვიდან უდიდესი და უმცირესი =====
        private void btn4_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (!ReadNumber(txt4A, out a) || !ReadNumber(txt4B, out b) || !ReadNumber(txt4C, out c))
                return;

            double max = a;
            if (b > max)
                max = b;
            if (c > max)
                max = c;

            double min = a;
            if (b < min)
                min = b;
            if (c < min)
                min = c;

            if (max == min)
                lblRes4.Text = "სამივე რიცხვი ტოლია: " + Fmt(a);
            else
                lblRes4.Text = "უდიდესი: " + Fmt(max) + "\nუმცირესი: " + Fmt(min);
        }

        // ===== ამოცანა 5: კვადრატული განტოლება ax² + bx + c = 0 =====
        private void btn5_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (!ReadNumber(txt5A, out a) || !ReadNumber(txt5B, out b) || !ReadNumber(txt5C, out c))
                return;

            if (a == 0)
            {
                // a = 0 -> განტოლება წრფივია: bx + c = 0
                if (b == 0)
                {
                    if (c == 0)
                        lblRes5.Text = "a = b = c = 0\nამონახსნი ნებისმიერი რიცხვია.";
                    else
                        lblRes5.Text = "a = b = 0, c ≠ 0\nამონახსნი არ აქვს.";
                }
                else
                {
                    lblRes5.Text = "a = 0, განტოლება წრფივია.\nx = " + Fmt(-c / b);
                }
                return;
            }

            double d = b * b - 4 * a * c;
            if (d > 0)
            {
                double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                lblRes5.Text = "D = " + Fmt(d) + " > 0, ორი ფესვი:\nx1 = " + Fmt(x1) + "\nx2 = " + Fmt(x2);
            }
            else if (d == 0)
            {
                lblRes5.Text = "D = 0, ერთი ფესვი:\nx = " + Fmt(-b / (2 * a));
            }
            else
            {
                lblRes5.Text = "D = " + Fmt(d) + " < 0\nნამდვილი ფესვები არ აქვს.";
            }
        }

        // ===== ამოცანა 6: ნაკიანი წელი =====
        private void btn6_Click(object sender, EventArgs e)
        {
            int year = (int)num6.Value;

            if ((year % 4 == 0 && year % 100 != 0) || year % 400 == 0)
            {
                lblRes6.Text = year + " ნაკიანი წელია.\nმასში 366 დღეა, თებერვალში — 29.";
                lblRes6.ForeColor = Color.SeaGreen;
            }
            else
            {
                lblRes6.Text = year + " ნაკიანი წელი არ არის.\nმასში 365 დღეა, თებერვალში — 28.";
                lblRes6.ForeColor = Color.Crimson;
            }
        }

        // ===== ამოცანა 7: სამკუთხედის არსებობა და სახე =====
        private void btn7_Click(object sender, EventArgs e)
        {
            double a, b, c;
            if (!ReadNumber(txt7A, out a) || !ReadNumber(txt7B, out b) || !ReadNumber(txt7C, out c))
                return;

            if (a <= 0 || b <= 0 || c <= 0)
            {
                lblRes7.Text = "გვერდები დადებითი უნდა იყოს!";
                lblRes7.ForeColor = Color.Crimson;
                return;
            }

            if (a + b <= c || a + c <= b || b + c <= a)
            {
                lblRes7.Text = "ასეთი სამკუთხედი არ არსებობს!\n(ორი გვერდის ჯამი მესამეზე მეტი უნდა იყოს)";
                lblRes7.ForeColor = Color.Crimson;
                return;
            }

            string type;
            if (a == b && b == c)
                type = "ტოლგვერდა";
            else if (a == b || b == c || a == c)
                type = "ტოლფერდა";
            else
                type = "სხვადასხვაგვერდა";

            // მართკუთხაა თუ არა (პითაგორას თეორემა)
            double a2 = a * a, b2 = b * b, c2 = c * c;
            if (Math.Abs(a2 + b2 - c2) < 1e-9 || Math.Abs(a2 + c2 - b2) < 1e-9 || Math.Abs(b2 + c2 - a2) < 1e-9)
                type += ", მართკუთხა";

            double p = a + b + c;
            double s = p / 2;
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c)); // ჰერონის ფორმულა

            lblRes7.Text = "სამკუთხედი არსებობს!\nსახე: " + type + "\nპერიმეტრი P = " + Fmt(p) + "\nფართობი S = " + Fmt(area);
            lblRes7.ForeColor = Color.SeaGreen;
        }

        // ===== ამოცანა 8: შეფასება ქულის მიხედვით =====
        private void trk8_ValueChanged(object sender, EventArgs e)
        {
            lbl8Value.Text = trk8.Value.ToString();
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            int score = trk8.Value;
            string grade, word;

            if (score >= 91)
            {
                grade = "A";
                word = "ფრიადი";
            }
            else if (score >= 81)
            {
                grade = "B";
                word = "ძალიან კარგი";
            }
            else if (score >= 71)
            {
                grade = "C";
                word = "კარგი";
            }
            else if (score >= 61)
            {
                grade = "D";
                word = "დამაკმაყოფილებელი";
            }
            else if (score >= 51)
            {
                grade = "E";
                word = "საკმარისი";
            }
            else if (score >= 41)
            {
                grade = "FX";
                word = "ვერ ჩააბარა (აქვს დამატებითი გამოცდის უფლება)";
            }
            else
            {
                grade = "F";
                word = "ჩაიჭრა";
            }

            lblRes8.Text = "ქულა: " + score + "\nშეფასება: " + grade + "\n" + word;
            if (score >= 51)
                lblRes8.ForeColor = Color.SeaGreen;
            else
                lblRes8.ForeColor = Color.Crimson;
        }

        // ===== ამოცანა 9: კალკულატორი =====
        private void btn9_Click(object sender, EventArgs e)
        {
            double a, b;
            if (!ReadNumber(txt9A, out a) || !ReadNumber(txt9B, out b))
                return;

            double r;
            string op;

            if (rb9Plus.Checked)
            {
                r = a + b;
                op = "+";
            }
            else if (rb9Minus.Checked)
            {
                r = a - b;
                op = "−";
            }
            else if (rb9Mul.Checked)
            {
                r = a * b;
                op = "×";
            }
            else if (rb9Div.Checked)
            {
                if (b == 0)
                {
                    lblRes9.Text = "ნულზე გაყოფა არ შეიძლება!";
                    lblRes9.ForeColor = Color.Crimson;
                    return;
                }
                r = a / b;
                op = "÷";
            }
            else
            {
                MessageBox.Show("აირჩიეთ მოქმედება!");
                return;
            }

            lblRes9.Text = Fmt(a) + " " + op + " " + Fmt(b) + " = " + Fmt(r);
            lblRes9.ForeColor = Color.MidnightBlue;
        }

        // ===== ამოცანა 10: სხეულის მასის ინდექსი (BMI) =====
        private void btn10_Click(object sender, EventArgs e)
        {
            double w, h;
            if (!ReadNumber(txt10W, out w) || !ReadNumber(txt10H, out h))
                return;

            if (w <= 0 || h <= 0)
            {
                MessageBox.Show("წონა და სიმაღლე დადებითი უნდა იყოს!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double m = h / 100; // სანტიმეტრი -> მეტრი
            double bmi = w / (m * m);
            string category;
            Color color;

            if (bmi < 18.5)
            {
                category = "წონის ნაკლებობა";
                color = Color.LightSkyBlue;
            }
            else if (bmi < 25)
            {
                category = "ნორმალური წონა";
                color = Color.LightGreen;
            }
            else if (bmi < 30)
            {
                category = "ჭარბი წონა";
                color = Color.Gold;
            }
            else
            {
                category = "სიმსუქნე";
                color = Color.Salmon;
            }

            lblRes10.Text = "BMI = " + Math.Round(bmi, 1) + "\nკატეგორია: " + category;
            pnl10.BackColor = color;
        }

        // ===== ამოცანა 11: წყლის მდგომარეობა ტემპერატურით =====
        private void btn11_Click(object sender, EventArgs e)
        {
            double t;
            if (!ReadNumber(txt11T, out t))
                return;

            double c;
            if (rb11F.Checked)
                c = (t - 32) * 5 / 9; // ფარენჰაიტი -> ცელსიუსი
            else
                c = t;

            if (c < -273.15)
            {
                lblRes11.Text = "ასეთი ტემპერატურა შეუძლებელია!\n(აბსოლუტური ნული = −273,15 °C)";
                lblRes11.ForeColor = Color.Crimson;
                return;
            }

            string state;
            if (c <= 0)
            {
                state = "ყინული (მყარი მდგომარეობა)";
                lblRes11.ForeColor = Color.SteelBlue;
            }
            else if (c < 100)
            {
                state = "წყალი (თხევადი მდგომარეობა)";
                lblRes11.ForeColor = Color.DodgerBlue;
            }
            else
            {
                state = "ორთქლი (აირადი მდგომარეობა)";
                lblRes11.ForeColor = Color.OrangeRed;
            }

            double f = c * 9 / 5 + 32;
            lblRes11.Text = Fmt(c) + " °C = " + Fmt(f) + " °F\n" + state;
        }

        // ===== ამოცანა 12: კვირის დღე ნომრით =====
        private void btn12_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(txt12N.Text.Trim(), out n))
            {
                MessageBox.Show("შეიყვანეთ მთელი რიცხვი!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (n < 1 || n > 7)
            {
                lblRes12.Text = "ასეთი დღე არ არსებობს!\nშეიყვანეთ რიცხვი 1-დან 7-მდე.";
                lblRes12.ForeColor = Color.Crimson;
                return;
            }

            string day;
            if (n == 1)
                day = "ორშაბათი";
            else if (n == 2)
                day = "სამშაბათი";
            else if (n == 3)
                day = "ოთხშაბათი";
            else if (n == 4)
                day = "ხუთშაბათი";
            else if (n == 5)
                day = "პარასკევი";
            else if (n == 6)
                day = "შაბათი";
            else
                day = "კვირა";

            if (n >= 6)
            {
                lblRes12.Text = n + " — " + day + "\nდასვენების დღეა!";
                lblRes12.ForeColor = Color.SeaGreen;
            }
            else
            {
                lblRes12.Text = n + " — " + day + "\nსამუშაო დღეა.";
                lblRes12.ForeColor = Color.MidnightBlue;
            }
        }

        // ===== ამოცანა 13: წელიწადის დრო და დღეები თვეში =====
        private void btn13_Click(object sender, EventArgs e)
        {
            DateTime date = dtp13.Value;
            int month = date.Month;
            string season;

            if (month == 12 || month == 1 || month == 2)
            {
                season = "ზამთარი";
                lblRes13.ForeColor = Color.SteelBlue;
            }
            else if (month >= 3 && month <= 5)
            {
                season = "გაზაფხული";
                lblRes13.ForeColor = Color.SeaGreen;
            }
            else if (month >= 6 && month <= 8)
            {
                season = "ზაფხული";
                lblRes13.ForeColor = Color.DarkOrange;
            }
            else
            {
                season = "შემოდგომა";
                lblRes13.ForeColor = Color.Sienna;
            }

            int days;
            if (month == 2)
            {
                int y = date.Year;
                if ((y % 4 == 0 && y % 100 != 0) || y % 400 == 0)
                    days = 29;
                else
                    days = 28;
            }
            else if (month == 4 || month == 6 || month == 9 || month == 11)
            {
                days = 30;
            }
            else
            {
                days = 31;
            }

            lblRes13.Text = "თარიღი: " + date.ToString("dd.MM.yyyy") + "\nწელიწადის დრო: " + season + "\nამ თვეში " + days + " დღეა.";
        }

        // ===== ამოცანა 14: წერტილის მეოთხედი =====
        private void btn14_Click(object sender, EventArgs e)
        {
            double x, y;
            if (!ReadNumber(txt14X, out x) || !ReadNumber(txt14Y, out y))
                return;

            string place;
            if (x == 0 && y == 0)
                place = "კოორდინატთა სათავეშია";
            else if (x == 0)
                place = "Y ღერძზე მდებარეობს";
            else if (y == 0)
                place = "X ღერძზე მდებარეობს";
            else if (x > 0 && y > 0)
                place = "I მეოთხედშია";
            else if (x < 0 && y > 0)
                place = "II მეოთხედშია";
            else if (x < 0 && y < 0)
                place = "III მეოთხედშია";
            else
                place = "IV მეოთხედშია";

            lblRes14.Text = "წერტილი (" + Fmt(x) + "; " + Fmt(y) + ")\n" + place;

            pointX = x;
            pointY = y;
            pointSet = true;
            pnl14.Invalidate(); // Panel-ის თავიდან დახატვა
        }

        private void pnl14_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = pnl14.ClientSize.Width;
            int h = pnl14.ClientSize.Height;
            int cx = w / 2;
            int cy = h / 2;

            // ღერძები
            g.DrawLine(Pens.Gray, 0, cy, w, cy);
            g.DrawLine(Pens.Gray, cx, 0, cx, h);
            g.DrawString("x", Font, Brushes.Gray, w - 16, cy);
            g.DrawString("y", Font, Brushes.Gray, cx + 4, 0);

            if (!pointSet)
                return;

            // მასშტაბი: უდიდესი კოორდინატი ეტევა პანელის ნახევრის 80%-ში
            double big = Math.Max(Math.Abs(pointX), Math.Abs(pointY));
            double scale = 1;
            if (big > 0)
                scale = Math.Min(cx, cy) * 0.8 / big;

            float px = (float)(cx + pointX * scale);
            float py = (float)(cy - pointY * scale);
            g.FillEllipse(Brushes.Red, px - 5, py - 5, 10, 10);
        }

        // ===== ამოცანა 15: მაღაზიის ფასდაკლება =====
        private void btn15_Click(object sender, EventArgs e)
        {
            double sum;
            if (!ReadNumber(txt15S, out sum))
                return;

            if (sum <= 0)
            {
                MessageBox.Show("თანხა დადებითი უნდა იყოს!", "შეცდომა", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int discount;
            if (sum >= 500)
                discount = 15;
            else if (sum >= 200)
                discount = 10;
            else if (sum >= 100)
                discount = 5;
            else
                discount = 0;

            if (chk15Card.Checked)
                discount += 5;
            if (chk15Student.Checked)
                discount += 3;
            if (discount > 20)
                discount = 20;

            double saved = sum * discount / 100;
            double pay = sum - saved;

            lblRes15.Text = "ფასდაკლება: " + discount + "%\nდაზოგილი: " + saved.ToString("0.00") + " ლარი\nგადასახდელი: " + pay.ToString("0.00") + " ლარი";
            if (discount == 0)
                lblRes15.ForeColor = Color.DimGray;
            else
                lblRes15.ForeColor = Color.SeaGreen;
        }
    }
}
