using GroupByExample.Extensions;
using GroupByExample.Models;

namespace GroupByExample.Examples
{
    internal class ExpressionTreeExample : ExampleBase
    {
        protected override void FirstNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{nameof(ExpressionTreeExample)}: first name");

            var propertyName = FIRST_NAME_KEY;

            var users = _users.GroupBy<string, User>(propertyName);
            ShowUsers(users);
        }

        protected override void LastNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{nameof(ExpressionTreeExample)}: last name");

            var propertyName = LAST_NAME_KEY;

            var users = _users.GroupBy<string, User>(propertyName);
            ShowUsers(users);
        }

        protected override void AgeExample()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{nameof(ExpressionTreeExample)}: age");

            var propertyName = AGE_KEY;

            var users = _users.GroupBy<int, User>(propertyName);
            ShowUsers(users);
        }
    }
}
