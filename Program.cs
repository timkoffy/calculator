namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputText = "";
            string[] operators = {"-", "+", "*", "/"};
            string[] buttons = {"C", "", "<-", "/", 
                "1", "2", "3", "*", 
                "4", "5", "6", "-", 
                "7", "8", "9", "+", 
                "", "0", ""};

            Form root = new Form
            {
                Text = "calculator",
                Size = new Size(400, 420),
                MinimumSize = new Size(400, 420)
            };

            TableLayoutPanel mainBox = new TableLayoutPanel
            {
                Size = new Size(root.Width, root.Height),
                Dock = DockStyle.Fill,
                RowCount = 2,
                ColumnCount = 1
            };
            
            Label display = new Label
            {
                Text = inputText,
                Font = new Font("Trebuchet MS", 26),
                TextAlign = ContentAlignment.TopRight,
                Dock = DockStyle.Fill,
                Height = 50
            };

            TableLayoutPanel buttonPanel = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 4,
                RowCount = 5
            };

            buttonPanel.ColumnStyles.Clear();
            for (int i = 0; i < 4; i++)
                buttonPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));

            buttonPanel.RowStyles.Clear();
            for (int i = 0; i < 5; i++)
                buttonPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));


            void addButtonToForm(string buttonText)
            {
                Button button = new Button
                {
                    Text = buttonText,
                    Font = new Font("Trebuchet MS", 16),
                    Dock = DockStyle.Fill
                };


                // очистить все
                if (buttonText == "C")
                {
                    button.Click += (o, s) =>
                    {
                        inputText = "";
                        display.Text = inputText;
                    };
                }

                // бекспейс
                if (buttonText == "<-")
                {
                    button.Click += (o, s) =>
                    {
                        try
                        {
                            inputText = inputText.Substring(0, inputText.Length - 1);
                        }
                        catch
                        {

                        }

                        display.Text = inputText;
                    };
                }

                // фикс повтора знаков

                if (operators.Contains(buttonText))
                {
                    button.Click += (o, s) =>
                    {
                        try
                        {
                            if (operators.Contains(inputText.Substring(inputText.Length - 1)))
                            {
                                inputText += "";
                                display.Text = inputText;
                            }
                            else
                            {
                                inputText += buttonText;
                                display.Text = inputText;
                            }
                        }
                        catch
                        {
                        }
                    };
                }

                // фикс деления на нуль
                if (buttonText == "0")
                {
                    button.Click += (o, s) =>
                    {

                        if (inputText.Length > 0 && inputText.Substring(inputText.Length - 1) == "/")
                        {
                            inputText += "";
                            display.Text = inputText;
                        }
                        else
                        {
                            inputText += buttonText;
                            display.Text = inputText;
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
                        display.Text = inputText;
                    };
                }

                buttonPanel.Controls.Add(button);
            }

            void addResultButton()
            {
                Button button = new Button()
                {
                    Text = "=",
                    Dock = DockStyle.Fill
                };

                buttonPanel.Controls.Add(button);
            }

            foreach (string i in buttons)
                addButtonToForm(i);
                
            addResultButton();
            
            mainBox.Controls.Add(display,0,0);
            mainBox.Controls.Add(buttonPanel,0,1);
            root.Controls.Add(mainBox);
            root.ShowDialog();
        }
    }
}