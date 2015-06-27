using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinalProject;
namespace UnitTestFinalProject
{
    [TestClass]
    public class DALUnitTest
    {
        //check false id for patient
        
        [TestMethod]
        public void FalsePatientExistTest()
        {
            bool result = MainBL.patientExistByTestName("000");
                 bool expected = false;
            Assert.AreEqual(expected, result);

        }


        //try to get gene that does not exit.
        [TestMethod]
        public void GetGeneThatNotExistTest()
        {
            Gene g = MainBL.getGene("TestGeneName", "TestChrom");
            bool result = (g == null);
            bool expected = true;
            Assert.AreEqual(expected, result);

        }

        [TestMethod]
        //try to add gene to DB.
        public void AddGeneTest()
        {
            MainBL.addGene("PIK3CA", "chr3");
            Gene g = MainBL.getGene("PIK3CA", "chr3");
            bool result = (g != null);
            bool expected = true;
            Assert.AreEqual(expected, result);

        }
    }
}
