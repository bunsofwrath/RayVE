﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RayVE.LinearAlgebra;

namespace RayVE.LinearAlgebra.Tests
{
    [TestClass]
    public class Vector3DTests
    {
        [TestMethod]
        public void Cross_WithNonZeroVectors_ExpectCorrectVector()
        {
            //arrange
            var vector1 = new Vector3D(4.3d, -4.2d, 3.1d);
            var vector2 = new Vector3D(4.2d, -4.1d, 3.0d);

            //act
            var crossProduct = vector1.Cross(vector2);

            //assert
            Assert.AreEqual(new Vector3D(0.11d, 0.12d, 0.01d), crossProduct);
        }

        [TestMethod]
        public void Cross_WithOneZeroVector_ExpectZeroVector()
        {
            //arrange
            var vector1 = new Vector3D(4.3d, -4.2d, 3.1d);
            var vector2 = Vector3D.Zero;

            //act
            var crossProduct = vector1.Cross(vector2);

            //assert
            Assert.AreEqual(crossProduct, Vector3D.Zero);
        }

        [TestMethod]
        public void Cross_WithParallelVectors_ExpectZeroVector()
        {
            //arrange
            var vector1 = new Vector3D(4.3d, -4.2d, 3.1d);
            var vector2 = new Vector3D(8.6d, -8.4d, 6.2d);

            //act
            var crossProduct = vector1.Cross(vector2);

            //assert
            Assert.AreEqual(crossProduct, Vector3D.Zero);
        }
    }
}