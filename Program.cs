using System.Reflection.Metadata;
using System.Windows.Forms;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "";
            
            Form root = new Form()
            {
                Text = "calculator",
                Size = new System.Drawing.Size(292, 349)
            };
            
            GroupBox groupBox1 = new GroupBox()
            {
                Location = new System.Drawing.Point(3, 3),
                Size = new System.Drawing.Size(270, 80)
            };
            
            Label entireExpression = new Label()
            {
                Text = inputText,
                TextAlign = System.Drawing.ContentAlignment.TopRight,
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(250, 40)
            };

            TableLayoutPanel layoutPanel1 = new TableLayoutPanel()
            {
                Size = new System.Drawing.Size(root.Width, root.Height),
                
                
            };
            
            
            void addButtonToForm(string buttonText, int x, int y)
            {
                Button button = new Button();
                button.Text = buttonText;
                button.Location = new System.Drawing.Point(x, y);
                button.Size = new System.Drawing.Size(65, 40);

                // очистить все
                if (buttonText == "C")
                {
                    button.Click += (o, s) =>
                    {
                        inputText = "";
                        entireExpression.Text = inputText;
                    };
                }
                
                // бекспейс
                if (buttonText == "<-")
                {
                    button.Click += (o, s) =>
                    {
                        try {inputText = inputText.Substring(0, inputText.Length - 1);}
                        catch {}
                        entireExpression.Text = inputText;
                    };
                }
                
                // фикс повтора знаков
                string[] signs = { "-", "+", "*", "/"};
                if (signs.Contains(buttonText))
                {
                    button.Click += (o, s) =>
                    {
                        try
                        {
                            if (signs.Contains(inputText.Substring(inputText.Length - 1)))
                            {
                                inputText += "";
                                entireExpression.Text = inputText;
                            }
                            else
                            {
                                inputText += buttonText;
                                entireExpression.Text = inputText;
                            }
                        }
                        catch {}
                    };
                }
                
                // фикс деления на нуль
                if (buttonText == "0")
                {
                    button.Click += (o, s) =>
                    {
                        
                        if (inputText.Length>0 && inputText.Substring(inputText.Length - 1) == "/")
                        {
                            inputText += "";
                            entireExpression.Text = inputText;
                        }
                        else
                        {
                            inputText += buttonText;
                            entireExpression.Text = inputText;
                        }
                    };
                }
                
                // проверка на число
                string[] ints = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                if (ints.Contains(buttonText))
                {
                    button.Click += (o, s) =>
                    {
                        inputText += buttonText;
                        entireExpression.Text = inputText;
                    };
                }
                
                root.Controls.Add(button);
            }

            void addResultButton(int x, int y)
            {
                Button button = new Button();
                button.Text = "=";
                button.Location = new System.Drawing.Point(x, y);
                button.Size = new System.Drawing.Size(65, 40);
                
                root.Controls.Add(button);
            }
            
            
            
            // addButtonToForm("C", 3, 86);
            // addButtonToForm("", 3+68, 86);
            // addButtonToForm("<-", 3+68+68, 86);
            // addButtonToForm("/", 3+68+68+68, 86);
            //
            // addButtonToForm("1", 3, 86+45);
            // addButtonToForm("2", 3+68, 86+45);
            // addButtonToForm("3", 3+68+68, 86+45);
            // addButtonToForm("*", 3+68+68+68, 86+45);
            //
            // addButtonToForm("4", 3, 86+45+45);
            // addButtonToForm("5", 3+68, 86+45+45);
            // addButtonToForm("6", 3+68+68, 86+45+45);
            // addButtonToForm("-", 3+68+68+68, 86+45+45);
            //  
            // addButtonToForm("7", 3, 86+45+45+45);
            // addButtonToForm("8", 3+68, 86+45+45+45);
            // addButtonToForm("9", 3+68+68, 86+45+45+45);
            // addButtonToForm("+", 3+68+68+68, 86+45+45+45);
            //
            // addButtonToForm("", 3, 86+45+45+45+45);
            // addButtonToForm("0", 3+68, 86+45+45+45+45);
            // addButtonToForm("", 3+68+68, 86+45+45+45+45);
            // addResultButton(3+68+68+68, 86+45+45+45+45);

            
            groupBox1.Controls.Add(entireExpression);
            root.Controls.Add(groupBox1);
            root.Controls.Add(layoutPanel1);
            root.ShowDialog();
        }
    }
}