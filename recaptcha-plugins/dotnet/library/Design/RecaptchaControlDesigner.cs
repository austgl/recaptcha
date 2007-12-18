using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.Design;
using System.ComponentModel.Design;
using System.Diagnostics;

namespace Recaptcha.Design
{
    class RecaptchaControlDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return CreatePlaceHolderDesignTimeHtml("reCAPTCHA Validator");
        }


        public override bool AllowResize
        {
            get
            {
                return false;
            }
        }

        // Return a custom ActionList collection
        public override DesignerActionListCollection ActionLists
        {
            get
            {
                DesignerActionListCollection _actionLists = new DesignerActionListCollection();
                _actionLists.AddRange(base.ActionLists);

                // Add a custom DesignerActionList
                _actionLists.Add(new ActionList(this));
                return _actionLists;
            }
        }

        public class ActionList : DesignerActionList
        {
            private RecaptchaControlDesigner _parent;

            // Constructor
            public ActionList(RecaptchaControlDesigner parent)
                : base(parent.Component)
            {
                _parent = parent;

            }

            // Create the ActionItem collection and add one command
            public override DesignerActionItemCollection GetSortedActionItems()
            {
                // fixme -- I can't get this to open up automatically (
                DesignerActionItemCollection _items = new DesignerActionItemCollection();
                _items.Add(new DesignerActionHeaderItem("API Key"));
                _items.Add(new DesignerActionTextItem("To use reCAPTCHA, you need an API key from http://admin.recaptcha.net/", ""));

                return _items;
            }
        }


    }
}