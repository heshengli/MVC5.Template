﻿using MvcTemplate.Resources;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MvcTemplate.Components.Mvc
{
    public class EqualToAdapter : DataAnnotationsModelValidator<EqualToAttribute>
    {
        public EqualToAdapter(ModelMetadata metadata, ControllerContext context, EqualToAttribute attribute)
            : base(metadata, context, attribute)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            Attribute.OtherPropertyDisplayName = ResourceProvider.GetPropertyTitle(Metadata.ContainerType, Attribute.OtherPropertyName);

            ModelClientValidationRule rule = new ModelClientValidationRule();
            rule.ValidationParameters.Add("other", "*." + Attribute.OtherPropertyName);
            rule.ErrorMessage = ErrorMessage;
            rule.ValidationType = "equalto";

            return new[] { rule };
        }
    }
}
