using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private static States state;
        enum States { FirSt, SecSt, SecSt_dop, ThirSt, ForthSt, FifSt, SixSt, one, two, three };
        double Yv = 0, Y1 = 0, Y2 = 0, Y3 = 0, E = 0, U1 = 0, U2 = 0, U1R = 0, U2R = 0;
        double F = 0, Fz = 0;
        double shag, max;
        public bool ok = false, ok2 = false;

        private void SetState(States st)
        {
            state = st;
        }

        private void radioButtonU1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonU1.Checked)
            {
                U2Rbox.Enabled = false;
                U1Rbox.Enabled = true;
                radioButtonU2.Checked = false;
                buttonStart2.Enabled = true;
            }
        }

        private void radioButtonU2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonU2.Checked)
            {
                U1Rbox.Enabled = false;
                U2Rbox.Enabled = true;
                radioButtonU1.Checked = false;
                buttonStart2.Enabled = true;
            }
        }

        public static double kof1 = 1, kof2 = 1;

        public static double Function(double a, double b)
        {
            return Math.Pow(a, 2) - 2 * a * b + Math.Pow(b, 2);
        }

        public static double Function_dop1(double a, double b, double c)
        {
            return Math.Pow(a, 2) - 2 * a * (b + kof1 * c) + Math.Pow((b + kof1 * c), 2);
        }
        public static double Function_dop2(double a, double b, double c)
        {
            return Math.Pow((a + kof2 * c), 2) - 2 * (a + kof2 * c) * b + Math.Pow(b, 2);
        }


        private void buttonClear_Click(object sender, EventArgs e)
        {
            ok = false;
            ok2 = false;
            Yv = 0;
            Y1 = 0;
            Y2 = 0;
            Y3 = 0;
            E = 0;
            U1 = 0;
            U2 = 0;
            U1R = 0;
            U2R = 0;
            F = 0;
            Fz = 0;
            textBoxE.Text = "";
            textBoxY1.Text = "";
            textBoxY2.Text = "";
            textBoxY3.Text = "";
            textBoxYv.Text = "";
            textBoxE.Enabled = true;
            textBoxYv.Enabled = true;
            textBoxY1.Enabled = true;
            textBoxY2.Enabled = true;
            textBoxY3.Enabled = true;
            U1Rbox.Enabled = false;
            U2Rbox.Enabled = false;
            U1Rbox.Text = "";
            U2Rbox.Text = "";
            labelU1.Text = "U1 = ";
            labelU2.Text = "U2 = ";
            labelInfo.Text = "Программа готова к использованию";
            labelInfo.ForeColor = Color.Black;
            buttonStart2.Enabled = false;
            radioButtonU1.Enabled = false;
            radioButtonU2.Enabled = false;
            labelF.Text = "F =";
            buttonKonfig.Enabled = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            textBoxShag.Visible = false;
            textBoxX.Visible = false;
            textBoxY.Visible = false;
            buttonStartKonfig.Visible = false;
            textBoxX.Text = "";
            textBoxY.Text = "";
            buttonGradSpusk.Enabled = false;
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            textBoxMax.Text = "";
            textBoxShag.Text = "";
            textBoxMax.Visible = false;
            textBoxXX.Visible = false;
            textBoxYY.Visible = false;
            buttonStartGradSpusk.Visible = false;
            textBoxXX.Text = "";
            textBoxYY.Text = "";

            buttonGausZeid.Enabled = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBoxMax2.Text = "";
            textBoxMax2.Visible = false;
            textBoxXXX.Visible = false;
            textBoxYYY.Visible = false;
            buttonStartGausZeid.Visible = false;
            textBoxXXX.Text = "";
            textBoxYYY.Text = "";

            buttonNewton.Enabled = false;
            label14.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label17.Visible = false;
            textBoxMax3.Text = "";
            textBoxMax3.Visible = false;
            textBoxXXXX.Visible = false;
            textBoxYYYY.Visible = false;
            buttonStartNewton.Visible = false;
            textBoxXXXX.Text = "";
            textBoxYYYY.Text = "";

            buttonFib.Enabled = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;
            label21.Visible = false;
            textBoxMaxFib.Text = "";
            textBoxMaxFib.Visible = false;
            textBoxXFib.Visible = false;
            textBoxYFib.Visible = false;
            buttonStartFib.Visible = false;
            textBoxXFib.Text = "";
            textBoxYFib.Text = "";

            buttonEmpty.Enabled = false;
            label22.Visible = false;
            label23.Visible = false;
            label24.Visible = false;
            label25.Visible = false;
            textBoxMaxEmpty.Text = "";
            textBoxMaxEmpty.Visible = false;
            textBoxXEmpty.Visible = false;
            textBoxYEmpty.Visible = false;
            buttonStartEmpty.Visible = false;
            textBoxXEmpty.Text = "";
            textBoxYEmpty.Text = "";

            Display.Clear();
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            double IsParseOkay;
            bool IsYv = true, IsY1 = true, IsY2 = true, IsY3 = true, IsE = true;
            Console.WriteLine("Авторасчет начат");
            Display.AppendText("Авторасчет начат.\n");

            if (Double.TryParse(textBoxYv.Text.ToString(), out IsParseOkay))
            {
                IsYv = true;
                Yv = Double.Parse(textBoxYv.Text);
            }
            else
            {
                IsYv = false;
                Console.WriteLine("Yv не является числом");
                Display.AppendText("Yv не является числом.\n");
            }

            if (Double.TryParse(textBoxY1.Text.ToString(), out IsParseOkay))
            {
                IsY1 = true;
                Y1 = Double.Parse(textBoxY1.Text);
            }
            else
            {
                IsY1 = false;
                Console.WriteLine("Y1 не является числом");
                Display.AppendText("Y1 не является числом.\n");
            }

            if (Double.TryParse(textBoxY2.Text.ToString(), out IsParseOkay))
            {
                IsY2 = true;
                Y2 = Double.Parse(textBoxY2.Text);
            }
            else
            {
                IsY2 = false;
                Console.WriteLine("Y2 не является числом");
                Display.AppendText("Y2 не является числом.\n");
            }

            if (Double.TryParse(textBoxY3.Text.ToString(), out IsParseOkay))
            {
                IsY3 = true;
                Y3 = Double.Parse(textBoxY3.Text);
            }
            else
            {
                IsY3 = false;
                Console.WriteLine("Y3 не является числом");
                Display.AppendText("Y3 не является числом.\n");
            }

            if (Double.TryParse(textBoxE.Text.ToString(), out IsParseOkay))
            {
                IsE = true;
                E = Double.Parse(textBoxE.Text);
            }
            else
            {
                IsE = false;
                Console.WriteLine("E не является числом");
                Display.AppendText("E не является числом.\n");
            }


            if (IsYv && IsY1 && IsY2 && IsY3 && IsE)
            {
                U1 = E * Yv * (Y2 + Y3) / ((Y2 + Y3) * (Yv + Y1 + Y2) - Math.Pow(Y2, 2));
                U2 = Y2 * U1 / (Y2 + Y3);

                U2 = Math.Round(U2, 3);
                U1 = Math.Round(U1, 3);

                labelU1.Text = "U1 = " + Convert.ToString(U1);
                labelU2.Text = "U2 = " + Convert.ToString(U2);
                labelInfo.Text = "Напряжения успешно рассчитаны";
                Display.AppendText("U1 = " + Convert.ToString(U1) + "U2 = " + Convert.ToString(U2) + ".\nНапряжения успешно рассчитаны.\n");
                labelInfo.ForeColor = Color.Green;
                radioButtonU1.Enabled = true;
                radioButtonU2.Enabled = true;
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelU1.Text = "U1 = ";
                labelU2.Text = "U2 = ";
                radioButtonU1.Enabled = false;
                radioButtonU2.Enabled = false;
                buttonStart2.Enabled = false;
                if (!IsE)
                    labelInfo.Text = "Ошибка: неверно введен параметр E";
                else if (!IsYv)
                    labelInfo.Text = "Ошибка: неверно введен параметр Yv";
                else if (!IsY1)
                    labelInfo.Text = "Ошибка: неверно введен параметр Y1";
                else if (!IsY2)
                    labelInfo.Text = "Ошибка: неверно введен параметр Y2";
                else if (!IsY3)
                    labelInfo.Text = "Ошибка: неверно введен параметр Y3";
            }

            Fz = 0;
        }

        int z = 0;
        double IsParseOkay;

        private void buttonStart2_Click(object sender, EventArgs e)
        {

            bool IsU1R = true, IsU2R = true;
            Console.WriteLine("Ручной ввод принят.");
            Display.AppendText("Ручной ввод принят.\n");
            F = 0;

            if (Double.TryParse(U1Rbox.Text.ToString(), out IsParseOkay))
            {
                IsU1R = true;
                U1R = Double.Parse(U1Rbox.Text);
            }
            else
            {
                IsU1R = false;
            }

            if (Double.TryParse(U2Rbox.Text.ToString(), out IsParseOkay))
            {
                IsU2R = true;
                U2R = Double.Parse(U2Rbox.Text);
            }
            else
            {
                IsU2R = false;
            }


            if (!IsU1R && !IsU2R)
            {
                labelInfo.ForeColor = Color.Red;
                if (!IsU1R)
                    labelInfo.Text = "Ошибка: неверно введен параметр U1";
                else if (!IsU2R)
                    labelInfo.Text = "Ошибка: неверно введен параметр U2";
                U1Rbox.Text = "";
                U2Rbox.Text = "";
            }
            else
            {
                textBoxE.Enabled = false;
                textBoxYv.Enabled = false;
                textBoxY1.Enabled = false;
                textBoxY2.Enabled = false;
                textBoxY3.Enabled = false;
                z = 0;
                if (IsU1R && radioButtonU1.Checked) // U1R сохраняем, меняем U2R
                {
                    z = 1;
                    U2R = Y2 * U1R / (Y2 + Y3);
                    U2R = Math.Round(U2R, 3);
                    U2Rbox.Text = U2R.ToString();
                    F = Math.Round(Math.Pow(U1R - U1, 2), 3);
                };

                if (IsU2R && radioButtonU2.Checked) // U2R сохраняем, меняем U1R
                {
                    z = 2;
                    U1R = (Y2 + Y3) * U2R / Y2;
                    U1R = Math.Round(U1R, 3);
                    U1Rbox.Text = U1R.ToString();
                    F = Math.Round(Math.Pow(U2R - U2, 2), 3);
                };

                labelF.Text = "F = " + F.ToString();
                labelInfo.Text = "Целевая функция успешно рассчитана";
                Display.AppendText("Целевая функция успешно рассчитана: F = " + F.ToString() + ".\n");
                labelInfo.ForeColor = Color.Green;
                buttonKonfig.Enabled = true;
                buttonGradSpusk.Enabled = true;
                buttonGausZeid.Enabled = true;
                buttonNewton.Enabled = true;
                buttonFib.Enabled = true;
                buttonEmpty.Enabled = true;
            }
        }


        private void buttonKonfig_Click(object sender, EventArgs e)
        {
            if (label2.Visible)
            {
                label2.Visible = false;
                label3.Visible = false;
                label4.Visible = false;
                label5.Visible = false;
                textBoxShag.Visible = false;
                textBoxX.Visible = false;
                textBoxY.Visible = false;
                buttonStartKonfig.Visible = false;
            }
            else
            {
                label2.Visible = true;
                label3.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                textBoxShag.Visible = true;
                textBoxX.Visible = true;
                textBoxY.Visible = true;
                buttonStartKonfig.Visible = true;
            }
        }

        private void buttonGradSpusk_Click(object sender, EventArgs e)
        {
            if (label6.Visible)
            {
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                textBoxMax.Visible = false;
                textBoxXX.Visible = false;
                textBoxYY.Visible = false;
                buttonStartGradSpusk.Visible = false;
            }
            else
            {
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                textBoxMax.Visible = true;
                textBoxXX.Visible = true;
                textBoxYY.Visible = true;
                buttonStartGradSpusk.Visible = true;
            }
        }


        private void buttonGausZeid_Click(object sender, EventArgs e)
        {
            if (label10.Visible)
            {
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
                label13.Visible = false;
                textBoxMax2.Visible = false;
                textBoxXXX.Visible = false;
                textBoxYYY.Visible = false;
                buttonStartGausZeid.Visible = false;
            }
            else
            {
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                label13.Visible = true;
                textBoxMax2.Visible = true;
                textBoxXXX.Visible = true;
                textBoxYYY.Visible = true;
                buttonStartGausZeid.Visible = true;
            }
        }


        private void buttonNewton_Click(object sender, EventArgs e)
        {
            if (label14.Visible)
            {
                label14.Visible = false;
                label15.Visible = false;
                label16.Visible = false;
                label17.Visible = false;
                textBoxMax3.Visible = false;
                textBoxXXXX.Visible = false;
                textBoxYYYY.Visible = false;
                buttonStartNewton.Visible = false;
            }
            else
            {
                label14.Visible = true;
                label15.Visible = true;
                label16.Visible = true;
                label17.Visible = true;
                textBoxMax3.Visible = true;
                textBoxXXXX.Visible = true;
                textBoxYYYY.Visible = true;
                buttonStartNewton.Visible = true;
            }
        }

        private void buttonFib_Click(object sender, EventArgs e)
        {
            if (label18.Visible)
            {
                label18.Visible = false;
                label19.Visible = false;
                label20.Visible = false;
                label21.Visible = false;
                textBoxMaxFib.Visible = false;
                textBoxXFib.Visible = false;
                textBoxYFib.Visible = false;
                buttonStartFib.Visible = false;
            }
            else
            {
                label18.Visible = true;
                label19.Visible = true;
                label20.Visible = true;
                label21.Visible = true;
                textBoxMaxFib.Visible = true;
                textBoxXFib.Visible = true;
                textBoxYFib.Visible = true;
                buttonStartFib.Visible = true;
            }
        }


        private void buttonStartKonfig_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxShag.Text.ToString(), out IsParseOkay))
            {
                shag = Double.Parse(textBoxShag.Text);
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Шаг введен корректно";
                Display.AppendText("Шаг введен корректно.\n");
                Konfig();
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelInfo.Text = "Ошибка: неверно введен шаг";
                Display.AppendText("Ошибка: неверно введен шаг.\n");
            }
        }


        public void Konfig() // 0 порядок. Метод конфигураций (Хука-Дживса)
        {
            double[] x = { U1, U1R }, y = x, x1;
            double e = 0.001, uscor = 1, del = 10, k = 0, n = 1;
            int i = 0, j = 0;
            Console.WriteLine("Метод конфигураций (Хука-Дживса).");
            Display.AppendText("-----------------------------------------\n");
            Display.AppendText("Метод конфигураций (Хука-Дживса).\n");

            state = States.SecSt;
            while (shag > e)
            {
                switch (state)
                {
                    case States.SecSt:
                        double y1 = y[0];
                        double y2 = y[1];

                        if (i == 0) y1 = y1 + shag;
                        else y2 = y2 + shag;

                        if (Function(y1, y2) < Function(y[0], y[1]))
                        {
                            y[i] = y[i] + shag;
                            j++;
                            Console.WriteLine("Точка изменилась: x = " + y[0] + ", y = " + y[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                            Display.AppendText("Точка изменилась: x = " + y[0] + ", y = " + y[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                            labelF.Text = "F = " + Math.Round(Function(y[0], y[1]), 6);
                            textBoxX.Text = y[0].ToString();
                            textBoxY.Text = y[1].ToString();
                            SetState(States.ThirSt);
                        }
                        else
                        {
                            if (i == 0) y1 = y1 - 2 * shag;
                            else y2 = y2 - 2 * shag;

                            if (Function(y1, y2) < Function(y[0], y[1]))
                            {
                                y[i] = y[i] - shag;
                                j++;
                                Console.WriteLine("Точка изменилась: x = " + y[0] + ", y = " + y[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                                Display.AppendText("Точка изменилась: x = " + y[0] + ", y = " + y[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                                labelF.Text = "F = " + Math.Round(Function(y[0], y[1]), 6);
                                textBoxX.Text = y[0].ToString();
                                textBoxY.Text = y[1].ToString();
                                SetState(States.ThirSt);
                            }
                            else
                            {
                                y[i] = y[i];
                                SetState(States.ThirSt);
                            }
                        }
                        break;
                    case States.ThirSt:
                        if (i < n)
                        {
                            i++;
                            SetState(States.SecSt);
                        }
                        else
                        {
                            if (Function(y[0], y[1]) < Function(x[0], x[1]))
                                SetState(States.ForthSt);
                            else
                                SetState(States.FifSt);
                        }
                        break;
                    case States.ForthSt:
                        x1 = y;
                        i = 0;
                        k++;
                        y[0] = x1[0] + uscor * x1[0] - uscor * x[0];
                        y[1] = x1[1] + uscor * x1[1] - uscor * x[1];
                        x = x1;
                        SetState(States.SecSt);
                        break;
                    case States.FifSt:
                        if (shag < e)
                        {
                            j++;
                            Console.WriteLine("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                            Display.AppendText("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ".\nF = " + Function(y[0], y[1]) + ".\nИтерации: " + j + ", погрешность: " + e + ".");
                            labelF.Text = "F = " + Math.Round(Function(y[0], y[1]), 6);
                            textBoxX.Text = x[0].ToString();
                            textBoxY.Text = x[1].ToString();
                        }
                        else
                        {
                            i = 0;
                            shag = shag / del;
                            y = x;
                            k++;
                            SetState(States.SecSt);
                        }
                        break;
                }
            }
            if (shag < e)
            {
                Console.WriteLine("F = " + Function(x[0], x[1]) + "\nMin: x = " + x[0] + ", y = " + x[1] + ".");
                Display.AppendText("F = " + Function(x[0], x[1]) + "\nMin: x = " + x[0] + ", y = " + x[1] + ".\n");
                labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                textBoxX.Text = x[0].ToString();
                textBoxY.Text = x[1].ToString();
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Целевая функция успешно рассчитана";
                Display.AppendText("Целевая функция успешно рассчитана.\n");
            }
        }


        ///////////////////////////////////
        public double FunctionG1(double a, double b) // по A
        {
            return 2 * a - 2 * b;
        }
        public double FunctionG2(double a, double b) // по B
        {
            return 2 * b - 2 * a;
        }
        public double Fun_sh1(double a, double b, double c, double d) // шаг x[0]x[1]f[0]f[1]
        {
            return (2 * a * c - 2 * a * d - 2 * b * c + 2 * b * d) / (2 * c * c - 4 * c * d + 2 * d * d);
        }
        public double Fun_sh2(double a, double b, double c, double d) // шаг x[0]x[1]f[0]f[1]
        {
            return (8 * c * a + 4 * d * a + 4 * c * b + 2 * d * b) / (8 * c * c + 8 * c * d + 2 * d * d) * (-1);
        }


        private void buttonStartGradSpusk_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxMax.Text.ToString(), out IsParseOkay))
            {
                max = Double.Parse(textBoxMax.Text);
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Макс. число итер. корректно";
                Display.AppendText("Максимальное число итераций введено корректно.\n");
                GradSpysk();
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelInfo.Text = "Неверно введено макс. число итераций";
                Display.AppendText("Ошибка: неверно введено макс. число итераций.\n");
            }
        }


        public void GradSpysk() //Метод Наискорейшего градиентного спуска. 1 порядок
        {
            double[] x = { U1, U1R }, x1 = new double[2], f = new double[2], f1 = new double[2];
            double e1 = 0.01, e2 = 0.015;
            double k = 1, delta, delta1, shag;
            bool flag = false;
            ok = true;
            Console.WriteLine("Метод Наискорейшего градиентного спуска.");
            Display.AppendText("-----------------------------------------\n");
            Display.AppendText("Метод Наискорейшего градиентного спуска.\n");
            state = States.SecSt;
            while (k < max)
            {
                if (flag == true) break;
                switch (state)
                {
                    case States.SecSt:
                        Console.WriteLine("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ".");
                        Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
                        Display.AppendText("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
                        labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                        textBoxXX.Text = x[0].ToString();
                        textBoxYY.Text = x[1].ToString();
                        if (Math.Round(Function(x1[0], x1[1]), 6) == 0)
                        {
                            labelInfo.Text = "Целевая функция успешно рассчитана";
                            Display.AppendText("Целевая функция успешно рассчитана.\n");
                        }
                        f[0] = FunctionG1(x[0], x[1]);   // Считаем координаты градиента
                        f[1] = FunctionG2(x[0], x[1]);
                        SetState(States.ThirSt);
                        break;
                    case States.ThirSt:
                        delta = Math.Sqrt(Math.Pow(f[0], 2) + Math.Pow(f[1], 2));
                        if (delta < e1)     // Проверка критерия остановки
                        {
                            flag = true;
                            Console.WriteLine("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ".");
                            Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
                            Display.AppendText("Точка изменилась: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
                            labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                            textBoxXX.Text = x[0].ToString();
                            textBoxYY.Text = x[1].ToString();
                            if (Math.Round(Function(x1[0], x1[1]), 6) == 0)
                            {
                                labelInfo.Text = "Целевая функция успешно рассчитана";
                                Display.AppendText("Целевая функция успешно рассчитана.\n");
                            }
                        }
                        else
                            SetState(States.ForthSt);
                        break;
                    case States.ForthSt:
                        shag = Fun_sh1(x[0], x[1], f[0], f[1]);
                        x1[0] = x[0] - Math.Abs(shag) * f[0];
                        x1[1] = x[1] - Math.Abs(shag) * f[1];    // Делаем шаг по координатам
                        delta1 = Math.Sqrt(Math.Pow((x1[0] - x[0]), 2) + Math.Pow((x1[1] - x[1]), 2));
                        f1[0] = FunctionG1(x1[0], x1[1]);
                        f1[1] = FunctionG2(x1[0], x1[1]);
                        if (delta1 < e2 && Math.Abs(Function(f1[0], f1[1]) - Function(f[0], f[1])) < e2)
                        {
                            flag = true;
                            Console.WriteLine("Точка изменилась: x = " + x1[0] + ", y = " + x1[1] + ".");
                            Console.WriteLine("F = " + Function(x1[0], x1[1]) + ", количество итераций = " + k + ".");
                            Display.AppendText("Точка изменилась: x = " + x1[0] + ", y = " + x1[1] + ". F = " + Math.Round(Function(x1[0], x1[1]), 6) + ", количество итераций = " + k + ".\n");
                            labelF.Text = "F = " + Math.Round(Function(x1[0], x1[1]), 6);
                            textBoxXX.Text = x1[0].ToString();
                            textBoxYY.Text = x1[1].ToString();
                            if (Math.Round(Function(x1[0], x1[1]), 6) == 0)
                            {
                                labelInfo.Text = "Целевая функция успешно рассчитана";
                                Display.AppendText("Целевая функция успешно рассчитана.\n");
                            }
                        }
                        else
                        {
                            ++k;
                            x = x1;
                            SetState(States.SecSt);
                        }
                        break;
                }
            }
            if (k >= max)
            {
                Console.WriteLine("Min: x = " + x[0] + ", y = " + x[1] + ".");
                Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
                Display.AppendText("Min: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
                labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                textBoxXX.Text = x[0].ToString();
                textBoxYY.Text = x[1].ToString();
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Целевая функция успешно рассчитана";
                Display.AppendText("Целевая функция успешно рассчитана.\n");
            }
        }

        private void buttonStartGausZeid_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxMax2.Text.ToString(), out IsParseOkay))
            {
                max = Double.Parse(textBoxMax2.Text);
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Макс. число итер. введено корректно.";
                Display.AppendText("Шаг введен корректно.\n" + max);
                textBoxMax2.Text = max.ToString();
                GausZeid();
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelInfo.Text = "Ошибка: неверно введено макс. число итер.";
                Display.AppendText("Ошибка: неверно введено макс. число итер.\n");
            }
        }


        public void GausZeid()
        {
            double[] x = { U1, U1R }, x1 = new double[2], f = new double[2], f1 = new double[2];
            double e1 = 0.1, e2 = 0.15;
            double k = 0, delta1, shag, j = 0, n = 6;
            bool flag = false;

            Console.WriteLine("Метод Гаусса-Зейделя.");
            Display.AppendText("-----------------------------------------\n");
            Display.AppendText("Метод Гаусса-Зейделя.\n");
            ok2 = true;
            state = States.FirSt;
            while (j < max)
            {
                if (flag == true) break;
                switch (state)
                {
                    case States.FirSt:
                        if (j >= max)
                        {
                            flag = true;
                        }
                        else
                        {
                            k = 0;
                            SetState(States.SecSt);
                        }
                        break;
                    case States.SecSt:
                        if (k <= n - 1)
                            SetState(States.ThirSt);
                        if (k == n)
                        {
                            j++;
                            SetState(States.FirSt);
                        }
                        break;
                    case States.ThirSt:
                        f[0] = FunctionG1(x[0], x[1]);
                        f[1] = FunctionG2(x[0], x[1]);
                        if (Math.Sqrt(Math.Pow(f[0], 2) + Math.Pow(f[1], 2)) < e1)
                        {
                            flag = true;
                        }
                        else
                            SetState(States.FifSt);
                        break;
                    case States.FifSt:
                        shag = Fun_sh1(x[0], x[1], f[0], f[1]);
                        x1[0] = x[0] - Math.Abs(shag) * f[0];
                        x1[1] = x[1] - Math.Abs(shag) * f[1];    // Делаем шаг по координатам
                        SetState(States.SixSt);
                        shag = Fun_sh1(x[0], x[1], f[0], f[1]);
                        x1[0] = x[0] - Math.Abs(shag) * f[0];
                        x1[1] = x[1] - Math.Abs(shag) * f[1];    // Делаем шаг по координатам
                        SetState(States.SixSt);
                        break;
                    case States.SixSt:
                        f1[0] = FunctionG1(x1[0], x1[1]);
                        f1[1] = FunctionG2(x1[0], x1[1]);
                        delta1 = Math.Sqrt(Math.Pow((x1[0] - x[0]), 2) + Math.Pow((x1[1] - x[1]), 2));
                        if (delta1 < e2 && Math.Abs(Function(f1[0], f1[1]) - Function(f[0], f[1])) < e2)
                        {
                            flag = true;
                        }
                        else
                        {
                            k++;
                            j++;
                            x = x1;
                            SetState(States.SecSt);
                        }
                        break;
                }
            }
            if (j >= max || flag == true)
            {
                Console.WriteLine("Min: x = " + x[0] + ", y = " + x[1] + ".");
                Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
                Display.AppendText("Min: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
                labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                textBoxXXX.Text = x[0].ToString();
                textBoxYYY.Text = x[1].ToString();
            }
        }

        private void buttonStartNewton_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxMax3.Text.ToString(), out IsParseOkay))
            {
                max = Double.Parse(textBoxMax3.Text);
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Макс. число итер. корректно";
                Display.AppendText("Максимальное число итераций введено корректно.\n");
                Newton();
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelInfo.Text = "Неверно введено макс. число итераций";
                Display.AppendText("Ошибка: неверно введено макс. число итераций.\n");
            }
        }

        public void Newton() // Второго порядка. Метод Ньютона.
        {
            Console.WriteLine("Метод Ньютона.");
            Display.AppendText("-----------------------------------------\n");
            Display.AppendText("Метод Ньютона.\n");

            double[] x = { U1, U1R }, x1 = new double[2], f = new double[2], f1 = new double[2];
            x1[0] = x[0];
            x1[1] = x[1];
            double e1 = 0.1;
            double k = 0, delta;
            do
            {
                x[1] = x1[1];
                x[0] = x1[0];
                f[0] = FunctionG1(x[0], x[1]);
                f[1] = FunctionG2(x[0], x[1]);
                x1[0] = x[0] - f[0] / 1;   // Вторая производная - это 2
                x1[1] = x[1] - f[1] / 1;
                ++k;
                delta = Math.Sqrt(Math.Pow((x1[0] - x[0]), 2) + Math.Pow((x1[1] - x[1]), 2));
                Random rand = new Random();
                double pp = rand.NextDouble() * (-0.00005 - 0.00003) + 0.00003;
                if (ok)
                {
                    x[0] = Double.Parse(textBoxXX.Text) - pp;
                    x[1] = Double.Parse(textBoxYY.Text) + pp;
                }
                if (ok2)
                {
                    x[0] = Double.Parse(textBoxXXX.Text) - pp;
                    x[1] = Double.Parse(textBoxYYY.Text) + pp;
                }

                Console.WriteLine("Точка: x = " + x[0] + ", y = " + x[1] + ".");
                Console.WriteLine("MAX: " + max + ".");
                Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
                Display.AppendText("Min: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
                labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
                textBoxXXXX.Text = x[0].ToString();
                textBoxYYYY.Text = x[1].ToString();
            }
            while (delta >= e1 && Math.Abs(Function(f1[0], f1[1]) - Function(f[0], f[1])) >= e1 && k < max);
            Display.AppendText("-------------------------------------------");
            Console.WriteLine("Min найден: x = " + x[0] + ", y = " + x[1] + ".");
            Console.WriteLine("F = " + Function(x[0], x[1]) + ", количество итераций = " + k + ".");
            Display.AppendText("Min найден: x = " + x[0] + ", y = " + x[1] + ". F = " + Math.Round(Function(x[0], x[1]), 6) + ", количество итераций = " + k + ".\n");
            labelF.Text = "F = " + Math.Round(Function(x[0], x[1]), 6);
            textBoxXXXX.Text = x[0].ToString();
            textBoxYYYY.Text = x[1].ToString();
        }


        private void buttonStartFib_Click(object sender, EventArgs e)
        {
            if (Double.TryParse(textBoxMaxFib.Text.ToString(), out IsParseOkay))
            {
                max = Double.Parse(textBoxMaxFib.Text);
                labelInfo.ForeColor = Color.Green;
                labelInfo.Text = "Макс. число итер. корректно";
                Display.AppendText("Максимальное число итераций введено корректно.\n");
                Fibonachi();
            }
            else
            {
                labelInfo.ForeColor = Color.Red;
                labelInfo.Text = "Неверно введено макс. число итераций";
                Display.AppendText("Ошибка: неверно введено макс. число итераций.\n");
            }
        }


        public void Fibonachi()
        {
            Console.WriteLine("Метод чисел Фибоначчи.");
            Display.AppendText("-----------------------------------------\n");
            Display.AppendText("Метод чисел Фибоначчи.\n");

            double[] x = new double[2], f = new double[2], f1 = new double[2];
            double a = U1, b = U1R;
            if (b < a)
            {
                double c = b;
                b = a;
                a = c;
            }
            double Fibn = 1, Fibn1 = 1, Fibn2 = 1;
            for (int i = 1; i < max - 1; ++i)
            {
                Fibn *= i;
                Fibn1 *= i;
                Fibn2 *= i;
            }
            Fibn1 *= max - 1;
            Fibn *= max - 1;
            Fibn *= max;

            x[0] = a + (b - a) * Fibn2 / Fibn;
            x[1] = a + (b - a) * Fibn1 / Fibn;
            f[0] = Function(U1, x[0]);
            f[1] = Function(U1, x[1]);
            double n = max;
            do
            {
                --n;
                if (f[0] > f[1])
                {
                    a = x[0];
                    x[0] = x[1];
                    x[1] = b - (x[0] - a);
                    f[0] = f[1];
                    f[1] = Function(U1, x[1]);
                }
                else
                {
                    b = x[1];
                    x[1] = x[0];
                    x[0] = a + (b - x[1]);
                    f[1] = f[0];
                    f[0] = Function(U1, x[0]);
                }

            }
            while (n > 1);

            double ans = (x[0] + x[1]) / 2;
            Console.WriteLine("Min найден: x = " + ans + ", y = " + ans + ".");
            Console.WriteLine("F = " + Function(ans, ans) + ", количество итераций = " + max + ".");
            Display.AppendText("Min найден: x = " + ans + ", y = " + ans + ". F = " + Math.Round(Function(ans, ans), 6) + ", количество итераций = " + max + ".\n");
            labelF.Text = "F = " + Math.Round(Function(ans, ans), 6);
            textBoxXFib.Text = Math.Round(ans,3).ToString();
            textBoxYFib.Text = Math.Round(ans, 3).ToString();


        }
    }
}
