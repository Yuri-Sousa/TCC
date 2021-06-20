gx.plugdesign.definition = {
	css:[
	],
	js:[
	],
	templates:[
		'labels',
		'atts-vars',
		'readonly-atts-vars',
		'checkbox',
		'radio-button',	
		'prompt',
		'prompt-trigger',
		'datepicker',
		'geolocation',
		'multimedia-upload',
		'navbar',
		'navbar-textblock-link',
		'navbar-textblock-text',
		'textarea-auto-expand',
		'image',
		'usercontrol',
		'errorviewer',
		'password-atts-vars'
	],
	class_maps:[
		{
			selector:'.control-group',
			cssClass:'form-group'
		},
		// Attributes and variables
		{
			selector:'.gx-attribute > input:not(.GeoLocOption):not([type="image"]):not([type="checkbox"]), .gx-attribute > select, .gx-attribute > textarea',
			cssClass:'form-control'
		},
		// Attributes and variables with prompt
		{
			selector:'.gx-attribute > .input-group > input, .gx-attribute > .input-group > select, .gx-attribute > .input-group > textarea, .gx-attribute > .dp_container input',
			cssClass:'form-control'
		},
		// Form
		{
			selector:'form',
			cssClass:'form-horizontal'
		},
		// Standard Grids
		{
			selector:'div.gx-standard-grid > table',
			cssClass:'table-responsive',
			global: true,
			first: true
		},
		// Buttons
		{
			selector:'.gx-button input, input[type="button"][data-gx-button], .gx-grid-paging-bar button',
			cssClass: ['btn', 'btn-default'],
			first: true
		},
		// Buttons in NavBars
		{
			selector:'.gx-navbar .gx-button input, .gx-navbar input[type="button"]',
			cssClass:'navbar-btn'
		},
		// Enter button - primary action
		{
			selector:'.BtnEnter',
			cssClass:'btn-primary',
			first: true
		},
		// Delete button - primary action
		{
			selector:'.BtnDelete',
			cssClass:'btn-danger',
			first: true
		},
		// Containers
		{
			selector:'.Container',
			cssClass:'container',
			first: true
		},
		// WA only for 'old' automatic prompts that not have ContainerFluid class set. 
		{
			selector:'#MAINTABLE_MPAGE.PromptMainTable:not(.ContainerFluid)',
			cssClass:'ContainerFluid'
		},
		{
			selector:'.ContainerFluid',
			cssClass:'container-fluid',
			first: true
		},
		// Images
		{
			selector: '.ReadonlyResponsiveImageAttribute, .ResponsiveImage',
			cssClass: 'img-responsive',
			first: true
		},
		// TextBlocks as buttons
		{
			selector: '.BtnTextBlock > a',
			cssClass: ['btn', 'btn-default'],
			first: true
		}
	]
}