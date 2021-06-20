function WWP_IconButton($) {
	  
	  

	var template = '<button  data-event=\"Event\"  class=\"{{Class}}\"> 	<i class=\"{{BeforeIconClass}}\"></i>	{{Caption}}	<i class=\"{{AfterIconClass}}\"></i></button>';
	Mustache.parse(template);
	var _iOnEvent = 0; 
	var $container;
	this.show = function() {
			$container = $(this.getContainerControl());

			// Raise before show scripts

			_iOnEvent = 0; 

			//if (this.IsPostBack)
				this.setHtml(Mustache.render(template, this));
			this.renderChildContainers();

			$(this.getContainerControl())
				.find("[data-event='Event']")
				.on('click', this.onEventHandler.closure(this))
				.each(function (i) {
					this.setAttribute("data-items-index", i + 1);
				}); 

			// Raise after show scripts

	}

	this.Scripts = [];



		this.onEventHandler = function (e) {
			if (e) {
				var target = e.currentTarget;
				e.preventDefault();
				 
				 
			}

			if (this.Event) {
				this.Event();
			}
		} 

	this.autoToggleVisibility = true;

	var childContainers = {};
	this.renderChildContainers = function () {
		$container
			.find("[data-slot][data-parent='" + this.ContainerName + "']")
			.each((function (i, slot) {
				var $slot = $(slot),
					slotName = $slot.attr('data-slot'),
					slotContentEl;

				slotContentEl = childContainers[slotName];
				if (!slotContentEl) {				
					slotContentEl = this.getChildContainer(slotName)
					childContainers[slotName] = slotContentEl;
					slotContentEl.parentNode.removeChild(slotContentEl);
				}
				$slot.append(slotContentEl);
				$(slotContentEl).show();
			}).closure(this));
	};

}