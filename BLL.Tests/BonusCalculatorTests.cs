﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface;
using NUnit.Framework;

namespace BLL.Tests
{
    [TestFixture]
    public class BonusCalculatorTests
    {
        private static IBonusPointsCalculator calculator = new BonusCalculator();
        private static AccountOwner owner = new AccountOwner("pid", "name", "email");
        private static BankAccount gold = new GoldAccount("iban", owner, 100, 0);
        private static BankAccount platinum = new PlatinumAccount("iban", owner, 100, 0);
        private static BankAccount standard = new StandardAccount("iban", owner, 100, 0);

        [Test]
        public void CalculateDepositPointsTest()
        {
            Assert.Greater(calculator.CalculateDepositBonus(standard, 500), calculator.CalculateDepositBonus(standard, 100));
            Assert.Greater(calculator.CalculateDepositBonus(gold, 500), calculator.CalculateDepositBonus(gold, 100));
            Assert.Greater(calculator.CalculateDepositBonus(platinum, 500), calculator.CalculateDepositBonus(platinum, 100));

            Assert.Less(calculator.CalculateDepositBonus(standard, 100), calculator.CalculateDepositBonus(gold, 100));
            Assert.Less(calculator.CalculateDepositBonus(standard, 100), calculator.CalculateDepositBonus(platinum, 100));
            Assert.Less(calculator.CalculateDepositBonus(gold, 100), calculator.CalculateDepositBonus(platinum, 100));

            Assert.Greater(calculator.CalculateDepositBonus(standard, 100), calculator.CalculateWithdrawalBonus(standard, 100));
            Assert.Greater(calculator.CalculateDepositBonus(gold, 100), calculator.CalculateWithdrawalBonus(gold, 100));
            Assert.Greater(calculator.CalculateDepositBonus(platinum, 100), calculator.CalculateWithdrawalBonus(platinum, 100));
        }

        [Test]
        public void CalculateWithdrawalPointsTest()
        {
            Assert.Greater(calculator.CalculateWithdrawalBonus(standard, 500), calculator.CalculateWithdrawalBonus(standard, 100));
            Assert.Greater(calculator.CalculateWithdrawalBonus(gold, 500), calculator.CalculateWithdrawalBonus(gold, 100));
            Assert.Greater(calculator.CalculateWithdrawalBonus(platinum, 500), calculator.CalculateWithdrawalBonus(platinum, 100));

            Assert.Less(calculator.CalculateWithdrawalBonus(standard, 100), calculator.CalculateWithdrawalBonus(gold, 100));
            Assert.Less(calculator.CalculateWithdrawalBonus(standard, 100), calculator.CalculateWithdrawalBonus(platinum, 100));
            Assert.Less(calculator.CalculateWithdrawalBonus(gold, 100), calculator.CalculateWithdrawalBonus(platinum, 100));
        }
    }
}