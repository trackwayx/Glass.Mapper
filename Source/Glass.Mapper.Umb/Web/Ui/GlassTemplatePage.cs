﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace Glass.Mapper.Umb.Web.Ui
{
    /// <summary>
    /// GlassTemplatePage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GlassTemplatePage : UmbracoTemplatePage
    {
        private readonly IUmbracoService _umbracoService;

        /// <summary>
        /// Initializes a new instance of the <see cref="GlassTemplatePage{T}"/> class.
        /// </summary>
        /// <param name="service">The service.</param>
        public GlassTemplatePage(IUmbracoService service)
        {
            _umbracoService = service;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GlassTemplatePage{T}"/> class.
        /// </summary>
        public GlassTemplatePage()
            : this(new UmbracoService(new ContentService()))
        {
        }

        /// <summary>
        /// Gets the umbraco service.
        /// </summary>
        /// <value>
        /// The umbraco service.
        /// </value>
        public IUmbracoService UmbracoService
        {
            get { return _umbracoService; }
        }

        /// <summary>
        /// Executes the server code in the current web page that is marked using Razor syntax.
        /// </summary>
        public override void Execute()
        {
        }
    }

    /// <summary>
    /// GlassTemplatePage
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GlassTemplatePage<T> : GlassTemplatePage where T : class
    {
        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public new T Model { get; set; }
        
        /// <summary>
        /// Initializes the page.
        /// </summary>
        protected override void InitializePage()
        {
            base.InitializePage();
            Model = UmbracoService.CreateType<T>(UmbracoService.ContentService.GetPublishedVersion(base.Umbraco.AssignedContentItem.Id));
        }

        /// <summary>
        /// Executes the server code in the current web page that is marked using Razor syntax.
        /// </summary>
        public override void Execute()
        {
        }
    }
}
