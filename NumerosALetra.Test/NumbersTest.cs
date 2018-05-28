using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace NumerosALetra.Test
{
    [TestClass]
    public class NumbersTest
    {
        [DataTestMethod]
        [DataRow(-253, "menos doscientos cincuenta y tres")]
        [DataRow(0, "cero")]
        [DataRow(1, "uno")]
        [DataRow(4, "cuatro")]
        [DataRow(10, "diez")]
        [DataRow(14, "catorce")]
        [DataRow(15, "quince")]
        [DataRow(16, "dieciseis")]
        [DataRow(19, "diecinueve")]
        [DataRow(20, "veinte")]
        [DataRow(25, "veinticinco")]
        [DataRow(33, "treinta y tres")]
        [DataRow(87, "ochenta y siete")]
        [DataRow(3864, "tres mil ochocientos sesenta y cuatro")]
        [DataRow(24521, "veinticuatro mil quinientos veintiuno")]
        [DataRow(1527901, "un millón quinientos veintisiete mil novecientos uno")]
        [DataRow(37000005, "treinta y siete millones cinco")]
        [DataRow(int.MaxValue, "dos mil ciento cuarenta y siete millones cuatrocientos ochenta y tres mil seiscientos cuarenta y siete")]
        [DataRow(int.MinValue, "menos dos mil ciento cuarenta y siete millones cuatrocientos ochenta y tres mil seiscientos cuarenta y ocho")]
        [DataRow(long.MaxValue, "nueve trillones doscientos veintitres mil trescientos setenta y dos billones treinta y seis mil ochocientos cincuenta y cuatro millones setecientos setenta y cinco mil ochocientos siete")]
        [DataRow(1000000000000000000, "un trillón")]
        public void TestNumbers(long value, string expectedResult)
        {
            string result = value.ToText();
            Assert.AreEqual(expectedResult, result);
        }
    }
}
