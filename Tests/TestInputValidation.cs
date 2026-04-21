using NUnit.Framework;

[TestFixture]
public class TestInputValidation {
    [Test]
    public void TestForSQLInjection() {
        string entradaPeligrosa = "admin' OR '1'='1";
        bool esSeguro = ValidarEntrada(entradaPeligrosa); 
        Assert.IsFalse(esSeguro);
    }

    [Test]
    public void TestForXSS() {
        string scriptMalicioso = "<script>alert('hack')</script>";
        bool esSeguro = ValidarEntrada(scriptMalicioso);
        Assert.IsFalse(esSeguro);
    }

    private bool ValidarEntrada(string texto) {
        if (texto.Contains("'") || texto.Contains("<script>")) return false;
        return true;
    }
}
