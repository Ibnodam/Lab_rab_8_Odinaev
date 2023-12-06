using System;

while (true)
{
    try
    {


        Console.WriteLine("Введите количество пользователей: ");
        int n = int.Parse(Console.ReadLine());
        Mail[] mail = new Mail[n];
        for (int i = 0; i < mail.Length; i++)
        {
            Console.Write("Введите e-mail отправителя: ");
            mail[i].email_sender = Console.ReadLine();
            Console.Write("Введите e-mail получателя: ");
            mail[i].email_recipient = Console.ReadLine();
            Console.Write("Введите дату отправки сообщения: ");
            mail[i].Datesent = DateOnly.Parse(Console.ReadLine());
            Console.Write("Введите время отправки сообщения: ");
            mail[i].Timesent = TimeOnly.Parse(Console.ReadLine());
            Console.Write("Введите размер сообщения (КБ): ");
            mail[i].size = double.Parse(Console.ReadLine());
            Console.WriteLine();
        }

        void Info(Mail[] mail)
        {
            Console.WriteLine("Информация обо всех письмах");
            Console.WriteLine();
            TimeSpan a = new TimeSpan();
            DateTime now = new DateTime();
            int n = 1; // Для более удобного ориентирования добавил счётчик отправлений...

            for (int i = 0; i < mail.Length; i++)

            {

                DateTime dateTime = mail[i].Datesent.ToDateTime(mail[i].Timesent);
                now = DateTime.Now;
                a = now - dateTime;

                Console.WriteLine($"{n++}.Отправитель: {mail[i].email_sender}; получатель: {mail[i].email_recipient}; отправлено: {mail[i].Datesent} {mail[i].Timesent} ({a.Days} дней назад); размер письма: {mail[i].size} КБ.");
                
            }
            Console.WriteLine();
        }

        void Info2(Mail[] mail, DateOnly date, TimeSpan span)
        {
            int n = 1;
            int nn = 1;
            TimeOnly time = new TimeOnly();
            TimeSpan a = new TimeSpan();
            for (int i = 0; i < mail.Length; i++)
            {
                a = DateTime.Now - mail[i].Datesent.ToDateTime(mail[i].Timesent);
                if ((DateTime.Compare(mail[i].Datesent.ToDateTime(time), date.ToDateTime(time))) == 0)
                {
                    Console.WriteLine($"{n++}.Oтправитель: {mail[i].email_sender}.");
                    Console.WriteLine();
                }
                else if (span >= a)
                {
                    Console.WriteLine($"Активность за последние {a.Days} проявляли:");
                    Console.WriteLine($"{nn++}.Отправитель: {mail[i].email_sender}, размер письма: {mail[i].size} КБ");

                }


            }


        }
        Info(mail);
        Console.Write("Введите дату, чтобы просмотреть все письма отправленные в эту дату.");
        DateOnly date = DateOnly.Parse(Console.ReadLine());
        Console.Write("Введите промежуток времени (дни.чч:мм:сс), чтобы просмотреть все письма отправленные в указанный период.");
        TimeSpan span = TimeSpan.Parse(Console.ReadLine());
        Info2(mail, date, span);

    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


struct Mail
{
    public string email_sender;
    public string email_recipient;
    public DateOnly Datesent;
    public TimeOnly Timesent;
    public double size;
}



