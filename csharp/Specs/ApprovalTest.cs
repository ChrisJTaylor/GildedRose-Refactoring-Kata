namespace csharp;

[UseReporter(typeof(DiffReporter))]
[TestFixture]
public class ApprovalTest
{
    [Test]
    public void ThirtyDays()
    {
        var fakeoutput = new StringBuilder();
        Console.SetOut(new StringWriter(fakeoutput));
        Console.SetIn(new StringReader("a\n"));

        Program.Main(["30"]);
        var output = fakeoutput.ToString();

        Approvals.Verify(output);
    }
}