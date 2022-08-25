using GroupByExample.Models;

namespace GroupByExample.Examples
{
    internal class SwitchExample : ExampleBase
    {
        protected override void FirstNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{nameof(SwitchExample)}: first name");

            var propertyName = FIRST_NAME_KEY;

            var users = GroupUsers(propertyName);
            ShowUsers(users);
        }

        protected override void LastNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{nameof(SwitchExample)}: last name");

            var propertyName = LAST_NAME_KEY;

            var users = GroupUsers(propertyName);
            ShowUsers(users);
        }

        protected override void AgeExample()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"{nameof(SwitchExample)}: age");

            var propertyName = AGE_KEY;

            var users = GroupUsers(propertyName);
            ShowUsers(users);
        }

        IEnumerable<IGrouping<string?, User>>? GroupUsers(string propertyName)
        {
            return propertyName switch
            {
                FIRST_NAME_KEY => _users?.GroupBy(_x => _x.FirstName),
                LAST_NAME_KEY => _users?.GroupBy(x => x.LastName),
                AGE_KEY => _users?.GroupBy(x => x.Age.ToString()),
                _ => throw new Exception()
            };
        }
    }
}
