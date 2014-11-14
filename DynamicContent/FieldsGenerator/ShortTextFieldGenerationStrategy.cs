﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Sitefinity.DynamicModules.Builder.Model;

namespace DynamicContent.FieldsGenerator
{
    /// <summary>
    /// This class represents field generation strategy for short text dynamic fields.
    /// </summary>
    public class ShortTextFieldGenerationStrategy : FieldGenerationStrategy
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortTextFieldGenerationStrategy"/> class.
        /// </summary>
        /// <param name="moduleType">Type of the module.</param>
        public ShortTextFieldGenerationStrategy(DynamicModuleType moduleType)
        {
            this.moduleType = moduleType;
        }

        /// <inheritdoc/>
        public override bool GetFieldCondition(DynamicModuleField field)
        {
            var condition = base.GetFieldCondition(field)
                && (field.FieldType == FieldType.ShortText || field.FieldType == FieldType.Guid)
                && field.Name != this.moduleType.MainShortTextFieldName;

            return condition;
        }

        /// <inheritdoc/>
        public override string GetFieldMarkup(DynamicModuleField field)
        {
            var markup = String.Format(ShortTextFieldGenerationStrategy.fieldMarkupTempalte, field.Name, field.Title);

            return markup;
        }

        private DynamicModuleType moduleType;
        private const string fieldMarkupTempalte = @"@Html.Sitefinity().ShortTextField((string)Model.Item.{0}, ""{0}"", ""{1}"",""sfitemShortTxtWrp"")";
    }
}
