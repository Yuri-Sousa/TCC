gx.ui.controls.Tab = gx.ui.controls.defineTabControl(function ($) {
	var template = '<ul id="{{containerId}}_tabs" class="nav nav-tabs">'+
						'{{#ctx}}' + 
						'<li>' + 
							'<a id="Tab_{{panel.id}}" href="#{{code}}" data-target="#{{panel.id}}" data-toggle="tab" data-index="{{index}}" data-code="{{code}}">{{title.textContent}}</a>' + 
						'</li>' + 
						'{{/ctx}}'+
					'</ul>' + 
					'<div class="tab-content">'+
						'{{#ctx}}' + 
						'<div class="tab-pane" id="{{panel.id}}"></div>' + 
						'{{/ctx}}' +
					'</div>';

	var addHistoryPoint = true,
		tabStripSelector = "",
		$container;

	this.render = function()
	{
		var container = this.getContainerControl(),
			containerId = container.id,
			currentGxClass;

		$container = $(container);
		tabStripSelector = '#' + containerId + '_tabs';

		var actx = [];
		for (var i=1; i<=this.PageCount; i++) {
			var ctx = {};
			ctx.index = i;
			ctx.panel = this.getChildContainer("panel" + i);
			ctx.title = this.getChildContainer("title" + i);
			ctx.code = $(ctx.title).contents('div').last().remove().text();
			if (ctx.panel && ctx.title)
				actx.push(ctx);
		}

		try {
			$container.append(Mustache.render(template, {
				ctx: actx, 
				containerId: containerId
			}));

			for (var i=0, len=actx.length; i<len; i++) {
				var $tabPane = $("#" + actx[i].panel.id);
				$(actx[i].panel).contents().each(function (i, el) {
					$tabPane[0].appendChild(el);
				});
				actx[i].panel.id = actx[i].panel.id + '_child';
				$tabPane[0].appendChild($(actx[i].panel)[0])
				var $tabItem = $("#Tab_" + actx[i].panel.id);
				$tabItem.data('target', '#' + actx[i].panel.id);
			}
		}
		catch(ex) {
			gx.dbg.write(ex.toString());
		}
	};
	
	this.afterRender = function () {
		var tabUC = this;
		$(tabStripSelector).find('a[data-toggle="tab"]')
			.on('click', function (e) {
				addHistoryPoint = true;
			})
			.on('shown.bs.tab', function (e) {
				tabUC.tabPageSelected(parseInt($(this).attr("data-index"), 10), false, addHistoryPoint);
				addHistoryPoint = false;
			});
	};
	
	this.allways = function () {
		var className = this.Class || ""

		if (gx.lang.gxBoolean(this.Visible)) {
			$container.show();
		}
		else {
			$container.hide();
		}

		currentGxClass = $container.attr('data-gx-class');
		if (currentGxClass) {
			$container.removeClass(currentGxClass);
		}
		$container.attr("data-gx-class", className).addClass(className);
	};

	this.getTabPageIndexByControlName = function (controlName) {
		return $(tabStripSelector)
					.find('li a[data-code="' + controlName + '"]')
					.data('index');
	};

	this.getTabPageControlNameByIndex = function (index) {
		return $(tabStripSelector)
					.find('li a[data-index="' + index + '"]')
					.data('code');
	};

	this.selectTabPageByIndex = function (i) {
		var fn = function () {
			$(tabStripSelector).find('li:nth-child(' + i +') a').tab('show');
		};

		if ($.prototype.tab) {
			fn();
		}
		else {
			gx.fx.obs.addObserver('gx.onready', this, fn, { single: true });
		}
	};
	
	this.hideTabPageByIndex = function (i) {
		var selector = tabStripSelector + ' li:nth-child(' + i +')';
		var child;
		$(selector).hide();
		if ($(selector).hasClass('active')) {
			if ($(tabStripSelector).is(':visible'))
				child = $(tabStripSelector).find('li:visible a');
			else
				child = $(tabStripSelector).find('li a').not(selector + ' a');
			child.each(function (i, el) {
						$(el).tab('show');
						return false;
					});
		}
	};

	this.showTabPageByIndex = function (i) {
		$(tabStripSelector).find('li:nth-child(' + i +')').show();
	};
});