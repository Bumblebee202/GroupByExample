namespace GroupByExample.Examples
{
    internal class ReflectionExample : ExampleBase
    {
        protected override void FirstNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{nameof(ReflectionExample)}: first name");

            var propertyName = FIRST_NAME_KEY;

            var users = _users.GroupBy(x => x.GetType().GetProperty(propertyName).GetValue(x));
            ShowUsers(users);
        }

        protected override void LastNameExample()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{nameof(ReflectionExample)}: last name");

            var propertyName = LAST_NAME_KEY;

            var users = _users.GroupBy(x => x.GetType().GetProperty(propertyName).GetValue(x));
            ShowUsers(users);
        }

        protected override void AgeExample()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"{nameof(ReflectionExample)}: age");

            var propertyName = AGE_KEY;

            var users = _users.GroupBy(x => x.GetType().GetProperty(propertyName).GetValue(x));
            ShowUsers(users);
        }
    }
}
