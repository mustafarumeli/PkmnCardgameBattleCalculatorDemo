﻿namespace BattleCalculatorDemo.Models
{
    public static class Helpers
    {
        public static string CreateCardDescription(this Card card)
        {
            string desc = "";
            foreach (CardAttribute cardAttribute in card.Attributes)
            {
                desc += CreateCardDescription(cardAttribute) + ",";
            }
            return desc;
        }
        private static string CreateCardDescription(CardAttribute cardAttribute)
        {
            string attributeDesc = cardAttribute.Name;
            foreach (var attributeVariable in cardAttribute.AttributeVariables)
            {
                attributeDesc += " " + attributeVariable.Value;
            }

            return attributeDesc;
        }
    }
}