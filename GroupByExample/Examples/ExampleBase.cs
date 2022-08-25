using GroupByExample.Models;

namespace GroupByExample.Examples
{
    internal abstract class ExampleBase
    {
        protected const string FIRST_NAME_KEY = "FirstName";
        protected const string LAST_NAME_KEY = "LastName";
        protected const string AGE_KEY = "Age";

        protected IEnumerable<User>? _users;

        public ExampleBase() => FillUsers();

        public virtual void CallExamples()
        {
            FirstNameExample();
            LastNameExample();
            AgeExample();
        }

        protected abstract void FirstNameExample();
        protected abstract void LastNameExample();
        protected abstract void AgeExample();

        protected void ShowUsers<T>(IEnumerable<IGrouping<T?, User>>? users)
        {
            foreach (var item in users)
            {
                var detailsOfUsers = string.Join('\n', item.Select((x, index) => $"{index + 1}. {x}"));

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Key: {item.Key}");

                Console.ResetColor();
                Console.WriteLine($"{detailsOfUsers}\n");
            }

            Console.WriteLine();
        }

        protected virtual void FillUsers()
        {
            _users = new[]
            {
                new User
                {
                    FirstName = "name..1",
                    LastName = "sur..1",
                    Age = 1
                },
                new User
                {
                    FirstName = "name..2",
                    LastName = "sur..1",
                    Age = 2
                },
                new User
                {
                    FirstName = "name..3",
                    LastName = "surname22",
                    Age = 2
                },
                new User
                {
                    FirstName = "name..4",
                    LastName = "surname",
                    Age = 2
                }
            };
        }
    }
}
