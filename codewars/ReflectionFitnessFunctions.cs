using System.Reflection;

namespace codewars;

public class ReflectionFitnessFunctions
{
    [Fact]
    public void VerifyThatTestMethodNamesStartWithVerify()
    {
        var testClasses = Assembly.GetExecutingAssembly().GetTypes().Where(_ => _.IsClass);

        List<string> failingMethods = [];

        foreach (var testClass in testClasses)
        {
            var methods = testClass.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static)
                .Where(_ => _.GetCustomAttributes().Any(attr => attr.GetType() == typeof(TheoryAttribute)) ||
                            _.GetCustomAttributes().Any(attr => attr.GetType() == typeof(FactAttribute)));

            var failingMethodsInClass = methods.Where(_ => !_.Name.StartsWith("Verify"));

            failingMethods.AddRange(failingMethodsInClass.Select(method => $"{method.Name} in class {testClass.FullName}"));
        }

        failingMethods.Should().BeEmpty($"The following test methods do not adhere to the naming convention: {string.Join("\n", failingMethods)}. All test methods should start with 'Verify'.");
    }
}
