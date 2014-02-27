﻿using NUnit.Framework;
using System;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Template.Components.Extensions.Html;
using Template.Resources;
using Template.Tests.Helpers;
using Tests.Helpers;

namespace Template.Tests.Tests.Components.Extensions.Html
{
    [TestFixture]
    public class WidgetBoxExtensionsTests
    {
        private HtmlHelper html;

        [SetUp]
        public void SetUp()
        {
            var contextStub = new HttpContextStub();
            HttpContext.Current = contextStub.Context;
            html = new HtmlHelperMock(contextStub).Html;
        }

        [TearDown]
        public void TearDown()
        {
            HttpContext.Current = null;
        }

        #region Extension method: TableWidgetBox(this HtmlHelper html, params LinkAction[] actions)

        [Test]
        public void TableWidgetBox_FormsTableWidgetBox()
        {
            var expected = new StringBuilder();
            var expectedWriter = new StringWriter(expected);
            var expectedWidgetBox = new WidgetBox(
                expectedWriter, "fa fa-th", ResourceProvider.GetCurrentTableTitle(), String.Empty);
            expectedWidgetBox.Dispose();

            var actual = new StringBuilder();
            var actualWriter = new StringWriter(actual);
            html.ViewContext.Writer = actualWriter;

            var actualWidgetBox = html.TableWidgetBox();
            actualWidgetBox.Dispose();

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        #endregion

        #region Extension method: FormWidgetBox(this HtmlHelper html, params LinkAction[] actions)

        [Test]
        public void FormWidgetBox_FormsFormWidgetBox()
        {
            var expected = new StringBuilder();
            var expectedWriter = new StringWriter(expected);
            var expectedWidgetBox = new WidgetBox(
                expectedWriter, "fa fa-th-list", ResourceProvider.GetCurrentFormTitle(), String.Empty);
            expectedWidgetBox.Dispose();

            var actual = new StringBuilder();
            var actualWriter = new StringWriter(actual);
            html.ViewContext.Writer = actualWriter;

            var actualWidgetBox = html.FormWidgetBox();
            actualWidgetBox.Dispose();

            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        #endregion
    }
}