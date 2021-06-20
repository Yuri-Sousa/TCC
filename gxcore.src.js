/* START OF FILE - ..\GenCommon\js\version.js - */
/**@preserve GeneXus 17.0.2.148165*/
/* END OF FILE - ..\GenCommon\js\version.js - */
/* START OF FILE - ..\GenCommon\js\mustache.js - */
/*!
 * mustache.js - Logic-less {{mustache}} templates with JavaScript
 * http://github.com/janl/mustache.js
 */

/*global define: false Mustache: true*/

(function defineMustache (global, factory) {
  if (typeof exports === 'object' && exports && typeof exports.nodeName !== 'string') {
    factory(exports); // CommonJS
  } else if (typeof define === 'function' && define.amd) {
    define(['exports'], factory); // AMD
  } else {
    global.Mustache = {};
    factory(global.Mustache); // script, wsh, asp
  }
}(this, function mustacheFactory (mustache) {

  var objectToString = Object.prototype.toString;
  var isArray = Array.isArray || function isArrayPolyfill (object) {
    return objectToString.call(object) === '[object Array]';
  };

  function isFunction (object) {
    return typeof object === 'function';
  }

  /**
   * More correct typeof string handling array
   * which normally returns typeof 'object'
   */
  function typeStr (obj) {
    return isArray(obj) ? 'array' : typeof obj;
  }

  function escapeRegExp (string) {
    return string.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, '\\$&');
  }

  /**
   * Null safe way of checking whether or not an object,
   * including its prototype, has a given property
   */
  function hasProperty (obj, propName) {
    return obj != null && typeof obj === 'object' && (propName in obj);
  }

  /**
   * Safe way of detecting whether or not the given thing is a primitive and
   * whether it has the given property
   */
  function primitiveHasOwnProperty (primitive, propName) {  
    return (
      primitive != null
      && typeof primitive !== 'object'
      && primitive.hasOwnProperty
      && primitive.hasOwnProperty(propName)
    );
  }

  // Workaround for https://issues.apache.org/jira/browse/COUCHDB-577
  // See https://github.com/janl/mustache.js/issues/189
  var regExpTest = RegExp.prototype.test;
  function testRegExp (re, string) {
    return regExpTest.call(re, string);
  }

  var nonSpaceRe = /\S/;
  function isWhitespace (string) {
    return !testRegExp(nonSpaceRe, string);
  }

  var entityMap = {
    '&': '&amp;',
    '<': '&lt;',
    '>': '&gt;',
    '"': '&quot;',
    "'": '&#39;',
    '/': '&#x2F;',
    '`': '&#x60;',
    '=': '&#x3D;'
  };

  function escapeHtml (string) {
    return String(string).replace(/[&<>"'`=\/]/g, function fromEntityMap (s) {
      return entityMap[s];
    });
  }

  var whiteRe = /\s*/;
  var spaceRe = /\s+/;
  var equalsRe = /\s*=/;
  var curlyRe = /\s*\}/;
  var tagRe = /#|\^|\/|>|\{|&|=|!/;

  /**
   * Breaks up the given `template` string into a tree of tokens. If the `tags`
   * argument is given here it must be an array with two string values: the
   * opening and closing tags used in the template (e.g. [ "<%", "%>" ]). Of
   * course, the default is to use mustaches (i.e. mustache.tags).
   *
   * A token is an array with at least 4 elements. The first element is the
   * mustache symbol that was used inside the tag, e.g. "#" or "&". If the tag
   * did not contain a symbol (i.e. {{myValue}}) this element is "name". For
   * all text that appears outside a symbol this element is "text".
   *
   * The second element of a token is its "value". For mustache tags this is
   * whatever else was inside the tag besides the opening symbol. For text tokens
   * this is the text itself.
   *
   * The third and fourth elements of the token are the start and end indices,
   * respectively, of the token in the original template.
   *
   * Tokens that are the root node of a subtree contain two more elements: 1) an
   * array of tokens in the subtree and 2) the index in the original template at
   * which the closing tag for that section begins.
   */
  function parseTemplate (template, tags) {
    if (!template)
      return [];

    var sections = [];     // Stack to hold section tokens
    var tokens = [];       // Buffer to hold the tokens
    var spaces = [];       // Indices of whitespace tokens on the current line
    var hasTag = false;    // Is there a {{tag}} on the current line?
    var nonSpace = false;  // Is there a non-space char on the current line?

    // Strips all whitespace tokens array for the current line
    // if there was a {{#tag}} on it and otherwise only space.
    function stripSpace () {
      if (hasTag && !nonSpace) {
        while (spaces.length)
          delete tokens[spaces.pop()];
      } else {
        spaces = [];
      }

      hasTag = false;
      nonSpace = false;
    }

    var openingTagRe, closingTagRe, closingCurlyRe;
    function compileTags (tagsToCompile) {
      if (typeof tagsToCompile === 'string')
        tagsToCompile = tagsToCompile.split(spaceRe, 2);

      if (!isArray(tagsToCompile) || tagsToCompile.length !== 2)
        throw new Error('Invalid tags: ' + tagsToCompile);

      openingTagRe = new RegExp(escapeRegExp(tagsToCompile[0]) + '\\s*');
      closingTagRe = new RegExp('\\s*' + escapeRegExp(tagsToCompile[1]));
      closingCurlyRe = new RegExp('\\s*' + escapeRegExp('}' + tagsToCompile[1]));
    }

    compileTags(tags || mustache.tags);

    var scanner = new Scanner(template);

    var start, type, value, chr, token, openSection;
    while (!scanner.eos()) {
      start = scanner.pos;

      // Match any text between tags.
      value = scanner.scanUntil(openingTagRe);

      if (value) {
        for (var i = 0, valueLength = value.length; i < valueLength; ++i) {
          chr = value.charAt(i);

          if (isWhitespace(chr)) {
            spaces.push(tokens.length);
          } else {
            nonSpace = true;
          }

          tokens.push([ 'text', chr, start, start + 1 ]);
          start += 1;

          // Check for whitespace on the current line.
          if (chr === '\n')
            stripSpace();
        }
      }

      // Match the opening tag.
      if (!scanner.scan(openingTagRe))
        break;

      hasTag = true;

      // Get the tag type.
      type = scanner.scan(tagRe) || 'name';
      scanner.scan(whiteRe);

      // Get the tag value.
      if (type === '=') {
        value = scanner.scanUntil(equalsRe);
        scanner.scan(equalsRe);
        scanner.scanUntil(closingTagRe);
      } else if (type === '{') {
        value = scanner.scanUntil(closingCurlyRe);
        scanner.scan(curlyRe);
        scanner.scanUntil(closingTagRe);
        type = '&';
      } else {
        value = scanner.scanUntil(closingTagRe);
      }

      // Match the closing tag.
      if (!scanner.scan(closingTagRe))
        throw new Error('Unclosed tag at ' + scanner.pos);

      token = [ type, value, start, scanner.pos ];
      tokens.push(token);

      if (type === '#' || type === '^') {
        sections.push(token);
      } else if (type === '/') {
        // Check section nesting.
        openSection = sections.pop();

        if (!openSection)
          throw new Error('Unopened section "' + value + '" at ' + start);

        if (openSection[1] !== value)
          throw new Error('Unclosed section "' + openSection[1] + '" at ' + start);
      } else if (type === 'name' || type === '{' || type === '&') {
        nonSpace = true;
      } else if (type === '=') {
        // Set the tags for the next time around.
        compileTags(value);
      }
    }

    // Make sure there are no open sections when we're done.
    openSection = sections.pop();

    if (openSection)
      throw new Error('Unclosed section "' + openSection[1] + '" at ' + scanner.pos);

    return nestTokens(squashTokens(tokens));
  }

  /**
   * Combines the values of consecutive text tokens in the given `tokens` array
   * to a single token.
   */
  function squashTokens (tokens) {
    var squashedTokens = [];

    var token, lastToken;
    for (var i = 0, numTokens = tokens.length; i < numTokens; ++i) {
      token = tokens[i];

      if (token) {
        if (token[0] === 'text' && lastToken && lastToken[0] === 'text') {
          lastToken[1] += token[1];
          lastToken[3] = token[3];
        } else {
          squashedTokens.push(token);
          lastToken = token;
        }
      }
    }

    return squashedTokens;
  }

  /**
   * Forms the given array of `tokens` into a nested tree structure where
   * tokens that represent a section have two additional items: 1) an array of
   * all tokens that appear in that section and 2) the index in the original
   * template that represents the end of that section.
   */
  function nestTokens (tokens) {
    var nestedTokens = [];
    var collector = nestedTokens;
    var sections = [];

    var token, section;
    for (var i = 0, numTokens = tokens.length; i < numTokens; ++i) {
      token = tokens[i];

      switch (token[0]) {
        case '#':
        case '^':
          collector.push(token);
          sections.push(token);
          collector = token[4] = [];
          break;
        case '/':
          section = sections.pop();
          section[5] = token[2];
          collector = sections.length > 0 ? sections[sections.length - 1][4] : nestedTokens;
          break;
        default:
          collector.push(token);
      }
    }

    return nestedTokens;
  }

  /**
   * A simple string scanner that is used by the template parser to find
   * tokens in template strings.
   */
  function Scanner (string) {
    this.string = string;
    this.tail = string;
    this.pos = 0;
  }

  /**
   * Returns `true` if the tail is empty (end of string).
   */
  Scanner.prototype.eos = function eos () {
    return this.tail === '';
  };

  /**
   * Tries to match the given regular expression at the current position.
   * Returns the matched text if it can match, the empty string otherwise.
   */
  Scanner.prototype.scan = function scan (re) {
    var match = this.tail.match(re);

    if (!match || match.index !== 0)
      return '';

    var string = match[0];

    this.tail = this.tail.substring(string.length);
    this.pos += string.length;

    return string;
  };

  /**
   * Skips all text until the given regular expression can be matched. Returns
   * the skipped string, which is the entire tail if no match can be made.
   */
  Scanner.prototype.scanUntil = function scanUntil (re) {
    var index = this.tail.search(re), match;

    switch (index) {
      case -1:
        match = this.tail;
        this.tail = '';
        break;
      case 0:
        match = '';
        break;
      default:
        match = this.tail.substring(0, index);
        this.tail = this.tail.substring(index);
    }

    this.pos += match.length;

    return match;
  };

  /**
   * Represents a rendering context by wrapping a view object and
   * maintaining a reference to the parent context.
   */
  function Context (view, parentContext) {
    this.view = view;
    this.cache = { '.': this.view };
    this.parent = parentContext;
  }

  /**
   * Creates a new context using the given view with this context
   * as the parent.
   */
  Context.prototype.push = function push (view) {
    return new Context(view, this);
  };

  /**
   * Returns the value of the given name in this context, traversing
   * up the context hierarchy if the value is absent in this context's view.
   */
  Context.prototype.lookup = function lookup (name) {
    var cache = this.cache;

    var value;
    if (cache.hasOwnProperty(name)) {
      value = cache[name];
    } else {
      var context = this, intermediateValue, names, index, lookupHit = false;

      while (context) {
        if (name.indexOf('.') > 0) {
          intermediateValue = context.view;
          names = name.split('.');
          index = 0;

          /**
           * Using the dot notion path in `name`, we descend through the
           * nested objects.
           *
           * To be certain that the lookup has been successful, we have to
           * check if the last object in the path actually has the property
           * we are looking for. We store the result in `lookupHit`.
           *
           * This is specially necessary for when the value has been set to
           * `undefined` and we want to avoid looking up parent contexts.
           *
           * In the case where dot notation is used, we consider the lookup
           * to be successful even if the last "object" in the path is
           * not actually an object but a primitive (e.g., a string, or an
           * integer), because it is sometimes useful to access a property
           * of an autoboxed primitive, such as the length of a string.
           **/
          while (intermediateValue != null && index < names.length) {
            if (index === names.length - 1)
              lookupHit = (
                hasProperty(intermediateValue, names[index]) 
                || primitiveHasOwnProperty(intermediateValue, names[index])
              );

            intermediateValue = intermediateValue[names[index++]];
          }
        } else {
          intermediateValue = context.view[name];

          /**
           * Only checking against `hasProperty`, which always returns `false` if
           * `context.view` is not an object. Deliberately omitting the check
           * against `primitiveHasOwnProperty` if dot notation is not used.
           *
           * Consider this example:
           * ```
           * Mustache.render("The length of a football field is {{#length}}{{length}}{{/length}}.", {length: "100 yards"})
           * ```
           *
           * If we were to check also against `primitiveHasOwnProperty`, as we do
           * in the dot notation case, then render call would return:
           *
           * "The length of a football field is 9."
           *
           * rather than the expected:
           *
           * "The length of a football field is 100 yards."
           **/
          lookupHit = hasProperty(context.view, name);
        }

        if (lookupHit) {
          value = intermediateValue;
          break;
        }

        context = context.parent;
      }

      cache[name] = value;
    }

    if (isFunction(value))
      value = value.call(this.view);

    return value;
  };

  /**
   * A Writer knows how to take a stream of tokens and render them to a
   * string, given a context. It also maintains a cache of templates to
   * avoid the need to parse the same template twice.
   */
  function Writer () {
    this.cache = {};
  }

  /**
   * Clears all cached templates in this writer.
   */
  Writer.prototype.clearCache = function clearCache () {
    this.cache = {};
  };

  /**
   * Parses and caches the given `template` according to the given `tags` or
   * `mustache.tags` if `tags` is omitted,  and returns the array of tokens
   * that is generated from the parse.
   */
  Writer.prototype.parse = function parse (template, tags) {
    var cache = this.cache;
    var cacheKey = template + ':' + (tags || mustache.tags).join(':');
    var tokens = cache[cacheKey];

    if (tokens == null)
      tokens = cache[cacheKey] = parseTemplate(template, tags);

    return tokens;
  };

  /**
   * High-level method that is used to render the given `template` with
   * the given `view`.
   *
   * The optional `partials` argument may be an object that contains the
   * names and templates of partials that are used in the template. It may
   * also be a function that is used to load partial templates on the fly
   * that takes a single argument: the name of the partial.
   *
   * If the optional `tags` argument is given here it must be an array with two
   * string values: the opening and closing tags used in the template (e.g.
   * [ "<%", "%>" ]). The default is to mustache.tags.
   */
  Writer.prototype.render = function render (template, view, partials, tags) {
    var tokens = this.parse(template, tags);
    var context = (view instanceof Context) ? view : new Context(view);
    return this.renderTokens(tokens, context, partials, template, tags);
  };

  /**
   * Low-level method that renders the given array of `tokens` using
   * the given `context` and `partials`.
   *
   * Note: The `originalTemplate` is only ever used to extract the portion
   * of the original template that was contained in a higher-order section.
   * If the template doesn't use higher-order sections, this argument may
   * be omitted.
   */
  Writer.prototype.renderTokens = function renderTokens (tokens, context, partials, originalTemplate, tags) {
    var buffer = '';

    var token, symbol, value;
    for (var i = 0, numTokens = tokens.length; i < numTokens; ++i) {
      value = undefined;
      token = tokens[i];
      symbol = token[0];

      if (symbol === '#') value = this.renderSection(token, context, partials, originalTemplate);
      else if (symbol === '^') value = this.renderInverted(token, context, partials, originalTemplate);
      else if (symbol === '>') value = this.renderPartial(token, context, partials, tags);
      else if (symbol === '&') value = this.unescapedValue(token, context);
      else if (symbol === 'name') value = this.escapedValue(token, context);
      else if (symbol === 'text') value = this.rawValue(token);

      if (value !== undefined)
        buffer += value;
    }

    return buffer;
  };

  Writer.prototype.renderSection = function renderSection (token, context, partials, originalTemplate) {
    var self = this;
    var buffer = '';
    var value = context.lookup(token[1]);

    // This function is used to render an arbitrary template
    // in the current context by higher-order sections.
    function subRender (template) {
      return self.render(template, context, partials);
    }

    if (!value) return;

    if (isArray(value)) {
      for (var j = 0, valueLength = value.length; j < valueLength; ++j) {
        buffer += this.renderTokens(token[4], context.push(value[j]), partials, originalTemplate);
      }
    } else if (typeof value === 'object' || typeof value === 'string' || typeof value === 'number') {
      buffer += this.renderTokens(token[4], context.push(value), partials, originalTemplate);
    } else if (isFunction(value)) {
      if (typeof originalTemplate !== 'string')
        throw new Error('Cannot use higher-order sections without the original template');

      // Extract the portion of the original template that the section contains.
      value = value.call(context.view, originalTemplate.slice(token[3], token[5]), subRender);

      if (value != null)
        buffer += value;
    } else {
      buffer += this.renderTokens(token[4], context, partials, originalTemplate);
    }
    return buffer;
  };

  Writer.prototype.renderInverted = function renderInverted (token, context, partials, originalTemplate) {
    var value = context.lookup(token[1]);

    // Use JavaScript's definition of falsy. Include empty arrays.
    // See https://github.com/janl/mustache.js/issues/186
    if (!value || (isArray(value) && value.length === 0))
      return this.renderTokens(token[4], context, partials, originalTemplate);
  };

  Writer.prototype.renderPartial = function renderPartial (token, context, partials, tags) {
    if (!partials) return;

    var value = isFunction(partials) ? partials(token[1]) : partials[token[1]];
    if (value != null)
      return this.renderTokens(this.parse(value, tags), context, partials, value);
  };

  Writer.prototype.unescapedValue = function unescapedValue (token, context) {
    var value = context.lookup(token[1]);
    if (value != null)
      return value;
  };

  Writer.prototype.escapedValue = function escapedValue (token, context) {
    var value = context.lookup(token[1]);
    if (value != null)
      return mustache.escape(value);
  };

  Writer.prototype.rawValue = function rawValue (token) {
    return token[1];
  };

  mustache.name = 'mustache.js';
  mustache.version = '3.0.1';
  mustache.tags = [ '{{', '}}' ];

  // All high-level mustache.* functions use this writer.
  var defaultWriter = new Writer();

  /**
   * Clears all cached templates in the default writer.
   */
  mustache.clearCache = function clearCache () {
    return defaultWriter.clearCache();
  };

  /**
   * Parses and caches the given template in the default writer and returns the
   * array of tokens it contains. Doing this ahead of time avoids the need to
   * parse templates on the fly as they are rendered.
   */
  mustache.parse = function parse (template, tags) {
    return defaultWriter.parse(template, tags);
  };

  /**
   * Renders the `template` with the given `view` and `partials` using the
   * default writer. If the optional `tags` argument is given here it must be an
   * array with two string values: the opening and closing tags used in the
   * template (e.g. [ "<%", "%>" ]). The default is to mustache.tags.
   */
  mustache.render = function render (template, view, partials, tags) {
    if (typeof template !== 'string') {
      throw new TypeError('Invalid template! Template should be a "string" ' +
                          'but "' + typeStr(template) + '" was given as the first ' +
                          'argument for mustache#render(template, view, partials)');
    }

    return defaultWriter.render(template, view, partials, tags);
  };

  // This is here for backwards compatibility with 0.4.x.,
  /*eslint-disable */ // eslint wants camel cased function name
  mustache.to_html = function to_html (template, view, partials, send) {
    /*eslint-enable*/

    var result = mustache.render(template, view, partials);

    if (isFunction(send)) {
      send(result);
    } else {
      return result;
    }
  };

  // Export the escaping function so that the user may override it.
  // See https://github.com/janl/mustache.js/issues/244
  mustache.escape = escapeHtml;

  // Export these mainly for testing, but also for advanced usage.
  mustache.Scanner = Scanner;
  mustache.Context = Context;
  mustache.Writer = Writer;

  return mustache;
}));
/* END OF FILE - ..\GenCommon\js\mustache.js - */
/* START OF FILE - ..\js\gxapi.js - */

(function () {
	window.onpageshow = function(event) {
		if (event.persisted) {
			window.location.reload();
		}
	};
})();

var gx = (function ($) {
	var VAR_PREFIX_REGEX_1 = /^(?:gx\.O\.)(.+)$/,
		VAR_PREFIX_REGEX_2 = /^(?:.+)?\((?:gx\.O\.)([a-zA-Z0-9_]+)(?:,)?(?:.*)\)$/;
		
	var GX_THEME_CSS_ELEMENT = 'gxtheme_css_reference';

	var trueFn = function () { return true; };
	var falseFn = function () { return false; };

	return {
		// Members whose value is the same when navigating through different pages, 
		// can be initialized here. If the value of the member changes
		// between pages, it must be initialized inside the _init function, so SPA can
		// re-initialize it when the user navigates.
		$:$.noConflict(),
		O: null,
		pO: null,
		languageCode: 'eng',
		dateFormat: 'MDY',
		timeFormat: 12,
		blankWhenEmpty: false,
		centuryFirstYear: 40,
		decimalPoint: '.',
		thousandSeparator: ',',
		staticDirectory: '/',
		basePath: '',
		datepickerImage: null,
		clientImages: {},
		blankImage: null,
		ascImage: null,
		descImage: null,
		expandImage: null,
		collapseImage: null,
		downloadImage: null,
		indicatorImage: null,
		resizeImage: null,
		msg: {},
		NULL_TIMEZONEOFFSET: 0,
		emptyFn: function () { },
		falseFn: falseFn,
		trueFn: trueFn,
		numericLenDec:function( picture) {
			var decPicturePart = picture.split('.'),
				integerPicturePart = decPicturePart.length === 2 ? decPicturePart[0] : picture,
				decPicturePart = decPicturePart.length === 2 ?decPicturePart[1] : "",
				integers = (integerPicturePart.match(/9|Z/g) || []).length,
				decimals = (decPicturePart.match(/9|Z/g) || []).length;
			return(	{
						Integers:integers, 
						Decimals:decimals
					});		
		},

		rtPicture:function(vStruct, Ctrl) {
			return (Ctrl && Ctrl.getAttribute('data-gx-rt-picture')) || vStruct && vStruct.pic || "";
		},

		dom: {
			_form: null,
			_avoidLeaksDiv: null,

			id: function (Control) {
				return ((Control.id == undefined || Control.id == '') ? Control.name : Control.id);
			},

			byId: function (id, root) {
				if (typeof id === 'string') {
					root = root || document;
					return root.getElementById(id);
				}
				return id;
			},

			byName: function (name) {
				if (name) {
					return document.getElementsByName(name);
				}
				return [];
			},

			byTag: function (name, root) {
				root = root || document;
				return root.getElementsByTagName(name);
			},

			byClass: function (name, tag, root) {
				if (!tag) {
					root = document || root;
					if (root.getElementsByClassName) {
						return root.getElementsByClassName(name);
					}
				}
				return $((tag || "") + "." + name, root).toArray();
			},

			bySelector: function ( selector) {
				return $(selector).toArray();
			},

			scripts: function (ignoreExternal) {
				var docScripts = document.scripts;
				if (!docScripts)
					docScripts = document.getElementsByTagName("script");
				if (typeof (docScripts) != 'undefined') {
					var scripts = [];
					var len = docScripts.length;
					for (var i = 0; i < len; i++) {
						if (ignoreExternal && docScripts[i].getAttribute("data-gx-external-script") != null)
							continue;
						var docScript = docScripts[i].attributes['src'];
						if (docScript && docScript.value) {
							docScript = docScript.value;
							if (docScript != '//:')
								scripts.push(docScript);
						}
					}
					return scripts;
				}
				return [];
			},

			getIntersectionObserver: function (callback) {
				var callbackCallFn = function () {
					if (callback) {
						callback(window.IntersectionObserver);
					}
				};

				if ('IntersectionObserver' in window &&
					'IntersectionObserverEntry' in window &&
					'intersectionRatio' in window.IntersectionObserverEntry.prototype) {
					callbackCallFn();
				}
				else {
					gx.http.loadScript(gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'intersection-observer.js' , false), function() { 
						callbackCallFn();
					});
				}
			},

			_init: function () {

				gx.evt.on_ready(this, function () {
					// Set autocomplete='off' to hidden inputs.
					// This is a WA for a bug that restores hidden inputs values when back button is hit (in Webkit) and a bug
					// that restores hidden inputs in nested iframes in Firefox.
					var i, len,
						browser = gx.util.browser;

					var hiddenInputs = [];
					if (document.querySelectorAll)
						hiddenInputs = document.querySelectorAll("input[type='hidden']");
					else {
						var inputs = gx.dom.byTag('input');
						for (i = 0, len = inputs.length; i < len; i++)
							if (inputs[i].getAttribute('type') == 'hidden')
								hiddenInputs.push(inputs[i]);
					}

					for (i = 0, len = hiddenInputs.length; i < len; i++)
						hiddenInputs[i].setAttribute('autocomplete', 'off');

					//WA when the first click is inside input type file.
					$('input[type="file"]').on('click', function ()	{
						gx.fx.obs.notify('gx.validation');
					});
					
					if (browser.isChrome()) {
						var selectEls = document.querySelectorAll('select');
						for (i = 0, len = selectEls.length; i < len; i++) {
							if (!selectEls[i].value) {
								var selOptionEl = selectEls[i].querySelectorAll('option[selected]');
								if (selOptionEl && selOptionEl.length) {
									selectEls[i].value = selOptionEl[0].value;
								}
							}
						}
					}
					$('input[type="file"]').on('click', function ()	{						
						gx.fx.obs.notify('gx.validation');
					});
				});
				this.TRANSITION_END_EVENT = gx.util.browser.isWebkit() ? 'webkitTransitionEnd' : gx.util.browser.isOpera() ? 'oTransitionEnd' : 'transitionend';
				this.ANIMATION_END_EVENT = gx.util.browser.isWebkit() ? 'webkitAnimationEnd' : gx.util.browser.isOpera() ? 'oAnimationEnd' : 'animationend';
			}
		},
		
		evt: {
			enter: false,
			lastKey: -1,
			lastControl: null,
			lastEvent: null,
			dummyCtrl: {},
			keyListeners: {},
			shiftPressed: false,
			execLoad: true,
			autoSkip: false,
			controlKeys: [0x03, 0x06, 0x08, 0x09, 0x0C, 0x0D, 0x0E, 0x10, 0x11, 0x12, 0x13, 0x14, 0x1B, 0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x2C, 0x2D, 0x2E],
			triggerKeys: [13, 32],
			processing: true,
			userReady: false,
			skipPromptCtrl: true,
			touchTimer: null,
			hooks: [],
			
			types: {
				VALUECHANGED:1,
				VALUECHANGING:2
			},

			serialRunner: function() {
				var pendingRun = [];
				return {
					addTask: function( fnc) {
								pendingRun.push( fnc);
								if (pendingRun.length  === 1) {
									pendingRun[0]();
								}
						},

					signalEndTask: function () {
						pendingRun.shift();
						if (pendingRun.length > 0) {
							pendingRun[0]();
						}
					}
				}
			},

			addHook: function (obj, evt, handler) {
				this.hooks.push({ c: obj, e: evt, f: handler });
			},
			
			attach: function (obj, evt, unScopedHandler, scope, options) {
				options = options || {};
				if (typeof (evt) == "string") {
					var handler = unScopedHandler;
					if (scope) {
						handler = unScopedHandler.closure(scope);
					}

					if (options.single) {
						var originalHandler = handler,
							handlerRan = false,
							handlerTimeout;

						handler = function () {
							// Altough the handler is detached to have a single execution of the handler, the mechanism is reinforced by 
							// using a flag to know if the handler was ran. This is because FF has issues with transitions and 'transitionend'
							// event handlers get fired more than once, even if the handler was detached, when more than one property has transitions.
							if (!handlerRan) {
								if (handlerTimeout) {
									clearTimeout(handlerTimeout);
								}
								gx.evt.detach(obj, evt, originalHandler, options);
								originalHandler.apply(this, arguments);
								handlerRan = true;
							}
						};
						
						if (options.timeout) {
							handlerTimeout = setTimeout(handler, options.timeout)
						}
					}

					if (obj.addEventListener) {
						obj.addEventListener(evt, handler, options.useCapture || false);
					}
					else if (obj.attachEvent) {
						obj.attachEvent('on' + evt, handler);
					}
					else {
						obj['on' + evt] = handler;
					}
					this.addHook(obj, evt, handler);
				}
				else if (gx.lang.isArray(evt)) {
					for (var i = 0, len = evt.length; i < len; i++) {
						this.attach(obj, evt[i], unScopedHandler, scope, options);
					}
				}
			},

			on_ready: function (context, fnc) {
				gx.fx.obs.addObserver('gx.onload', context, fnc);
			},
			
			onload: function () {
				gx.objectLoad().done( function () {
					gx.spa.start({
						listeners: {
							'onnavigatestart': function () {
								gx.dom.addClass(document.body, 'gx-spa-navigating');
							},
							'onnavigate': function () {
								gx.dom.removeClass(document.body, 'gx-spa-navigating');
							},
							'onbeforesend': function (eventObject, spaRequestHeader, mpRequestHeader) {
								if (gx.pO.MasterPage)
									eventObject.req.setRequestHeader(mpRequestHeader, gx.pO.MasterPage.ServerClass);
							},
							'onbeforeprocessresponse': function (eventObject, responseText, gxObjectClass, sourceMpClass, targetMpClass, sameMp) {
								gx.reinit(!sameMp);
							},
							'oncontentreplace': function (eventObject, responseText, contents, objectName, sourceMpObj, sourceMpName, targetMpName, sameMp) {
								var objectClass = gx.lang.getType(objectName),
									mpName = (sourceMpName == targetMpName ? sourceMpName : targetMpName),
									mpClass = mpName ? gx.lang.getType(mpName.toLowerCase()) : false,
									jsonResponse = gx.ajax.getJsonResponse();

								if (jsonResponse)
									gx.fn.setJsonHiddens(null, jsonResponse.gxHiddens, false);
								objectClass.prototype = new gx.GxObject;
								gx.setParentObj(new objectClass());
								if (sameMp) {
									gx.setMasterPage(sourceMpObj);
								}
								else {
									if (mpClass)
										gx.setMasterPage(new mpClass());
								}

								gx.ajax.clearJsonResponse();
								if (jsonResponse) {
									gx.ajax.setJsonResponse({ 
										response: jsonResponse, 
										isPostBack: false, 
										afterCmpLoaded: function () {
											if (sameMp) {
												sourceMpObj.restoreTargetComponents();
												sourceMpObj.restoreExoEventHandlers();
											}
											gx.objectLoad(jsonResponse.gxGrids, jsonResponse.gxHiddens).done(function() {
												gx.pO.SetStandaloneVars();
											});
										}, 
										gxObject: gx.O
									}).done( function() {
											gx.fn.setFocusAfterLoad(true);

									});
								}
								else {
									gx.objectLoad();
								}
							}
						}
					});
				});
			},

			onready: function (event) {
				if (gx.lang.emptyObject(event)) {
					if (document.readyState == 'complete')
						gx.evt.onload();
					else
						setTimeout(function () { gx.evt.onready(null); }, 250);
				}
				else if (gx.util.browser.isIE()) {
					if (document.readyState == 'complete')
						gx.evt.onload();
				}
			},

			_init: function () {
				document.gxReadyState = 'loading';
				if (gx.util.browser.isIE() && (gx.util.browser.isCompatMode() || document.documentMode <= 8 || gx.util.browser.ieVersion() <= 8 && !gx.util.browser.isWinCE())) {
					this.attach(document, 'readystatechange', this.onready);
				}
				else if ((gx.util.browser.ieVersion() >= 9 && !gx.util.browser.isWinCE()) || gx.util.browser.isFirefox() || gx.util.browser.isWebkit() || gx.util.browser.isOperaMini()) {
					this.attach(document, 'DOMContentLoaded', this.onload);
				}
				else if (gx.util.browser.isBlackBerry())
					this.attach(window, 'load', this.onload);
				else
					gx.wi( function() {	this.onready(null);}, gx.evt);
				gx.wi( function() {
					this.attach(document, ["touchstart"], this.ontouchstart);
					this.attach(document, "mousedown", this.onmousedown);				
					this.attach(document, ["mousemove", "touchmove"], this.onmousemove);
					this.attach(document, ["mouseup", "touchend"], this.onmouseup);
					this.attach(document, "click", this.onclick);
					this.attach(document, "dblclick", this.ondblclick);
					this.attach(window, "blur", this.onwindowblur);
					if (gx.dbg.performance && !gx.util.browser.isBlackBerry())
						this.attach(window, 'load', function () { gx.dbg.logPerf('onload', 'Page Loaded'); gx.dbg.printPerformanceLog(); });
				}, gx.evt);
			}
		},

		define: function (Name, IsComponent, Ctr) {
			var i = 0;
			var fn = (window || this);
			var arr = Name.split(".");
			var len = arr.length;
			for (i = 0; i < len - 1; i++) {
				if (typeof (fn[arr[i]]) == "undefined") {
					fn[arr[i]] = {};
				}
				fn = fn[arr[i]];
			}
			fn[arr[len - 1]] = Ctr;
			if (!IsComponent) {
				fn[arr[len - 1]].prototype = new gx.GxObject();
			}
		},

		setParentObj: function (GxObj) {
			gx.pO = GxObj;
			gx.O = gx.pO;
			gx.AjaxSecurity = gx.pO.AjaxSecurity;
			gx.OnSessionTimeout = gx.pO.OnSessionTimeout;
			gx.fx.obs.notify(gx.PARENT_OBJECT_EVT);
		},

		createParentObj: function (GxObjClass) {
			if (!gx.spa || !gx.spa.started) {
				if (!(GxObjClass instanceof gx.GxObject)) {
					GxObj = new GxObjClass();
				}
				if (GxObj) {
					this.setParentObj(GxObj);
				}
			}
		},

		setExecutableComponent: function (ObjType) {
			if (!gx.spa || !gx.spa.started) {
				gx.wi(function () {
					if (gx.pO == null) {
						gx.setParentObj(gx.createComponent(ObjType, ""));
						gx.fn.objectOnload(undefined, true);
					}
				},this);
			}
		},

		setMasterPage: function (MPage) {
			gx.wpo( function() {
				if (gx.pO != null) {
					gx.pO.MasterPage = MPage;
					gx.fx.obs.notify(gx.SETMASTERPAGE_EVT);
				}
			});
		},

		createMasterPage: function (MPageClass) {
			gx.wpo( function() {
				var GxObj;
				if (!gx.spa.isNavigating()) {
					if (!(MPageClass instanceof gx.GxObject)) {
						GxObj = new MPageClass();
					}

					if (GxObj) {
						this.setMasterPage(GxObj);
					}
				}
			}, this);
		},

		addComponent: function (gxComp, gxHiddens) {
			if (gx.pO != null) {
				gx.pO.setWebComponent(gxComp, gxHiddens);
			}
		},

		createComponent: function (CmpType, CmpCtx, CmpContainer) {
			var webComp = null, cmpClass, tCmp;
			cmpClass = gx.lang.getType(CmpType);
			if (cmpClass != null) {
				cmpClass.prototype = new gx.GxObject();
				tCmp = gx.csv.cmpCtx;
				gx.csv.cmpCtx = CmpCtx;
				webComp = new cmpClass(CmpCtx);
				if (CmpContainer) {
					webComp.setContainer(CmpContainer);
				}
				gx.csv.cmpCtx = tCmp;
				webComp.serviceUrl = gx.fn.getControlValue(webComp.CmpContext + '_CMPPGM');
			}
			return webComp;
		},

		getObj: function (CmpContext, IsMasterPage) {
			if (CmpContext == '') {
				if (IsMasterPage == true)
					return gx.pO.MasterPage;
				else
					return gx.pO;
			}
			else
				return gx.pO.getWebComponent(CmpContext);
		},
		
		setGxO: function () {
			var CmpContext, 
				IsMasterPage;

			if (arguments.length == 1 && typeof arguments[0] == 'object') {
				CmpContext = arguments[0].CmpContext;
				IsMasterPage = arguments[0].IsMasterPage;
				gx.O = arguments[0];
			}
			else {
				CmpContext = arguments[0];
				IsMasterPage = arguments[1];
				gx.O = this.getObj(CmpContext, IsMasterPage) || gx.pO;
			}
			gx.csv.cmpCtx = gx.O.CmpContext;
			return gx.O;
		},

		setVar: function (VarName, Value) {
			gx.O.setVariable(VarName, Value);
		},

		getVar: function (VarName) {
			return gx.O.getVariable(VarName);
		},

		prefixVar: function (VarName) {
			return 'gx.O.' + VarName;
		},

		unprefixVar: function (pVarName) {
			var varRE = VAR_PREFIX_REGEX_1;
			var isMatch = varRE.exec(pVarName);
			if (isMatch != null && isMatch[1]) {
				pVarName = isMatch[1];
			}
			else {
				varRE = VAR_PREFIX_REGEX_2;
				isMatch = varRE.exec(pVarName);
				if (isMatch != null && isMatch[1]) {
					pVarName = isMatch[1];
				}
			}
			return pVarName;
		},

		getMessage: function (code) {
			if (gx.msg[code] == undefined)
				return code;
			else
				return gx.msg[code];
		},

		setLanguageCode: function (value) {
			gx.languageCode = value;
		},

		setDateFormat: function (value) {
			gx.dateFormat = value;
		},

		setTimeFormat: function (value) {
			gx.timeFormat = value;
		},

		setCenturyFirstYear: function (value) {
			gx.centuryFirstYear = value;
		},

		setBlankWhenEmptyDate: function (value) {
			gx.blankWhenEmpty = value;
		},

		setDecimalPoint: function (value) {
			gx.decimalPoint = value;
		},

		setThousandSeparator: function (value) {
			gx.thousandSeparator = value;
		},

			
		setStaticDirectory: function (value) {
			gx.staticDirectory = value;
			if (gx.staticDirectory == '') {
				gx.staticDirectory = '/';
			}
			else {
				var len = gx.staticDirectory.length;
				var addFBar = (gx.staticDirectory.charAt(0) != '/');
				var addLBar = (gx.staticDirectory.charAt(len - 1) != '/');

				gx.staticDirectory = ((addFBar ? '/' : '') + gx.staticDirectory + (addLBar ? '/' : ''));
			}
		},

		getThemeElement: function () {
			return gx.dom.byId(GX_THEME_CSS_ELEMENT);
		},

		updateTheme: function () {
			var newTheme = gx.fn.getHidden('GX_THEME');
			if (newTheme && newTheme != this.theme) {
				this.theme = newTheme;
				var theme_el = gx.getThemeElement();
				if (theme_el && theme_el.href.search("/" + this.theme + '.css') < 0) {
					theme_el.href = theme_el.href.replace(new RegExp("[^/]*\.css"), this.theme + '.css');
				}
			}
		},

		setTheme: function (root) {
			var browser = gx.util.browser,
				isIE = browser.isIE(),
				ieVersion = browser.ieVersion(),
				gxDomFixes = gx.dom.fixes;

			this.theme = gx.fn.getHidden('GX_THEME');
			if (!this.theme) {
				this.theme = '';
			}
			try {
				if (root === undefined) {
					gxDomFixes.resetFixesStyleElement();
				}
				if (gx.HTML5) {
					gxDomFixes.html5(root);
				}

				if (root === undefined) {
					if (isIE) {
						$(document.documentElement).addClass("ie");
						$(document.documentElement).addClass("ie" + ieVersion);
						
						if (gx.runtimeTemplates && !Modernizr.flexbox) {
							$(document.documentElement).addClass("gx-align-fallback");
						}
					}

					// WA for IE10 bug: https://connect.microsoft.com/IE/feedback/details/776537/
					if (isIE && ieVersion == 10) {
						var styleEl = document.createElement("style");
						styleEl.innerHTML = "input::-ms-clear {display: none;}";
						document.body.appendChild(styleEl);
					}

					gxDomFixes.setPopupMinWidth();
				}

				gxDomFixes.fixTableResets(root);
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxapi.js', 'setTheme');
			}
		},

		typedOld: function (ctrlName, varName, type) {
			switch (type) {
				case 'int':
					return this.OldInteger(ctrlName, varName);
				case 'decimal':
					return this.OldDecimal(ctrlName, varName, true);
				case 'date':
					return this.OldDate(ctrlName, varName);
				case 'dtime':
					return this.OldDateTime(ctrlName, varName);
				default:
					return this.Old(ctrlName, varName);
			}
		},
		
		isInputEnabled: function (evt) {
			if (evt && gx.evt.lastEvt == evt) {
				return true;
			}
			return !((gx.evt.processing && !gx.csv.validating) || gx.spa.isNavigating());
		},

		types: {
			numeric: 0,
			character: 1,
			date: 2,
			dateTime: 3,
			blob: 4,
			varChar: 5,
			longVarChar: 6,
			bool: 7,
			geolocation: 8
		},
		domains: {
			url: "Url",
			email: "Email",
			phone: "Phone",
			address: "Address",
			geolocation: "Geolocation",
			component: "Component",
			feed: "Feed"
		},

		gen: {
			net: false,

			isDotNet: function () {
				return this.net;
			},
			isRuby: falseFn,
			isJava: function () {
				return !this.net;
			},
			resolveObjClass: function (objUrl) {
				var objClass = objUrl;
				if (gx.gen.isDotNet())
					objClass = objUrl.replace(/\.aspx$/, "");
				if (gx.gen.isJava() && gx.pO && gx.pO.PackageName && gx.text.startsWith(objUrl, gx.pO.PackageName))
					objClass = objUrl.substring(gx.pO.PackageName.length + 1);
				return objClass;
			}
		},

	
		util: {
			executionContext: {
				getContext: function() {
					//Used to detect page/document changing
					return gx.http.currentUrl();					
				},
				changedContext: function( handler) {
					return handler !== gx.util.executionContext.getContext();
				}				
			},
			contentTypes: {
				"txt": "text/plain",
				"rtx": "text/richtext",
				"htm": "text/html",
				"html": "text/html",
				"xml": "text/xml",
				"aif": "audio/x-aiff",
				"au": "audio/basic",
				"wav": "audio/wav",
				"bmp": "image/bmp",
				"gif": "image/gif",
				"jpe": "image/jpeg",
				"jpeg": "image/jpeg",
				"jpg": "image/jpeg",
				"jfif": "image/pjpeg",
				"tif": "image/tiff",
				"tiff": "image/tiff",
				"png": "image/x-png",
				"mpg": "video/mpeg",
				"mpeg": "video/mpeg",
				"mov": "video/quicktime",
				"qt": "video/quicktime",
				"avi": "video/x-msvideo",
				"exe": "application/octet-stream",
				"dll": "application/x-msdownload",
				"ps": "application/postscript",
				"pdf": "application/pdf",
				"tgz": "application/x-compressed",
				"zip": "application/x-zip-compressed",
				"gz": "application/x-gzip"
			},

			compare: function (operand1, op, operand2) {
				if(typeof operand1 != typeof operand2)
				  return false;
				if(typeof operand1 == "string" && op == 'like')
				{
					var cleansedOperand2 = operand2.replace(/[\-\[\]{}()*+?.,\\\^$|#\s]/g, "\\$&");
					cleansedOperand2 = gx.text.replaceAll(gx.text.replaceAll(cleansedOperand2, '%', '.*'), '_', '.');
					return new RegExp(cleansedOperand2, 'i').test(operand1);
				}
				switch(op)
				{
					case '>': return operand1 > operand2;
					case '>=': return operand1 >= operand2;
					case '<': return operand1 < operand2;
					case '<=': return operand1 <= operand2;
					case '<>': return operand1 != operand2;
					case '=':
					default: return operand1 == operand2;
				}
			},

			isKnownContentType: function (cType) {
				for (var ext in this.contentTypes) {
					if (this.contentTypes[ext] == cType)
						return true;
				}
				return false;
			},

			getContentTypeFromExt: function (ext) {
				var dotIdx = ext.lastIndexOf('.');
				if (dotIdx != -1)
					ext = ext.substring(dotIdx + 1);
				if (ext)
					return this.getContentType(ext);
				return "";
			},

			getContentType: function (ext) {
				if (gx.lang.emptyObject(ext))
					return 'text/html';
				ext = ext.toLowerCase();
				ext = gx.text.trim(ext);
				if (this.isKnownContentType(ext))
					return ext;
				var dotIdx = ext.lastIndexOf('.');
				if (dotIdx != -1)
					ext = ext.substring(dotIdx + 1);
				var cType = this.contentTypes[ext];
				if (gx.lang.emptyObject(cType))
					return 'text/html';
				return cType;
			},

			getFileName: function(file) {
				var slashIndexOf = file.lastIndexOf('/'),
					backSlashIndexOf = file.lastIndexOf('\\'),
					start = slashIndexOf > backSlashIndexOf ? slashIndexOf : backSlashIndexOf,
					end = file.lastIndexOf('.');

				if (!file) {
					return file;
				}

				if (end < 0 || start > end) {
					end = file.length;
				}
			
				return file.substring(start+1, end);
			},

			getFileType: function(file) {
				var slashIndexOf = file.lastIndexOf('/'),
					backSlashIndexOf = file.lastIndexOf('\\'),
					indexOf = file.lastIndexOf('.');
			
				if	(indexOf < 0 || indexOf < slashIndexOf || indexOf < backSlashIndexOf)
					return "";
				return file.substring(indexOf + 1);
			},

			getWindowInfo: function() {
				var id = "";
				var accessFrame = true;
				var isInIframe = false;
				try {
					// Test wether the frameElement can be accessed					
					isInIframe = (window.location != window.parent.location) ? true : false;
					if (isInIframe) {
						try {
							accessFrame = window.frameElement.id || window.top.document.body;
							id = window.name;
						}
						catch (e) {
							accessFrame = false;					
						}
					}
				}
				catch (e) {
					
				}
				return {insideIframe: isInIframe, canAccessFrame: accessFrame, frameId: id};
			},
	
			browser: (function () {
				var ua = navigator.userAgent;
				var IE_VERSION_REGEX = /; rv.([0-9]+)/;
				var ieVersion;
				return {
					w3c: true,
					ie5: true,
					ie: (ua.indexOf("MSIE") != -1|| ua.indexOf("Trident") != -1),
					edge: ua.indexOf("Edge") != -1,
					ff: (ua.indexOf("Firefox") != -1),
					winCE: (ua.indexOf("Windows CE") != -1),
					iphone: (ua.indexOf("iPhone") != -1),
					ipad: (ua.indexOf("iPad") != -1),
					ipod: (ua.indexOf("iPod") != -1),
					blackBerry: (ua.indexOf("BlackBerry") != -1),
					operaMini: (ua.indexOf("Opera Mini") != -1),
					opera: (ua.indexOf("Opera") != -1),
					chrome: (ua.indexOf("Chrome") != -1),
					android: (ua.indexOf("Android") != -1),
					webkit: (ua.search(/webkit/ig) != -1),
					safari: (ua.indexOf("Safari") != -1),

					isIE: function () {
						return this.ie || this.edge;
					},

					isEdge: function () {
						return this.edge;
					},

					isSafari: function () {
						return this.safari;
					},

					isFirefox: function () {
						return this.ff;
					},

					isChrome: function () {
						return this.chrome;
					},

					isWinCE: function () {
						return this.winCE;
					},

					isIPhone: function () {
						return this.iphone;
					},

					isIPad: function () {
						return this.ipad;
					},

					isAndroid: function () {
						return this.android;
					},

					isBlackBerry: function () {
						return this.blackBerry;
					},
					isOperaMini: function () {
						return this.operaMini;
					},

					isOpera: function () {
						return this.opera;
					},

					isWebkit: function () {
						return this.webkit;
					},

					isSmartDevice: function () {
						return this.isWinCE() || this.isIPhone() || this.isBlackBerry() || this.isOperaMini() || this.isAndroid();
					},

					isCompatMode: function () {
						return document.compatMode == "BackCompat";
					},

					isOldIE: function (ieVersion) {
						return gx.util.browser.isIE() && gx.util.browser.ieVersion() <= (ieVersion || 8);
					},

					ieVersion: function () {
						var ieVersionImpl = function () {
							var matches;
							if (this.ie) {
								try {
									var ieIdx = ua.indexOf('MSIE');
									if (ieIdx >= 0) {
										var cIdx = ua.indexOf(';', ieIdx);
										var version = ua.substring(ieIdx + 5, cIdx);
										return parseFloat(version, 10);
									}
									else {
										matches = ua.match(IE_VERSION_REGEX);
										if (matches.length > 1) {
											return parseFloat(matches[1], 10);
										}
									}
								}
								catch (e) {
									gx.dbg.logEx(e, 'gxapi.js', 'ieVersion');
								}
							}
							else if (this.edge) {
								matches = ua.match(/ Edge\/([0-9]+)\./);
								if (matches.length > 1) {
									return parseFloat(matches[1], 10);
								}
							}
							return -1;
						}

						if (!ieVersion) {
							ieVersion = ieVersionImpl.call(this);
						}
						return ieVersion;
					},

					chromeVersion: function () {
						if (this.isChrome()) {
							var matches = ua.match(/Chrome\/([0-9]+)/);
							if (matches.length > 1) {
								return parseFloat(matches[1], 10);
							}
						}
					},

					setupIE: function () {
						if (this.ieVersion() >= 9 && !this.isCompatMode()) {
							if ((typeof Range !== "undefined") && !Range.prototype.createContextualFragment) {
								Range.prototype.createContextualFragment = function (html) {
									var frag = document.createDocumentFragment(),
									div = document.createElement("div");
									frag.appendChild(div);
									div.outerHTML = html;
									return frag;
								};
							}
						}
						if(typeof String.prototype.trim !== 'function') {
						  String.prototype.trim = function() {
							return this.replace(/^\s+|\s+$/g, ''); 
						  }
						}
					},

					_init: function () {
						if (!this.isWinCE()) {
							this.w3c = (document.getElementById) ? true : false;							
							this.ie5 = (this.ie && document.getElementById && document.all) ? true : false;							
						}
						this.setupIE();
					}
				};
			})(),

			addOnce: function (O, Element, Key) {
				if (O[Key] == undefined)
					O[Key] = Element;
			},

			inArray: function (obj, arr) {
				if ((obj == null) || !(gx.lang.isArray(arr)))
					return false;
				if (typeof(arr.indexOf) == 'function')
					return arr.indexOf( obj) != -1;
				var len = arr.length;
				for (var i = 0; i < len; i++) {
					if (arr[i] == obj)
						return true;
				}
				return false;
			},
			
			pushOnceSorted: function( num, arr) {
				var bInclude = true;
				for (var i = 0, len = arr.length; i < len; i++) {
					if (num == arr[i]) {
						bInclude = false;
						break;
					}
					if (num < arr[i]) {
						arr.splice(i, 0, num);
						bInclude = false;
						break;
					}
				}
				if (bInclude) {
					arr.push( num);				
				}
			},

			lastArray: function( arr) {				
				return arr.length > 0 ? arr[arr.length - 1] : null;
			},
		
			noParmsUrl: function (url) {
				var qIdx = url.indexOf('?');
				if (qIdx != -1)
					url = url.substring(0, qIdx);
				return url;
			},

			resolveUrl : function (url) {
				if (!url)
					return url;
				if (gx.isabsoluteurl(url)) {
					return url;
				}
				else {
					if (gx.isRelativeToHost(url)) {
						if (url.toLowerCase().indexOf("/" + gx.basePath.toLowerCase()) != 0)
							return gx.util.resourceUrl(gx.basePath + url, false);
						return url;
					}
					else
						return gx.util.resourceUrl(gx.basePath + gx.staticDirectory + url, false);
				}
			},
		
			resourceUrl: function () {
				var BASE_PATH_REGEX;

				return function (path, notRelative) {
					if (!BASE_PATH_REGEX) {
						BASE_PATH_REGEX = new RegExp(gx.basePath + '(/|$)', 'i');
					}

					if (typeof (path) == 'undefined')
						return '';
					if (path.indexOf('://') != -1 || path.charAt(0) == '.')
						return path;
					var len = gx.basePath.length;
					var addlBar = (gx.basePath.charAt(len - 1) != '/');
					var pathIdx = (gx.basePath == '') ? 0 : path.search(BASE_PATH_REGEX);
					if (pathIdx == 0 && !notRelative)
						return ((path.charAt(0) == '/') ? '' : '/') + path;
					if ((pathIdx != -1) || notRelative) {
						var urlSuffix = '';
						if (pathIdx != -1 && gx.basePath.length>0)
							urlSuffix = gx.text.replaceAll(path.substring(pathIdx + gx.basePath.length), "\\", "/");
						else
							urlSuffix = path;

						if (path.charAt(0) == '/') {
							return location.protocol + "//" + location.host + path;
						}
						else {
						    var addfBar = (gx.basePath.length>0 && gx.basePath.charAt(0) != '/');
							addlBar = (addlBar && (urlSuffix.charAt(0) != '/'));

							return location.protocol + "//" + location.host + (addfBar ? "/" : "") + gx.basePath + (addlBar ? "/" : "") + urlSuffix;
						}
					}
					return path;
				};
			}(),

			sameAppUrl: function (url) {
				url = new this.Url(url);
				if (url.isRelative()) {
					return true;
				}
				return url.isSameApp(location.href);
			},

			removeBaseUrl: function (url) {
				var len = gx.staticDirectory.length;
				var staticDir;
				var addlBar = (gx.staticDirectory.charAt(len - 1) != '/');
				var addBasePathBar = gx.basePath.length > 0;
				if (gx.staticDirectory.charAt(0) == '/') {
					staticDir = gx.staticDirectory.substring(1);
				} else {
					staticDir = gx.staticDirectory;
				}
				var urlRegex = new RegExp('(?:/)?(?:' + gx.basePath + (addBasePathBar ? '/' : '') + '(?:' + staticDir + (addlBar ? '/' : '') + ')?)?((?:[\\S]*))');
				var realUrl = urlRegex.exec(url);
				if (realUrl != null && realUrl[1]) {
					url = realUrl[1];
				}
				return url;
			},

			getIFrameEmptySrc: function () {
				if (location.protocol == 'https:' && gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 6)
					return 'gx_blank.html'
				else
					return 'about:blank';
			},

			Url: (function () {
				var URL_REGEX = /^(([^\:\/\?#]+)\:)?(\/\/([^\/\?#]*))?([^\?#]*)(\?([^#]*))?(#(.*))?$/,
					URL_REGEX_USER_HOST_PORT = /^(([^@]+)@)?([^\:]+)(:(.+))?$/;

				var fn = function (url) {
					this.url = url;
					this.protocol = '';
					this.host = '';
					this.port = '';
					this.path = '';
					this.query = '';
					this.hash = '';
					this.user = '';

					function init(obj, url) {
						var urlRegex = URL_REGEX,
							urlParts = urlRegex.exec(url),
							isMatch = !gx.lang.emptyObject(urlParts);
						if (isMatch) {
							obj.protocol = (urlParts[2] ? urlParts[2] : '');
							var auth = (urlParts[4] ? urlParts[4] : '');
							obj.path = (urlParts[5] ? urlParts[5] : '');
							obj.query = (urlParts[7] ? urlParts[7] : '');
							obj.hash = (urlParts[9] ? urlParts[9] : '');
							urlRegex = URL_REGEX_USER_HOST_PORT;
							urlParts = urlRegex.exec(auth);
							isMatch = !gx.lang.emptyObject(urlParts);
							if (isMatch) {
								obj.user = (urlParts[2] ? urlParts[2] : '');
								obj.host = (urlParts[3] ? urlParts[3] : '');
								obj.port = (urlParts[5] ? urlParts[5] : '');
							}
						}
					}

					this.isRelative = function () {
						return gx.lang.emptyObject(this.host);
					}

					this.isSameApp = function (url) {
						url = new gx.util.Url(url);
						return ((this.protocol == url.protocol) && (this.host == url.host));
					}

					init(this, url);
				};

				fn.parseWithAnchor = function (url) {
					var a = document.createElement('a');
					a.href = url;
					if (!a.protocol && gx.util.browser.isIE())
						a.href = a.href;
					return a;
				};

				return fn;
			})(),

			regExp: {
				isMatch: function (str, rex) {
					var ret = new RegExp(rex).exec(str);
					return (ret !== null);
				},

				replace: function (str, rex, repl) {
					return str.replace(rex, repl);
				},

				split: function (str, rex) {
					return str.split(rex);
				},

				matches: function (str, rex) {
					var ret = new RegExp(rex).exec(str);
					if (ret !== null)
						return ret;
					else
						return [];
				}
			},

			autoRefresh: {
				arTimer: null,

				getProps: function () {
					var rfrTimeout = gx.fn.getHidden("_GxRefreshTimeout");
					if (rfrTimeout != null) {
						rfrTimeout = gx.json.evalJSON(rfrTimeout);
						rfrTimeout.Time = parseInt(rfrTimeout.Time);
					}
					return rfrTimeout;
				},

				install: function () {
					var rfrTimeout = this.getProps();
					if (rfrTimeout != null) {
						this.create();
						if (rfrTimeout.Type == "focus")
							gx.evt.attach(window, "blur", this.destroy);
					}
				},

				create: function () {
					if (this.arTimer == null) {
						var rfrTimeout = this.getProps();
						if (rfrTimeout != null)
							this.arTimer = setTimeout(function () { gx.http.reload(); }, rfrTimeout.Time * 1000);
					}
				},

				destroy: function () {
					if (gx.util.autoRefresh.arTimer != null) {
						window.clearTimeout(gx.util.autoRefresh.arTimer);
						gx.util.autoRefresh.arTimer = null;
					}
				}
			},

			accessKey: function (caption) {
				var aKey = '';
				if (caption.indexOf('&') != -1) {
					var len = caption.length;
					for (var i = 0; i < len - 1; i++) {
						if (caption[i] == '&' && caption[i + 1] != '&') {
							aKey = aKey + caption[i + 1];
							break;
						}
					}
				}
				return aKey;
			},

			accessKeyCaption: function (caption) {
				var dCapt = '';
				if (caption.indexOf('&') == -1)
					return caption;
				var len = caption.length;
				for (var i = 0; i < len - 1; i++) {
					if (caption[i] == '&' && caption[i + 1] != '&') {
						dCapt += caption.substring(i + 1);
						break;
					}
					else
						dCapt += caption[i];
				}
				return dCapt;
			},

			invalidFunc: function (strCode) {
				throw "gxInvalidFunc: " + strCode;
			},

			urlValue: function (ctrl) {
				var value = ctrl;
				if (typeof (value) != 'string')
					value = gx.fn.getControlValueInt(ctrl);
				return encodeURIComponent(value);
			},

			help: function (urlfile) {
				open(urlfile, 'gxHelpWindow', 'toolbar=no,location=no,directories=no,status=yes,menubar=no,scrollbars=yes,resizable=yes,copyhistory=no');
			},

			_init: function () {
				this.browser._init();				
			}
		},

		guid: {
			generate: function() {
				return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, function(c) {(c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)});		
			}
		},

		lang: {
			inherits: function (subclass, superclass, mergeConstructors) {
				var oldProt = subclass.prototype;
				subclass.prototype = new superclass();
				for (var pName in oldProt) {
					if (typeof (subclass.prototype[pName]) == 'undefined')
						subclass.prototype[pName] = oldProt[pName];
				}
				if (typeof (subclass.prototype.base) == 'undefined')
					subclass.prototype.base = superclass;

				if (mergeConstructors === true) {
					subclass.prototype.constructor = function () {
						superclass.prototype.constructor.apply(this, arguments);
						oldProt.constructor.apply(this, arguments);
					};
				}
			},

			apply: function (obj, cfg) {
				if (obj && cfg && typeof cfg === 'object') {
					for (var pName in cfg) {
						obj[pName] = cfg[pName];
					}
				}

				return obj;
			},

			instanceOf: function (obj, objClass) {
				if ((obj == null) || (objClass == null))
					return false;
				if (obj instanceof objClass)
					return true;
				if ((objClass == String) && (typeof (obj) == 'string'))
					return true;
				if ((objClass == Number) && (typeof (obj) == 'number' || (typeof (gx.num.dec) != "undefined" && obj instanceof gx.num.dec.bigDecimal)))
					return true;
				if ((objClass == Array) && (typeof (obj) == 'array'))
					return true;
				if ((objClass == Function) && (typeof (obj) == 'function'))
					return true;
				if ((typeof (obj) == 'string') || (typeof (obj) == 'number') || (typeof (obj) == 'array'))
					return false;
				var base = obj.base;
				while (typeof (base) != 'undefined') {
					if (base == objClass)
						return true;
					base = base.base;
				}
				return false;
			},

			clone: function (obj) {
				var newObj = {};
				for (var prop in obj) {
					newObj[prop] = obj[prop];
				}
				return newObj;
			},

			cloneDeep: function (obj) {
				return JSON.parse(JSON.stringify(obj));
			},

			isDateType: function (type) {
				return type == 'date' || type == 'dtime';
			},

			isNumericType: function (type) {
				return type == 'int' || type == 'decimal';
			},

			isBooleanType: function (type) {
				return type == 'boolean' || type == 'bool';
			},

			isFixedCharacterType: function (type) {
				return type == 'char' || type == 'bits';
			},

			isCharacterType: function (type) {
				return type == 'char' || type == 'svchar' || type == 'bits';
			},

			isArray: function (obj) {
				return obj && typeof obj.length == 'number' && typeof obj.splice == 'function';
			},

			booleanValue: function (obj) {
				if (obj == true || obj == false) {
					return obj;
				}
				else if (typeof (obj) == 'string') {
					if (obj.toLowerCase() == 'true')
						return true;
					else
						return false;
				}
				return false;
			},

			gxBoolean: function (obj) {
				if (typeof (obj) == 'undefined') {
					return false;
				}
				else if (typeof (obj) == 'boolean') {
					return obj;
				}
				else if (typeof (obj) == 'number') {
					if (obj == 0)
						return false;
				}
				else if (typeof (obj) == 'string') {
					if (obj == '')
						return false;
					if (obj.toLowerCase() == 'false')
						return false;
					else if (obj.replace(/^ */, '').replace(/ *$/, '') == '0')
						return false;
				}
				return true;
			},

			emptyNum: function (obj) {
				return (obj && obj === 0) || !obj
			},

			emptyObj: function (obj) {
				if (obj) {
					for (var prop in obj)
						if (obj.hasOwnProperty(prop))
							return false;
					return true;
				} else
					return true;
			},

			/*Returns true for undefined, null, empty string, zero, and NaN*/
			emptyObject: function (obj) {
				if ((obj === undefined) || (obj == null) || (obj == '') || (typeof (obj) == 'number' && isNaN(obj)))
					return true;
				return false;
			},

			supEval: function (obj, arr) {
				var fcn = null;
				if (arr instanceof String || typeof (arr) == 'string')
					fcn = obj[arr];
				else
					fcn = arr;
				return function () {
					return fcn.apply(obj, arguments);
				};
			},

			getType: function (typeName) {
				var typeObj = null;
				try {
					var i = 0;
					var fn = window;
					var arr = typeName.split(".");
					var len = arr.length;
					for (i = 0; i < len; i++) {
						if (fn[arr[i]]) {
							fn = fn[arr[i]];
						}
					}
					if (fn && fn != window)
						typeObj = fn;
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'getType');
				}
				return typeObj;
			},

			doEval: function (src, scope) {
				scope = scope || window;
				if (scope.execScript)
					return scope.execScript(src);
				else if (eval.call)
					return eval.call(scope, src);
				else
					return eval(src);
			},

			doCall: function () {
				try {
					var func = arguments[0];
					var args = [];
					var len = arguments.length;
					for (var i = 1; i < len; i++) {
						args.push(arguments[i]);
					}
					return func.apply(this, args);
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'doCall');
				}
			},

			doExecTimeout: function (obj) {
				clearTimeout(obj.t);
				obj.f.call();
			},

			doCallTimeout: function (func, ctx, args, to) {
				var _function = func.closure(ctx, args);
				var timer = setTimeout(_function, to);
				return { f: _function, t: timer };
			},

			requestAnimationFrame: function (fn, scope) {
				fn = scope ? fn.closure(scope) : fn;

				if (window.requestAnimationFrame) {
					window.requestAnimationFrame(fn);
				}
				else {
					window.setTimeout(fn, 10);
				}
			},
			
			htmlDecode:  (function() {
				// Remove HTML Entities
				var element = document.createElement('div');

				function decodeHTMLEntities (str) {
					if (str && typeof str === 'string') {
						// Escape HTML before decoding for HTML Entities
						str = escape(str).replace(/%26/g,'&').replace(/%23/g,'#').replace(/%3B/g,';');

						element.innerHTML = str;
						str = $(element).text();
						$(element).text('')
					}
					return unescape(str);
				}
				return decodeHTMLEntities;
			})(),

			arrayUnique: function (array) {
				var a = array.concat();
				for(var i=0; i<a.length; ++i) {
					for(var j=i+1; j<a.length; ++j) {
						if(a[i] === a[j]) {
							a.splice(j--, 1);
						}
					}
				}

				return a;
			},
			
			objToArray: function () {
				var fnObjToArray = function (value) {
					return [value];
				};

				return function (obj) {
					return $.map(obj, fnObjToArray)
				}
			}()
		},

		cache: (function () {
			var initialized = false;

			return {
				exceptionsRegEx: false,
				remoteFiles: {},
				inlineCode: {},

				isCacheable: function (file) {
					if (!this.exceptionsRegEx)
						return true;

					return !!file && file.search(this.exceptionsRegEx) == -1;
				},

				addRemoteFile: function (file) {
					if (this.isCacheable(file)) {
						file = gx.util.noParmsUrl(file);
						var fileUrl = gx.util.resourceUrl(file, true);
						this.remoteFiles[fileUrl] = true;
					}
				},

				addLoadedFile: function (file) {
					if (this.isCacheable(file)) {
						file = gx.util.noParmsUrl(file);
						var fileUrl = gx.util.resourceUrl(file, true);
						this.remoteFiles[fileUrl] = true;
					}
				},

				removeAllRemoteFiles: function () {
					this.remoteFiles = {};
				},

				removeRemoteFiles: function (pattern) {
					var remoteFile;
					if (pattern) {
						for (remoteFile in this.remoteFiles) {
							if (pattern.exec(remoteFile)) {
								this.remoteFiles[remoteFile] = false;
							}
						}
					}
				},

				removeRemoteFile: function (file) {
					file = gx.util.noParmsUrl(file);
					var fileUrl = gx.util.resourceUrl(file, true);
					this.remoteFiles[fileUrl] = false;
				},

				fileLoaded: function (file) {
					file = gx.util.noParmsUrl(file);
					var fileUrl = gx.util.resourceUrl(file, true);
					if (this.remoteFiles[fileUrl])
						return true;
					return false;
				},

				updateStyles: function (olds, news) {
					var deleted = [];
					var len = olds.length;
					for (var i = 0; i < len; i++) {
						var sheet = olds[i];
						if (!gx.lang.emptyObject(sheet)) {
							var found = false;
							var len1 = news.length;
							for (var j = 0; j < len1; j++) {
								if (sheet == news[j]) {
									found = true;
									break;
								}
							}
							if (!found)
								deleted.push(sheet);
						}
					}
					var imgsDir = gx.staticDirectory;
					if (imgsDir.charAt(0) == '/')
						imgsDir = imgsDir.substring(1);
					len = deleted.length;
					for (var i = 0; i < len; i++) {
						var sheet = deleted[i];
						if (sheet.charAt(0) != '/')
							sheet = imgsDir + sheet;
						this.removeRemoteFile(sheet);
					}
				},

				addInlineCode: function (obj) {
					this.inlineCode[obj] = true;
				},

				deleteInlineCode: function (obj) {
					delete this.inlineCode[obj];
				},

				codeLoaded: function (obj) {
					if (this.inlineCode[obj])
						return true;
					return false;
				},

				_init: function () {					
					if (!initialized) {
						initialized = true;
						var imgsDir = gx.staticDirectory;
						if (imgsDir.charAt(0) == '/')
							imgsDir = imgsDir.substring(1);
						var scripts = gx.dom.scripts(true);
						var len = scripts.length;
						for (var i = 0; i < len; i++) {
							var docScript = scripts[i];
							if (!gx.lang.emptyObject(docScript)) {
								if (docScript.charAt(0) != '/' && !gx.isabsoluteurl(docScript))
									docScript = imgsDir + docScript;
								this.addRemoteFile(docScript);
							}
						}
						var styles = gx.dom.styles();
						var len = styles.length;
						for (var i = 0; i < len; i++) {
							var sheet = styles[i];
							if (!gx.lang.emptyObject(sheet)) {
								if (sheet.charAt(0) != '/' && !gx.isabsoluteurl(sheet))
									sheet = imgsDir + sheet;
								this.addRemoteFile(sheet);
							}
						}
					}
				}
			}
		})(),

		json: {
			_nonSerializables: [],

			setNonSerializable: function (ctrlName) {
				if (!this.isNonSerializable(ctrlName))
					this._nonSerializables.push(ctrlName);
			},

			isNonSerializable: function (ctrlName) {
				var len = this._nonSerializables.length;
				for (var i = 0; i < len; i++) {
					if (this._nonSerializables[i] == ctrlName)
						return true;
				}
				return false;
			},

			evalJSON: function (value, useLegacy) {
				try {
					if (window.JSON && !useLegacy) {
						if (value === undefined) {
							return value;
						}
						return JSON.parse(value);
					}
					return eval('(' + value + ')');
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'evalJSON');
				}
				return value;
			},

			evalValidJSON: function (value) {
				return eval('(' + value + ')');
			},
			
			serializeSDTJson: function (obj, typename, allFields) {
				var objExt = gx.lang.cloneDeep(obj);
				objExt = gx.O.applySDTMapping( objExt, typename, false);					
				return gx.json.serializeJson(objExt, allFields);				
			},

			serializeJson: function (obj, allFields) {
				if (allFields && window.JSON) {
					return JSON.stringify(obj);
				}

				var objJson = this.objToJson(obj);
				if (objJson === null)
					objJson = this.arrayToJson(obj);
				else
					return objJson;
				if (objJson === null) {
					if (typeof (obj) == 'function')
						return null;
					var tmp = [];
					for (var prop in obj) {
						if (!allFields && this.isNonSerializable(prop))
							continue;
						var key = this.objToJson(prop, true);
						if (key === null)
							continue;
						var value = this.serializeJson(obj[prop]);
						if (typeof (value) != 'string')
							continue;
						tmp.push(key + ':' + value);
					}
					return '{' + tmp.join(',') + '}';
				}
				else
					return objJson;
			},

			objToJson: function (obj, isKey) {
				var type = typeof (obj);
				if (isKey) {
					if (!gx.lang.emptyObject(obj)) {
						if (type == 'string')
							return gx.text.escapeString(obj);
						else if (type == 'number')
							return '"' + obj + '"';
						else if (typeof (gx.num.dec) != "undefined" && obj instanceof gx.num.dec.bigDecimal)
							return '"' + obj.toString() + '"';
					}
				}
				else {
					if (type == 'undefined')
						return type;
					else if (type == 'string')
						return gx.text.escapeString(obj);
					else if ((type == 'number') || (type == 'boolean'))
						return obj.toString();
					else if (typeof (gx.num.dec) != "undefined" && obj instanceof gx.num.dec.bigDecimal)
						return '"' + obj.toString() + '"';
					else if (obj === null)
						return 'null';
					else if (typeof (obj.json) == 'function') {
						var tmp = obj.json();
						if (obj !== tmp)
							return this.serializeJson(tmp);
					}
				}
				return null;
			},

			arrayToJson: function (arr) {
				if (Array.isArray(arr)) {
					var res = [];
					var len = arr.length;
					for (var i = 0; i < len; i++) {
						var val = this.serializeJson(arr[i]);
						if (typeof (val) != 'string')
							val = 'undefined';
						res.push(val);
					}
					return '[' + res.join(',') + ']';
				}
				return null;
			},
			
			
			SDTFromJson: function (obj, typename, value, messages) {
				var ret = gx.json.objFromJson( obj, value, messages);
				if (ret) {
					obj = gx.O.applySDTMapping( obj, typename, true);	
				}
				return ret;
			},		

			objFromJson: function (obj, value, messages) {
				try {
					var jObj = this.evalValidJSON(value);
					if (Array.isArray(obj) && Array.isArray(jObj)) {
						while (obj.length > jObj.length) obj.shift();
					}
					else {
						for (var prop in obj) {
							if (typeof (obj[prop]) != 'function') {
								delete obj[prop];
							}
						}
					}
					for (var prop in jObj) {
						obj[prop] = jObj[prop];
					}
					return true;
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxapi.js', 'objFromJson');
					if (messages)
						messages.push({ Id: 'FromJson Error', Description: gx.dbg.exTxt(e), Type: 0 });
					return false;
				}
			}
		},

		dbg: {
			lastTime: 0,
			enabled: false,
			performance: false,
			dbgWin: null,
			outputFunc: null,
			hshTimes: null,
			performanceLog: [],
			_init: function () {
				this.hshTimes = [];
				this.hshTimes['onload'] = new Date().getTime();
			},

			logDebug: function (msg) {
				if (this.enabled) {
					this.write(msg);
				}
			},
			
			logMsg: function (msg) {
				if (this.enabled || window['console']) {
					this.write(msg);
				}
			},

			logEx: function (ex, file, func) {
				if (this.enabled || window['console']) {
					var msg = '';
					if (ex && ex instanceof Error) {
						msg = '[' + ex.name + ': ' + this.exTxt(ex);
						msg += (file ? ', file: ' + file : '');
						msg += (func ? ', func: ' + func : '') + ']';
						if (ex.fileName)
							msg += ' FileName:' + ex.fileName;
						if (ex.lineNumber)
							msg += ' ln:' + ex.lineNumber;
					}
					else {
						try {
							msg = String(ex);
						}
						catch (e) {
							msg = '[Unknown Error]';
						}
					}
					this.write(msg, true, ex);
				}
			},

			exTxt: function (ex) {
				if (!ex)
					return 'Unknown Error';
				if (ex.message)
					return ex.message;
				else if (ex.description)
					return ex.description;
				else
					return ex.toString();
			},

			write: function (txt, isError, ex) {
				if (this.enabled) {
					try {
						if (this.dbgWin == null)
							this.dbgWin = window.open("", "debug", "scrollbars=1,height=900,width=900");
						gx.dom.write(txt + '<BR>', this.dbgWin.document);
					}
					catch (e) { }
				}
				if (window['console']) {
					if (isError){
						if (ex && ex.stack)
							console.error(ex, ex.stack);
						else 
							console.error(txt);
					}
					else
						console.log(txt);
				}
				if (isError && window['ga']){
					ga('send', 'exception', {
						'exDescription': txt,
						'exFatal': isError
					});
				}
			},

			writeT: function (txt) {
				var now = new Date();
				var nt = now.getTime();
				var st = this.lastTime;
				if (this.lastTime > 0) {
					st = (nt - this.lastTime) / 1000;
				}
				this.lastTime = nt;
				txt = now.toString() + ' (+' + st + 'seg): ' + txt;
				this.write(txt);
			},

			logPerf: function (id, txt) {
				if (this.performance) {
					if (this.hshTimes[id] === undefined) {
						this.hshTimes[id] = new Date().getTime();
					}
					else {
						var st = (new Date().getTime() - this.hshTimes[id]) / 1000;
						delete this.hshTimes[id];
						if (st > 0) {
							var label = (txt == undefined) ? id : txt;
							var txt = label + ':(' + st + 'seg)';
							this.performanceLog.push(txt);
						}
					}
				}
			},
			printPerformanceLog: function () {
				if (this.performance) {
					for (msg in this.performanceLog) {
						if (typeof (this.performanceLog[msg]) == 'string') {
							if (this.outputFunc)
								this.outputFunc(this.performanceLog[msg]);
							this.write(this.performanceLog[msg]);
						}
					}
					this.performanceLog = [];
				}
			}
		},

		stackId: function(lvl) {			
			return 'stack_' + gx.util.getWindowInfo().frameId + lvl;
		},
		
		stackSupported: function() {
			return (gx.evt.clinav || gx.fn.getHidden('GX_CLI_NAV') == 'true') && gx.call_stack_storage.supported;
		},
		
		csv: {
		},
		
		http: {
			currentUrl: function() {
				return location.href.replace(location.hash,'');				
			},
			
			loadScript: function (url, callback, ignoreExisting) {
				var scriptCallback = callback,
					isExternal = false,
					urlCallback,
					attris,
					attr;

				if (typeof url !== "string") {
					urlCallback = url.callback;
					isExternal = url.isExternal;
					attris = url.attris;
					url = url.url;
					scriptCallback = function () {
						if (urlCallback) {
							urlCallback();
						}
						callback();
					};
				}

				var head = gx.dom.byTag('head')[0],
					script,
					$existingScript = $("script[src='" + url + "']"),
					appendToHead = true;

				if ($existingScript.length > 0 && !ignoreExisting) {
					if (isExternal) {
						$existingScript.remove();
					}
					else {
						script = $existingScript.get(0);
						appendToHead = false;
					}
				}
				
				var notifyCallback = function(scriptCallback) {
					var scriptLoadedCallback = function() {
						scriptCallback();
						script.removeAttribute('data-gx-loading-script');
					};
				
					if (typeof (scriptCallback) == 'function') {
						if (script.addEventListener)
							gx.evt.attach(script, ['load', 'error'] ,scriptLoadedCallback, { userCapture: false} );
						else {
							script.onreadystatechange = function () {
								if (script.readyState == 'loaded' || script.readyState == 'complete') {
									scriptLoadedCallback();
								}
							};
						}
					}
				};
		
				if (!script) {
					script = document.createElement('script');
					script.type = 'text/javascript';
					script.src = url;

					if (attris) {
						for (attr in attris) {
							if (attris.hasOwnProperty(attr)) {
								script.setAttribute(attr, attris[attr]);
							}
						}
					}

					if (scriptCallback) {
						script.setAttribute("async", "");
					}
					if (isExternal) {
						script.setAttribute("data-gx-external-script", "");
					}
					notifyCallback(scriptCallback);
					if (appendToHead) {
						head.appendChild(script);
						script.setAttribute('data-gx-loading-script','');
					}
				}
				else {
					var isLoading = script.getAttribute('data-gx-loading-script') !== null;
					if (isLoading) {
						notifyCallback(scriptCallback);
					}
					else {
						scriptCallback();
					}
				}
			}			
		},
		
		storage: function (prefix) {
			this._store = window.sessionStorage;
			this._prefix = prefix;	
			this.supported = false;
			
			this.set_string = function (key, value) {	
				if (this.supported)			
					this._store[this._prefix + key] = value;	
			}

			this.get_string = function (key) {
				if (this.supported)	
					return this._store[this._prefix + key];
				return null;
			}

			this.set = function (key, value) {
				this.set_string(key, gx.json.serializeJson(value));
			}

			this.get = function (key) {
				var val = this.get_string(key);
				return val ? gx.json.evalJSON(val) : null;
			}

			this.remove = function (key) {
				if (this.supported)	
					this._store.removeItem(this._prefix + key);
			}			
			
			// Initialize
			if (typeof (window.sessionStorage) != 'undefined') {
				try {
					window.sessionStorage.setItem('storage.test',true);
					window.sessionStorage.removeItem('storage.test');
					this.supported = true;
				} 
				catch (e) {
					gx.http.setCookie('GXLocalStorageSupport', 'false', 1, false);					
				}					
			}							
		},

		_setBasePath: function () {
			var scripts = gx.dom.scripts(),
				gxgral = null;

			for (var i = 0, len = scripts.length; i < len; i++) {
				if (scripts[i].indexOf("gxgral.js") >= 0 || scripts[i].indexOf("gxcore.js") >= 0 || scripts[i].indexOf("gxapiSD.js") >= 0) {
					gxgral = scripts[i];
					break;
				}
			}

			var path = "";
			if (!gx.isRelativeToHost(gxgral) || gx.isabsoluteurl(gxgral)) {
				var lastIdx = location.pathname.lastIndexOf("/");
				path = lastIdx > 1 ? location.pathname.substring(1, lastIdx) : "";
			}
			else {
				var gxgralParts = gxgral.split('/'),
					locationParts = location.pathname.split('/');

				gxgralParts.splice(gxgralParts.length - 1, 1);
				locationParts.splice(locationParts.length - 1, 1);

				for (var i = 0, len = locationParts.length; i < len; i++) {
					if (locationParts[i] == gxgralParts[i])
						path = path + ((path == '') ? '' : '/') + locationParts[i];
					else
						break;
				}
			}

			gx.basePath = path;
		},

		objectLoad: function (gxGrids, gxHiddens) {
			var deferred = $.Deferred(),
				domFixes = gx.dom.fixes;
			
			if (!gx.evt.execLoad) {	
				deferred.resolve();
				return deferred.promise();
			}

			var fncAfterInteractive = function() {
				gx.sec.loadKey();

				if (gx.runtimeTemplates === undefined) {
					gx.runtimeTemplates = ($('div[data-abstract-form]').length > 0);
				}

				var loadingObject = true;
				gx.setTheme();
				gx.html.applyCustomHTMLAttributes();
				gx.fx.obs.addObserver('webcom.render', this, function (gxComponent) {
					var container = gxComponent.getContainer();
					if (container) {
						gx.setTheme(container);
						gx.html.applyCustomHTMLAttributes(container);
						var fnc = function() {
							if (typeof(gx.pendingCmps) != 'undefined') {
								gx.pendingCmps -= 1;
								if (gx.pendingCmps === 0) {
									gx.fx.obs.notify('webcom.all_rendered');
								}
							}
						}
						if (!loadingObject) {
							gx.pendingCmps = gx.pendingCmps || 0;
							gx.pendingCmps += 1;
							gx.plugdesign.applyTemplateObject({ selector: '#' + container.id, deferred:true}).then(fnc);
						}
					}
				});
				gx.fx.obs.addObserver('grid.onafterrender', this, function (grid, isNestedLoad) {
					if (!isNestedLoad) {
						gx.dom.fixes.fixTableResets(grid.container);
					}
				});
				delete gx.evt.redirecting;
				gx.ajax._init();
				gx.grid._init();
				gx.evt.attach(window, 'unload', gx.evt.onunload);
				gx.fn.setFocusInit();
				gx.dom.fixes.createLegacyNotification();
				gx.cache._init();
				gx.fn.installComponents(true, gxHiddens);
				gx.http.loadStyles();
				if (gxGrids) {
					gx.fn.loadJsonGrids(gxGrids, false);
				}

				gx.plugdesign.init().done(function() {
					if (typeof(gx.StorageTimeZone) != 'undefined' && gx.StorageTimeZone != gx.NULL_TIMEZONEOFFSET) {
						var timezone = jstz.determine().name();
						if (!gx.lang.emptyObject(timezone) && gx.http.getCookie('GxTZOffset') != timezone  && gx.http.setCookie('GxTZOffset', timezone, 365, false, '/') && gx.config.timezone.reload)
							gx.http.reload();
					}

					gx.evt.attach(window, 'load', gx.http.applyDeferredStyles);
					gx.fn.objectOnload();
					gx.goReady();
					document.gxReadyState = 'complete';
					gx.util.autoRefresh.install();
					gx.fn.setOpacity("reset", 'body');
					gx.evt.setProcessing(false);
					gx.fx.obs.notify('gx.onload');
					gx.evt.userOnload();
					gx.fn.setFocusOnload();
					gx.fx.delayedSuggest();
					gx.http.doCommands();
					gx.evt.setReady(true);
					gx.evt.userReadyCnt = 0;
					loadingObject = false;
					deferred.resolve();
				});
			}
			if (gx.popup) {
				gx.goInteractive();
			}
			else {
				gx.http.loadScript( gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'gxi.js' , false), function() { 
					gx.goInteractive();
				});
			}
			gx.wpo(function() {	
				fncAfterInteractive();
			});
			return deferred.promise();
		},

		objectUnload: function (unloadMasterPage) {
			gx.fx.obs.notify('gx.onunload');
			gx.http.saveState(true);
			gx.evt.clearHooks();
			gx.fx.notifications.deinit();
			gx.fx.obs.removeAll();
			gx.util.autoRefresh.destroy();
			gx.fn.objectOnUnload(unloadMasterPage);
			gx.plugdesign.deinit();
			gx._deinit();
			$(document).off("keypress keyup");
			gx.evt.detach(document, 'keydown', gx.evt.onkeypress_hdlr);
		},
		
		_init_interactive: function() {
			gx.evt.dispatcher.initialize();
			gx.base64._init();
			gx.sec._init();
			gx.geolocation._init();
			gx.popup._init();
			gx.livePrevWS._init();
		},

		_init: function () {
			gx.wi( gx._init_interactive, gx);
			gx.lang.apply(this, {
				oldValues: [],
				oldKeyValues: [],
				newRows: [],
				suggestControls: {},
				disabledControls: [],
				usrPtys: [],
				usrFocusControl: '',
				currentRows: [],
				attachedControls: [],
				theme: ''
			});
			gx.dbg._init();
			gx.dom._init();
			gx.util._init();
			gx.evt._init();
			gx._setBasePath();
			gx.date._init();
			gx.html.controls._init();
			gx.call_stack_storage = new gx.storage('gx_call_stack');
		},

		_deinit: function () {
			if ((gx.popup.ispopup() && gx.evt.execLoad) || gx.dom.shouldPurge()) {
				gx.dom.purgeElement(document.body);
				gx.dom.purgeElement(gx.dom.form());
				var events = ['onblur', 'onclick', 'onfocus', 'onchange'];
				var formEls = gx.fn.getFormElements();
				for (var i = 0, len = formEls.length; i < len; i++)
					gx.dom.purgeElement(formEls[i], events);
				var spans = gx.dom.byTag('span');
				for (var i = 0, len = spans.length; i < len; i++)
					gx.dom.purgeElement(spans[i], events);
				var imgs = gx.dom.byTag('img');
				for (var i = 0, len = imgs.length; i < len; i++)
					gx.dom.purgeElement(imgs[i], events);
			}
			gx.dom._deinit();
			gx.csv._deinit();
			gx.evt._deinit();
			gx.grid._deinit();
			gx.printing._deinit();
			gx.core.audio._deinit();
			gx.O = null;
			gx.pO = null;
		},

		reinit: function (unloadMasterPage) {
			gx.pO.clean(unloadMasterPage);
			gx.objectUnload(unloadMasterPage);
			gx._init();
		}
	};
})(jQuery);

/* END OF FILE - ..\js\gxapi.js - */
/* START OF FILE - ..\js\plugdesign.js - */
/*global Mustache:true */
/*global jQuery:true */
gx.plugdesign = (function($) {
	var registeredTemplates = {};
	
	var templatesLoaded = false,
		templates,
		class_maps,
		templatesNamesCounter = 1;
	
	var beforePropertyChangeHandlers = {},
		afterPropertyChangeHandlers = {};

	var propertyChangeHandlerBuilder = function (propertyChangeHandlers, setEventCancel) {
		return function (eventObject) {
			var handlers = propertyChangeHandlers[eventObject.property],
				controlHandler;

			if (handlers) {
				controlHandler = handlers[eventObject.control.id];
			}
			if (!controlHandler && handlers) {
				controlHandler = handlers[eventObject.control.name];
			}
			if (controlHandler) {
				var cancel = controlHandler.fn.call(controlHandler.template, eventObject.control, eventObject.value) === true;
				if (setEventCancel) {
					eventObject.cancel = cancel;
					return;
				}
			}
		};
	};
	
	var deferCallback = function (callback) {
		if (window.requestIdleCallback) {
			window.requestIdleCallback(callback);
		}
		else {
			gx.lang.requestAnimationFrame(callback);
		}
	};

	return {
		init:function() {
			gx.plugdesign.initialized = true;
			gx.fx.obs.addObserver('gx.plugdesign.onafterapplytemplate', this, gx.plugdesign.fixBootstrapGridLayout.closure(this));
			gx.fx.obs.addObserver('gx.control.onbeforepropertychange', this, gx.plugdesign.onBeforePropertyChange);
			gx.fx.obs.addObserver('gx.control.onafterpropertychange', this, gx.plugdesign.onAfterPropertyChange);
			return gx.plugdesign.applyTemplateObject();
		},

		deinit:function() {
			gx.fx.obs.deleteObserver('gx.control.onbeforepropertychange', this, gx.plugdesign.onBeforePropertyChange);
			gx.fx.obs.deleteObserver('gx.control.onafterpropertychange', this, gx.plugdesign.onAfterPropertyChange);
			gx.plugdesign.initialized = false;
			delete gx.runtimeTemplates;
		},

		onBeforePropertyChange: propertyChangeHandlerBuilder(beforePropertyChangeHandlers, true),

		onAfterPropertyChange: propertyChangeHandlerBuilder(afterPropertyChangeHandlers, false),

		registerTemplate:function( t) {
			registeredTemplates[t.name] = t;
		},

		unRegisterTemplate:function( templateName) {
			delete registeredTemplates[templateName];
			var templates = gx.plugdesign.definition.templates;
			gx.plugdesign.definition.templates = $.grep(templates, function(value) {
				return value !== templateName;
			});
		},

		getDOMContext:function(el, context, outerHTML, innerHTML, setContextFn, text) {
			var i, att, len;

			context = {};
			if (text) {
				context.text = $(el).text();
			}
			for (i = 0, len = el.attributes.length; i < len; i++) {
				att = el.attributes[i];
				context[att.name] = att.value;
			}
			context.el = el;
			if (outerHTML) {
				context.outerHTML = el.outerHTML;
			}
			if (innerHTML) {
				context.innerHTML = el.innerHTML;
			}
			if (setContextFn) {
				context = setContextFn.call(this, context, el) || context;
			}
			return context;
		},
		
		assingUserAPI:function(t, el) {
			el.fnc_isRO = t.fnc_isRO;
		},

		getElements: function (t, selector, excluded, opts) {
			opts = opts || {};
			var $elements;
			

			if (typeof t.selector == "function")
			{
				$elements = t.selector(!selector ? "" : selector);
			}
			else
			{
				if (selector && !t.global) {
					$elements = $(selector).find(t.selector);
				}
				else {
					$elements = $(t.selector);
				}
			}

			if (excluded) {
				return $elements.not(excluded);
			}
			return $elements;
		},
		
		shouldApplyOnElement: function (el, t) {
			if (typeof t.selector == "function") {
				return this.getElements(t).is(el);
			}
			else {
				return $(el).is(t.selector);
			}
		},

		applyTemplateOnElement: function (t, el, checkInclusion) {
			var deferred = $.Deferred();
			deferCallback((function () {
				if (typeof t == "string") {
					t = registeredTemplates[t];
					if (!t)
						return;
				}
				if ((checkInclusion === true) && !this.shouldApplyOnElement(el, t)) {
					return;
				}
				var context = gx.plugdesign.getDOMContext(el, context, t.outerHTML, t.innerHTML, t.setContext);
				t.apply(el, context);
				if (t.initialize) {
					t.initialize(context);
				}

				if (t.listeners) {
					var listeners = t.listeners,
						prop;
					var controlId = (typeof listeners.control == "function") ? listeners.control(context) : listeners.control;

					if (listeners.before) {
						for (prop in listeners.before) {
							if (listeners.before.hasOwnProperty(prop)) {
								if (!beforePropertyChangeHandlers[prop]) {
									beforePropertyChangeHandlers[prop] = {};
								}
								beforePropertyChangeHandlers[prop][controlId] = {
									id: controlId,
									fn: listeners.before[prop],
									template: t
								};
							}
						}
					}
					if (listeners.after) {
						for (prop in listeners.after) {
							if (listeners.after.hasOwnProperty(prop)) {
								if (!afterPropertyChangeHandlers[prop]) {
									afterPropertyChangeHandlers[prop] = {};
								}
								afterPropertyChangeHandlers[prop][controlId] = {
									id: controlId,
									fn: listeners.after[prop],
									template: t
								};
							}
						}
					}
				}
				deferred.resolve();
			}).closure(this));
			return deferred;
		},

		applyTemplateSelection: function (t, selector, excluded, opts) {
			var deferred = $.Deferred();
			var innerDeferreds = [];
			var attrName = "data-gx-tpl-applied-" + t.name, 
				elements = this.getElements(t, selector, excluded, opts);
			if (t.onDemandInvoke !== true && !t.reDraw) {
				elements = elements.not("[" + attrName + "]");
			}
			elements.each(function(i, el) {
				if (el) {
					if (typeof(t.reDraw) == 'function') {
						if (el.getAttribute(attrName) !== null) {
							var context;
							context = gx.plugdesign.getDOMContext(el, context, false, false, t.setContext);
							t.reDraw(context);
						}
						else {
							innerDeferreds.push(gx.plugdesign.applyTemplateOnElement(t, el));
						}
					}
					else {
						innerDeferreds.push(gx.plugdesign.applyTemplateOnElement(t, el));
					}
				}
			});
			$.when.apply($, innerDeferreds).done((function () { 
				if (t.outerHTML) {
					elements = this.getElements(t, selector, excluded, opts);
				}
				elements.attr(attrName, '');
				deferred.resolve();
			}).closure(this));
			return deferred;
		},

		applyClassMapOnElement: function (t, el) {
			var context, i, len;
			if (t.initialize) {
				context = gx.plugdesign.getDOMContext(el, context, false, false, t.setContext);
			}

			if (Array.isArray(t.cssClass)) {
				for (i=0, len=t.cssClass.length; i<len; i++) {
					gx.dom.addClass(el, t.cssClass[i]);
				}
			}
			else {
				gx.dom.addClass(el, t.cssClass);
			}

			if (t.initialize) {
				t.initialize(context);
			}
		},
		

		applyClassSelection: function (t, selector, excluded, opts) {
			var onAfterPropertyChangeFn = function (eventObject) {
				if (eventObject.property == "Class") {
					if (gx.dom.matchesSelector(eventObject.control, t.selector)) {
						gx.plugdesign.applyClassMapOnElement(t, eventObject.control);
					}
				}
			};
			this.getElements(t, selector, excluded, opts).each(function(i, el) {
				if (el) {
					gx.plugdesign.applyClassMapOnElement(t, el);
					gx.plugdesign.assingUserAPI(t, el);
					gx.fx.obs.addObserver('gx.control.onafterpropertychange', this, onAfterPropertyChangeFn, { unique: false });
				}
			});
		},

		controlValueChanged:function(ctrl, value) {
			if (ctrl) {
				gx.fx.obs.notify("gx.control.onafterpropertychange", [{
								control: ctrl,
								property: "Value",
								value: value
				}]);
			}
		},

		applyControlValue:function(ctrl, value) {
			// TODO: Este metodo debe pasar al api de gx
			gx.fn.setControlValue( ctrl.id, value);
			gx.html.onchange(ctrl, value);
		},

		applyTemplates: function (templates, selector, excluded, templateSelector, opts) {
			opts = opts || {};
			var deferred = $.Deferred();
			if (templates.length === 0) {
				return deferred.resolve();
			}

			var arrDeferreds = $.map(templates, function( t) {
				var inner_deferred = $.Deferred();
				if (typeof t == "string") {
					t = registeredTemplates[t];
				}
				else {
					t.name = t.name || ('auto-generated-' + templatesNamesCounter++);
					t = new gx.plugdesign.Template(t);
				}
				if ( !templateSelector || ((typeof templateSelector == "function") && templateSelector(t))) {
					var applyTemplateFn = function() {
						gx.plugdesign.applyTemplateSelection(t, selector, excluded, opts).done(function () {
							inner_deferred.resolve();
						});
					};
					if (opts.deferred === true) {
						deferCallback(applyTemplateFn);
					}
					else {
						applyTemplateFn();
						inner_deferred.resolve();
					}
				}
				else {
					inner_deferred.resolve();
				}
				return inner_deferred;
			});
			if (opts.deferred === true) {
				$.when.apply($, arrDeferreds).done(function () {
					deferred.resolve();
				});
			}
			else {
				deferred.resolve();
			}
			return deferred;
		},
		
		applyClassMaps: function (class_maps, selector, excluded, classMapSelector, opts) {
			var deferred = $.Deferred(),
				classMapsApplyFn = function(i, m) {
					gx.plugdesign.applyClassSelection(m, selector, excluded, opts);
				},
				applyClassMapFn = function() {
					class_maps = $.grep(class_maps, classMapSelector || gx.trueFn);
					$.each(class_maps, classMapsApplyFn);
					deferred.resolve();
				};
			deferCallback(applyClassMapFn);
			return deferred;
		},

		applyTemplateObject: function(opts) {
			opts = opts || {};
			var selector = opts.selector,
				excluded = opts.excluded, 
				templateSelector = opts.templateSelector,
				classMapSelector = opts.classMapSelector,
				deferred = $.Deferred(),
				deferred_map,
				deferred_apply,
				deferred_g = $.Deferred();

			
			templateSelector = templateSelector || function(t) { return t.onDemandInvoke !== true;};
			
			
			if (!gx.runtimeTemplates || !gx.plugdesign.initialized)
				return deferred.resolve().promise();

			if (!templatesLoaded) {
				var definition = gx.plugdesign.definition;
				if (definition.css) {
					$.each(definition.css, function(i, css) {
						gx.http.loadStyle(gx.util.resourceUrl(gx.basePath + gx.staticDirectory + css + '?' + gx.gxBuild, false), false, true); 
					});
				}
				var ajs = [];
				if (definition.js) {
					$.each(definition.js, function(i, js) {
						ajs.push(gx.util.resourceUrl(gx.basePath + gx.staticDirectory + js + '?' + gx.gxBuild, false))
					});
				}
				var oldJQuery = jQuery;
				jQuery = gx.$;
				gx.http.loadScripts(ajs, (function() {
					templatesLoaded = true;
					templates = definition.templates || [];
					class_maps = definition.class_maps || [];
					deferred_apply = this.applyTemplates(templates, selector, excluded, templateSelector, opts);
					deferred_map = this.applyClassMaps(class_maps, selector, excluded, undefined, opts);
					jQuery = oldJQuery;
					deferred.resolve();
				}).closure(this));
			}
			else {
				deferred_apply = this.applyTemplates(templates, selector, excluded, templateSelector, opts);
				deferred_map = this.applyClassMaps(class_maps, selector, excluded, classMapSelector, opts);
				deferred.resolve();
			}
			$.when.apply($, [deferred, deferred_apply, deferred_map]).done(function () { 
				gx.fx.obs.notify('gx.plugdesign.onafterapplytemplate', [opts]); 
				deferred_g.resolve();
			});
			return deferred_g.promise();
		},

		fixBootstrapGridLayout: function() {
			if ($('.container-fluid, .container').length === 0) {
				$('.row').first().parent().toggleClass('container-fluid', true);				
			}			
		},
		
		/**
		* @class gx.plugdesign.Template
		* Base class for creating Templates to be applied in runtime, to change and enhance GeneXus controls
		*/
		Template: (function () {
			var template = function (opts) {
				var compiledTemplate,
					templateElements = [];

				opts = opts || {};
				if (!opts.name) {
					gx.dbg.write("A name must be specified", true);
					return;
				}
				if (!opts.selector) {
					gx.dbg.write("A selector must be specified", true);
					return;
				}
				if (opts.listeners) {
					var listeners = opts.listeners;
					if (!listeners.control && (listeners.before || listeners.after)) {
						gx.dbg.write("If a visible or enabled handler is specified, a control must be specified too", true);
						return;
					}
				}
				
				this.preProcessTemplate = function () {
					var template = this.template,
						regex = /\{\{\$(\w+)\$\}\}/g,
						matches,
						i = 0;
						
					templateElements = [];
					while ((matches = regex.exec(template)) !== null) {
						templateElements[i] = matches[1];
						template = template.replace(matches[0], '<span id="hook_' + i + '"></span>');
						i++;
					}

					return template;
				};
				
				this.postProcessTemplate = function (context) {
					var i,
						len,
						replacement,
						$hookEl;
					if (templateElements) {
						for (i = 0, len=templateElements.length; i<len; i++) {
							replacement = context[templateElements[i]];
							$hookEl = $("#hook_" + i);
							if (replacement) {
								$hookEl.after(replacement);
							}
							$hookEl.remove();
						}
					}
				};
				
				this.apply = function (el, context) {
					var t = this,
						outputHtml,
						isIE = gx.util.browser.isIE(),
						restoreFocus = false;

					if (!compiledTemplate && t.template)
					{
						compiledTemplate = t.preProcessTemplate();
						Mustache.parse(compiledTemplate);
					}
					if (compiledTemplate) {
						outputHtml = Mustache.render(compiledTemplate, context);
						if (t.applyTo == "inner") {
							// This is a WA for IE, because of this bug: https://developer.microsoft.com/en-us/microsoft-edge/platform/issues/110959/
							if (isIE) {
								while (el.firstChild) {
									el.removeChild(el.firstChild);
								}
							}
							el.innerHTML = outputHtml;
						}
						else {
							restoreFocus = (el === document.activeElement);
							if (el.parentNode && !isIE)
								el.outerHTML = outputHtml;
							else 
								$(el).replaceWith(outputHtml);
						}
						t.postProcessTemplate(context);
						if (restoreFocus) {
							gx.fn.setFocus(el);
						}
					}
				};
				
				gx.lang.apply(this, opts);
				return this;
			};

			template.prototype = {
				/**
				* @property {String}
				* Template name, used to reference the template from de gxtemplate.json file (required)
				*/
				name: "",
				/**
				* @property {String}{Function}
				* A valid JQuery selector or function, used to match the elements that will be transformed with the template (required).
				*/
				selector: "",
				/**
				* @property {String}
				* An extended Mustache template that will be used to replace the matched elements. The template will be applied to replace each matched element.
				* A default context object is created with all the attributes of the matched element. For example, given a matched element like 
				*		<a href="http://www.genexus.com" target="_blank" id="some-id">Hello</a>
				* The context object will look like this:
				*		{
				*			href: "http://www.genexus.com",
				*			target: "_blank",
				*			id: "some-id"
				*		}
				* 
				* DOM elements or jQuery objects in the context can be referenced from the template, using the following Mustache extended syntax: {{$context_member$}}.
				* For example, if the context has a property called field referencing a DOM element, it can be specified in the template like this:
				*
				* <div id="id_{{id}}">{{$field$}}</div>
				*
				* It supports specifying the same type of input as the jQuery replaceWith() method (see: http://api.jquery.com/?s=replaceWith).
				*
				*/
				template: "",
				/**
				* @property {String} [applyTo="outer"]
				* Set to 'outer' if you want the HTML to be applied to the matched elements outerHTML. Set to 'inner' to apply the HTML to the matched elements innerHTML.
				*/
				applyTo: "outer",
				/**
				* @property {Boolean}
				* Set to true if you want to add the the matched element's outerHTML set as a context property.
				*/
				outerHTML: false,
				/**
				* @property {Boolean}
				* Set to true if you want to add the the matched element's innerHTML set as a context property.
				*/
				innerHTML: false,
				/**
				* @property {Boolean}
				* Set to true if you want the selector to be always applied globally. In some cases, the templates are only applied to 
				* the children elements of a given element, for example, when a grid is redrawn, the templates are only applied inside the grid.
				*/
				global: false,
				/**
				* @property {Boolean}
				* Set to true if you want invoke this template onDemand. onDemandInvoke template can be applied using a templateSelector. See function gx.plugdesign.applyTemplateObject.
				* By default tamplates are triggered automatically as needed.
				*/
				onDemandInvoke: false,
				/**
				* @property {Function}
				* An optional function that enables you to change the default context or even create a new one. This function is called 
				* after creating the deafult context and before applying the template. To create a new context, the function must return a new object.
				* @param setContext.context The deafult context.
				* @param setContext.el The matched element.
				*/
				setContext: gx.emptyFn,
				/**
				* @property {Function}
				* An optional function that is called after applying the template, to let you do some initialization work.
				* @param initialize.context The deafult context.
				*/
				initialize: gx.emptyFn,
				/**
				* @property listeners {Object}
				* A config object containing event handlers that are fired before and after every time a property of the control specified in the control property
				* is changed. The handler functions that are fired before the property change are specified in the listeners.before config object. 
				* If one of these handlers returns false, the default property change behaviour is cancelled.
				* The handler functions that are fired after the property change are specified in the listeners.after config object. 
				* The name of the functions in the listeners.before and listeners.after config object
				* must map with the name of the changed property. For example: Visible, Enabled, Caption, Class (see gx.fn.setCtrlPropertyImpl function for a complete list).
				* @property listeners.control {String}{Function}
				* The id of the control whose events will be handled. A string containing the id or a function that returns id of the control can be specified.
				* @property listeners.before {Object)
				* A config object where the event handlers are specified.
				* @property listeners.before.Property {Function)
				* A function fired before GX standard property change routines. It handles changes made on a property named "Property". If it returns false,
				* the default behaviour is cancelled.
				* @param listeners.before.Property.control {HTMLElement}
				* Control element
				* @param listeners.before.Property.value {Boolean}
				* The value that will be set to the property named "Property" of the control.
				* @property listeners.after {Object)
				* A config object where the event handlers are specified.
				* @property listeners.after.Property {Function)
				* A function fired after GX standard property change routines. It handles changes made on a property named "Property". 
				* @param listeners.after.Property.control {HTMLElement}
				* Control element
				* @param listeners.after.Property.value {Boolean}
				* The value that has been set to the property named "Property" of the control.
				*/
				listeners: {}
			};

			return template;
		})()
	}
})(gx.$);
/* END OF FILE - ..\js\plugdesign.js - */
/* START OF FILE - ..\GenCommon\js\gxtemplate.js - */
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
/* END OF FILE - ..\GenCommon\js\gxtemplate.js - */
/* START OF FILE - ..\js\gxhtml.js - */
gx.html = (function ($) {
	var STYLE_ELEMENT_PATTERN = "<style[^>]*>([\\s\\S]*?)<\/style>",
		STYLE_ELEMENT_REGEX = new RegExp(STYLE_ELEMENT_PATTERN, "i"),
		STYLE_ELEMENT_REGEX_GLOBAL = new RegExp(STYLE_ELEMENT_PATTERN, "ig"),
		LINK_ELEMENT_FAVICON = "<link ([^>]*rel=['\"]?shortcut icon['\"]?[^>]*)>",
		LINK_ELEMENT_PATTERN = "<link ([^>]*rel=['\"]?stylesheet['\"]?[^>]*)>",
		LINK_ELEMENT_REGEX = new RegExp(LINK_ELEMENT_PATTERN, "i"),
		LINK_ELEMENT_FAVICON_REGEX = new RegExp(LINK_ELEMENT_FAVICON, "i"),
		LINK_ELEMENT_REGEX_GLOBAL = new RegExp(LINK_ELEMENT_PATTERN, "ig"),
		SCRIPT_ELEMENT_PATTERN = "<script([^>]*)>([\\s\\S]*?)<\/script>",

		SCRIPT_N_NESTED_ELEMENT_PATTERN = "<script([^>]*)>(([\\s\\S]*?<script[^>]*>[\\s\\S]*?<.?\/script>[\\s\\S]*?){X})<.?\/script>",
		SCRIPT_NESTED_ELEMENT_PATTERN = "<script[^>]*>[\\s\\S]*?(<script[^>]*>[\\s\\S]*?<.?\/script>)",
		SCRIPT_NESTED_ELEMENT_PATTERN_REGEX = new RegExp(SCRIPT_NESTED_ELEMENT_PATTERN, "i"),

		SCRIPT_ELEMENT_REGEX = new RegExp(SCRIPT_ELEMENT_PATTERN, "i"),
		SCRIPT_ELEMENT_IS_EXTERNAL_REGEX = /data-gx-external-script/;
		HREF_ELEMENT_ATT_REGEX = /href=(['"]?)([^'">]*)\1/i,
		ID_ELEMENT_ATT_REGEX = /id=(['"]?)([^'">]*)\1/i,
		SRC_ELEMENT_ATT_REGEX_1 = /src=(['"]?)([\s\S]*)\?([^"']*)\1/i,
		SRC_ELEMENT_ATT_REGEX_2 = /src=(['"]?)([^"']*)\1/i,
		INPUT_GXSTATE_REGEX = /<div><input type="hidden" name="GXState" value="{.*}"><\/div>/g;

	return {
		encodeCaseFormat: function (Value, nFormat, multiline) {
			if ((nFormat == gx.html.controls.formats.TEXT))
				Value = gx.html.encode(Value, false, multiline);
			else if ((nFormat == gx.html.controls.formats.TEXT_W_SPACES))
				Value = gx.html.encode(Value, true, multiline);
			return Value;
		},
		
		applyCustomHTMLAttributes: function( rootEl) {
			var $rootEl =  rootEl ? $(rootEl) : $(document);
			$rootEl.find("input[data-msk-att], textarea[data-msk-att]").each( function(i,el) {
				var $el = $(el),
					attName = $el.attr("data-msk-att");				
				$el.attr( attName, $el.attr("data-"+attName)); 
			});				
		},

		encode: function (Value, encodeWhiteSpace, encodeEnter) {
			var oldChars = ['<', '>', '&'];
			var newChars = ['&lt;', '&gt;', '&amp;'];
			if (encodeWhiteSpace) {
				oldChars.push(' ');
				newChars.push('&nbsp;');
			}
			if (encodeEnter) {
				oldChars.push('\n');
				newChars.push('<br/>');
			}
			return gx.text.charReplace(Value, oldChars, newChars);
		},

		getHidden: function (id, value) {
			return '<input type="hidden" id="' + id + '" name="' + id + '" value="' + value + '">';
		},

		viewportWidth: function () {
			var doc = document.documentElement;
			if (doc && doc.clientHeight)
				return Math.max(doc.clientWidth, document.body.clientWidth);
			else
				return document.body.clientWidth;
		},

		viewportHeight: function () {
			var doc = document.documentElement;
			if (doc && doc.clientHeight)
				return Math.max(doc.clientHeight, document.body.clientHeight) - 5;
			else
				return document.body.clientHeight - 5;
		},

		cleanHtmlRefs: function (html, removeStyles) {
			removeStyles = (removeStyles === undefined || removeStyles);
			if (removeStyles) {
				html = html.replace(STYLE_ELEMENT_REGEX_GLOBAL, '');
			}
			html = html.replace(LINK_ELEMENT_REGEX_GLOBAL, '');

			var match = [];
			while (match) // Remove scripts tags considering nested script tags
			{
				match = html.match(SCRIPT_ELEMENT_REGEX);
				if (!match)
					break;
				else {
					var count = this.nestedScripts(match, html);
					if (count > 0) {
						var SCRIPT_N_NESTED_ELEMENT_PATTERN_REGEX = new RegExp(SCRIPT_N_NESTED_ELEMENT_PATTERN.replace("{X}", "{" + count + "}"), "i");
						match = html.match(SCRIPT_N_NESTED_ELEMENT_PATTERN_REGEX);
					}
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(0, match.index) + html.substring(lastIndex);
				}
			}

			return html;
		},

		setOuterHtml: function (Control, Html) {
			Control.outerHTML = Html;
		},

		setInnerHtml: function (control, html, process, transition, removeStyles) {
			var styles = gx.dom.styles(),
				bodyClassName = gx.GxObject.WEBCOMPONENT_BODY_CLASS_NAME;
			if (gx.dom.shouldPurge())
				gx.dom.purge(control, true);
			var bodyEl = $(control).children("." + bodyClassName).get(0);
			if (!bodyEl && transition) {
				bodyEl = document.createElement('div');
				gx.dom.addClass(bodyEl, bodyClassName);
				gx.dom.addClass(bodyEl, "Form-fx");
				control.appendChild(bodyEl);
			}
			if (transition && gx.pO.fullAjax && bodyEl && gx.dom.hasClass(bodyEl, bodyClassName) && !gx.dom.hasClass(control, 'transitioning')) {
				var tempDiv = document.createElement('div');
				tempDiv.innerHTML = this.cleanHtmlRefs(html, removeStyles);
				gx.dom.replaceWithFx(bodyEl, tempDiv.children[0]);
			}
			else {
				$(control).html(this.cleanHtmlRefs(html, removeStyles));
			}
			if (gx.util.browser.isIE())
				gx.cache.updateStyles(styles, gx.dom.styles());
			if (process == true)
				this.processCode(html, false);
		},

		setInnerText: function (control, text, format, multiline) {
			var $control = $(control);
			if (control.nodeValue != null)
				control.nodeValue = text;
			else if (!gx.util.browser.isChrome() && control.innerText != null)
				control.innerText = text;
			else if (gx.util.browser.isFirefox() || gx.util.browser.isChrome())
				$control.html(gx.html.encodeCaseFormat(text, format, multiline));
			else if (control.tagName == 'TEXT' && control.innerHTML != null)
				$control.html(text);
			else
				$control.html('<text>' + text + '</text>');
		},

		nodesFromText: function (text) {
			var node = document.createElement('div');
			node.style.visibility = 'hidden';
			node.style.display = 'none';
			document.body.appendChild(node);
			if (gx.dom.shouldPurge())
				gx.dom.purge(node, true);
			node.innerHTML = text;
			var nodes = [];
			var len = node.childNodes.length;
			for (var i = 0; i < len; i++) {
				nodes.push(node.childNodes[i].cloneNode(true));
			}
			gx.dom.removeControlSafe(node);
			return nodes;
		},

		onTypeAvailable: function (cName, callback, callbackParms) {
			try {
				var typeObj = eval(gx.gen.resolveObjClass(cName));
				if (callbackParms instanceof Array)
					callback.apply(this, callbackParms);
				else
					callback();
			}
			catch (e) {
				setTimeout(function () { gx.html.onTypeAvailable(cName, callback, callbackParms); }, 150);
			}
		},

		processCSS: function( CSSCode) {
			if (CSSCode != '') {
				// Put styles into html head
				var styleCtrl = document.createElement("style");
				styleCtrl.setAttribute("type", "text/css");
				var domHead = document.getElementsByTagName("head")[0];
				domHead.appendChild(styleCtrl);
				if (styleCtrl.styleSheet)
					styleCtrl.styleSheet.cssText = CSSCode;
				else {
					var textNode = document.createTextNode(CSSCode);
					styleCtrl.appendChild(textNode);
				}
			}
		},

		nestedScripts: function (match, html) {
			var nestedMatch = match[0].match(SCRIPT_NESTED_ELEMENT_PATTERN_REGEX);
			var htmlTemporal = html;
			var count = 0;
			while (nestedMatch) //Contiene un script anidado => calcula total de anidados (solo un nivel de anidacion).
			{
				htmlTemporal = htmlTemporal.replace(nestedMatch[1], '');
				count++;
				match = htmlTemporal.match(SCRIPT_ELEMENT_REGEX);
				if (match)
					nestedMatch = match[0].match(SCRIPT_NESTED_ELEMENT_PATTERN_REGEX);
				else
					nestedMatch = null;
			}
			return count;
		},
		processCode: function (html, avoidEval, callback, callbackParms, cName, moveInlineStyles, ignoreExistingJs) {
			var origHtml = html,
				remoteScripts = [],
				checkTypeLoaded = false,
				scripts = [],
				remoteStyles = [],
				styles = [],
				evalStr = '',
				remoteFilesStr = [],
				match = [];

			moveInlineStyles = (moveInlineStyles === undefined || moveInlineStyles);

			if (html == '')
				return;
			
			if (moveInlineStyles) {
				while (match) // Parse inline styles
				{
					match = html.match(STYLE_ELEMENT_REGEX);
					if (!match)
						break;
					else {
						var lastIndex = match.lastIndex;
						if (!lastIndex)
							lastIndex = match.index + match[0].length;
						html = html.substring(lastIndex);
					}
					styles.push(match[1]);
				}
			}
			html = origHtml;
			match = [];
			while (match) // Parse links to stylesheets
			{
				match = html.match(LINK_ELEMENT_REGEX);
				if (!match)
					break;
				else {
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				attr = match[1].match(HREF_ELEMENT_ATT_REGEX);
				idAttr = match[1].match(ID_ELEMENT_ATT_REGEX);
				if (attr && !gx.cache.fileLoaded(attr[2])) {
					remoteStyles.push({
						href: attr[2],
						id: (idAttr && idAttr.length > 2) ? idAttr[2] : null
					});
					gx.cache.addRemoteFile(attr[2]);
				}
			}
			html = origHtml;
			match = [];
			while (match) // Parse links to favicon
			{
				match = html.match(LINK_ELEMENT_FAVICON_REGEX);
				if (!match)
					break;
				else {
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				$("head link[rel='shortcut icon'").remove();
				$(document.head).append(match[0]);
			}
			html = origHtml.replace(INPUT_GXSTATE_REGEX, '');
			match = [];
			while (match) // Parse scripts
			{
				match = html.match(SCRIPT_ELEMENT_REGEX);
				if (!match)
					break;
				else {
					var count = this.nestedScripts(match, html);
					if (count > 0) {
						var SCRIPT_N_NESTED_ELEMENT_PATTERN_REGEX = new RegExp(SCRIPT_N_NESTED_ELEMENT_PATTERN.replace("{X}", "{" + count + "}"), "i");
						match = html.match(SCRIPT_N_NESTED_ELEMENT_PATTERN_REGEX);
					}
					var lastIndex = match.lastIndex;
					if (!lastIndex)
						lastIndex = match.index + match[0].length;
					html = html.substring(lastIndex);
				}
				if ((match[1] != undefined) && (match[1] != '')) // Remote scripts
				{
					var attr = match[1].match(SRC_ELEMENT_ATT_REGEX_1);
					var isExternal = !!match[1].match(SCRIPT_ELEMENT_IS_EXTERNAL_REGEX);
					if (attr == null)
						attr = match[1].match(SRC_ELEMENT_ATT_REGEX_2);
					if (attr && !gx.cache.fileLoaded(attr[2])) {
						var fullUrl = attr[2];
						if (!gx.lang.emptyObject(attr[3])) {
							fullUrl += '?' + attr[3];
						}
						remoteScripts.push({
							url: fullUrl,
							isExternal: isExternal,
							callback: (isExternal) ? undefined :(function (remoteFile, isExternal) {
								return function () {
									gx.cache.addRemoteFile(remoteFile);
								};
							})(attr[2], isExternal)
						});
					}
					else if (attr && gx.cache.fileLoaded(attr[2])) {
						checkTypeLoaded = true;
					}
					else if (!attr && match[2]) // Inline scripts
						scripts.push(match[2]);
				}
				else if (match[2]) // Inline scripts
					scripts.push(match[2]);
			}
			if (avoidEval == true)
				return;
			//Eval Embedded script before calling async callback
			evalStr = scripts.join(";");

			if (evalStr != '')
				gx.lang.doEval(evalStr); // Evaluate scripts code
			
			if (typeof (callback) == 'function') {
				gx.http.loadScripts(remoteScripts, (function (callback, callbackParms) {
					if (callbackParms instanceof Array)
						callback.apply(this, callbackParms);
					else
						callback();
				}).closure(this, [callback, callbackParms]), undefined, ignoreExistingJs);
			}
			else {
				var getInfo = {};
				getInfo.method = 'GET';
				getInfo.useCash = true;
				getInfo.load = (function (type, scriptStr) {
					gx.lang.supEval(this, remoteFilesStr.push(scriptStr));
				}).closure(this);
				getInfo.mimetype = "text/plain";
				getInfo.sync = true;
				var scrRemoteQty = remoteScripts.length;
				for (var i = 0; i < scrRemoteQty; i++) {
					getInfo.url = remoteScripts[i].url; // GET remote scripts from server
					gx.http.doCall(getInfo);
				}
			}

			evalStr = remoteFilesStr.join("");

			if (evalStr != '')
				gx.lang.doEval(evalStr); // Evaluate scripts code

			var styleCtrls = document.getElementsByTagName("style");
			scrQty = remoteStyles.length;
			for (var i = 0; i < scrQty; i++) {
				var exists = false;
				var stQty = styleCtrls.length;
				for (var j = 0; j < stQty; j++) {
					if (styleCtrls[i]) {
						var cssUrl = (styleCtrls[j].styleSheet && styleCtrls[j].styleSheet.cssText) ? styleCtrls[j].styleSheet.cssText : styleCtrls[j].innerHTML;
						if (remoteStyles[i].href == cssUrl)
							exists = true;
					}
				}
				if (!exists) {
					var styleEl = gx.dom.byId(remoteStyles[i].id);
					if (styleEl) {
						styleEl.href = remoteStyles[i].href;
					}
					else {
						gx.http.loadStyle(remoteStyles[i].href, gx.emptyFn, false, remoteStyles[i].id); // GET remote stylesheets from server
					}
				}
			}

			evalStr = styles.join("");

			gx.html.processCSS( evalStr);
			if ((scrRemoteQty == 0) && (typeof (callback) == 'function')) {
				if (checkTypeLoaded && cName)
					gx.html.onTypeAvailable(cName, callback, callbackParms);
				else
					if (callbackParms instanceof Array)
						callback.apply(this, callbackParms);
					else
						callback();
			}
		},

		getFieldLabel: function (field, scope) {
			var label,
				labelFor,
				id = field.id,
				previousSibling = field.previousSibling;

			// Check optimistically if the previous sibling is in fact the label
			// If not, try a DOM query using the for attribute in the selector.
			if (previousSibling 
				&& previousSibling.tagName === "LABEL"
				&& previousSibling.htmlFor === id) {
					labelEl = previousSibling;
			}
			else {
			if (field.tagName == "INPUT" || field.tagName == "SELECT" || field.tagName == "TEXTAREA") {
				labelFor = field.id;
			}
			else if (field.tagName == "SPAN") {
				labelFor = $(field).attr('data-gx-enabled-id');
				if (!labelFor && id.indexOf("span_")  === 0) {
					labelFor = id.substring(5);
				}
			}
			else if (gx.dom.hasClass(field, gx.uc.gxCssClass)) {
				labelFor = gx.uc.CtrlId(field.id);
			}
			if (gx.dom.hasClass(field, gx.html.multimediaUpload.gxCssClass)) {
				labelFor = gx.html.multimediaUpload.CtrlId(field.id);
			}

			if (labelFor) {
				return $("label[for='" + labelFor + "']", scope).get(0);
				}
			}
		},

		multimediaUpload: {
			gxCssClass:'gx-multimedia-upload',
			
			getInputFileEl: function(id) {
				return $("#" + id + "[type='file']")[0];
			},
			
			CtrlId: function (ContainerId) {
				return ContainerId.replace(/_ct$/, '');
			},
			
			resolveFileName: function(file, uri) {
				return file || uri || "";
			},

			onOptionChange: function (el) {
				var elements = this.getElements(el),
					uriOpt = elements.uriOption,
					file = elements.fileField,
					uri = elements.uriField;

				if (uriOpt.checked) {
					gx.dom.removeClass(file, "field-selected");
					gx.dom.addClass(uri, "field-selected");
				}
				else {
					gx.dom.removeClass(uri, "field-selected");
					gx.dom.addClass(file, "field-selected");
				}
			},

			imageLoadHandler: function (prevImg, prevLink) {
				var isEmpty = function (el) {
					var att = el.tagName == 'IMG' ? 'src' : 'href';
					return (!el[att] || el[att] == document.location.href || el[att].charAt(el[att].length - 1) == '/')
				};
				gx.dom.removeClass(prevLink, "gx-multimedia-unknown");
				gx.dom.removeClass(prevLink, "gx-multimedia-download");
				if (!prevImg || isEmpty(prevImg))
					gx.dom.addClass(prevLink, "gx-multimedia-empty");
				else
					gx.dom.removeClass(prevLink, "gx-multimedia-empty");

				if (isEmpty(prevImg) && prevLink && !isEmpty(prevLink)) {
					gx.dom.removeClass(prevLink, "gx-multimedia-empty");
					if (prevImg.tagName !== 'IMG' || isEmpty(prevImg))
						gx.dom.addClass(prevLink, "gx-multimedia-download");
				}

				if (gx.util.browser.isIE()) {
					if (prevImg && prevImg.tagName == 'IMG') {
						var jPrevImg = $(prevImg);
						var maxWidth = parseInt(jPrevImg.css('maxWidth'));
						var maxHeight = parseInt(jPrevImg.css('maxHeight'));
						if (maxWidth < prevImg.width) {
							jPrevImg.css('height', gx.dom.addUnits(maxWidth * prevImg.height / prevImg.width));
							jPrevImg.css('width', gx.dom.addUnits(maxWidth));
						}
						
						if (maxHeight < prevImg.height) {
							jPrevImg.css('width', gx.dom.addUnits(maxHeight * prevImg.width / prevImg.height));
							jPrevImg.css('height', gx.dom.addUnits(maxHeight));
						}
					}
				}
			},

			dialogCloseHandler: function (el, fieldsCt, btn) {
				var elements = this.getElements(el);

				fieldsCt.style.display = 'none';
				el.appendChild(fieldsCt);

				if (elements.uriOption.checked) {
					this.refreshPreviewImg(el, elements.uriField);
				}
				else {
					this.refreshPreviewImg(el, elements.fileField);
				}
			
				elements.action.focus();
				gx.fx.obs.deleteObserver('gx.keypress', this, this.keypressHandler);
			},

			prevImgClickHandler: function (evt, el) {
				evt = evt || event;
				var target = gx.evt.source(evt);

				if ($(target).closest(".gx-multimedia-empty").length > 0) {
					this.actionClickHandler(evt, el);
				}
			},

			actionClickHandler: function (evt, el) {
				var isModal = gx.html.multimediaUpload.isModal;

				evt = evt || event;
				if (evt.preventDefault)
					evt.preventDefault();
				else
					evt.returnValue = false;

				var elements = this.getElements(el),
					btn = elements.button;
				elements.fieldsCt.style.display = 'block';

				var height = 130,
					width = 500,
					resizable = true;
				if (gx.util.browser.isIE() && gx.util.browser.isCompatMode()) {
					el.style.position = 'static';
					elements.fileField.style.marginTop = '0';
					elements.uriField.style.marginTop = '0';
					height = 230;
				}

				if (gx.runtimeTemplates) {
					resizable = false;
					if ($(window).width() < width) {
						width = $(window).width() - 20;
						height = 170;
					}
				}

				var dialog = gx.popup.openDialog({
					parentElement: el,
					w: width,
					h: height,
					contentHtml: elements.fieldsCt,
					title: "",
					showParentPopups: false,
					showCloseButton: true,
					resizable: resizable,
					isModal: isModal === undefined || isModal,
					callbacks: {
						beforeClose: this.dialogCloseHandler.closure(this, [el, elements.fieldsCt, btn])
					}
				});

				elements.fileOption.focus();
				gx.evt.attach(btn, 'click', dialog.close, dialog, { single: true});
				gx.fx.obs.addObserver('gx.keypress', this, this.keypressHandler);
			},

			clearActionHandler: function (evt, el) {
				evt = evt || event;
				if (evt.preventDefault)
					evt.preventDefault();
				else
					evt.returnValue = false;

				var elements = this.getElements(el);
				elements.uriField.value = "";
				elements.fileField.value = "";
				elements.uriOption.checked = false;
				elements.fileOption.checked = true;

				gx.fx.obs.notify('gx.multimedia.clear', [el]);

				this.clearPreviewImg(el);
				this.imageLoadHandler(elements.previewImg, elements.previewLink);
			},
		
			keypressHandler: function(eventObject){
				var evt = eventObject.event;
				if (evt.keyCode == 13)
				{
					eventObject.cancel = true;
					gx.popup.currentPopup.close();
				}
			},

			tapHandler: function (el) {
				var elements = this.getElements(el);
				elements.action.focus();
			},

			getElements: function (el) {
				el = gx.dom.byId(el);
				var $el = $(el),
					action = $el.find('.change-action')[0],
					clearAction = $el.find('.clear-action')[0],
					previewLink = null,
					prevImg = $(clearAction).next()[0],
					$fieldsCt = $el.find('.fields-ct');

				if (prevImg.tagName == "A") {
					previewLink = prevImg;
					prevImg = prevImg.firstChild;
				}
				else if (prevImg.tagName != "IMG") {
					prevImg = null;
				}

				return {
					previewLink: previewLink,
					action: action,
					clearAction: clearAction,
					previewImg: prevImg,
					fieldsCt: $fieldsCt[0],
					uriField: $fieldsCt.find("input[type='text']")[0],
					fileField: $fieldsCt.find("input[type='file']")[0],
					uriOption: $fieldsCt.find("input[type='radio'][value='uri']")[0],
					fileOption: $fieldsCt.find("input[type='radio'][value='file']")[0],
					button: $fieldsCt.find("input[type='button']")[0]
				};
			},

			getContainer: function (el) {
				var parent = gx.dom.byId(el);
				while (parent) {
					if (gx.dom.hasClass(parent, gx.html.multimediaUpload.gxCssClass))
						return parent;
					parent = parent.parentNode;
				}
				return null;
			},

			setPreviewImage: function (el, link) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);

				var parsedUrl = gx.util.Url.parseWithAnchor(link);
				if (parsedUrl.protocol.search(/^https?:/) < 0 && elements.uriOption.checked)
					return;
				this.clearPreviewImg(el);
				if (elements.previewImg && gx.text.startsWith(gx.util.getContentTypeFromExt(link), "image")) {
					if (elements.previewImg.tagName == 'IMG')
						elements.previewImg.src = link;
					this.imageLoadHandler(elements.previewImg, elements.previewLink);
				}
			},

			setPreviewLink: function (el, link) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);
				if (elements.previewLink) {
					if (link && elements.previewLink)
						elements.previewLink.href = link;				
				}
				this.imageLoadHandler(elements.previewImg, elements.previewLink);
			},

			clearPreviewImg: function (el) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);

				if (elements && elements.previewImg && elements.previewLink) {
					elements.previewImg.src = "";
					elements.previewLink.href = "";
				}
			},

			refreshPreviewImg: function (el, input) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);

				if (elements.previewImg) {
					if (input.tagName == 'INPUT') {
						if (input == elements.fileField) {
							var file;
							if (input.files) {
								file = input.files[0];
								if (file) {
									if (file.type.match(/image.*/)) {
										var reader = new FileReader();
										reader.onload = (function (e, aImg, aLink) {
											aImg.src = e.target.result;
											aLink.href = e.target.result;
										}).closure(this, [elements.previewImg, elements.previewLink], true);
										reader.readAsDataURL(file);
									}
									else {
										elements.previewLink.href = "#";
										elements.previewLink.className = 'gx-multimedia-download';
										this.clearPreviewImg(el);
										return;
									}
								}
							}
							if (input.gxctrldeleted) {
								this.clearPreviewImg(el);
							}
						}
						else if (input == elements.uriField) {
							elements.previewImg.src = input.value;
							elements.previewLink.href = input.value;
						}
						this.imageLoadHandler(elements.previewImg, elements.previewLink);
					}
				}
			},

			setType: function (el, isBlob) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);

				elements.fileOption.checked = isBlob;
				elements.uriOption.checked = !isBlob;
				if (isBlob)
					elements.uriField.value = "";

				this.onOptionChange(el);
			},

			getOptionValue: function (el) {
				el = gx.dom.byId(el);
				var elements = this.getElements(el);
				return (elements.fileOption.checked) ? "file" : "uri";
			},

			createControl: function (el) {
				el = gx.dom.byId(el);

				if (!el._created) {
					el._created = true;

					var elements = this.getElements(el);
					gx.dom.addClass(elements.fileField, "field-selected");
					elements.action.setAttribute("gxfocusable", '1');

					var btn = document.createElement('input');
					btn.type = 'button';
					btn.className = 'BtnEnter';
					btn.value = gx.getMessage('GXM_uploadconfirmoption');
					elements.fieldsCt.appendChild(btn);

					var imageLoadHandler = this.imageLoadHandler.closure(this, [elements.previewImg, elements.previewLink]);

					var optionChangeHandler = this.onOptionChange.closure(this, [el]);

					imageLoadHandler();
					if (elements.previewImg)
						gx.evt.attach(elements.previewImg, 'load', imageLoadHandler);
					optionChangeHandler();
					gx.evt.attach(elements.uriOption, 'click', optionChangeHandler);
					gx.evt.attach(elements.fileOption, 'click', optionChangeHandler);
					gx.evt.attach(elements.action, 'click', this.actionClickHandler.closure(this, [el], true));
					gx.evt.attach(elements.previewImg.parentNode, 'click', this.prevImgClickHandler.closure(this, [el], true));
					gx.evt.attach(elements.clearAction, 'click', this.clearActionHandler.closure(this, [el], true));
					gx.evt.attach(el, 'touchstart', this.tapHandler.closure(this, [el]));
				}
			}
		},

		controls: (function () {
			var inputRadioTemplate = 	'<label for="{{itemId}}">' + 
											'<input type="radio" ' +
												'id="{{itemId}}" ' + 
												'name="{{id}}" ' + 
												'value="{{itemValue}}" ' + 
												'title="{{title}}"' + 
												'data-gxoch0="{{data-gxoch0}}"' + 
												'{{#isSelected}} checked{{/isSelected}}' + 
												'{{#isDisabled}} disabled{{/isDisabled}}' + 
												'{{{extraAttributes}}}>' +
											'{{itemDesc}}' +
										'</label>';

			var templates = {},
				templatesSource = {
					'label': '<label class="gx-label {{className}} control-label" {{{additionalAtts}}} for="{{relatedElement}}">{{caption}}</label>',
					'radio': [
						'<span class="{{className}}" style="{{style}}">',
						'{{#values}}',
							inputRadioTemplate,
						'{{/values}}',
						'</span>'
					]
				},
				applyTemplate = function (name, context) {
					var source = gx.lang.isArray(templatesSource[name]) ? templatesSource[name].join("") : templatesSource[name];
					if (!templates[name]) {
						templates[name] = true;
						Mustache.parse(source);
					}
					return Mustache.render(source, context);
				};

			var TAG_ATT_REGEX = /\"/g;

			return {
				applyTemplate: applyTemplate,
				types: {
					singleLineEdit: 1,
					multipleLineEdit: 2,
					blob: 3,
					radio: 4,
					comboBox: 5,
					listBox: 6,
					checkBox: 7,
					image: 8,
					textBlock: 9,
					button: 10,
					grid: 11,
					userControl: 12,
					userControlContainer: 13,
					webComponent: 14,
					embeddedPage: 15,
					table: 16,
					row: 17,
					cell: 18,
					group: 19,
					multimedia: 20,
					video: 21,
					audio: 22,
					div: 23,
					responsiveRow: 24,
					responsiveCell: 25,
					label: 26,
					divEnd: 27,
					formGroup: 28,
					formGroupEnd: 29
				},

				formats: {
					TEXT: 0,
					HTML: 1,
					RAW_HTML: 2,
					TEXT_W_SPACES: 3
				},

				isMultiSelection: function (ctrlType) {
					if (ctrlType == 'combo' || ctrlType == 'dyncombo'
						|| ctrlType == 'listbx' || ctrlType == 'dynlistbx') {
						return true;
					}
					return false;
				},

				eventJSCode: function (jsScrCode, eventName, jsDynCode, gridObj, rowObj) {
					var sEventJsCode = '';
					if (jsScrCode == 4 && jsDynCode)
						sEventJsCode = jsDynCode;
					else if (jsScrCode == 1)
						sEventJsCode = 'gx.fn.closeWindow();';
					else if (jsScrCode == 7) {
						var gridInfo = '';
						if (gridObj && rowObj)
							gridInfo = ',\'' + gridObj.gridName + '\',\'' + rowObj.gxId + '\'';
						sEventJsCode = 'gx.evt.execCliEvt( ' + eventName + gridInfo + ',this);';
					}
					else if (jsScrCode == 6 || jsScrCode == 5)
						sEventJsCode = "gx.evt.execEvt(" + eventName + ",this," + gridObj.gridId + ");";
					return sEventJsCode;
				},

				onJsEventAttributes: function (nJScriptCode, sGXOnClickCode, sUserOnClickCode) {
					var gxObject = gx.GxObject,
						eventAttribute = ' ' + gxObject.GX_EVENT_DATA_ATTR + '="' + nJScriptCode + '"';
						scriptAttribute = "";
					if (nJScriptCode === 4) {
						scriptAttribute = ' ' + gxObject.GX_EVENT_CODE_DATA_ATTR + '="' + nJScriptCode + '"';
					}
					if (sUserOnClickCode) {
						if (sGXOnClickCode)
							eventAttribute += " " + gxObject.GX_EVENT_CONDITION_DATA_ATTR + '="' +  sUserOnClickCode + '"' + scriptAttribute;
						else
							eventAttribute += scriptAttribute;
					}
					else {
						if (sGXOnClickCode)
							eventAttribute += scriptAttribute;
					}
					return eventAttribute + ' ';
				},
				startAnchor: function (parentCtrl, nJScriptCode, sGXOnClickCode, sUserOnClickCode, sLinkURL, sLinkTarget, sClassName) {
					var classAttribute = sClassName ? ' class="' + sClassName + '"' : "",
						gxObject = gx.GxObject,
						eventAttribute = this.onJsEventAttributes( nJScriptCode, sGXOnClickCode, sUserOnClickCode);
					if (sUserOnClickCode) {
						parentCtrl.append('<a href="#"' + eventAttribute + classAttribute + '>');
					}
					else {
						if (sGXOnClickCode)
							parentCtrl.append('<a href="#"' + eventAttribute + classAttribute + '>');
						else {
							if (sLinkURL) {
								var safeLink = sLinkURL.replace(/(\\")/ig, '\\u0022');
								parentCtrl.append('<a href="' + safeLink + '"');
								if (sLinkTarget != '')
									parentCtrl.append(' target="' + sLinkTarget + '"');
								parentCtrl.append(classAttribute + '>');
							}
						}
					}
				},

				endAnchor: function (parentCtrl, sGXOnClickCode, sUserOnClickCode, sLinkURL) {
					if (sGXOnClickCode || sUserOnClickCode || sLinkURL)
						parentCtrl.append('</a>');
				},

				onJSEvent_impl: function (sEventName, sEventJsCode, sUserOnClickCode) {
					var buffer = [];
					if (sUserOnClickCode != '')
						buffer.push('jsevent="' + sUserOnClickCode + '" ');
					buffer.push(sEventName + '="if( ');
					if (sEventJsCode != '')
						buffer.push('gx.evt.jsEvent(this)) {' + sEventJsCode + '} else return false;"');
					else
						buffer.push('!gx.evt.jsEvent(this)) return false;"');

					return buffer.join("");
				},
				
				onJSEvent: function (parentCtrl, sEventName, sEventJsCode, sUserOnClickCode) {
					parentCtrl.append(' ');
					parentCtrl.append(this.onJSEvent_impl(sEventName, sEventJsCode, sUserOnClickCode));
				},

				htmlControl: function (id, width, height, cssClass, title) {
					this.id = id || '';
					this.width = width || 0;
					this.widthUnit = 'px';
					this.height = height || 0;
					this.heightUnit = 'px';
					this.cssClass = cssClass || '';
					this.roClass = '';
					this.ownCssClass = '';
					this.style = '';
					this.title = title || '';
					this.value = '';
					this.type = -1;
					this.dataType = '';
					this.visible = true;
					this.enabled = true;
					this.rtEnabled = false;
					this.link = '';
					this.linkTarget = '';
					this.jsEvent = '';
					this.hasJsLink = false;
					this.extraAttributes = '';
					this.grid = null;
					this.row = null;
					this.column = null;
					this.gridId = '';
					this.gridRow = '';
					this.buffer = new gx.text.stringBuffer();
					
					this.getHtml = function () {
						this.buffer.clear();
						this._getHtml();
						return this.buffer.toString();
					}

					this.append = function (value) {
						return this.buffer.append(value);
					}

					this.tagAtt = function (name, value) {
						value = value.toString();
						value = (value.indexOf('"') >= 0) ? value.replace(TAG_ATT_REGEX, '&quot;') : value;
						return this.buffer.append(' ' + name + '="' + value + '"');
					}

					this.persistValue = function () {
						var vStruct = this.getVStruct();
						if (!gx.lang.emptyNum(this.column.gxId) && vStruct) {
							if (this._persistValue)
								this._persistValue();
							else {
								if (vStruct.v2v)
									vStruct.v2v(this.value);
							}
						}
					}

					this.setIndividualProp = function (ptyName, ptyValue) {
						if (ptyName == 'enabled' || ptyName == 'visible' || ptyName == 'isPassword' || ptyName == 'autoComplete' || ptyName == 'hasJsLink')
							this[ptyName] = gx.lang.gxBoolean(ptyValue);
						else
							this[ptyName] = ptyValue;
					}

					this.setGridData = function (data) {
						this.grid = data.grid;
						this.row = data.row;
						this.gridId = data.gridId;
						this.gridRow = data.gridRow;
					}

					this.getGridData = function () {
						return {
							grid: this.grid,
							row: this.row,
							gridId: this.gridId,
							gridRow: this.gridRow
						};
					};

					this.getVStruct = function () {
						return this.grid.parentObject.GXValidFnc[this.column.gxId];
					};

					this.getEventContext = function () {
						var gxO = this.grid.parentObject;
						return gx.json.serializeJson([gxO.CmpContext, gxO.IsMasterPage]);
					};
				},

				singleLineEdit: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.singleLineEdit;
					this.maxLength = '';
					this.isPassword = false;
					//this.valueIndex = 1;
					this.setProperties = function (sCtrlName, sFormatedValue, sTags, sEventName, sLinkURL, sLinkTarget, sTooltipText, sPlaceholder, sUserOnClickCode, nJScriptCode, sClassString, sStyleString, sROClassString, sColumnClass, sColumnHeaderClass, nVisible, nEnabled, nRTEnabled, sType, sStep, nWidth, nWidthUnit, nHeight, nHeightUnit, nLength, nIsPassword, nFormat, nParentId, bHasTheme,
									 nAutoComplete, nAutoCorrection, bSendHidden, sDomType, sAlign, bIsTextEdit, rtPicture, sValue) {
						this.id = sCtrlName;
						this.inputType = sType;
						this.step = sStep;
						this.title = sTooltipText;
						this.placeholder = sPlaceholder;
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight == 17 ? 0 : nHeight;
						this.heightUnit = nHeightUnit;
						this.maxLength = nLength;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.rtEnabled = (nRTEnabled != 0);
						this.isPassword = (nIsPassword != 0);
						this.format = nFormat;
						this.link = sLinkURL;
						this.linkTarget = sLinkTarget;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.roClass = sROClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.vStruct = gx.O.getValidStructFld(this.column.htmlName);
						if (bIsTextEdit && (this.rtEnabled || this.enabled)) {
							sFormatedValue = sValue;
						}
						this.formattedValue = (sValue === "") ? "" : (!gx.lang.emptyObject(sFormatedValue)) ? gx.html.encodeCaseFormat(sFormatedValue, nFormat) : gx.applyPicture(this.vStruct, gx.html.encodeCaseFormat(sValue || "", nFormat));
						this.extraAttributes = sTags;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.parentId = nParentId;
						this.hasTheme = bHasTheme;
						this.autoComplete = (nAutoComplete != 0);
						this.autoCorrection = (nAutoCorrection != 0);
						this.value = sValue || "";
						this.domainName = sDomType;
						this.rtPicture = rtPicture;
					}
				
					this._getHtml = function () {
						var sSize = '',
							sOStyle = '',
							vStruct = this.getVStruct();
						
						if (this.width == 0) {
							if (this.colSize)
								this.width = this.colSize;
							else
								this.width = this.maxLength;
							this.widthUnit = 'chr';
						}
						if (this.width > 0) {
							if (this.widthUnit == 'chr')
								sSize = ' size="' + this.width + '"';
							else
								this.style = this.style + ';width: ' + this.width + this.widthUnit + ';';
						}
						if (this.height > 0 && this.heightUnit != 'row')
							this.style = this.style + ';height: ' + this.height + this.heightUnit + ';';
						sOStyle = this.style;
						this.style = this.style + (!this.visible ? ';display:none;' : '');
						if (this.rtEnabled || this.enabled) {
							if ((this.dataType == gx.types.date) || (this.dataType == gx.types.dateTime)) {
								this.append('<div');
								this.tagAtt('id', this.id + '_dp_container');
								if (this.column.align != '')
									this.tagAtt('data-align', this.column.align);
								this.tagAtt('class', 'dp_container');
								if (this.style != '')
									this.tagAtt('style', 'white-space:nowrap;display:inline;width:auto;');
								this.append('>');
							}
							if (!this.row.ownerGrid.isFreestyle && (this.column.titleformat === undefined || this.column.titleformat == gx.html.controls.formats.TEXT)) {
								this.append('<label for="'+this.id+'" style="display:none">'+this.column.title+'</label>');
							}
							this.append('<input');
							if (this.isPassword == true)
								this.tagAtt('type', 'password');
							else {
								this.tagAtt('type', this.inputType);
								if (this.step && (this.inputType == 'number' || this.inputType == 'range')) {
									this.tagAtt('step', this.step);
									var max = Math.pow(10, this.maxLength) - 1;
									this.tagAtt('min', -1 * max);
									this.tagAtt('max', max);
									if (this.inputType == 'search')
										this.extraAttributes += ' onsearch="this.onchange();"';
								}
								if (this.dataType == gx.types.geolocation) {
									this.extraAttributes += ' data-gx-geolocation';
								}
							}
							this.tagAtt('id', this.id)
							this.tagAtt('name', this.id);
							this.tagAtt('value', (this.dataType == gx.types.numeric) ? gx.text.ltrim(this.formattedValue) : this.formattedValue);
							this.append(sSize);
							if (this.title != '')
								this.tagAtt('title', this.title);
							if (this.placeholder != '')
								this.tagAtt('placeholder', this.placeholder);
							if (!this.autoComplete)
								this.tagAtt('autocomplete', 'off');
							this.tagAtt('spellcheck', this.autoCorrection.toString());
							if (this.inputType != 'date' && this.inputType != 'datetime' && this.inputType != 'datetime-local')
								this.tagAtt('maxlength', this.maxLength);
							if (this.cssClass != '')
								this.tagAtt('class', this.cssClass);
							if (this.rtPicture != '')
								this.tagAtt('data-gx-rt-picture', this.rtPicture);
							var rowStyle = this.style;
							if (this.column.align != '')
								rowStyle += ";text-align:" + this.column.align;
							var displayProperty = (!this.enabled && this.rtEnabled) ? ';display:none;' : '';
							rowStyle += displayProperty;
							if (rowStyle != '')
								this.tagAtt('style', rowStyle);
							this.append(this.extraAttributes);
							if (gx.fn.controlFiresEvent(vStruct)) {
									this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
									this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext())
								}
							this.append('>');
							if ((this.dataType == gx.types.date) || (this.dataType == gx.types.dateTime)) {
								var validStruct = this.grid.parentObject.getValidStructFld(this.id);
								if (validStruct.dp != undefined) {
									if (validStruct.dp.f == 0) {
										this.append('<img');
										this.tagAtt('src', gx.ajax.getImageUrl(gx, 'datepickerImage'));
										this.tagAtt('id', this.id + '_dp_trigger');
										displayProperty = (!this.enabled && this.rtEnabled || !this.visible) ? ';display:none;' : '';
										this.tagAtt('style', 'cursor: pointer' + displayProperty);
										this.append('>');
									}
									this.append('</div>');
									this.grid.addDatepickerToSetup({ CtrlId: this.id, Grid: this.gridId, Row: this.gridRow });
								}
							} else
								gx.html.controls.specificDomainCtrls(this);
						}
						if (!this.enabled) {
							var ClassHTML = '';
							if (!this.rtEnabled)
								this.grid.addHiddenControl(this.id, ((this.dataType == gx.types.date) || (this.dataType == gx.types.dateTime)) ? this.formattedValue : this.value);
							if (!this.hasTheme)
								ClassHTML = this.cssClass;
							else {
								if (this.parentId == 0) {
									if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
										ClassHTML = 'Readonly' + this.cssClass;
									else
										ClassHTML = this.cssClass;
								}
								else {
									if (this.roClass != '' && this.roClass.indexOf('Readonly') != 0)
										ClassHTML = 'Readonly' + this.roClass;
									else
										ClassHTML = this.roClass;
								}
							}
							var sEventJsCode = '';
							if (this.format != gx.html.controls.formats.RAW_HTML) {
								if (gx.runtimeTemplates) {
									this.append('<p class="form-control-static">');
								}
								sOStyle = sOStyle + ((!this.visible) ? ';display:none;' : '');
								this.append('<span');
								if (gx.runtimeTemplates) {
									this.append(' data-gx-tpl-applied-readonly-atts-vars');
								}
								this.append(this.extraAttributes);
								if (ClassHTML != '')
									this.tagAtt('class', ClassHTML);
								if (sOStyle != '')
									this.tagAtt('style', sOStyle);
								if (this.title != '')
									this.tagAtt('title', this.title);
								this.tagAtt('id', 'span_' + this.id);
								this.tagAtt('data-gx-enabled-id', this.id);
								if (gx.fn.controlFiresEvent(vStruct)) {
									this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
									this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext());
									this.tagAtt("tabindex", "0");
								}
								this.append('>');
								sEventJsCode = gx.html.controls.eventJSCode(this.jsScrCode, this.eventName, null, this.grid, this.row);
								gx.html.controls.startAnchor(this, this.jsScrCode, sEventJsCode, this.usrOnclick, this.link, this.linkTarget);
							}
							if (!this.isPassword) {
								this.append(this.formattedValue);
							}
							else {
								var maxLen = gx.lang.emptyObject(this.maxLength) ? 3 : parseInt(this.maxLength);
								for (var i = 0; i < maxLen; i++)
									this.append('*');
							}
							if (this.format != gx.html.controls.formats.RAW_HTML) {
								gx.html.controls.endAnchor(this, sEventJsCode, this.usrOnclick, this.link);
								this.append('</span>');
								if (gx.runtimeTemplates) {
									this.append('</p>');
								}
							}
							if (this.format == gx.html.controls.formats.RAW_HTML)
								gx.html.processCode(this.buffer.toString(), false);

							gx.html.controls.specificDomainCtrls(this);
						}
					}
				},

				multipleLineEdit: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.multipleLineEdit;

					this.setProperties = function (sCtrlName, sLinkURL, sTags, nFormat, nVisible, nEnabled, nRTEnabled, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, nLength, nAutoresize, nMaxTextLines, sLinkTarget, sPlaceholder, nAutoCorrection, bSendHidden, sDomType, sEventName, nJScriptCode, sValue) {
						this.id = sCtrlName;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.rtEnabled = (nRTEnabled != 0);
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.maxLength = nLength;
						this.extraAttributes = sTags;
						this.autoresize = (nAutoresize != 0);
						this.format = nFormat;
						this.link = sLinkURL;
						this.linkTarget = sLinkTarget;
						this.placeholder = sPlaceholder;
						this.value = sValue || "";
						this.autoCorrection = (nAutoCorrection != 0);
						this.domainName = sDomType;
						this.maxTextLines = nMaxTextLines;
						this.jsScrCode = nJScriptCode;
					}


					this._getHtml = function () {
						var vStruct = this.getVStruct();
						this.style = this.style + ((!this.visible || (!this.enabled && this.rtEnabled)) ? ';display:none;' : '');
						if (this.rtEnabled || this.enabled) {
							if (!this.row.ownerGrid.isFreestyle && (this.column.titleformat === undefined || this.column.titleformat == gx.html.controls.formats.TEXT)) {
								this.append('<label for="'+this.id+'" style="display:none">'+this.column.title+'</label>');
							}
							this.append('<textarea');
							if (this.placeholder != '')
								this.tagAtt('placeholder', this.placeholder);
							this.tagAtt('spellcheck', this.autoCorrection.toString());
							if (this.widthUnit == 'chr')
								this.tagAtt('cols', this.width);
							else
								this.style = this.style + ';width: ' + this.width + this.widthUnit;
							if (this.maxTextLines > 1)
								this.tagAtt('data-gx-text-maxlines', this.maxTextLines);
							if (this.heightUnit == 'row')
								this.tagAtt('rows', this.height);
							else
								this.style = this.style + ';height: ' + this.height + this.heightUnit;
							this.tagAtt('id', this.id);
							this.tagAtt('name', this.id);
							this.tagAtt('maxlength', this.maxLength);
							this.append('onkeyup = "return gx.evt.checkMaxLength(this,' + this.maxLength + ',event);"');
							this.append('onkeydown = "return gx.evt.checkMaxLength(this,' + this.maxLength + ',event);"');
							if (this.cssClass != '')
								this.tagAtt('class', this.cssClass);
							if (this.style != '')
								this.tagAtt('style', this.style);
							if (this.title != '')
								this.tagAtt('title', this.title);
							this.append(this.extraAttributes);
							this.append('>');
							this.append(gx.html.encodeCaseFormat(this.value, gx.html.controls.formats.TEXT, false));
							this.append('</textarea>');
						}
						if (!this.enabled) {
							var sOStyle = (!this.visible ? 'display:none;' : '');
							if (!this.autoresize)
								sOStyle += 'overflow="hidden";';
							if (!this.rtEnabled)
								this.grid.addHiddenControl(this.id, this.value);
							if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
								this.cssClass = 'Readonly' + this.cssClass;
							this.append('<span ');
							this.append(this.extraAttributes);
							if (this.cssClass != '')
								this.tagAtt('class', this.cssClass);
							if (sOStyle != '')
								this.tagAtt('style', sOStyle);
							if (this.title != '')
								this.tagAtt('title', this.title);
							this.tagAtt('id', 'span_' + this.id);
							if (vStruct.evt) {
								this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
								this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext());
								this.tagAtt("tabindex", "0");
							}
							this.append('>');
							gx.html.controls.startAnchor(this, this.jsScrCode, !!vStruct.evt, '', this.link, this.linkTarget);
							this.append(gx.html.encodeCaseFormat(this.value, this.format, true));
							gx.html.controls.endAnchor(this, !!vStruct.evt, '', this.link);
							gx.html.controls.specificDomainCtrls(this);

							this.append('</span>');
						}
					}


				},

				blob: function (id, width, height, cssClass, title, dislplay, contentType) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.blob;
					this.display = dislplay || 0;
					this.contentType = contentType || 'text/html';
					this.url = '';
					this.parameters = '';

					this.setProperties = function (sInternalName, sValue, sContenttype, bHasFiletypeatt, sLinkTarget, sObjecttagparameters, nDisplay, nEnabled, nVisible, sAlternateText, sTooltipText, nBorderWidth,
										   nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nVerticalSpace, nHorizontalSpace, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString, sColumnClass, sColumnHeaderClass,
										   sInputTags, sDisplayTags, sJsDynCode, sURL) {
						this.id = sInternalName;
						this.value = sValue;
						this.contentType = sContenttype || 'text/html';
						this.linkTarget = sLinkTarget;
						this.parameters = sObjecttagparameters;
						this.display = nDisplay;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.alt = sAlternateText;
						this.title = sTooltipText;
						this.borderWidth = nBorderWidth;
						this.autoresize = (nAutoresize != 0);
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.vSpace = nVerticalSpace;
						this.hSpace = nHorizontalSpace;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.extraAttributes = sInputTags;
						this.extraDisplayAttributes = sDisplayTags;
						this.jsDynCode = sJsDynCode;
						this.url = gx.util.resolveUrl(sURL);
					}

					this._getHtml = function () {
						var ClassHTML = '';
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						this.append('<div class="gx-tbldsp-container"');
						this.tagAtt('border', 0);
						this.tagAtt('data-cellpadding', 0);
						this.tagAtt('data-cellspacing', 0);
						this.tagAtt('style', 'margin:' + this.vSpace + 'px ' + this.hSpace + 'px;');
						this.tagAtt('title', gx.lang.emptyObject(this.title ) ? this.id : this.title);
						this.append('><div>');
						var imgType = (this.contentType.toLowerCase().indexOf('image/') != -1);
						if (this.display == 0) {
							if (imgType) {
								this.append('<img');
								this.tagAtt('alt', this.alt);
								if (this.url == '' || this.url == gx.util.resourceUrl(gx.basePath + gx.staticDirectory))
									this.url = gx.ajax.getImageUrl(gx, 'blankImage');
								this.tagAtt('src', this.url);
							}
							else {
								this.append('<object');
								this.tagAtt('type', this.contentType);
								if (this.url == '')
									this.url = 'about:blank';
								this.tagAtt('data', this.url);
							}
							this.tagAtt('id', 'Object_' + this.id);
							this.style = this.style + 'display:block;';
							if (this.width != 0 && !this.autoresize)
								this.style = this.style + 'width:' + this.width + this.widthUnit + ';';
							if (this.height != 0 && !this.autoresize)
								this.style = this.style + 'height:' + this.height + this.heightUnit + ';';
							this.tagAtt('style', this.style);
							if (this.cssClass != '')
								ClassHTML = 'BlobContent' + this.cssClass;
							else
								ClassHTML = this.cssClass;
							if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
								ClassHTML = 'Readonly' + ClassHTML;
							this.tagAtt('class', ClassHTML);
							this.append(this.extraDisplayAttributes);
							this.append('>');
							if (imgType)
								this.append('</img>');
							else {
								this.append(this.parameters);
								this.append('</object>');
							}
						}
						else if (this.display == 1) {
							this.append('<a');
							this.tagAtt('id', 'Link_' + this.id);
							if (this.url != '')
								this.style = this.style + 'display:block;';
							else
								this.style = this.style + 'display:none;';
							this.tagAtt('style', this.style);
							this.tagAtt('href', this.url);
							this.tagAtt('type', this.contentType);
							if (this.linkTarget != '')
								this.tagAtt('target', this.linkTarget);
							this.append('><img');
							this.tagAtt('border', '0');
							this.tagAtt('src', gx.ajax.getImageUrl(gx, 'downloadImage'));
							this.append('></a>');
						}
						this.append('</div><div>');
						if (this.enabled) {
							var inputStyle = '';
							if (!gx.lang.emptyObject(this.value))
								gx.dom.form().encoding = 'multipart/form-data';
							// File inputs inside grids must be reused between refreshes if we want to keep the selected value, as it cannot
							// be assigned programatically for security reasons.
							// This is specially important in transactions, where the user can select a value in a row and then add another row.
							// As the grid is completely refreshed with each added row, if we want to remember the value the user selected in a
							// previous row, we must reuse the original input element.
							var inputEl = gx.dom.byId(this.id);
							if (this.grid && this.grid.parentObject.isTransaction() && inputEl && this.value === inputEl.value) {
								var hookId = this.id + "_hook";
								this.append('<div');
								this.tagAtt('id', hookId);
								this.append('>');
								this.append('</div>');
								this.grid.addControlToReuse({ el: inputEl, hookId: hookId });
							}
							else {
								this.append('<input');
								this.tagAtt('type', 'file');
								this.tagAtt('id', this.id);
								this.tagAtt('name', this.id);
								if (!this.visible)
									inputStyle = inputStyle + 'display:none;';
								if (this.width != 0)
									inputStyle = inputStyle + 'width:' + this.width + ';';
								this.tagAtt('style', inputStyle);
								this.tagAtt('value', this.value);
								if (this.cssClass != '')
									ClassHTML = 'BlobInput' + this.cssClass;
								else
									ClassHTML = this.cssClass;
								if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
									ClassHTML = 'Readonly' + ClassHTML;
								this.tagAtt('class', ClassHTML);
								if (imgType)
									this.tagAtt('accept', this.contentType);
								this.append(this.extraAttributes);
								this.append('>');
							}
						}
						this.append('</div></div>');
					}
				},

				radio: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.radio;
					this.vertical = true;
					this.possibleValues = [];
					//this.valueIndex = 2;
					this.setProperties = function (radRObjCtrl, sCtrlName, sTooltipText, nVisible, nEnabled, nRadioColumns, nOrientation, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, nJScriptCode, sUserOnClickCode, sEventName, sTags, sValue) {
						this.possibleValues = radRObjCtrl.v || [];
						this.id = sCtrlName;
						this.title = sTooltipText;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.columns = nRadioColumns;
						this.orientation = nOrientation;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.extraAttributes = sTags;
						this.value = sValue;
					}

					this._getHtml = function () {
						if (this.dataType == gx.types.numeric)
							this.value = gx.text.trim(this.value.toString());
						var cssClassArray = [];
						if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							cssClassArray.push('Readonly' + this.cssClass);
						else
							cssClassArray.push(this.cssClass);
						cssClassArray.push('gx-radio-button');
						if (this.orientation == 1)
							cssClassArray.push('gx-radio-button-vertical');
						var ClassHTML = cssClassArray.join(" ");

						var sEventJsCode = gx.html.controls.eventJSCode(this.jsScrCode, this.eventName, null, this.grid, this.row);
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						this.append(applyTemplate("radio", {
							id: this.id,
							className: ClassHTML,
							style: this.style,
							title: this.title,
							isDisabled: !this.enabled,
							extraAttributes: this.extraAttributes,
							gxoch0: gx.html.controls.onJSEvent_impl('data-gxoch0', sEventJsCode, this.usrOnclick),
							values: $.map(this.possibleValues, (function (item, i) {
								return {
									itemId: this.id + "_" + i,
									itemValue: item[0],
									itemDesc: item[1],
									isSelected: (gx.text.trim(this.value.toString()) == gx.text.trim(item[0].toString()))
							}
							}).closure(this))
						}));
					}
				},

				comboBox: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.comboBox;
					this.rows = 1;
					this.possibleValues = [];

					this.setProperties = function (cmbCObjCtrl, sCtrlName, nRows, sUserOnClickCode, nJScriptCode, sEventName, sType, sTooltipText, nVisible, nEnabled, nRTEnabled, nFormat, nWidth, nWidthUnit, nHeight, nHeightUnit, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, sTags, sFormatedValue, bSendHidden, sValue) {
						this.possibleValues = cmbCObjCtrl.v || [];
						this.id = sCtrlName;
						this.title = sTooltipText;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.rtEnabled = (nRTEnabled != 0);
						this.rows = nRows;
						this.format = nFormat;
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.formattedValue = sFormatedValue;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.extraAttributes = sTags;
						this.value = sValue;
						this.rawValue = cmbCObjCtrl;
					}

					this._getHtml = function () {
						if (this.dataType == gx.types.numeric)
							this.value = gx.text.trim(this.value.toString());
						if (this.width > 0)
							this.style = this.style + ';width: ' + this.width + this.widthUnit;
						if (this.height > 0)
							this.style = this.style + ';height: ' + this.height + this.heightUnit;
						var sOStyle = this.style + ' ;overflow:hidden;';
						var enabledAny = this.enabled || this.rtEnabled;
						this.style = this.style + ((!this.visible || !this.enabled && this.rtEnabled) ? ';display:none;' : '');
						if (enabledAny) {
							var sEventJsCode = gx.html.controls.eventJSCode(this.jsScrCode, this.eventName, null, this.grid, this.row);
							this.append('<select');
							if (this.rows > 1)
								this.tagAtt('size', this.rows);
							this.tagAtt('id', this.id);
							this.tagAtt('name', this.id);
							if (this.title != '')
								this.tagAtt('title', this.title);
							if (this.cssClass != '')
								this.tagAtt('class', this.cssClass);
							if (this.style != '')
								this.tagAtt('style', this.style);
							if (!this.enabled) {
								this.append(' disabled');
								gx.util.addOnce(gx.disabledControls, this.id, this.id);
							}
							this.append(this.extraAttributes);
							gx.html.controls.onJSEvent(this, 'data-gxoch0', sEventJsCode, this.usrOnclick);
							this.append('>');
							var len = this.possibleValues.length;
							for (var i = 0; i < len; i++) {
								var item = this.possibleValues[i];
								this.append('<option');
								this.tagAtt('value', item[0]);
								if (gx.text.trim(item[0].toString()) == gx.text.trim(gx.lang.htmlDecode(this.value.toString())))
									this.append(' selected');
								this.append('>');
								this.append(item[1]);
								this.append('</option>');
							}
							this.append('</select>');
						}
						if (!this.enabled) {
							if (!this.rtEnabled)
								this.grid.addHiddenControl(this.id, this.value);
							var ClassHTML = '';
							if (this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
								ClassHTML = 'Readonly' + this.cssClass;
							else
								ClassHTML = this.cssClass;
							sOStyle = sOStyle + ((!this.visible) ? ';display:none;' : '');
							this.append('<span ');
							this.tagAtt('id', 'span_' + this.id);
							if (this.title != '')
								this.tagAtt('title', this.title);
							if (ClassHTML != '')
								this.tagAtt('class', ClassHTML);
							if (sOStyle != '')
								this.tagAtt('style', sOStyle);
							if (!enabledAny)
								this.tagAtt(gx.GxObject.GX_DATA_RAW_VALUE_ATTR, gx.json.serializeJson(this.rawValue));
							this.append(this.extraAttributes);
							this.append('>');
							var len = this.possibleValues.length;
							for (var i = 0; i < len; i++) {
								var item = this.possibleValues[i];
								if (gx.text.trim(item[0].toString()) == gx.text.trim(gx.lang.htmlDecode(this.value.toString()))) {
									this.append(item[1]);
									break;
								}
							}
							this.append('</span>');
						}
					}
				},

				listBox: function (id, width, height, cssClass, title, rows) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.listBox;
					this.rows = rows;
				},

				checkBox: function (id, width, height, cssClass, title, caption, checkedValue, uncheckedValue) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.checkBox;
					this.caption = caption || '';
					this.checkedValue = checkedValue;
					this.uncheckedValue = uncheckedValue;

					this.setProperties = function (sCtrlName, sTooltipText, sLabelCaption, nVisible, nEnabled, sCheked, sCaption, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, sTags, sValue) {
						this.id = sCtrlName;
						this.title = sTooltipText;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.checkedValue = sCheked;
						this.caption = sCaption;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.extraAttributes = sTags;
						this.value = sValue;
						this.labelCaption = sLabelCaption;
					}

					this._getHtml = function () {
						var vStruct = this.getVStruct();
						if (this.dataType == gx.types.numeric) {
							this.value = gx.text.trim(this.value.toString());
							this.checkedValue = gx.text.trim(this.checkedValue.toString());
						}
						var ClassHTML = this.cssClass;
						if (!this.enabled && this.cssClass != '' && this.cssClass.indexOf('Readonly') != 0)
							ClassHTML = 'Readonly' + this.cssClass;
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						this.append('<label');					
						this.tagAtt('for', this.id);
						if (ClassHTML != '')
							this.tagAtt('class', ClassHTML);
						if (this.style != '')
							this.tagAtt('style', this.style);
						this.append('><input');
						this.tagAtt('id', this.id);
						this.tagAtt('type', 'checkbox');					
						this.tagAtt('name', this.id);
						var isChecked = (this.value.toString() == this.checkedValue.toString());
						if (isChecked) {
							this.append(' checked');
							this.tagAtt('value', this.checkedValue);
						}
						else
							this.tagAtt('value', this.uncheckedValue);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (!this.enabled)
							this.append(' disabled');
						this.append(this.extraAttributes);
						if (gx.fn.controlFiresEvent(vStruct)) {
							this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
							this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext())
						}
						this.append('>');
						this.append(this.caption);
						this.append('</label>');
					}
				},

				imageReadOnly: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.image;
					this.alt = '';

					this.setProperties = function (sInternalName, sLinkURL, sLinkTarget, sAccesskey, sThemeName, nVisible, nEnabled, sAlternateText, sTooltipText, nBorderWidth, nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nVerticalSpace,
											nHorizontalSpace, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, sAlign, sTags, sUseMap, sJsDynCode, sImgSrcSet, sImageURL) {
						this.id = sInternalName;
						this.accessKey = sAccesskey;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.alt = sAlternateText;
						this.title = sTooltipText;
						this.borderWidth = nBorderWidth;
						this.autoresize = (nAutoresize != 0);
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.vSpace = nVerticalSpace;
						this.hSpace = nHorizontalSpace;
						this.link = sLinkURL;
						this.linkTarget = sLinkTarget;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.align = sAlign;
						this.extraAttributes = sTags;
						this.useMap = sUseMap;
						this.jsDynCode = sJsDynCode;
						this.imgSrcSet = sImgSrcSet;
						this.imageUrl = sImageURL;
						this.value = sImageURL;
					}

					this._getHtml = function () {
						var vStruct = this.getVStruct();
						this.grid.addHiddenControl(this.id, this.imageUrl);
						if (this.eventName != '' && gx.text.endsWith(this.eventName, ".'"))
							this.eventName = this.eventName.replace(".'", "."+this.gridRow+"'");
						var sCapAKey = gx.util.accessKey(this.title);
						this.title = gx.util.accessKeyCaption(this.title);
						if (sCapAKey != '')
							this.accessKey = sCapAKey;
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						var sEventJsCode = gx.html.controls.eventJSCode(this.jsScrCode, this.eventName, this.jsDynCode, this.grid, this.row);
						if (this.enabled && this.link != '')
							gx.html.controls.startAnchor(this, this.jsScrCode, sEventJsCode, this.usrOnclick, this.link, this.linkTarget, "gx-image-link");
						this.append('<img');
						this.tagAtt('src', this.value);
						if (this.imgSrcSet) {
							this.tagAtt('srcset', this.imgSrcSet);
						}
						if (!this.enabled)
							this.cssClass = (this.cssClass || "") + " gx-disabled";
						if (this.accessKey != '')
							this.tagAtt('accesskey', this.accessKey);
						this.tagAtt('id', this.id);
						if (this.vSpace != 0)
							this.tagAtt('vspace', this.vSpace);
						if (this.hSpace != 0)
							this.tagAtt('hspace', this.hSpace);
						if (this.align != '')
							this.tagAtt('align', this.align);
						if (this.cssClass == '' || this.borderWidth > 0) {
							this.tagAtt('border', this.borderWidth);
							if (this.cssClass != '')
								this.style = this.style + ';border-width: ' + this.borderWidth;
						}
						this.tagAtt('alt', this.alt || this.title);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (this.width > 0)
							this.style = this.style + ';width: ' + this.width + this.widthUnit;
						if (this.height > 0)
							this.style = this.style + ';height: ' + this.height + this.heightUnit;
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (this.useMap != '')
							this.tagAtt('usemap', this.useMap);
						if (this.extraAttributes)
							this.append(this.extraAttributes);
						if (vStruct.evt) {
							this.tagAtt("tabindex", "0");
							this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
							this.tagAtt(gx.GxObject.GX_EVENT_DATA_ATTR, "");
							this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext())
							if (this.usrOnclick) {
								this.tagAtt(gx.GxObject.GX_EVENT_CONDITION_DATA_ATTR, this.usrOnclick);
							}
						}
						this.append('>');
						if (this.enabled && this.link != '' && sEventJsCode == '')
							gx.html.controls.endAnchor(this, sEventJsCode, this.usrOnclick, this.link);
					},

					this._persistValue = function () {
						var vStruct = this.getVStruct();
						if (vStruct.v2v)
							vStruct.v2v(this.imageUrl);
					}
				},

				multimedia: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.multimedia;
					this.setProperties = function (sInternalName, sText, nDisplay, nVisible, nEnabled, nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, sInputTags, sVideoTags, sJsDynCode, nReadOnly, bIsBlob, sMultimediaURL) {
						this.id = sInternalName;
						this.text = sText;
						this.display = (nDisplay != 0);
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.autoresize = (nAutoresize != 0);
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.extraInputAttributes = sInputTags;
						this.jsDynCode = sJsDynCode;
						this.readOnly = (nReadOnly != 0);
						this.isBlob = gx.lang.gxBoolean(bIsBlob);
						this.multimediaUrl = sMultimediaURL;
						this.value = gx.util.resolveUrl(sMultimediaURL);
					};

				

					this.startMultimediaUploadControl = function (id, visible, width, style) {
						var styleAtt = (style || "") + (visible ? "" : "display:none;");
						if (width > 0)
							style += "width:" + width;
						var html = ['<div id="', id, '_ct" class="', gx.html.multimediaUpload.gxCssClass,'" style="', styleAtt, '">'];
						return html.join('');
					};

					this.endMultimediaUploadControl = function (id, url, tooltip, width, widthUnit, height, heightUnit, userOnClick, eventName, style, cssClass, align, inputAttributes, readOnly, isBlob, accept) {
						var buffer = [],
							fileInputEl = gx.html.multimediaUpload.getInputFileEl(this.id),
							uriChecked = 'checked', 
							fileChecked = '', 
							uriValue = url,
							idParts = id.match(/([\w]+)(_\d{4})$/),
							gxiId = idParts[1] + "_GXI" + idParts[2];
					
						if (isBlob || isBlob === undefined) {
							uriChecked = ''
							fileChecked = 'checked';
							uriValue = '';
						}
						var html = [
									'<div id="', id, '_ct_fields" class="fields-ct">',
										'<label class="option">',
											'<input name="', id, 'Option" type="radio" value="file" ', fileChecked, '/>',
											gx.getMessage("GXM_uploadfileoption"),
										'</label>',
										'<label class="option">',
											'<input name="', id, 'Option" type="radio" value="uri" ', uriChecked, '/>',
											gx.getMessage("GXM_uploadurioption"),
										'</label>',
										'<input type="text" class="field ', cssClass, '" id="', gxiId, '" name="', gxiId, '" value="', uriValue, '" ', inputAttributes, ' />'
						];
						buffer.push(html.join(''));

						if (fileInputEl)
							html = ['<div id="', id, '_hook"></div>'];
						else
							html = ['<input type="file" class="field ', cssClass, '" id="', id, '" name="', id, '" accept="', accept, '" ', inputAttributes, '/>'];
						buffer.push(html.join(''));

						html = ['</div>',
								'</div>'
						];
						buffer.push(html.join(''));

						return buffer.join('');
					};

					this.getPreviewHtml = function () {
						var className = this.cssClass ? "Readonly" + this.cssClass : "",
							blobUrl = this.value,
							href = blobUrl ? ' href="' + blobUrl + '"' : "",
							ro = this.readOnly || !this.enabled,
							id = ro? this.id : "",
							html = "";
						
						var anchorClassName = " gx-multimedia-ro";
						
						if (gx.text.startsWith(gx.util.getContentTypeFromExt(blobUrl), "image") || (!ro && blobUrl === '') ) {
							html = ['<a' /*, (blobUrl)? ' download': ''*/, ' class="',anchorClassName, '"', ' target ="_blank"', href, '>',
											'<img id = "Object_', this.id, '" class = "', className, '" alt = "', this.alt, '" src = "', blobUrl, '" />',
											'<span id="', id, '" class="', this.placeHolderClass, '"></span>',
										'</a>'];							
						}
						else {							
							html = ['<a' , (blobUrl)? ' download': '', ' class="',anchorClassName, '"', ' target = "_blank"', href, '>',
											'<span id = "', id, '" class = "', className, ' ', this.placeHolderClass, '" title = "', gx.getMessage("GXM_multimediaalttext"), '"></span>',
										'</a>'];							
						}
						return html.join('');
					};

					this._getHtml = function () {
						if (!this.readOnly && this.enabled) {
							this.append(this.startMultimediaUploadControl(this.id, this.visible, this.width, this.style));
							this.append('<a class="action change-action" gxfocusable="1" href=""' + this.extraInputAttributes + '>' + gx.getMessage("GXM_multimediachange") + '</a>');
							this.append('<a gxfocusable="1" href="" class="action clear-action"></a>');
						}
						else {
							this.grid.addHiddenControl(this.id, this.multimediaUrl);
						}

						this.append(this.getPreviewHtml());

						if (!this.readOnly && this.enabled) {
							this.append(this.endMultimediaUploadControl(this.id, this.value, "", this.width, this.widthUnit, this.height, this.heightUnit, this.usrOnclick, this.eventName, this.style, this.cssClass, "", this.extraInputAttributes, this.readOnly, this.isBlob, this.accept));

							var fileInputEl = gx.html.multimediaUpload.getInputFileEl(this.id);
							if (this.grid && this.grid.parentObject.isTransaction() && fileInputEl)
								this.grid.addControlToReuse({ el: fileInputEl, hookId: this.id + "_hook" });
						}
					};

					this._persistValue = function () {
						var vStruct = this.getVStruct();
						if (vStruct.v2v)
							vStruct.v2v(this.multimediaUrl);
					};
				},

				image: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.image;
					this.alt = '';
					this.innerImage = new gx.html.controls.imageReadOnly();
					this.placeHolderClass = 'gx-image-placeholder';

					this.setProperties = function (sInternalName, sLinkURL, sLinkTarget, sAccesskey, sThemeName, nVisible, nEnabled, sAlternateText, sTooltipText, nBorderWidth, nAutoresize, nWidth, nWidthUnit, nHeight, nHeightUnit, nVerticalSpace,
						nHorizontalSpace, nJScriptCode, sUserOnClickCode, sEventName, sStyleString, sClassString, sColumnClass, sColumnHeaderClass, sAlign, sInputTags, sImageTags, sUseMap, sJsDynCode, nReadOnly, bIsBlob, bIsAttribute, sImgSrcSet, sImageURL) {
						this.id = sInternalName;
						this.accessKey = sAccesskey;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.alt = sAlternateText;
						this.title = sTooltipText;
						this.borderWidth = nBorderWidth;
						this.autoresize = (nAutoresize != 0);
						this.width = nWidth;
						this.widthUnit = nWidthUnit;
						this.height = nHeight;
						this.heightUnit = nHeightUnit;
						this.vSpace = nVerticalSpace;
						this.hSpace = nHorizontalSpace;
						this.link = sLinkURL;
						this.linkTarget = sLinkTarget;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.columnClass = sColumnClass;
						this.columnHeaderClass = sColumnHeaderClass;
						this.align = sAlign;
						this.extraInputAttributes = sInputTags;
						this.extraImageAttributes = sImageTags;
						this.useMap = sUseMap;
						this.jsDynCode = sJsDynCode;
						this.readOnly = (nReadOnly != 0);
						this.isBlob = gx.lang.gxBoolean(bIsBlob);
						this.isAttribute = gx.lang.gxBoolean(bIsAttribute);
						this.imgSrcSet = sImgSrcSet;
						this.multimediaUrl = sImageURL;
						this.value = gx.util.resolveUrl(sImageURL);
						this.themeName = sThemeName;
						this.className = bIsAttribute && sClassString ? "Readonly" + sClassString : sClassString;
						var gridData = this.getGridData();
						this.updateinnerImageProperties();
						this.innerImage.setGridData(gridData);
						this.innerImage.column = this.column;
					};

					this.updateinnerImageProperties = function () {
						this.innerImage.setProperties(this.id, this.link, this.linkTarget, this.accessKey, this.themeName, this.visible,
						this.enabled, this.alt, this.title, this.borderWidth, this.autoresize, this.width, this.heightUnit,
						this.height, this.heightUnit, this.vSpace,
						this.hSpace, this.jsScrCode, this.usrOnclick, this.eventName, this.style, this.className, this.columnClass, this.columnHeaderClass, 
						this.align, this.extraImageAttributes, this.useMap, this.jsDynCode, this.imgSrcSet, this.value);
					}

					this.getPreviewHtml = function () {
						var imgUrl = this.value,							
							className = this.cssClass ? "Readonly" + this.cssClass : "",
							href = this.value ? ' href="' + this.value + '"' : "";
							
							var html = ['<a target="_blank"', ' class="gx-multimedia-ro"', '>',
										'<img id="Object_', this.id, '" class="', className, '" alt="', this.alt, '" src="', imgUrl, '" />',
										'<span class="', this.placeHolderClass, '"></span>',
									'</a>'];
						return html.join('');
					};

					this._getHtml = function () {
						if (this.readOnly || !this.enabled) {
							this.buffer = this.innerImage.buffer;
							this.updateinnerImageProperties();
							this.innerImage._getHtml();
						}
						else {
							this.append(this.startMultimediaUploadControl(this.id, this.visible, this.width, this.style));

							this.append('<a class="action change-action" gxfocusable="1" href=""' + this.extraInputAttributes + '>' + gx.getMessage("GXM_multimediachange") + '</a>');
							this.append('<a gxfocusable="1" href="" class="action clear-action"></a>');

							this.append(this.getPreviewHtml());

							this.append(this.endMultimediaUploadControl(this.id, this.value, this.title, this.width, this.widthUnit, this.height, this.heightUnit, this.usrOnclick, this.eventName, this.style, this.cssClass, this.align, this.extraInputAttributes, this.readOnly, this.isBlob, "image/*"));

							var fileInputEl = gx.html.multimediaUpload.getInputFileEl(this.id);
							if (this.grid && this.grid.parentObject.isTransaction() && fileInputEl)
								this.grid.addControlToReuse({ el: fileInputEl, hookId: this.id + "_hook" });
						}
					};
				},

				video: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.video;
					this.accept = "video/*";
					this.placeHolderClass = 'gx-video-placeholder';
				},

				audio: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.audio;
					this.accept = "audio/*";
					this.placeHolderClass = 'gx-audio-placeholder';
				},

				file: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);
					this.type = gx.html.controls.types.audio;					
					this.placeHolderClass = 'gx-download-placeholder';
				},

				textBlock: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.textBlock;

					this.setProperties = function (sInternalName, sLinkURL, sLinkTarget, sUserOnClickCode, sEventName, sTags, sClassString, nJScriptCode, sTooltipText, nVisible, nEnabled, nRTEnabled, nFormat, sCaption) {
						this.id = sInternalName;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.rtEnabled = (nRTEnabled != 0);
						this.format = nFormat;
						this.title = sTooltipText;
						this.link = sLinkURL;
						this.linkTarget = sLinkTarget;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName;
						this.extraAttributes = sTags;
						this.cssClass = sClassString;
						this.value = gx.text.replaceAll(sCaption, '�', "'");
					}

					this._getHtml = function () {
						var sStyle;
						var vStruct = this.getVStruct();
						var enabledCondition = this.enabled || this.rtEnabled;
						if (this.format != gx.html.controls.formats.RAW_HTML) {
							if (this.format == gx.html.controls.formats.HTML) {
								sStyle = ((this.visible) ? ';display:inline;' : ';display:none;') + this.extraAttributes;
								this.append('<div ');
							} else {
								sStyle = ((this.visible) ? '' : ';display:none;') + this.extraAttributes;
								this.append('<span ');
							}
							this.tagAtt('id', this.id);
							if (!this.enabled)
								this.cssClass = (this.cssClass || "") + " gx-disabled";
							if (this.cssClass != '')
								this.tagAtt('class', this.cssClass);
							this.tagAtt('data-gxformat', this.format);
							if (sStyle != '')
								this.tagAtt('style', sStyle);
							if (this.title != '')
								this.tagAtt('title', this.title);
							if (gx.fn.controlFiresEvent(vStruct)) {
								this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
								this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext());
								this.tagAtt("tabindex", "0");
							}
							this.append('>');
						}
						var sEventJsCode = '';
						if (enabledCondition) {
							sEventJsCode = gx.html.controls.eventJSCode(this.jsScrCode, this.eventName, null, this.grid, this.row);
							gx.html.controls.startAnchor(this, this.jsScrCode, sEventJsCode, this.usrOnclick, this.link, this.linkTarget);
						}
						else
							sEventJsCode = '';
						this.append(gx.html.encodeCaseFormat(this.value, this.format));
						if (enabledCondition)
							gx.html.controls.endAnchor(this, sEventJsCode, this.usrOnclick, this.link);
						if (this.format == gx.html.controls.formats.HTML)
							this.append('</div>');
						else if (this.format != gx.html.controls.formats.RAW_HTML)
							this.append('</span>');
						if (this.format == gx.html.controls.formats.RAW_HTML)
							gx.html.processCode(this.buffer.toString(), false);
					}
				},

				label: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.label;

					this.setProperties = function (sReferencedEl, sLabelCaption, sLabelClass, labelPosition, bDataAttSupported, sExtraStyle) {
						this.referencedEl = sReferencedEl;
						this.labelCaption = sLabelCaption;
						this.labelClass = sLabelClass;
						this.extraStyle = sExtraStyle;
						this.addAttributes = ([
							(labelPosition === 0) ? 'data-gx-sr-only' : '',
							this.extraStyle ? 'style="' + this.extraStyle + '"' : ""
						]).join(" ");
					}

					this._getHtml = function () {
						this.append(applyTemplate('label', {
							caption: this.labelCaption,
							className: this.labelClass,
							additionalAtts: this.addAttributes,
							relatedElement: this.referencedEl
						}));
					}
				},

				button: function (id, width, height, cssClass, title, buttonStyle) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.button;
					this.caption = '';
					this.buttonStyle = buttonStyle || 'rounded';

					this.setProperties = function (sCtrlName, sJsCode, sUserOnClickCode, nJScriptCode, sTooltipText, sAccesskey, sStyleString, sClassString, nVisible, nEnabled, sBorderStyle, sEventName,
										   sTags, sJsDynCode, nReset, sCaption) {
						this.reset = nReset;
						this.id = sCtrlName;
						this.title = sTooltipText;
						this.accessKey = sAccesskey;
						this.style = sStyleString;
						this.cssClass = sClassString;
						this.visible = (nVisible != 0);
						this.enabled = (nEnabled != 0);
						this.buttonStyle = sBorderStyle;
						this.jsScrCode = nJScriptCode;
						this.usrOnclick = sUserOnClickCode;
						this.eventName = sEventName + (this.jsScrCode == 5 ? "+'" + this.gridRow + "'": "");
						this.extraAttributes = sTags;
						this.jsCode = sJsCode;
						this.jsDynCode = sJsDynCode;
						this.caption = sCaption;
					}

					this._getHtml = function () {
						var vStruct = this.getVStruct();
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						var sClassRoundedBtn = 'BaseRBtn ' + 'R' + this.cssClass;
						if (this.buttonStyle == 'rounded') {
							this.cssClass = 'BtnText';
							this.append('<span ');
							this.tagAtt('onclick', 'gx.evt.doClick(\'' + this.id + '\', event);');
							if (this.style != '')
								this.tagAtt('style', this.style);
							this.tagAtt('class', sClassRoundedBtn);
							this.append('><span class="BtnLeft"><span class="BtnRight"><span class="BtnBackground">');
						}
						this.append('<input');
						var inputType = 'button';
						if (this.reset == 1)
							inputType = 'submit';
						else if (this.reset == 0)
							inputType = 'reset';
						this.tagAtt('type', inputType);
						var sCapAKey = gx.util.accessKey(this.caption);
						this.caption = gx.util.accessKeyCaption(this.caption);
						if (sCapAKey == '') {
							sCapAKey = gx.util.accessKey(this.title);
							this.title = gx.util.accessKeyCaption(this.title);
						}
						if (sCapAKey != '')
							this.accessKey = sCapAKey;
						this.tagAtt('name', this.id);
						this.tagAtt('id', this.id);
						this.tagAtt('value', this.caption);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (this.accessKey != '')
							this.tagAtt('accesskey', this.accessKey);
						this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (!this.enabled)
							this.append(' disabled');
						this.append(gx.html.controls.onJsEventAttributes(this.jsScrCode, this.jsCode, this.usrOnclick));
						this.append(this.extraAttributes);
						if (gx.fn.controlFiresEvent(vStruct)) {
							this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
							this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext())
						}
						this.append('>');
						if (this.buttonStyle == 'rounded')
							this.append('</span></span></span></span>');
					}
				},

				grid: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.grid;
					this.containerName = '';

					this.setProperties = function (sContainerName) {
						this.containerName = sContainerName;
						this.id = this.grid.gxComponentContext + this.containerName + 'Div_' + this.gridRow;
					}

					this._getHtml = function () {
						this.append('<div');
						this.tagAtt('id', this.id);
						this.append('></div>');
					}
				},

				userControl: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.userControl;
					this.containerName = '';

					this.setProperties = function (sContainerName, nVisible) {
						this.containerName = sContainerName;
						this.id = this.containerName;
						this.visible = (nVisible != 0);
					}

					this._getHtml = function () {
						this.append('<div');
						this.tagAtt('id', this.id);
						this.tagAtt('class', gx.uc.gxCssClass);
						this.append('></div>');
						this.grid.addUsercontrolToDraw({ r: this.gridRow, c: this.column });
					}
				},

				userControlContainer: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.userControlContainer;
					this.parentName = '';
					this.containerName = '';

					this.setProperties = function (sParentName, sContainerName) {
						this.parentName = sParentName;
						this.containerName = sContainerName;
						this.id = this.parentName + this.containerName + '_' + this.gridRow;
					}

					this._getHtml = function () {
						this.append('<div');
						this.tagAtt('id', this.id);
						this.tagAtt('style', 'display:none;');
						this.tagAtt('class', 'gx_usercontrol_child');
						this.append('>');
					}
				},

				webComponent: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.webComponent;
					this.controlName = '';
					this.content = '';

					this.setProperties = function (sControlName) {
						this.controlName = sControlName;
						var cmpData = this.grid.parentObject.getComponentData(this.controlName);
						var cmpPrefix = cmpData.Prefix
						var cmpCtrlId = this.grid.gxComponentContext + 'gxHTMLWrp' + cmpPrefix + this.gridRow;
						var cmpCtrl = gx.dom.byId(cmpCtrlId);
						var cmpHtml = '';
						this.grid.addOldComponent(this.gridRow, this.grid.gxComponentContext + cmpPrefix + this.gridRow);
						if (cmpCtrl != null) {
							var hookId = cmpCtrlId + '_hook';
							this.grid.addComponentToDraw({ create: false, existingEl: hookId, el: cmpCtrlId, p: this.grid.gxComponentContext + cmpPrefix + this.gridRow });
							cmpCtrlId = hookId;
						}
						else {
							if (!gx.lang.emptyObject(gx.csv.lastEvtResponse) && !gx.lang.emptyObject(gx.csv.lastEvtResponse.gxComponents)) {
								var tmpHtml = gx.csv.lastEvtResponse.gxComponents[cmpCtrlId];
								if (!gx.lang.emptyObject(tmpHtml)) {
									cmpHtml = gx.html.cleanHtmlRefs(tmpHtml);
									var cmpName = gx.fn.getHidden(this.grid.gxComponentContext + cmpPrefix + this.gridRow);
									if (!cmpName)
										cmpName = cmpData.GXClass;
									if (!gx.lang.emptyObject(cmpName))
										this.grid.addComponentToDraw({ load: true, n: cmpName.toLowerCase(), p: this.grid.gxComponentContext + cmpPrefix + this.gridRow, c: tmpHtml });
								}
								else
									cmpHtml = '';
							}
						}
						this.id = cmpCtrlId;
						this.content = cmpHtml;
					}

					this._getHtml = function () {
						this.append('<div');
						this.tagAtt('id', this.id);
						this.tagAtt('class', gx.GxObject.WEBCOMPONENT_CLASS_NAME);
						this.append('>');
						this.append(this.content);
						this.append('</div>');
					}
				},

				embeddedPage: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.embeddedPage;
					this.align = 'center';
					this.scrollbars = 'auto';
					this.borderStyle = '1';

					this.setProperties = function (sControlName, sSrc, nVisible, nWidth, sWidthUnit, nHeight, sHeightUnit, nBorderStyle, sAlign, sTooltipText, sScroll) {
						this.id = sControlName;
						this.value = sSrc;
						this.visible = (nVisible != 0);
						this.width = nWidth;
						this.widthUnit = sWidthUnit;
						this.height = nHeight;
						this.heightUnit = sHeightUnit;
						this.borderStyle = nBorderStyle;
						this.align = sAlign;
						this.title = sTooltipText;
						this.scrollbars = sScroll;
					}

					this._getHtml = function () {
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						this.append('<iframe');
						this.tagAtt('frameborder', this.borderStyle);
						this.tagAtt('align', this.align);
						this.tagAtt('scrolling', this.scrollbars);
						if (this.height > 0)
							this.tagAtt('height', this.height + this.heightUnit);
						if (this.width > 0)
							this.tagAtt('width', this.width + this.widthUnit);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (this.id != '') {
							this.tagAtt('id', this.id);
							this.tagAtt('name', this.id);
						}
						if (this.value != '')
							this.tagAtt('src', this.value);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						this.append('>');
						this.append('</iframe>');
					}
				},

				table: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.table;
					this.cellSpacing = '';
					this.cellPadding = '';
					this.backColor = '';

					this.setProperties = function (sCtrlName, nVisible, sClassString, sBackground, nBackcolor, nBordercolor, sAlign, sTooltiptext,
																		nBorderwidth, nCellpadding, nCellspacing, nHeight, nWidth, sRules, sHeightUnit, sWidthUnit, sHeader) {
						this.id = sCtrlName;
						this.visible = (nVisible != 0);
						this.cssClass = sClassString;
						this.background = sBackground;
						this.backColor = nBackcolor;
						this.borderColor = nBordercolor;
						this.align = sAlign;
						this.title = sTooltiptext;
						this.borderWidth = nBorderwidth;
						this.cellPadding = nCellpadding;
						this.cellSpacing = nCellspacing;
						this.height = nHeight;
						this.width = nWidth;
						this.rules = sRules;
						this.heightUnit = sHeightUnit;
						this.widthUnit = sWidthUnit;
						this.style = "";
						this.header = sHeader;
					}

					this._getHtml = function () {
						var vStruct = this.getVStruct();
						this.style = this.style + ((this.visible) ? '' : ';display:none;');
						if (this.background != '') {
							this.background = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + this.background, true);
							this.style = this.style + 'background-image: url(' + this.background + ');';
						}
						if (this.backColor != '') {
							var col = parseInt(this.backColor);
							if (!isNaN(col))
								col = gx.color.html(col).Html;
							else
								col = this.backColor;
							this.style = this.style + 'background-color: ' + col + ';';
						}
						if (this.borderColor != '') {
							var col = parseInt(this.borderColor);
							if (!isNaN(col))
								col = gx.color.html(col).Html;
							else
								col = this.borderColor;
							this.style = this.style + 'border-color: ' + col + ';';
						}
						if (this.borderWidth != '')
							this.style = this.style + 'border-width: ' + this.borderWidth + ';';
						if (this.height != '')
							this.style = this.style + 'height: ' + this.height + this.heightUnit + ';';
						if (this.width != '')
							this.style = this.style + 'width: ' + this.width + this.widthUnit + ';';
						this.append('<table');
						this.tagAtt('id', this.id);
						this.tagAtt('align', this.align);
						if (this.borderWidth != '')
							this.tagAtt('border', this.borderWidth);
						if (this.cellSpacing !== '')
							this.tagAtt('data-cellspacing', this.cellSpacing);
						if (this.cellPadding !== '')
							this.tagAtt('data-cellpadding', this.cellPadding);
						if (this.rules != '' && this.rules != 'none')
							this.tagAtt('rules', this.rules);
						if (this.title != '')
							this.tagAtt('title', this.title);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (vStruct.evt) {
							this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
							this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext());
							this.tagAtt("tabindex", "0");
						}
						this.append('>');
						if (this.header != '') {
							this.append("<caption>");
							this.append(this.header);
							this.append("</caption>");
						}
					}
				},

				row: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.row;
					this.backColor = '';
					this.borderColor = '';
					this.align = '';
					this.verticalAlign = '';
					this.isFreestyleRow = false;
					this.oncontextmenu = '';

					this.setProperties = function (sCtrlName, sClassString, sStyleString) {
						if (sClassString) {
							if (this.ownCssClass) {
								this.cssClass = sClassString + (this.ownCssClass ? (' ' + this.ownCssClass) : '');
							}
							else {
								this.cssClass = sClassString;
							}
						}
						this.style = sStyleString;
					}

					this._getHtml = function () {
						this.append('<tr');
						if (this.id != '')
							this.tagAtt('id', this.id);
						if (this.isFreestyleRow)
							this.tagAtt('data-gxrow', this.gridRow);
						if (this.backColor != '')
							this.style = this.style + 'background-color:' + this.backColor + ';';
						if (this.borderColor != '')
							this.tagAtt('bordercolor', this.borderColor);
						if (this.align != '')
							this.tagAtt('align', this.align);
						if (this.verticalAlign != '')
							this.tagAtt('data-cell-valign', this.verticalAlign);
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (this.oncontextmenu != '')
							this.tagAtt('oncontextmenu', this.oncontextmenu);
						this.append('>');
					}
				},

				cell: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.cell;
					this.style = '';
					this.background = '';
					this.backColor = '';
					this.borderColor = '';
					this.align = '';
					this.verticalAlign = '';
					this.colSpan = '';
					this.rowSpan = '';
					this.className = "";

					this.setProperties = function (sBackground, sStyleString, sClassName) {
						this.background = sBackground;
						this.cssClass = sClassName;
						if (sStyleString && sStyleString != "") {
							var idx = sStyleString.indexOf('style=');
							if (idx > 0) {
								this.style = sStyleString.substring(8);
								this.style = this.style.substring(0, this.style.length - 1) + ';';
							}
						}
					}

					this._getHtml = function () {
						this.append('<td');
						if ((typeof (this.width) != 'undefined') && (this.width != 0))
							this.tagAtt('width', this.width);
						if ((typeof (this.height) != 'undefined') && (this.height != 0))
							this.tagAtt('height', this.height);
						if (this.background != '')
							this.tagAtt('background', this.background);
						if (this.backColor != '')
							this.style += 'background-color:' + this.backColor + ';';
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (this.borderColor != '')
							this.tagAtt('bordercolor', this.borderColor);
						if (this.align != '')
							this.tagAtt('align', this.align);
						if (this.verticalAlign != '')
							this.tagAtt('data-cell-valign', this.verticalAlign);
						if (this.colSpan != '')
							this.tagAtt('colspan', this.colSpan);
						if (this.rowSpan != '')
							this.tagAtt('rowspan', this.rowSpan);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						this.append('>');
					}
				},

				responsiveRow: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this._getHtml = function () {
						this.append('<div');
						if (this.id != '')
							this.tagAtt('id', this.id);
						if (this.isFreestyleRow)
							this.tagAtt('data-gxrow', this.gridRow);
						if (this.backColor != '')
							this.style = this.style + 'background-color:' + this.backColor + ';';
						if (this.borderColor != '')
							this.tagAtt('bordercolor', this.borderColor);
						if (this.align != '')
							this.tagAtt('align', this.align);
						if (this.verticalAlign != '')
							this.tagAtt('data-cell-valign', this.verticalAlign);
						if (this.style != '')
							this.tagAtt('style', this.style);
						this.tagAtt('class', "row " + (this.cssClass || ""));
						if (this.oncontextmenu != '')
							this.tagAtt('oncontextmenu', this.oncontextmenu);
						this.append('>');
					}
				},

				responsiveCell: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this._getHtml = function () {
						this.append('<div');
						if ((typeof (this.width) != 'undefined') && (this.width != 0))
							this.tagAtt('width', this.width);
						if ((typeof (this.height) != 'undefined') && (this.height != 0))
							this.tagAtt('height', this.height);
						if (this.background != '')
							this.tagAtt('background', this.background);
						if (this.backColor != '')
							this.style += 'background-color:' + this.backColor + ';';
						if (this.style != '')
							this.tagAtt('style', this.style);
						if (this.borderColor != '')
							this.tagAtt('bordercolor', this.borderColor);
						if (this.align != '')
							this.tagAtt('align', this.align);
						if (this.verticalAlign != '')
							this.tagAtt('data-cell-valign', this.verticalAlign);
						if (this.colSpan != '')
							this.tagAtt('colspan', this.colSpan);
						if (this.rowSpan != '')
							this.tagAtt('rowspan', this.rowSpan);
						this.tagAtt('class', "col-xs-12 " + (this.cssClass || ""));
						this.append('>');
					}
				},

				group: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.group;
					this.caption = '';

					this.setProperties = function (sCtrlName, sCaption, nVisible, nWidth, sWidthUnit, nHeight, sHeightUnit, sClassString, sTags) {
						this.id = sCtrlName;
						this.caption = sCaption;
						this.visible = (nVisible != 0);
						this.width = nWidth;
						this.widthUnit = sWidthUnit;
						this.height = nHeight;
						this.heightUnit = sHeightUnit;
						this.cssClass = sClassString;
						this.extraAtts = sTags;
					}


					this._getHtml = function () {
						this.append('<fieldset');
						this.tagAtt('id', this.id);
						this.tagAtt('name', this.id);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						var styleStr = '-moz-border-radius:3pt;';
						if (this.width != '0')
							styleStr += 'width: ' + this.width + this.widthUnit + ';';
						if (this.height != '0')
							styleStr += 'height: ' + this.height + this.heightUnit + ';';
						if (!this.visible)
							styleStr += 'display:none;';
						this.tagAtt('style', styleStr);
						if (this.extraAtts != '')
							this.append(this.extraAtts);
						this.append('>');
						this.append('<legend');
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass + 'Title');
						this.append('>');
						this.append(gx.getMessage(this.caption));
						this.append('</legend>');
					};
				},

				div: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.div;

					this.setProperties = function (sCtrlName, nVisible, nWidth, sWidthUnit, nHeight, sHeightUnit, sClassString, sAlign, sVAlign, sTags, sExtraStyle) {
						this.id = sCtrlName;
						this.visible = (nVisible != 0);
						this.width = nWidth;
						this.widthUnit = sWidthUnit;
						this.height = nHeight;
						this.heightUnit = sHeightUnit;
						this.cssClass = sClassString;
						this.align = sAlign;
						this.vAlign = sVAlign;
						this.extraAtts = sTags;
						this.extraStyle = sExtraStyle;
					}

					this._getHtml = function () {
						var vStruct = this.getVStruct(),
							hAlign = this.align && this.align.toLowerCase() != "left",
							vAlign = this.vAlign && this.vAlign.toLowerCase() != "top",
							style = ((this.visible) ? '' : ';display:none;');

						if (this.height != '')
							style = style + 'height: ' + this.height + this.heightUnit + ';';
						if (this.width != '')
							style = style + 'width: ' + this.width + this.widthUnit + ';';
						style = style + this.extraStyle;
						this.append('<div');
						if (this.id)
							this.tagAtt('id', this.id);
						if (this.cssClass != '')
							this.tagAtt('class', this.cssClass);
						if (style != '')
							this.tagAtt('style', style);
						if (this.extraAtts != '')
							this.append(this.extraAtts);
						if (hAlign)
							this.tagAtt('data-align', this.align.toLowerCase());
						if (vAlign)
							this.tagAtt('data-valign', this.vAlign.toLowerCase());
						if (gx.fn.controlFiresEvent(vStruct)) {
							this.tagAtt(gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, vStruct.fld);
							this.tagAtt(gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, this.getEventContext());
							this.tagAtt("tabindex", "0");
						}
						this.append('>');
						if (hAlign || vAlign)
							this.append('<div data-align-outer=""><div data-align-inner="">');
					}
				},

				divEnd: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.divEnd;

					this.setProperties = function (sAlign, sVAlign) {
						this.align = sAlign;
						this.vAlign = sVAlign;
					}

					this._getHtml = function () {
						var hAlign = this.align && this.align.toLowerCase() != "left",
							vAlign = this.vAlign && this.vAlign.toLowerCase() != "top";
						if (hAlign || vAlign)
							this.append('</div></div>');
						this.append('</div>');
					}
				},

				formGroup: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.formGroup;

					this.setProperties = function (captionPosition) {
						this.captionPosition = captionPosition;
					}

					this._getHtml = function () {
						if (this.captionPosition === 1) {
							this.append('<div class="form-group gx-form-group">');
						}
					}
				},

				formGroupEnd: function (id, width, height, cssClass, title) {
					this.base(id, width, height, cssClass, title);

					this.type = gx.html.controls.types.formGroupEnd;

					this.setProperties = function (captionPosition) {
						this.captionPosition = captionPosition;
					}

					this._getHtml = function () {
						if (this.captionPosition === 1) {
							this.append('</div>');
						}
					}
				},

				specificDomainCtrls: function (Ctrl) {
					if (Ctrl.domainName == gx.domains.component && Ctrl.enabled == 0) {
						var displayProperty = (Ctrl.enabled) ? ';display:none;' : '';
						var compId = Ctrl.id + '_comp_trigger';
						var componentImg = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + "Resources\\" + gx.theme + "\\Select.png", false);
						Ctrl.append('<img');
						Ctrl.tagAtt('src', componentImg);
						Ctrl.tagAtt('id', compId);
						Ctrl.tagAtt('class', '');
						Ctrl.tagAtt('style', displayProperty + " margin-left:2px; cursor:pointer;");
						Ctrl.tagAtt('onclick', "gx.popup.openUrl('" + Ctrl.value + "')");
						Ctrl.append('/>');

						var Deps = [];
						Deps.push(Ctrl.column.gxId);
						//gx.fn.attachCtrl(compId, {isPrompt:false, wc:gx.O.CmpContext, mp:gx.O.IsMasterPage, controls:Deps} );
					}
					else {
						if (Ctrl.dataType == gx.types.geolocation) {
							var displayProperty = (!Ctrl.enabled) ? ';display:none;' : '';							
							var geoLocMeId = Ctrl.id + '_geoLocMe';
							Ctrl.append('<img');
							Ctrl.tagAtt('src', gx.ajax.getImageUrl(gx, 'myLocationImage'));
							Ctrl.tagAtt('id', geoLocMeId);
							Ctrl.tagAtt('class', 'GeoLocOption');
							Ctrl.tagAtt('style', displayProperty);
							Ctrl.tagAtt('onclick', 'gx.geolocation.getMyPosition(this)');
							Ctrl.append('>');

							var Deps = [];
							Deps.push(Ctrl.column.gxId);
							//gx.fn.attachCtrl(geoLocMeId, {isPrompt:false, wc:gx.O.CmpContext, mp:gx.O.IsMasterPage, controls:Deps} );
							/*this.append('<img');
							this.tagAtt('src', 'Resources\\locatePoint.png');
							this.tagAtt('id', this.id + '_geoLocPoint');
							this.tagAtt('class', 'GeoLocOption');	
							this.tagAtt('onclick', 'gx.geolocation.locatePoint(this,"' + this.id + '")');
							this.append('>') ;*/
						}
					}
				},

				_init: function () {
					gx.lang.inherits(this.singleLineEdit, this.htmlControl);
					gx.lang.inherits(this.multipleLineEdit, this.singleLineEdit);
					gx.lang.inherits(this.blob, this.htmlControl);
					gx.lang.inherits(this.radio, this.htmlControl);
					gx.lang.inherits(this.comboBox, this.htmlControl);
					gx.lang.inherits(this.listBox, this.comboBox);
					gx.lang.inherits(this.checkBox, this.htmlControl);
					gx.lang.inherits(this.imageReadOnly, this.htmlControl);
					gx.lang.inherits(this.textBlock, this.htmlControl);
					gx.lang.inherits(this.button, this.htmlControl);
					gx.lang.inherits(this.grid, this.htmlControl);
					gx.lang.inherits(this.userControl, this.htmlControl);
					gx.lang.inherits(this.userControlContainer, this.htmlControl);
					gx.lang.inherits(this.webComponent, this.htmlControl);
					gx.lang.inherits(this.embeddedPage, this.htmlControl);
					gx.lang.inherits(this.table, this.htmlControl);
					gx.lang.inherits(this.row, this.htmlControl);
					gx.lang.inherits(this.cell, this.htmlControl);
					gx.lang.inherits(this.group, this.htmlControl);
					gx.lang.inherits(this.multimedia, this.htmlControl);
					gx.lang.inherits(this.image, this.multimedia);
					gx.lang.inherits(this.video, this.multimedia);
					gx.lang.inherits(this.file, this.multimedia);
					gx.lang.inherits(this.audio, this.multimedia);
					gx.lang.inherits(this.div, this.htmlControl);
					gx.lang.inherits(this.divEnd, this.htmlControl);
					gx.lang.inherits(this.responsiveRow, this.row);
					gx.lang.inherits(this.responsiveCell, this.cell);
					gx.lang.inherits(this.label, this.htmlControl);
					gx.lang.inherits(this.formGroup, this.htmlControl);
					gx.lang.inherits(this.formGroupEnd, this.htmlControl);
				}
			};
		})()
	};
})(gx.$);
/* END OF FILE - ..\js\gxhtml.js - */
/* START OF FILE - ..\GenCommon\js\util\observable.js - */
gx.util.Observable = function(){
	return {
		observers: [],
		initialObservers: [],
		
		addObserver: function( evtName, obj, func, cfg) {
			new gx.thread.Mutex( this, this.addObserverSync, arguments);
		},
		
		addObserverSync: function( evtName, obj, func, cfg) {
			cfg = cfg || {};
			if (cfg.unique === false || this.indexOf( evtName, obj, func) < 0)
			{
				this.observers.push({
					e:evtName, 
					o:obj, 
					f:func, 
					cfg: cfg
				});
				if (cfg.doNotDelete === true) {
					this.initialObservers.push({
						e:evtName, 
						o:obj, 
						f:func, 
						cfg: cfg
					});
				}
			}
		},
		
		deleteObserver: function( evtName, obj, func) {
			new gx.thread.Mutex( this, this.deleteObserverSync, [evtName, obj, func]);
		},
		
		deleteObserverSync: function( evtName, obj, func) {
			var idx = this.indexOf( evtName, obj, func);
			if (idx >= 0)
			{
				this.observers.splice(idx, 1);
			}
		},
		
		removeAll: function() {
			this.observers = this.initialObservers.slice();
		},
		
		indexOf: function( evtName, obj, func) {
			var len = this.observers.length;
			for (var i=0; i<len; i++)
			{
				var obs = this.observers[i];
				if (obs && obs.e == evtName && obs.o == obj && obs.f == func)
				{
					return i;
				}
			}
			return -1;
		},
		
		notify_count: 0,

		notify: function( evtName, parms, callback) {
			if (!parms) {
				parms = [];
			}
			var len = this.observers.length;
			this.notify_count += 1;
			var promises = [];
			var returnedValue;
			for (var i=0; i<len; i++) {
				var obs = this.observers[i];
				if (obs && obs.e == evtName && !obs.removed) {
					try {
						if (obs.cfg && obs.cfg.single) {
							obs.removed = true;
						}
						returnedValue = obs.f.apply(obs.o, parms);
						if (obs.cfg && obs.cfg.async) {
							// If an observer is async, it must return a promise
							promises.push(returnedValue);
						}
					}
					catch(e) {
						gx.dbg.logEx(e, 'gxfx.js', 'gx.obs.notify');
					}
				}
			}
			gx.$.when.apply($, promises).then((function () {
				this.notify_count -= 1;
				if (this.notify_count === 0) {
					for (var i=this.observers.length-1; i>=0; i--) {
						if (this.observers[i].removed) {
							this.observers.splice(i, 1);
						}
					}
				}
				if (callback) {
					callback();
				}
			}).closure(this));
		}
	};
};
/* END OF FILE - ..\GenCommon\js\util\observable.js - */
/* START OF FILE - ..\js\gxfx.js - */
gx.fx = {
	GX_DATA_SUGGEST_LENGTH: 'data-gx-suggest-length',
	GX_DATA_SUGGEST: 'data-gx-suggest',

	delayedSuggest: function () {		
		gx.$.each(gx.suggestControls, function (id, Control) {				
			gx.fx.installSuggest(Control, true);			
		});
	},

	installSuggest: function (Ctrl, force) {
		if (!force && document.readyState && document.readyState != "complete") {
			gx.suggestControls[Ctrl.id] = Ctrl;
			return;
		}
		try {
			var vStruct = gx.O.getValidStructFld(Ctrl.id);
			if (vStruct && !gx.lang.emptyObject(vStruct.gxsgprm)) {
				var rowId = (vStruct.grid > 0) ? gx.fn.currentGridRowImpl(vStruct.grid) : 'main';
				var gxsgprm = vStruct.gxsgprm;
				if (!gxsgprm.installed) {
					gxsgprm.installed = {};
				}
				if (!gxsgprm.installed[rowId]) {
					gx.ajax.suggest(gx.O, gxsgprm[1], Ctrl.id, gxsgprm[0], gxsgprm[3], gxsgprm[2]);
					gxsgprm.installed[rowId] = true;
					$(Ctrl).attr(gx.fx.GX_DATA_SUGGEST, 'true');
					$(Ctrl).attr(gx.fx.GX_DATA_SUGGEST_LENGTH, $(Ctrl).val().length);
				}
			}
		}
		catch (e) {
			gx.dbg.logEx(e, 'gxfx.js', 'installSuggest');
		}
	},

	updateSuggestParms: function (suggestParms) {
		if (suggestParms) {
			var len = suggestParms.length;
			for (var i = 0; i < len; i++) {
				var validStruct = gx.fn.validStruct(suggestParms[i]);
				if (validStruct && typeof (validStruct.c2v) == 'function')
					validStruct.c2v();
			}
		}
	},

	firesuggest: function (context, provider, typeahead, suggestParms) {
		this.updateSuggestParms(suggestParms);
		if (context.textbox.value) {
			return provider.requestSuggestions(context.sdtParms, function () {
				if (provider.values)
					context.autosuggest(provider.values, typeahead);
				else
					context.hideSuggestions();
				delete gx.fx.delayedValidation;
				gx.fx.obs.notify('gx.validation');
			});
			
		}
		if (context.textbox.value === "")
		{
			gx.evt.onchange_impl(context.textbox);
		}
		delete gx.fx.delayedValidation;
		gx.fx.obs.notify('gx.validation');
	},

	autoSuggestControl: function (oTextbox, oProvider, ControlRefresh, typeahead, suggestParms, sdtparms) {
		this.cur = -1;
		this.IFrameControl = null;
		this.layer = null;
		this.provider = oProvider;
		this.textbox = oTextbox;
		if (typeof (this.textbox.GXonblur) == 'undefined') this.textbox.GXonblur = oTextbox.onblur;
		this.ControlRefresh = ControlRefresh;
		this.typeahead = typeahead;
		this.suggestParms = suggestParms || [];
		this.sdtParms = sdtparms || [];

		this.requestSuggestions = function (context, provider, typeahead) {
			gx.fx.delayedValidation = true;
			var suggestParms = this.suggestParms;
			if (this.timer)
				window.clearTimeout(this.timer);
			this.timer = window.setTimeout(function () { gx.fx.firesuggest(context, provider, typeahead, suggestParms) }, 400);
		}

		this.hideSuggestions = function () {
			$(this.IFrameControl).hide();
			$(this.layer).hide();
		}

		this.highlightSuggestion = function (oSuggestionNode) {
			var len = this.layer.childNodes.length;
			for (var i = 0; i < len; i++) {
				var oNode = this.layer.childNodes[i];
				if (oNode == oSuggestionNode) {
					oNode.className = 'current';
				}
				else if (oNode.className == 'current') {
					oNode.className = '';
				}
			}
		}

		this.init = function () {
			var onkeyup = function (oEvent) {
				if (!oEvent) {
					oEvent = window.event;
				}
				this.handleKeyUp(oEvent);
			};

			var onkeydown = function (oEvent) {
				if (!oEvent) {
					oEvent = window.event;
				}
				this.handleKeyDown(oEvent);
			};

			var onblur = function () {
				this.hideSuggestions();
				this.textbox.GXonblur();
			};

			gx.evt.attach(this.textbox, "keyup", onkeyup.closure(this));
			gx.evt.attach(this.textbox, "keydown", onkeydown.closure(this));
			gx.evt.attach(this.textbox, "blur", onblur.closure(this));

			// This is a WA for a Firefox bug: https://bugzilla.mozilla.org/show_bug.cgi?id=354358
			if (gx.util.browser.isFirefox()) {
				gx.evt.attach(this.textbox, "input", onkeyup.closure(this));
			}

			this.createDropDown();
		}

		this.nextSuggestion = function () {
			var cSuggestionNodes = this.layer.childNodes;
			if (cSuggestionNodes.length > 0) {
				this.cur = (this.cur < cSuggestionNodes.length - 1) ? this.cur + 1 : 0;
				var oNode = cSuggestionNodes[this.cur];
				this.highlightSuggestion(oNode);
				this.pickvalue(oNode.firstChild.nodeValue);
			}
		}

		this.previousSuggestion = function () {
			var cSuggestionNodes = this.layer.childNodes;
			if (cSuggestionNodes.length > 0) {
				this.cur = (this.cur > 0) ? this.cur - 1 : cSuggestionNodes.length - 1;
				var oNode = cSuggestionNodes[this.cur];
				this.highlightSuggestion(oNode);
				this.pickvalue(oNode.firstChild.nodeValue);
			}
		}

		this.selectRange = function (iStart /*:int*/, iLength /*:int*/) {
			if (this.textbox.createTextRange) {
				var oRange = this.textbox.createTextRange();
				oRange.moveStart('character', iStart);
				oRange.moveEnd('character', iLength - this.textbox.value.length);
				oRange.select();
			}
			else if (this.textbox.setSelectionRange) {
				this.textbox.setSelectionRange(iStart, iLength);
			}
			if (gx.csv.stopOnError)
				this.textbox.focus();
		}

		this.showSuggestions = function (aSuggestions) {
			this.cur = -1;
			var oDiv = null;

			this.setupLayer();
			if (gx.dom.shouldPurge())
				gx.dom.purge(this.layer, true);
			this.layer.innerHTML = '';

			if (!this.IFrameControl) {
				var justCreated = false;
				var ifrId = 'gxAutosuggestIFrame';
				this.IFrameControl = gx.dom.byId(ifrId);
				if (!this.IFrameControl) {
					justCreated = true;
					this.IFrameControl = document.createElement('IFRAME');
					this.IFrameControl.src = 'about:blank';
					this.IFrameControl.id = ifrId;
				}
				var $frame = $(this.IFrameControl);
				$frame.css({
							zIndex: 1, 
							display: 'none', 
							position: 'absolute'
				});				
				this.IFrameControl.frameBorder = '0';
				if (justCreated) {
					document.body.appendChild(this.IFrameControl);
				}
			}
			var len = aSuggestions.length;
			for (var i = 0; i < len; i++) {
				oDiv = document.createElement('div');
				oDiv.appendChild(document.createTextNode(aSuggestions[i].d));
				oDiv.style.width = this.textbox.offsetWidth;
				this.layer.appendChild(oDiv);
			}
			this.layer.style.left = this.getLeft() + 'px';
			this.layer.style.top = (this.getTop() + this.textbox.offsetHeight) + 'px';			
			this.layer.style.zIndex = 2;
			
			this.IFrameControl.style.top = this.layer.style.top;
			this.IFrameControl.style.left = this.layer.style.left;
			this.IFrameControl.style.height = this.layer.offsetHeight;
			this.IFrameControl.style.width = this.layer.offsetWidth;			
			$([this.IFrameControl, this.layer]).show();			
		}

		this.typeAhead = function (sSuggestion) {
			if (this.textbox.createTextRange || this.textbox.setSelectionRange) {
				var iLen = this.textbox.value.length;
				this.pickvalue(sSuggestion);
				var sLen = sSuggestion.length;
				if (iLen < sLen)
					this.selectRange(iLen, sLen);
			}
		}

		this.pickvalue = function (Value, raiseInput) {
			var len = this.aSuggestions.length;
			for (var i = 0; i < len; i++) {
				if (this.aSuggestions[i].d == Value) {
					this.textbox.value = Value;
					if (raiseInput === true)
					{
						gx.evt.fireEvent( this.textbox, 'input');
					}
					gx.evt.onchange_impl(this.textbox, undefined, true);
					return;
				}
			}
		}

		this.autosuggest = function (aSuggestions, bTypeAhead) {
			this.aSuggestions = aSuggestions;
			var sLen = this.aSuggestions.length;
			if (bTypeAhead && this.aSuggestions != null && sLen == 1) {
				this.typeAhead(this.aSuggestions[0].d);
				this.hideSuggestions();
			}
			else {
				if (this.textbox == gx.csv.lastControl && this.aSuggestions != null && sLen > 0) {
					if ((sLen == 1) && (this.aSuggestions[0].d != this.textbox) || (sLen > 1)) {
						this.showSuggestions(this.aSuggestions);
						return;
					}
				}
				this.hideSuggestions();
			}
		}

		this.createDropDown = function () {
			var ddId = 'gxAutosuggestElement';
			var justCreated = false;

			this.layer = gx.dom.byId(ddId);
			if (!this.layer) {
				justCreated = true;
				this.layer = document.createElement('div');
				this.layer.className = 'suggestions';
				this.layer.id = ddId;
			}
			this.setupLayer();
			if (justCreated) {
				document.body.appendChild(this.layer);
			}
		}

		this.setupLayer = function () {
			$(this.layer).hide();
			if (this.textbox.offsetWidth) {
				$(this.layer).width(this.textbox.offsetWidth);
			}
			this.layer.onmousedown =
			this.layer.onmouseup =
			this.layer.onmouseover = (function (oEvent) {
				oEvent = oEvent || window.event;
				var oTarget = gx.evt.source(oEvent);

				if (oEvent.type == 'mousedown') {
					gx.evt.cancel(oEvent, true);
					this.pickvalue(oTarget.firstChild.nodeValue, true);
					this.hideSuggestions();
					window.setTimeout(function () { gx.fn.setFocus(this.textbox) }, 100);
				}
				else if (oEvent.type == 'mouseover') {
					this.highlightSuggestion(oTarget);
				}
				else {
					this.textbox.focus();
				}
			}).closure(this);
		}

		this.getLeft = function () {
			var oNode = this.textbox;
			var iLeft = 0;

			while (oNode != null && oNode.tagName != 'BODY') {
				iLeft += oNode.offsetLeft;
				oNode = oNode.offsetParent;
			}
			oNode = this.textbox;
			while (oNode != null && oNode.tagName != 'BODY') {
				iLeft -= oNode.scrollLeft;
				oNode = oNode.parentNode;
			}
			return iLeft;
		}

		this.getTop = function () {
			var oNode = this.textbox;
			var iTop = 0;

			while (oNode != null && oNode.tagName != 'BODY') {
				iTop += oNode.offsetTop;
				oNode = oNode.offsetParent;
			}
			oNode = this.textbox;
			while (oNode != null && oNode.tagName != 'BODY') {
				iTop -= oNode.scrollTop;
				oNode = oNode.parentNode;
			}
			return iTop;
		}

		this.handleKeyDown = function (oEvent) {
			switch (oEvent.keyCode) {
			case 38://up arrow
				this.previousSuggestion();
				break;
			case 40: //down arrow 
				this.nextSuggestion();
				break;
			case 13: //enter
				this.hideSuggestions();
				break;
			}
		}

		this.handleKeyUp = function (oEvent /*:Event*/) {
			var iKeyCode = oEvent.keyCode;

			if (iKeyCode == 9) {
				this.hideSuggestions();
			}
			else {
				if (iKeyCode == 8 || iKeyCode == 46) {
					this.requestSuggestions(this, this.provider, false);
				}
				else {
					if (!(iKeyCode < 32 || (iKeyCode >= 33 && iKeyCode < 46) || (iKeyCode >= 112 && iKeyCode <= 123))) {
						this.requestSuggestions(this, this.provider, this.typeahead);
					}
					else {
						if (iKeyCode === 0) {						
							var length = this.textbox.value.length,
								lastLength = parseInt($(this.textbox).attr(gx.fx.GX_DATA_SUGGEST_LENGTH) || '0', 10);	
							if (length !== lastLength) {												
								this.requestSuggestions(this, this.provider, this.typeahead);
							}
						}
					}
				}
			}
			$(this.textbox).attr(gx.fx.GX_DATA_SUGGEST_LENGTH, this.textbox.value.length);
		}

		this.init();
	},

	suggestProvider: function (gxO, ControlId, ControlRefresh, CtrlSvc) {
		this.requestSuggestions = function (sdtParms, callback, failCallback, query) {
			var i,
				sURL = gx.ajax.gxObjectUrl(gxO) + '?',
				sParms = 'gxajaxSuggest_' + CtrlSvc,
				len = ControlId.length;

			for (i = 0; i < len; i++)
			{
				sParms += ',' + encodeURIComponent(gx.fn.evalCtxScope(gxO, ControlId[i]));
			}
			sParms += ',' + encodeURIComponent(query === undefined ? gx.fn.getControlValue_impl(ControlRefresh) : query);
			len = sdtParms.length;
			for (i = 0; i < len; i++)
			{
				sParms += ',' + encodeURIComponent(gx.fn.evalCtxScope(gxO, sdtParms[i]));
			}
			sURL += gx.ajax.encryptParms(gxO, sParms);
			
			gx.http.doCall({
				method: 'GET',
				url: sURL,
				handler: function(type, responseText) {
					var response = gx.json.evalJSON(responseText);
					this.values = gx.fx.returnSuggestValues(this.VarRefresh, response[0]);
					callback();
				},
				error: failCallback,
				obj: this
			});
		}
	},

	returnSuggestValues: function (Var, adata) {
		return adata;
	},

	addElement: function (arr, el, mindTypes) {
		if (this.elementExists(arr, el, mindTypes))
			return;
		var hashId = el.id;
		if (mindTypes === true)
			hashId += el.types.sort().join('');
		arr.splice(0, 0, el);
		arr[hashId] = el;
	},

	elementExists: function (arr, el, mindTypes) {
		var hashId = el.id;
		if (mindTypes === true)
			hashId += el.types.sort().join('');
		if (arr[hashId])
			return true;
		return false;
	},

	deleteElement: function (arr, ctrlId, types) {
		var hashId = ctrlId;
		if (types)
			hashId += types.sort().join('');
		var element = arr[hashId];
		if (element)
			delete arr[hashId];
		var len = arr.length;
		for (var i = 0; i < len; i++) {
			var curElem = arr[i];
			if (curElem.id == ctrlId) {
				if (types) {
					if (this.matchingTypes(types, curElem.types)) {
						arr.splice(i, 1);
						break;
					}
				}
				else {
					arr.splice(i, 1);
					break;
				}
			}
		}
		return arr;
	},

	matchingTypes: function (src, tgt) {
		var tLen = tgt.length;
		for (var i = 0; i < tLen; i++) {
			var found = false;
			var sLen = src.length;
			for (var j = 0; j < sLen; j++) {
				if (tgt[i].toLowerCase() == src[j].toLowerCase())
					found = true;
			}
			if (!found)
				return false;
		}
		return true;
	},

	findControl: function (evtCtrl, gxObj, ctrlId, findRONodes) {
		var ctrl = gx.dom.el(ctrlId);
		if (ctrl != null && $(ctrl).css('display') !== 'none') {
			return ctrl;
		}
		ctrl = gx.fn.getRONode(ctrlId, false);
		if (findRONodes && ctrl != null && $(ctrl).is(':visible')) {			
			return ctrl;
		}
		ctrl = gx.dom.el('gxHTMLWrp' + ctrlId);
		if (ctrl != null)
			return ctrl;

		if (findRONodes && !evtCtrl.id && evtCtrl.tagName === "A") 
			evtCtrl = evtCtrl.parentNode;
		var GRID_CTRL_PATTERN = '(^' + ((findRONodes)? '(' + gx.fn.getRONodePrefix() + ')?': '') + 'v?' + ctrlId + '_(?:(?:[0-9]){4})+$)';		
		var cRegex = new RegExp(GRID_CTRL_PATTERN);
		if (evtCtrl != null && cRegex.test(evtCtrl.id))
			return evtCtrl;
		return null;
	},

	isUnderMouse: function (Control) {
		var mx = gx.evt.mouse.x;
		var my = gx.evt.mouse.y;
		var targPos = gx.dom.position(Control);
		var targDims = gx.dom.dimensions(Control);
		if ((mx >= targPos.x) && (mx <= (targPos.x + targDims.w)) && (my >= targPos.y) && (my <= (targPos.y + targDims.h)))
			return true;
		else if (Control.tagName == "DIV" && targDims.w === 0 && targDims.h === 0 && Control.firstChild)//Textblocks with HTML Format are in a inline div
		{
			targPos = gx.dom.position(Control.firstChild);
			targDims = gx.dom.dimensions(Control.firstChild);
			if ((mx >= targPos.x) && (mx <= (targPos.x + targDims.w)) && (my >= targPos.y) && (my <= (targPos.y + targDims.h)))
				return true;
		}
		return false;
	},

	dom: {
		generics: [],
		dblclicks: [],

		getEventHandlers: function (evtType) {
			if (evtType == 'dblclick') {
				return this.dblclicks;
			}
			return this.generics;
		},

		addEventHandler: function (gxObj, evtType, ctrlId, handler) {
			ctrlId = gx.lang.emptyObject(gxObj) ? ctrlId : gxObj.CmpContext + ctrlId;
			var evtHandler = {
				id: evtType + ctrlId,
				cId: ctrlId,
				type: evtType,
				obj: gxObj,
				hdl: handler
			};
			var handlers = this.getEventHandlers(evtType);
			gx.fx.addElement(handlers, evtHandler, false);
		},

		deleteEventHandlers: function (gxObj) {
			var handlertypes = [this.dblclicks, this.generics];
			var lenj = handlertypes.length;
			for (var j = 0; j < lenj; j++) {
				var handlersToDelete = [];
				var handlers = handlertypes[j];
				var len = handlers.length;
				for (var i = 0; i < len; i++) {
					var evtHandler = handlers[i];
					if (evtHandler.obj == gxObj)
						handlersToDelete.push(evtHandler);
				}
				len = handlersToDelete.length;
				for (var k = 0; k < len; k++) {
					gx.fx.deleteElement(handlers, handlersToDelete[k].id)
				}
			}
		},

		hasEventHandler: function (evtType, evtObj) {
			var evtCtrl = gx.evt.source(evtObj),
				handlers = this.getEventHandlers(evtType),
				len = handlers.length,
				hasEvtHandler = false;
			for (var i = 0; i < len && !hasEvtHandler; i++) {
				var evtHandler = handlers[i];
				var ctrl = gx.fx.findControl(evtCtrl, evtHandler.obj, evtHandler.cId, true);
				if (ctrl != null) {
					hasEvtHandler = evtObj.currentTarget === ctrl || gx.fx.isUnderMouse(ctrl);
				}
			}
			return hasEvtHandler;
		},
		
		delayedDispatch: function (domEvt) {
			return gx.fx.dom.hasEventHandler('dblclick', domEvt);
		},
		

		raiseEvent: function (evtType, evtObj) {
			var evtCtrl = gx.evt.source(evtObj),
				$evtCtrl = $(evtCtrl),
				attDelayedName = gx.GxObject.GX_EVENT_CONTROL_DELAYED_ATTR;

			if (evtType == 'dblclick') {		
				clearTimeout(parseInt($evtCtrl.attr(attDelayedName), 10));
				$evtCtrl.removeAttr(attDelayedName);
			}

			var handlers = this.getEventHandlers(evtType);
			var len = handlers.length;
			for (var i = 0; i < len; i++) {
				var evtHandler = handlers[i];
				var ctrl = gx.fx.findControl(evtCtrl, evtHandler.obj, evtHandler.cId, true);
				if (ctrl != null) {
					if (gx.fx.isUnderMouse(ctrl)) {
						evtHandler.hdl.call(evtHandler.obj);
					}
				}
			}
		},

		highlight: function (control, color, time) {
			var gxColor = gx.color.fromRGB(color[0], color[1], color[2]);
			var oldColor = gx.dom.getStyle(control, 'backgroundColor');
			var wasTransparent = (oldColor == 'transparent' || oldColor == 'rgba(0, 0, 0, 0)');
			return {
				play: function () {
					control.style.backgroundColor = gxColor.Html;
					setTimeout(this.end, time);
				},

				end: function () {
					var endColor = oldColor;
					if (wasTransparent) {
						endColor = 'transparent';
					}
					control.style.backgroundColor = endColor;
				}
			};
		}
	},

	obs: new gx.util.Observable(),

	dnd: {
		obj: null,
		dragCtrl: null,
		clonCtrl: null,
		sources: [],
		targets: [],
		dropCtrl: null,
		noDropCtrl: null,
		toHdl: null,

		drag: function (gxObj, types, handler) {
			if (handler) {
				gx.evt.setEventRow(gxObj, this.dragCtrl);
				this.obj = handler.call(gxObj, this.dragCtrl);
				this.obj.gxDragTypes = types;
			}
		},

		drop: function (ctrl, gxObj, handler) {
			if (handler)
				handler.call(gxObj, ctrl, this.dragCtrl, this.obj);
		},

		noDrop: function () {
			var ctrl = this.noDropCtrl;
			if (ctrl != null) {
				if (ctrl.gxDndClassName)
					ctrl.className = ctrl.gxDndClassName + 'NoAcceptDrag';
			}
		},

		out: function () {
			var ctrl = this.dropCtrl;
			if (ctrl) {
				if (ctrl.gxClassName)
					ctrl.className = ctrl.gxClassName;
			}
			this.dropCtrl = null;
			ctrl = this.noDropCtrl;
			if (ctrl != null) {
				if (ctrl.gxClassName)
					ctrl.className = ctrl.gxClassName;
			}
			this.noDropCtrl = null;
		},

		over: function () {
			var ctrl = this.dropCtrl;
			if (ctrl != null) {
				if (ctrl.gxDndClassName)
					ctrl.className = ctrl.gxDndClassName + 'AcceptDrag';
			}
		},

		deleteClonControl: function () {
			if (this.clonCtrl != null)
				gx.dom.removeControlSafe(this.clonCtrl);
			this.clonCtrl = null;
		},

		restoreControl: function () {
			var ctrl = this.clonCtrl;
			if (ctrl != null) {
				if (this.toHdl == null) {
					ctrl.dropLeft = parseFloat(ctrl.style.left || '0');
					ctrl.dropTop = parseFloat(ctrl.style.top || '0');
					this.toHdl = setInterval('gx.fx.dnd.restoreControl()', 2);
				}
				if (this.controlRestored()) {
					clearInterval(this.toHdl);
					this.toHdl = null;
					this.deleteClonControl();
				}
				else {
					var newCoords = this.nextCoords();
					this.moveDragControl(newCoords.X, newCoords.Y);
				}
			}
		},

		nextCoords: function () {
			var ctrl = this.clonCtrl;
			var X = parseFloat(ctrl.style.left || '0');
			var Y = parseFloat(ctrl.style.top || '0');
			var diffX = 0;
			var diffY = 0;
			if (X >= Y) {
				diffX = X - 1;
				diffY = ctrl.dropTop - (((ctrl.dropTop - ctrl.originalTop) * (ctrl.dropLeft - diffX)) / (ctrl.dropLeft - ctrl.originalLeft));
			}
			else {
				diffY = Y - 1;
				diffX = ctrl.dropLeft - (((ctrl.dropTop - diffY) * (ctrl.dropLeft - ctrl.originalLeft)) / (ctrl.dropTop - ctrl.originalTop));
			}
			if (diffX <= ctrl.originalLeft)
				diffX = ctrl.originalLeft;
			if (diffY <= ctrl.originalTop)
				diffY = ctrl.originalTop;
			return { X: diffX, Y: diffY };
		},

		moveControl: function (Control) {
			if (this.clonCtrl == null) {
				var offset = 10;
				var ctrl = document.createElement("DIV");
				ctrl.style.position = "absolute";
				if (Control.gxDndClassName)
					ctrl.className = Control.gxDndClassName + 'Dragging';
				if (gx.dom.shouldPurge())
					gx.dom.purge(ctrl, true);
				ctrl.innerHTML = this.dragInfo();
				gx.fn.setOpacity(50, ctrl);
				document.body.appendChild(ctrl);
				ctrl.originalLeft = gx.evt.mouse.x - offset;
				ctrl.originalTop = gx.evt.mouse.y - offset;
				ctrl.diffLeft = offset;
				ctrl.diffTop = offset;
				this.clonCtrl = ctrl;
			}
			this.moveDragControl(gx.evt.mouse.x, gx.evt.mouse.y);
		},

		controlRestored: function () {
			var ctrl = this.clonCtrl;
			if (ctrl == null)
				return true;
			var X = parseFloat(ctrl.style.left || '0');
			var Y = parseFloat(ctrl.style.top || '0');
			var diffX = X - ctrl.originalLeft;
			var diffY = Y - ctrl.originalTop;
			if ((diffX <= 0) && (diffY <= 0))
				return true;
			return false;
		},

		moveDragControl: function (X, Y) {
			try {
				var ctrl = this.clonCtrl;
				if (ctrl != null) {
					ctrl.style.left = (X - ctrl.diffLeft) + 'px';
					ctrl.style.top = (Y - ctrl.diffTop) + 'px';
				}
			}
			catch (e) {
				this.deleteClonControl();
			}
		},

		dragInfo: function () {
			if (this.obj != null) {
				var lines = '';
				var dragStr = '';
				for (var prop in this.obj) {
					if (prop != "gxDragTypes") {
						var Lines = [lines];
						if (typeof (this.obj[prop]) == 'function')
							continue;
						dragStr += prop + ': ' + this.obj[prop] + '</br>';
						lines = Lines[0];
					}
					if (lines >= 5) {
						dragStr += '...';
						break;
					}
					lines++;
				}
				return dragStr;
			}
			return '';
		},

		deleteHandlers: function (gxObj) {
			gx.thread.Mutex(this, this.deleteHandlersSync, [gxObj]);
		},

		deleteHandlersSync: function (gxObj) {
			var tmp = [];
			var i;
			var len = this.sources.length;
			for (i = 0; i < len; i++) {
				var source = this.sources[i];
				if (source.obj != gxObj)
					tmp.push(source);
			}
			this.sources = tmp;
			tmp = [];
			len = this.targets.length;
			for (i = 0; i < len; i++) {
				var target = this.targets[i];
				if (target.obj != gxObj)
					tmp.push(target);
			}
			this.targets = tmp;
		},

		addSource: function (gxObj, ctrlId, cClass, dTypes, handler) {
			gx.thread.Mutex(this, this.addSourceSync, [gxObj, ctrlId, cClass, dTypes, handler]);
		},

		addSourceSync: function (gxObj, ctrlId, cClass, dTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj) ? ctrlId : gxObj.CmpContext + ctrlId;
			var dragSource = {
				id: ctrlId,
				cssClass: cClass,
				types: dTypes,
				obj: gxObj,
				hdl: handler
			};
			gx.fx.addElement(this.sources, dragSource, false);
		},

		addTarget: function (gxObj, ctrlId, cClass, dTypes, handler) {
			gx.thread.Mutex(this, this.addTargetSync, [gxObj, ctrlId, cClass, dTypes, handler]);
		},

		addTargetSync: function (gxObj, ctrlId, cClass, dTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj) ? ctrlId : gxObj.CmpContext + ctrlId;
			var dropTarget = {
				id: ctrlId,
				cssClass: cClass,
				types: dTypes,
				obj: gxObj,
				hdl: handler
			};
			gx.fx.addElement(this.targets, dropTarget, true);
		},

		deleteSource: function (ctrlId) {
			gx.thread.Mutex(this, this.deleteSourceSync, [ctrlId]);
		},

		deleteSourceSync: function (ctrlId) {
			this.sources = gx.fx.deleteElement(this.sources, ctrlId);
		},

		getSource: function (evtObj) {
			var evtCtrl = gx.evt.source(evtObj);
			var len = this.sources.length;
			for (var i = 0; i < len; i++) {
				var curSource = this.sources[i];
				this.dragCtrl = gx.fx.findControl(evtCtrl, curSource.obj, curSource.id);
				var ctrl = this.dragCtrl;
				if (ctrl != null) {
					ctrl.gxClassName = ctrl.className;
					ctrl.gxDndClassName = curSource.cssClass;
					if (gx.fx.isUnderMouse(ctrl))
						return curSource;
				}
			}
			this.dragCtrl = null;
			this.obj = null;
			return null;
		},

		getTarget: function (evtObj, types) {
			var evtCtrl = gx.evt.source(evtObj);
			var len = this.targets.length;
			for (var i = 0; i < len; i++) {
				var curTarget = this.targets[i];
				var Control = gx.fx.findControl(evtCtrl, curTarget.obj, curTarget.id);
				if (Control != null) {
					Control.gxClassName = Control.className;
					Control.gxDndClassName = curTarget.cssClass;
					if (gx.fx.isUnderMouse(Control)) {
						if (gx.fx.matchingTypes(types, curTarget.types)) {
							this.noDropCtrl = null;
							this.dropCtrl = Control;
							return curTarget;
						}
						else {
							this.out();
							this.noDropCtrl = Control;
							this.noDrop();
							return null;
						}
					}
				}
			}
			this.out();
			return null;
		}
	},

	notifications: {
		queuedEvents: [],
		initialize: function (gxObj) {
			if (!gxObj.notifications) {
				gxObj.notifications = [];
				gx.fx.obs.addObserver('gx.ws.onMessage.notifications', gxObj, gx.fx.notifications.notify.closure(gxObj), { single: false, doNotDelete: gxObj.IsMasterPage });
				gx.fx.obs.addObserver('gx.onafterevent', gxObj, gx.fx.notifications.fireQueuedEvents.closure(gxObj), { single: false, doNotDelete: gxObj.IsMasterPage });
			}
			if (!this.webSocket) {
				if (!gxObj.fullAjax)
					gx.dbg.write('Warning: WebNotifications are not supported with "Web User Experience": "Previous versions". You must use Smooth.');
				var port = gx.fn.getHidden("GX_WEBSOCKET_PORT");
				var resourceUrlBar = (gx.basePath && gx.basePath.length>0) ? '/' : '';
				this.webSocket = new gx.webSocket({
					'port': port,
					'clientId': gx.fn.getHidden("GX_WEBSOCKET_ID"),
					'wsProtocol': (location.protocol === 'https:')? "wss://": "ws://",
					'host': (port)? location.hostname + ":" + port + "/" : location.host + "/",
					'resourceUrl': resourceUrlBar + ((gx.gen.isDotNet())? "gxwebsocket.svc?": "gxwebsocket?"),
					'basePath': gx.basePath,
					'namespace': "notifications"
				});
			}
		},

		deinit: function() {
			gx.fx.notifications.queuedEvents = [];
		},

		addTracker: function (gxObj, groupName, evtName, sTypes, handler, noWait) {		
			gx.fx.notifications.initialize(gxObj);
			gxObj.notifications[groupName || ""] = { gxO: gxObj, handler: handler, eventName: evtName, type: sTypes, noWait: noWait };
		},

		notify: function (msg) {			
			var data = gx.json.evalJSON(msg);	
			var groupName = data.GroupName || "";
			var obj = this.notifications[groupName];
			if (obj){
				gx.fx.notifications.queuedEvents.push({notifObj:obj, data:data});
				if (!obj.noWait && !gx.isInputEnabled()) {
					//'gx.onafterevent' will be called when postHandlerFullAjax is completed.
				} else {
					gx.fx.notifications.fireQueuedEvents();
				}
			}
		},
		
		fireQueuedEvents: function() {
			for (var i = 0; i <gx.fx.notifications.queuedEvents.length; i++) {
				var obj = gx.fx.notifications.queuedEvents[i];
				if (!obj.executed) {
					gx.fx.notifications.queuedEvents.splice(i--, 1);
					var gxO = obj.notifObj.gxO;	
					obj.executed = true;
					if (!gx.lang.emptyObject(obj.data.Object) && obj.data.Object.toUpperCase() != gxO.ServerClass.toUpperCase()) {
						//Ignore notification for current object
						continue;
					}					
					var type = obj.notifObj.type;
					var evtName = obj.notifObj.eventName;
					if (evtName) {
						var isServerEvent = gxO.isServerEvent(evtName);
						var parm = {}; parm[type[0][0]] = obj.data;
						gxO.setEventParameters(obj.notifObj.type, parm);						
						gx.evt.dispatcher.dispatch(gxO.getServerEventName(evtName), gxO, 0, 0, isServerEvent, undefined, undefined, true);
					}
					else {
						obj.notifObj.handler(obj.data);
					}
				}
			}			
		}				
	},

	ctx: {
		setters: [],
		trackers: [],

		deleteHandlers: function (gxObj) {
			gx.thread.Mutex(this, this.deleteHandlersSync, [gxObj]);
		},

		deleteHandlersSync: function (gxObj) {
			var i;
			var tmp = [];
			var len = this.setters.length;
			for (i = 0; i < len; i++) {
				var setter = this.setters[i];
				if (setter.obj != gxObj)
					tmp.push(setter);
			}
			this.setters = tmp;
			tmp = [];
			len = this.trackers.length;
			for (i = 0; i < len; i++) {
				var tracker = this.trackers[i];
				if (tracker.obj != gxObj)
					tmp.push(tracker);
			}
			this.trackers = tmp;
		},

		addSetter: function (gxObj, ctrlId, cClass, sTypes, handler) {
			gx.thread.Mutex(this, this.addSetterSync, [gxObj, ctrlId, cClass, sTypes, handler]);
		},

		addSetterSync: function (gxObj, ctrlId, cClass, sTypes, handler) {
			ctrlId = gx.lang.emptyObject(gxObj) ? ctrlId : gxObj.CmpContext + ctrlId;
			var setter = {
				id: ctrlId,
				cssClass: cClass,
				types: sTypes,
				obj: gxObj,
				hdl: handler
			};
			gx.fx.addElement(this.setters, setter, false);
		},

		addTracker: function (gxObj, sTypes, handler) {
			gx.thread.Mutex(this, this.addTrackerSync, [gxObj, sTypes, handler]);
		},

		addTrackerSync: function (gxObj, sTypes, handler) {
			var ctrlId = gxObj.CmpContext + gxObj.IsMasterPage.toString();
			var tracker = {
				id: ctrlId,
				cssClass: '',
				types: sTypes,
				obj: gxObj,
				hdl: handler
			};
			gx.fx.addElement(this.trackers, tracker, true);
		},

		deleteSetter: function (ctrlId) {
			gx.thread.Mutex(this, this.deleteSetterSync, [ctrlId]);
		},

		deleteSetterSync: function (ctrlId) {
			this.setters = gx.fx.deleteElement(this.setters, ctrlId);
		},

		notify: function (Control, setterTypes, ctxObj) {
			gx.thread.Mutex(this, this.notifySync, [Control, setterTypes, ctxObj]);
		},

		notifySync: function (Control, setterTypes, ctxObj) {
			if (Control && Control.forcedFocus) {
				Control.forcedFocus = false;
				return;
			}
			var i;
			var eo = gx.lang.emptyObject;			
			var callCtxScope = function(objContext, callback) {
				var gxOld = gx.O;
				gx.setGxO(objContext);	
				callback();
				gx.setGxO(gxOld);
			};
	
			var setterCtrl = null;
			if (eo(setterTypes) || eo(ctxObj)) {
				var settersQty = this.setters.length;
				for (i = 0; i < settersQty; i++) {
					var curSetter = this.setters[i];
					if (!eo(Control)) {
						if (Control.id == curSetter.id) {							
							callCtxScope.apply(this, [curSetter.obj, 
								function() {
									setterCtrl = Control;
									gx.evt.setEventRow(curSetter.obj, setterCtrl);
									setterTypes = curSetter.types;
									ctxObj = curSetter.hdl.call(curSetter.obj, setterCtrl);												
							}]);
							break;
						}
					}
					else {
						setterCtrl = gx.fx.findControl(null, curSetter.obj, curSetter.id);
						if (setterCtrl != null) {
							if (eo(setterCtrl.onfocus)) {
								if (gx.fx.isUnderMouse(setterCtrl)) {
									callCtxScope.apply(this, [curSetter.obj, 
										function() {
											gx.evt.setEventRow(curSetter.obj, setterCtrl);
											setterTypes = curSetter.types;
											ctxObj = curSetter.hdl.call(curSetter.obj, setterCtrl);
									}]);
									break;
								}
							}
						}
					}
				}
			}
			if (!eo(setterTypes) && (ctxObj || ctxObj === '')) {
				var trackersQty = this.trackers.length;
				for (i = 0; i < trackersQty; i++) {
					var curTracker = this.trackers[i];
					if (gx.fx.matchingTypes(setterTypes, curTracker.types)) {
						callCtxScope.apply(this, [curTracker.obj, 
							function() {						
								curTracker.hdl.call(curTracker.obj, null, setterCtrl, ctxObj);						
							}]);
					}
				}
			}
		}
	}
};
/* END OF FILE - ..\js\gxfx.js - */
/* START OF FILE - ..\js\gxdate.js - */
gx.date = (function () {
	var ANSI_DATETIME_REGEX = /([0-9]{1,4})\/?-?([0-9]{1,2})\/?-?([0-9]{1,4})\s?T?([0-9]{1,2})?:?([0-9]{1,2})?:?([0-9]{1,2})?\.?([0-9]{1,3})?\s?(AM|PM)?/i,
		ANSI_TIME_REGEX = /([0-9]{1,2}):?([0-9]{1,2})?:?([0-9]{1,2})?[\.:]?([0-9]{1,3})?\s?(AM|PM)?/i,
		ANSI_DATE_REGEX = new RegExp("^[0-9]{4}[\/-]{1}[0-9]{2}[\/-]{1}[0-9]{2}$"),
		EMPTY_DATE_REGEX = /^([ ]*([\/|\-][ ]*[\/|\-][ ]*((00|12)(:00(:00)?)?[ ]*(a|am)?)?)?)?[ ]*$/i;		

	var EMPTY_DATE_VALUE = new Date(0, 0, 0, 0, 0, 0, 0);

	return {
		UTC_Offset: new Date().getTimezoneOffset(),

		clone: function () {
			return new Date(this.getTime());
		},

		equalsNoTime: function (d2) {
			if (this.getDay() == d2.getDay() && this.getMonth() == d2.getMonth() && this.getFullYear() == d2.getFullYear())
				return true;
			return false;
		},

		toJson: function () {
			var newdate = new gx.date.gxdate("");
			newdate.assign_date(this);
			return newdate.json();
		},

		isoString: function(d) {
			return d.toISOString();
		},

		jsonNullFormat: {
			Default: 0,
			YearOne: 1
		},

		gxdate: function (SDate, XSFmt) {
			this.json = function () {
				var oldTFmt = this.TimeFmt;
				this.TimeFmt = 24;
				var oldHTime = this.HasTimePart;
				var oldDTime = this.HasDatePart;
				this.HasTimePart = true;
				this.HasDatePart = true;
				var jsonDate = this.getStringWithFmt("Y4MD") + ' ' + ((oldHTime) ? this.getTimeString(true, true, true, this.Value.getMilliseconds() > 0) : '00:00:00');
				this.TimeFmt = oldTFmt;
				this.HasTimePart = oldHTime;
				this.HasDatePart = oldDTime;
				return jsonDate;
			}

			this.mapCTODFormatToPattern = function (nFormat) {
				if (nFormat == "ANSI")
					return "Y4MD";
				else return nFormat;
			}

			this.emptyDateString = function (sDateFormat) {
				if (sDateFormat.indexOf("Y4") == -1)
					if (gx.blankWhenEmpty)
						return '        ';
					else
						return '  /  /  ';
				else
					if (gx.blankWhenEmpty)
						return '          ';
					else
						if (sDateFormat == "Y4MD")
							return '    /  /  ';
						else
							return '  /  /    ';
			}

			this.getStringWithFmt = function (sDateFormat) {
				sDateFormat = this.mapCTODFormatToPattern(sDateFormat);
				if (this.Value - EMPTY_DATE_VALUE === 0)
					return this.emptyDateString(sDateFormat);
				var sDate = sDateFormat;
				var sDay;
				var sMonth;
				var sYear;
				var Pos = this.FormatPos(sDateFormat);
				if (this.JsonNullFormat === gx.date.jsonNullFormat.YearOne) {
					sDay = "01";
					sMonth = "01";
					sYear = "0001";
				}
				else {
					sDay = gx.text.padl(this.Value.getDate().toString(), 2, '0');
					sMonth = gx.text.padl((this.Value.getMonth() + 1).toString(), 2, '0');
					sYear = gx.text.padl(this.Value.getFullYear().toString(), 4, '0');
				}
				sDate = sDate.replace('D', sDay + ((Pos.DPos < 3) ? '/' : ''));
				sDate = sDate.replace('M', sMonth + ((Pos.MPos < 3) ? '/' : ''));
				if (sDateFormat.indexOf("Y4") == -1) {
					sYear = sYear.slice(2, 4);
					sDate = sDate.replace('Y', sYear + ((Pos.YPos < 3) ? '/' : ''));
				}
				else
					sDate = sDate.replace('Y4', sYear + ((Pos.YPos < 3) ? '/' : ''));
				return sDate;
			}

			this.getString = function (dFormat) {				
				if (gx.lang.emptyObject(dFormat)) {
					dFormat = gx.dateFormat;					
				}
				return this.getStringWithFmt(dFormat);								
			}

			this.toISOString = function () {
				return this.Value.toISOString();
			}

			this.toString = function () {
				var timePart = (this.HasTimePart)? ' ' + this.getTimeString(true, true): '';
				return this.getString() + timePart;
			}

			this.gxdtoc = function (nDateFormat, sSeparator) {
				var sDate = this.getStringWithFmt(this.mapCTODFormatToPattern(nDateFormat));
				return sDate.replace('/', sSeparator);
			}

			this.getUrlVal = function () {
				var sDay, sMonth, sYear;
				if (gx.date.isNullDate(this))
					return '';
				if (!this.HasDatePart)
				{
					sDay = '01';
					sMonth = '01';
					sYear = '0001';
				}
				else
				{
					sDay = gx.text.padl(this.Value.getDate().toString(), 2, '0');
					sMonth = gx.text.padl((this.Value.getMonth() + 1).toString(), 2, '0');
					sYear = gx.text.padl(this.Value.getFullYear().toString(), 4, '0');
				}
				var sHour = this.HasTimePart ? gx.text.padl(this.Value.getHours().toString(), 2, '0') : '';
				var sMin = this.HasTimePart ? gx.text.padl(this.Value.getMinutes().toString(), 2, '0') : '';
				var sSec = this.HasTimePart ? gx.text.padl(this.Value.getSeconds().toString(), 2, '0') : '';
				var sMil = this.HasTimePart ? gx.text.padl(this.Value.getMilliseconds().toString(), 3, '0') : '';					
									
				return sYear + sMonth + sDay + sHour + sMin + sSec + sMil;
			}

			this.getTimeString = function (WithMin, WithSec, WithHour, WithMil) {
				if (gx.date.isNullDate(this) && gx.blankWhenEmpty) {
					var timeString = "";
					if (WithHour)
						timeString += "  ";
					if (WithMin)
						timeString += "   ";
					if (WithSec)
						timeString += "   ";
					if (WithMil)
						timeString += "    ";						
					return timeString;
				}
				else {
					var amPm = "";
					var iHour = this.Value.getHours();
					WithHour = WithHour || true;
					if ((this.TimeFmt == 12) && (iHour >= 12)) {
						if (iHour > 12)
							iHour = iHour - 12;
						amPm = " PM";
					}
					else if (this.TimeFmt == 12)
						amPm = " AM";
					var sHour = this.HasTimePart ? gx.text.padl(iHour.toString(), 2, '0') : '';
					var sMin = this.HasTimePart ? gx.text.padl(this.Value.getMinutes().toString(), 2, '0') : '';
					var sSec = this.HasTimePart ? gx.text.padl(this.Value.getSeconds().toString(), 2, '0') : '';
					var sMil = this.HasTimePart ? gx.text.padl(this.Value.getMilliseconds().toString(), 3, '0') : '';					
					if (iHour === 0 && (amPm !== "")) {	//It shows 12:00 AM not 00:00 AM (and Null datetime is / / 12:00 AM, not  / / 00:00 AM)
						sHour = '12';
					}
					var sHourRet = "";
					if (WithHour)
						sHourRet = sHour;
					if (WithMin)
						sHourRet = sHourRet + ':' + sMin;
					if (WithSec)
						sHourRet = sHourRet + ':' + sSec;
					if (WithMil)
						sHourRet = sHourRet + '.' + sMil;						
					return sHourRet + amPm;
				}
			}

			this.FormatPos = function (SFmt) {
				var YPos, MPos, DPos, Y4Pos;
				if (SFmt == "ANSI") {
					YPos = 1;
					MPos = 2;
					DPos = 3;
				}
				else {
					Y4Pos = SFmt.indexOf("Y4");
					YPos = (Y4Pos == -1) ? SFmt.indexOf("Y") + 1 : Y4Pos + 1;
					MPos = SFmt.indexOf("M");
					if (Y4Pos !== 0) MPos++;
					DPos = SFmt.indexOf("D");
					if (Y4Pos !== 0) DPos++;
				}
				return { YPos: YPos, MPos: MPos, DPos: DPos };
			}

			this.assign_date = function (DateValue) {
				if (DateValue instanceof gx.date.gxdate) {
					this.Value = DateValue.Value;
					this.HasTimePart = DateValue.HasTimePart;
					this.HasDatePart = DateValue.HasDatePart;
				}
				else {
					if (DateValue === undefined) {
						this.Value = EMPTY_DATE_VALUE;
					}
					else {
						this.Value = DateValue;
					}
				}
			}

			this.toUTC = function () {
				if (gx.date.isNullDate(this) || (typeof (gx.StorageTimeZone) == 'undefined') || gx.StorageTimeZone == gx.NULL_TIMEZONEOFFSET)
					return this;
				var xdate = new gx.date.gxdate('');
				xdate.Value.setTime(this.Value.getTime() + this.Value.getTimezoneOffset() * 60000);
				xdate.HasTimePart = this.HasTimePart;
				xdate.HasDatePart = this.HasDatePart;
				return xdate;
			}

			this.fromUTC = function () {
				if (gx.date.isNullDate(this) || (typeof (gx.StorageTimeZone) == 'undefined') || gx.StorageTimeZone == gx.NULL_TIMEZONEOFFSET)
					return this;
				var xdate = new gx.date.gxdate('');
				xdate.Value.setTime(this.Value.getTime() - this.Value.getTimezoneOffset() * 60000);
				xdate.HasTimePart = this.HasTimePart;
				xdate.HasDatePart = this.HasDatePart;
				return xdate;
			}

			this.assign_string = function (SDate, SFmt, IgnoreTime, ThrowExc) {
				var ANSIDateExp = ANSI_DATETIME_REGEX,
					DateParts = ANSIDateExp.exec(SDate),					
					datePartsLen = 0;				
			
				if (DateParts != null)
				{
					var pos = SDate.indexOf(DateParts[0]);
					if ( pos > 0 && gx.text.substring(SDate, pos,1) == "." )				
						DateParts = null;
				}
				if (DateParts == null) {
					if (SDate.indexOf("  /  /  ") != -1)
						IgnoreTime = true;
				}
				else {
					var len = DateParts.length;
					for (var i = 1; i < len; i++) {
						if (!gx.lang.emptyObject(DateParts[i])) datePartsLen++;
					}
				}
				var Pos = this.FormatPos(SFmt);
				var YY = 0, MM = 0, DD = 0, Ho = 0, Mi = 0, Se = 0, Ce = 0;
				try {
					this.HasDatePart = true;
					if ((Pos.DPos + Pos.MPos + Pos.YPos == 6) && (DateParts != null) && (datePartsLen >= 3)) {
						if (DateParts[Pos.YPos] != null)
							YY = parseInt(DateParts[Pos.YPos], 10);
						if (isNaN(YY))
							throw "InvalidDate";
						if (YY < this.FYearOfCentury)
							YY += 2000;
						else if (YY < 100)
							YY += 1900;
						else if (YY < 1000)
							YY += 1000;
						if (DateParts[Pos.MPos] != null)
							MM = parseInt(DateParts[Pos.MPos], 10) - 1;
						if (isNaN(MM) || (MM < 0) || (MM > 11)) throw "InvalidDate";
						if (DateParts[Pos.DPos] != null)
							DD = parseInt(DateParts[Pos.DPos], 10);
						if (isNaN(DD) || (DD < 0) || (DD > gx.date.maxDays(MM, YY))) throw "InvalidDate";
					} else {
						this.HasDatePart = false;
					}
					this.HasTimePart = false;
					var TimeOffSet = 0;
					if (DateParts == null) {
						ANSIDateExp = ANSI_TIME_REGEX;
						DateParts = ANSIDateExp.exec(SDate);
						if (DateParts != null) {
							TimeOffSet = 1;
							//Has time part
							this.HasTimePart = true;
						}
					}
					else {
						if (datePartsLen > 3) {
							TimeOffSet = 4;
							//Has time part
							this.HasTimePart = true;
						}
					}
					if (this.HasTimePart && !IgnoreTime) {
						if (DateParts[TimeOffSet] != null)
							Ho = parseInt(DateParts[TimeOffSet], 10);
						if (gx.lang.emptyObject(DateParts[TimeOffSet]) || isNaN(Ho)) {
							this.HasTimePart = false;
							throw "InvalidHour";
						}
						if (DateParts[TimeOffSet + 1] != null)
							Mi = parseInt(DateParts[TimeOffSet + 1], 10);
						if (isNaN(Mi)) Mi = 0;
						if (DateParts[TimeOffSet + 2] != null)
							Se = parseInt(DateParts[TimeOffSet + 2], 10);
						if (isNaN(Se)) Se = 0;
						if (DateParts[TimeOffSet + 3] != null)
							Ce = parseInt(DateParts[TimeOffSet + 3], 10);
						if (isNaN(Ce)) Ce = 0;

						if (!this.validTime((SDate.toLowerCase().indexOf("m") != -1), Ho, Mi, Se, Ce))
							throw "InvalidHour";
						if ((SDate.indexOf("PM") != -1 || SDate.indexOf("pm") != -1) && (Ho < 12))
							Ho += 12;
						if ((SDate.indexOf("AM") != -1 || SDate.indexOf("am") != -1) && (Ho == 12))
							Ho = 0;
					}
				}
				catch (E) {
					if (ThrowExc) {
						throw E;
					}
					else {
						if (E == "InvalidDate") {
							YY = 0;
							MM = 0;
							DD = 0;
							Ho = 0;
							Mi = 0;
							Se = 0;
							Ce = 0;
						}
						if (E == "InvalidHour") {
							Ho = 0;
							Mi = 0;
							Se = 0;
							Ce = 0;
						}
					}
				}
				this.Value = new Date(YY, MM, DD, Ho, Mi, Se, Ce);
				if ((YY + MM + DD + Ho + Mi + Se + Ce) > 0 && (!this.HasTimePart || IgnoreTime) && this.Value.getDate() != DD) {
					this.Value = new Date(Date.UTC(YY, MM, DD, Ho + 12, Mi, Se, Ce));
				}
			}

			this.validTime = function (AMPM, Hour, Min, Sec, Ce) {
				if (AMPM && Hour > 12)
					return false;
				if (!AMPM && (Hour > 24 || (Hour == 24 && (Min + Sec) > 0)))
					return false;
				return ((Min <= 59) || (Sec <= 59) || (Ce <= 999));
			}

			this.compare = function (DateValue) {
				if (typeof (DateValue) == "string")
					return this.compare_string(DateValue);
				return this.compare_date(DateValue);
			}

			this.compare_string = function (SDate) {
				var DateValue = new gx.date.gxdate(SDate);
				return this.compare_date(DateValue.Value);
			}

			this.compare_date = function (DateValue) {
				var Val;
				if (!DateValue)
					return null;					
				if (DateValue instanceof gx.date.gxdate)
					Val = DateValue.Value;
				else
					Val = DateValue;
				if (this.HasTimePart )
					return this.Value - Val;
				else {
					if (this.Value.getFullYear() > Val.getFullYear())
						return 1;
					else if (this.Value.getFullYear() < Val.getFullYear())
						return -1;
					else {
						if (this.Value.getMonth() > Val.getMonth())
							return 1;
						else if (this.Value.getMonth() < Val.getMonth())
							return -1;
						else {
							if (this.Value.getDate() > Val.getDate())
								return 1;
							else if (this.Value.getDate() < Val.getDate())
								return -1;
							else
								return 0;
						}
					}
				}
			}
			this.JsonNullFormat = gx.date.jsonNullFormat.Default;
			this.TimeFmt = gx.timeFormat || 12;
			this.SFmt = XSFmt || gx.dateFormat;
			this.FYearOfCentury = gx.centuryFirstYear || 40;
			if (typeof (SDate) == "string")
				this.assign_string(SDate, this.SFmt);
			else
				this.assign_date(SDate);
		},

		isANSIDateTime: function (sdate) {
			if (typeof (sdate) == "string") {
				var ansiRE = ANSI_DATETIME_REGEX;									
				if (ansiRE.test(sdate)) {
					return true;
				}
			}
			return false;
		},

		isANSIDate: function (sdate) {
			if (typeof (sdate) == "string") {
				var ansiRE = ANSI_DATE_REGEX;
				if (ansiRE.test(sdate)) {
					return true;
				}
			}
			return false;
		},

		isLeapYear: function (year) {
			if (year % 400 === 0)
				return true;
			if (year % 100 === 0)
				return false;
			if (year % 4 === 0)
				return true;
			return false;
		},

		dateObject: function (date) {
			if (date instanceof this.gxdate)
				return date.Value;
			if (typeof (date) == "string")
				return new this.gxdate(date, (this.isANSIDate(date) ? 'Y4MD' : undefined)).Value;
			if (date instanceof Date)
				return date;
			return new Date();
		},

		gxdateObject: function (date) {
			if (date instanceof this.gxdate)
				return date;
			if (typeof (date) == "string")
				return new this.gxdate(date, (this.isANSIDate(date) ? 'Y4MD' : undefined));
			if (date instanceof Date) {
				var newDate = new this.gxdate("");
				newDate.assign_date(date);
				return newDate;
			}
			return new this.gxdate("");
		},

		clonedDate: function (gxDateObj, realDateObj) {
			var newdate = new this.gxdate("");
			newdate.assign_date(realDateObj);
			if (gxDateObj instanceof this.gxdate) {
				newdate.SFmt = gxDateObj.SFmt;
				newdate.HasTimePart = gxDateObj.HasTimePart;
				newdate.HasDatePart = gxDateObj.HasDatePart;
			}
			return newdate;
		},

		nullDate: function () {
			return new this.gxdate("").Value;
		},

		now: function () {
			var ret = this.today();
			ret.HasTimePart = true;
			ret.HasDatePart = true;
			return ret;
		},

		today: function () {
			var day = new this.gxdate('');
			day.assign_date(new Date());
			return day;
		},

		ctot: function (date, fmt) {
			return new this.gxdate(date, fmt);
		},

		ctod: function (date, fmt) {
			var day = new this.gxdate(date, fmt);
			day.Value.setHours(0, 0, 0, 0);
			return day;
		},

		ymdtod: function (Y, M, D) {
			var day = new this.gxdate(Y + '/' + M + '/' + D, 'ANSI');
			day.Value.setHours(0, 0, 0, 0);
			return day;
		},

		ymdhmstot: function (Y, M, D, H, Mi, S) {
			var day = new this.gxdate(Y + '/' + M + '/' + D + ' ' + H + ':' + Mi + ':' + S, 'ANSI');
			return day;
		},

		hour: function (SDate) {
			return (new this.gxdate(SDate)).Value.getHours();
		},

		minute: function (SDate) {
			return (new this.gxdate(SDate)).Value.getMinutes();
		},

		second: function (SDate) {
			return (new this.gxdate(SDate)).Value.getSeconds();
		},

		millisec: function (Days) {
			return Days * 24 * 60 * 60 * 1000;
		},

		day: function (SDate) {
			return (new this.gxdate(SDate)).Value.getDate();
		},

		month: function (SDate) {
			return (new this.gxdate(SDate)).Value.getMonth() + 1;
		},

		year: function (SDate) {
			return (new this.gxdate(SDate)).Value.getFullYear();
		},

		addDays: function (sdate, inc) {
			return this.addMill(sdate, this.dayToMillisec(inc));
		},

		addSec: function (sdate, inc) {
			return this.addMill(sdate, this.secToMillisec(inc));
		},

		addMill: function (sdate, inc) {
			var date = this.dateObject(sdate).clone();
			var xdate = new this.gxdate();
			xdate.assign_date(date);
			var mill = date.getMilliseconds();
			date.setMilliseconds(mill + inc);
			return xdate.getString((this.isANSIDate(sdate) ? 'Y4MD' : undefined));
		},

		secDiff: function (date1, date2) {
			var val = this.millisecToSec(this.milliDiff(date1, date2));
			return val;
		},

		daysDiff: function (date1, date2) {
			var val = this.millisecToDay(this.milliDiff(date1, date2));
			return val;
		},

		milliDiff: function (date1, date2) {
			var xdate1 = this.gxdateObject(date1);
			var xdate2 = this.gxdateObject(date2);
			date1 = xdate1.Value.valueOf();
			date2 = xdate2.Value.valueOf();
			return date1 - date2;
		},

		dayToMillisec: function (Days) {
			return Days * 24 * 60 * 60 * 1000;
		},

		secToMillisec: function (Sec) {
			return Sec * 1000;
		},

		millisecToDay: function (Mill) {
			return Mill / 24 / 60 / 60 / 1000;
		},

		millisecToSec: function (Mill) {
			return Mill / 1000;
		},

		dateParm: function (sdate) {
			if (typeof (sdate) == "string")
				return new this.gxdate(sdate);
			return sdate;
		},

		urlDate: function (Control, sFmt) {
			var value;
			if (typeof (Control.value) != 'undefined')
				value = Control.value;
			else
				value = gx.dom.spanValue(Control) || Control;
			var date = new this.gxdate(value, sFmt);
			if (!this.isNullDate(date)) {
				return date.Value.getFullYear().toString() +
						gx.text.padl((date.Value.getMonth() + 1).toString(), 2, '0') +
						gx.text.padl(date.Value.getDate().toString(), 2, '0');
			}
			return '';
		},

		urlDateTime: function (Control, sFmt) {
			var value;
			if (typeof(Control.value) != 'undefined')
				value = Control.value;
			else
				value = gx.dom.spanValue(Control) || Control;
			var date = new this.gxdate(value, sFmt);
			if (!date.HasDatePart)
			{
				return '00010101' +
						gx.text.padl(date.Value.getHours().toString(), 2, '0') +
						gx.text.padl(date.Value.getMinutes().toString(), 2, '0') +
						gx.text.padl(date.Value.getSeconds().toString(), 2, '0');
			}
			else if (!this.isNullDate(date)) {

				return date.Value.getFullYear().toString() +
						gx.text.padl((date.Value.getMonth() + 1).toString(), 2, '0') +
						gx.text.padl(date.Value.getDate().toString(), 2, '0') +
						gx.text.padl(date.Value.getHours().toString(), 2, '0') +
						gx.text.padl(date.Value.getMinutes().toString(), 2, '0') +
						gx.text.padl(date.Value.getSeconds().toString(), 2, '0') +
						((date.Value.getMilliseconds() === 0)?"":gx.text.padl(date.Value.getMilliseconds().toString(), 3, '0'));
			}
			return '';
		},

		isNullDate: function (date) {
			if (date instanceof this.gxdate)
				date = date.Value;
			var nullD = this.nullDate();
			if (nullD.getFullYear() != date.getFullYear())
				return false;
			if (nullD.getMonth() != date.getMonth())
				return false;
			if (nullD.getDate() != date.getDate())
				return false;
			if (nullD.getHours() != date.getHours())
				return false;
			if (nullD.getMinutes() != date.getMinutes())
				return false;
			if (nullD.getSeconds() != date.getSeconds())
				return false;
			if (nullD.getMilliseconds() != date.getMilliseconds())
				return false;				
			return true;
		},

		dtoc: function (SDate, nDateFormat, sSeparator) {
			var d = new this.gxdate(SDate, (this.isANSIDate(SDate) ? 'Y4MD' : undefined));
			return d.gxdtoc(nDateFormat, sSeparator);
		},

		dttoc: function (SDate, nLen, nDec) {
			var date = new this.gxdate(SDate, (this.isANSIDateTime(SDate) ? 'Y4MD' : undefined));
			var sFmt = gx.dateFormat;
			var DatePart = '';
			if (nLen > 0) {
				if ((nLen > 8) && (sFmt.indexOf("Y4") == -1))
					sFmt = sFmt.replace('Y', 'Y4');
				DatePart = date.getStringWithFmt(sFmt) + ' ';
			}
			if (nDec > 0)				
				return DatePart + date.getTimeString(nDec > 3, nDec >= 8, nDec > 1, nDec >= 12);
			return DatePart;
		},

		nulldate_toc: function (nLen, nDec) {
			var Date = new this.gxdate('');
			Date.HasTimePart = true;
			Date.HasDatePart = true;
			var sFmt = gx.dateFormat;
			var DatePart = "";
			if (nLen > 0) {
				if ((nLen > 8) && (sFmt.indexOf("Y4") == -1))
					sFmt = sFmt.replace('Y', 'Y4');
				DatePart = Date.getStringWithFmt(sFmt) + ' ';
			}
			if (nDec > 0 && !gx.blankWhenEmpty)
				return DatePart + Date.getTimeString(nDec > 3, nDec >= 8, nDec > 1, nDec >= 12);
			return DatePart;
		},


		addyr: function (date, inc) {
			return this.addmth(date, 12 * inc);
		},

		addmth: function (date, inc) {
			var gxDate = this.gxdateObject(date);			
			date = new Date(this.dateObject(date).getTime());	
			var datePart = date.getDate();
			date.setDate(1);
			date.setMonth(date.getMonth() + inc * 1);
			date.setDate(Math.min(datePart, this.maxDays(date.getMonth(), date.getFullYear())));
			return this.clonedDate(gxDate, date);
		},		

		dtadd: function (date, inc) {
			var gxDate = this.gxdateObject(date);			
			date = new Date(this.dateObject(date).getTime());						
			var millis = date.getMilliseconds();
			date.setMilliseconds(millis + inc * 1000);
			return this.clonedDate(gxDate, date);
		},

		dtdiff: function (date1, date2) {
			date1 = this.dateObject(date1);
			date2 = this.dateObject(date2);
			return (date1 - date2) / 1000;
		},

		maxDays: function (month, year) {
			return [31, (this.isLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31][month];
		},

		eom: function (date) {
			var origDate = this.gxdateObject(date);
			date = this.dateObject(date);
			date = new Date(date.getTime());
			var lastDay = this.maxDays(date.getMonth(), date.getFullYear());
			date.setDate(lastDay);
			return this.clonedDate(origDate, date);
		},

		dow: function (date) {
			date = this.dateObject(date);
			if (date.equalsNoTime(this.nullDate()))
				return 0;
			return date.getDay() + 1;
		},

		age: function (date1, date2) {
			var dtAsOfDate;
			var dtBirth;
			var dtAnniversary;
			var intSpan;
			var intYears;
			var intMonths;

			dtBirth = this.dateObject(date1);
			dtAsOfDate = this.dateObject(date2);

			var nullDate = this.nullDate();
			if (dtBirth.equalsNoTime(nullDate) || dtAsOfDate.equalsNoTime(nullDate) || dtBirth.equalsNoTime(dtAsOfDate))
				return 0;

			// if as of date is on or after born date
			if (dtAsOfDate >= dtBirth) {
				// get time span between as of time and birth time
				intSpan = (dtAsOfDate.getUTCHours() * 3600000 +
					dtAsOfDate.getUTCMinutes() * 60000 +
					dtAsOfDate.getUTCSeconds() * 1000) -
					(dtBirth.getUTCHours() * 3600000 +
					dtBirth.getUTCMinutes() * 60000 +
					dtBirth.getUTCSeconds() * 1000)
				// start at as of date and look backwards for anniversary 

				// if as of day (date) is after birth day (date) or
				//    as of day (date) is birth day (date) and
				//    as of time is on or after birth time
				if (dtAsOfDate.getUTCDate() > dtBirth.getUTCDate() ||
					(dtAsOfDate.getUTCDate() == dtBirth.getUTCDate() && intSpan >= 0)) {
					// most recent day (date) anniversary is in as of month
					dtAnniversary = new Date(Date.UTC(dtAsOfDate.getUTCFullYear(),
						dtAsOfDate.getUTCMonth(),
						dtBirth.getUTCDate(),
						dtBirth.getUTCHours(),
						dtBirth.getUTCMinutes(),
						dtBirth.getUTCSeconds()));

				}
					// if as of day (date) is before birth day (date) or
					//    as of day (date) is birth day (date) and
					//    as of time is before birth time
				else {
					// most recent day (date) anniversary is in month before as of month
					dtAnniversary = new Date(Date.UTC(dtAsOfDate.getUTCFullYear(),
						dtAsOfDate.getUTCMonth() - 1,
						dtBirth.getUTCDate(),
						dtBirth.getUTCHours(),
						dtBirth.getUTCMinutes(),
						dtBirth.getUTCSeconds()));

					// get previous month
					intMonths = dtAsOfDate.getUTCMonth() - 1;
					if (intMonths == -1)
						intMonths = 11;

					// while month is not what it is supposed to be (it will be higher)
					while (dtAnniversary.getUTCMonth() != intMonths)
						// move back one day
						dtAnniversary.setUTCDate(dtAnniversary.getUTCDate() - 1);
				}
				// if anniversary month is on or after birth month
				if (dtAnniversary.getUTCMonth() >= dtBirth.getUTCMonth()) {
					// years elapsed is anniversary year - birth year
					intYears = dtAnniversary.getUTCFullYear() - dtBirth.getUTCFullYear();
				}
					// if birth month is after anniversary month
				else {
					// years elapsed is year before anniversary year - birth year
					intYears = (dtAnniversary.getUTCFullYear() - 1) - dtBirth.getUTCFullYear();
				}
				return intYears;
			}
			return 0;
		},

		valid_date: function (Elem, nDateLen, nDateFmt, nTimeLen, nTimeFmt, sIdiom, pMandatoryCentury, nBlankWhenEmpty) {
			var bMandatoryCentury = pMandatoryCentury || false,
				reEmpty = EMPTY_DATE_REGEX,
				reVDTime,
				wasEmpty = false,
				rawValue = Elem.value,
				elemValue = '',
				nDateFmtStr = nDateFmt,
				controlValue = "",
				sVDTime = "^[ ]*(";
			var invalidDateMsg = nDateLen > 0 ? 'GXM_invaliddate' : 'GXM_invalidtime';

			elemValue = gx.num.replaceFullWidthNumerals(rawValue);

			elemValue = elemValue.split('\n')[0];

			if (nDateFmt == "YMD") 
				nDateFmt = 1;
			else 
				nDateFmt = 0;

			if (nTimeFmt == 12) 
				nTimeFmt = 1;
			else 
				nTimeFmt = 0;

			if (reEmpty.test(elemValue)) {
				wasEmpty = true;
				elemValue = "";
				rawValue = "";
			}
			else if (nDateLen > 0 && elemValue.length === 4) { //Allow DDMM or MMDD inputs without specifying Year.
				var currentYear = new Date().getFullYear().toString().substring((nDateLen === 10)? 0: 2);
				elemValue = (nDateFmt === 1)? currentYear + elemValue: elemValue + currentYear;				
			}

			if (nDateLen > 0) {
				if (nDateLen == 8)
					sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{2})";
				else {
					if (nDateFmt === 0) {
						if (bMandatoryCentury)
							sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{4})";
						else
							sVDTime = sVDTime + "([0-9]{1,2})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{2,4})";
					}
					else {
						if (bMandatoryCentury)
							sVDTime = sVDTime + "([0-9]{4})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{1,2})";
						else
							sVDTime = sVDTime + "([0-9]{2,4})[\/|-]?([0-9]{1,2})[\/|-]?([0-9]{1,2})";
					}
				}
			}
			else
				/* Extra parenthesis are added to maintain parameter numbers */
				sVDTime = sVDTime + "( )?( )?( )?";

			if (nTimeLen > 0) {
				sVDTime = sVDTime + "(";
				if (nDateLen > 0)
					sVDTime = sVDTime + "[ ]*";
				sVDTime = sVDTime + "([0-9]{1,2})";

				if (nTimeLen > 2)
					sVDTime = sVDTime + "(:?([0-9]{1,2}))?";
				else
					sVDTime = sVDTime + "(( )?)?";

				if (nTimeLen > 5)
					sVDTime = sVDTime + "(:?([0-9]{1,2}))?";
				else
					sVDTime = sVDTime + "(( )?)?";

				if (nTimeLen > 8)
					sVDTime = sVDTime + "(\\.?([0-9]{1,3}))?";
				else
					sVDTime = sVDTime + "(( )?)?";


				if (nTimeFmt == 1)
					sVDTime = sVDTime + "[ ]*(a|am|p|pm)?";
				else
					sVDTime = sVDTime + "(( )?)?";

				sVDTime = sVDTime + ")?";
			}
			sVDTime = sVDTime + ")?[ ]*$";
			reVDTime = new RegExp(sVDTime, "i");

			if (reVDTime.test(elemValue)) {
				var sTokArr = elemValue.match(reVDTime);

				if (nDateLen > 0) {
					var dateSep = '/';
					if (elemValue.indexOf('-') > 0)
						dateSep = '-';
					if (!sTokArr[2]) {
						if (nBlankWhenEmpty == 1)
							controlValue = "        ";
						else
							controlValue = "  " + dateSep + "  " + dateSep + "  ";
						if (nDateLen == 10)
							controlValue += "  ";
					}
					else {
						controlValue = sTokArr[2] + dateSep + sTokArr[3] + dateSep + sTokArr[4];
					}
				}
				else
					controlValue = "";

				if (nTimeLen > 0) {
					if (nDateLen > 0)
						controlValue = controlValue + " ";
					if (nBlankWhenEmpty == 1 && (!sTokArr[6]) && (!sTokArr[8]) && (!sTokArr[10]) && (!sTokArr[12])) {
						controlValue = controlValue + "        ";
					}
					else {

						if (!sTokArr[6]) {
							if (wasEmpty) {
								var emptTokArr = elemValue.match(reEmpty);
								if (emptTokArr[4])
									controlValue = controlValue + emptTokArr[4];
								else
									controlValue = controlValue + ((nTimeFmt == 1) ? "12" : "00");
							}
							else
								controlValue = controlValue + ((nTimeFmt == 1) ? "12" : "00");
						}
						else
							controlValue = controlValue + sTokArr[6];

						if (nTimeLen > 2) {
							if (!sTokArr[8])
								controlValue = controlValue + ":00";
							else
								controlValue = controlValue + ":" + sTokArr[8];
						}

						if (nTimeLen > 5) {
							if (!sTokArr[10])
								controlValue = controlValue + ":00";
							else
								controlValue = controlValue + ":" + sTokArr[10];
						}

						if (nTimeLen > 8) {
							if (!sTokArr[12])
								controlValue = controlValue + ".000";
							else
								controlValue = controlValue + "." + sTokArr[12];
						}
						if (nTimeFmt == 1) {
							var x;
							if (!sTokArr[13])
								x = "a";
							else
								x = sTokArr[13].substr(0, 1);
							if (x.toLowerCase() == "p") {
								controlValue = controlValue + " PM";
							}
							else {
								controlValue = controlValue + " AM";
							}
						}
					}
				}

				var testDate = new this.gxdate('', nDateFmtStr);
				try {
					testDate.assign_string(controlValue, nDateFmtStr, (nTimeLen <= 0), true);
					if (gx.text.trim(controlValue) !== '')//if not Blanwhenempty
					{
						controlValue = this.formatDateTime(nTimeLen, nDateLen, nDateFmtStr, testDate);
					}
				}
				catch (E) {
					gx.fn.alert(Elem, gx.getMessage(invalidDateMsg));
					gx.csv.setFormatError(Elem);
					return false;
				}

				if (controlValue != rawValue) {
					Elem.value = controlValue;
					if (navigator.userAgent.indexOf("Firefox/2") != -1) {
						//WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
						Elem.onchange();
					}
					var vStruct = gx.O.getValidStructFld(Elem);
					if (vStruct) {
						gx.O.refreshDependantGrids(vStruct);
					}
				}
				gx.csv.setFormatError(Elem, false);
				return true;
			}
			gx.fn.alert(Elem, gx.getMessage(invalidDateMsg));
			gx.csv.setFormatError(Elem);
			return false;
		},

		formatDateTime: function (nTimeLen, nDateLen, nDateFmt, Value) {
			var timeString = '';
			var ret;
			if (nTimeLen > 0 && Value.HasTimePart)
				timeString = Value.getTimeString(nTimeLen >= 4, nTimeLen >= 8, undefined, nTimeLen >= 12);
			var Fmt = nDateFmt;
			if (nDateLen > 8 && Fmt.indexOf("Y4") == -1)
				Fmt = Fmt.replace('Y', 'Y4');
			if (nDateLen > 0)
				ret = Value.getStringWithFmt(Fmt) + ((Value.HasTimePart) ? " " + timeString : "");
			else
				ret = (Value.HasTimePart) ? timeString : "";
			return ret;
		},

		_init: function () {
			Date.prototype.equalsNoTime = this.equalsNoTime;
			Date.prototype.clone = this.clone;
			Date.prototype.json = this.toJson;
		}
	};
})();

/* END OF FILE - ..\js\gxdate.js - */
/* START OF FILE - ..\js\gxtext.js - */
gx.text = {
	stringBuffer: function (capacity) {
		this.capacity = capacity || 10;
		this.buffer = [];

		this.append = function (value) {
			this.buffer.push(value);
			return this;
		}

		this.clear = function () {
			delete this.buffer;
			this.buffer = [];
		}

		this.toString = function () {
			if (this.buffer.length === 0)
				return '';
			return this.buffer.join('');
		}

		this.length = function () {
			return this.toString().length;
		}
	},

	format: function () {
		var msg = arguments[0];
		var len = arguments.length;
		for (var i = 1; i < len; i++)
			msg = msg.replace('%' + i, gx.text.rtrim(arguments[i].toString()));
		return msg;
	},

	formatString: function (str, len, isPwd, pic) {
		if (isPwd)
			return gx.text.padl('', len, "*");
		else 
			if (!gx.lang.emptyObject(pic) && this.startsWith(pic, '@') && pic.indexOf('!') > 0) {
				var ret = '',
					mask = this.padr('', (!str) ? 0 : str.length, '!'),
					nullMask = this.replaceAll(mask, '!', ' ');

				if (!str) {
					ret = nullMask;
				}
				else {					
					var maskIndex = 0, j = 0, c;

					while (maskIndex < nullMask.length && j < str.length) {
						c = str[j];
						if (this.isSeparator(mask[maskIndex])) {
							if (c == mask[maskIndex]) {
								j++;
								ret = ret + c;
							}
							else {
								ret = ret + nullMask[maskIndex];
							}
							maskIndex++;
						}
						else {
							ret = ret + this.getCaret(mask, c, maskIndex, ret);
							maskIndex++;
							j++;
						}
					}					
				}
				return gx.text.rtrim(ret);
			}
			else {
				return str;
			}
	},

	getCaret: function (mask, cIn, pos, b) {
		switch (mask[pos]) {
			case '9':
				if (isNaN(cIn))
					return ' ';
				else
					return cIn;
				break;
			case 'X':
				return cIn;
			case 'A':
			case 'M':
			case '!':
				return cIn.toUpperCase();
			case 'Z':
				if (cIn >= '1' && cIn <= '9') {
					return cIn;
				}
				else {
					if (cIn == '0') {
						var first = true;
						for (var i = 0; i < pos; i++) {
							if (b[i] != ' ') {
								first = false;
								break;
							}
						}

						if (first) {
							return ' ';
						}
						else {
							return '0';
						}
					}
				}
				break;
		}

		return ' ';
	},

	isSeparator: function (c) {
		return (c != '9' && c != 'X' && c != '!' && c != 'Z' && c != 'A' && c != 'M');
	},

	replaceAll: function (value, toReplace, replaceWith) {
		if (value.toString().indexOf(toReplace) != -1) {
			return String(value).split(toReplace).join(replaceWith);
		}
		return value;
	},

	charReplace: function (Value, Chars, Repls) {
		var Ret = '';
		var len = Value.length;
		for (var i = 0; i < len; i++) {
			var bFixed = false;
			var len1 = Chars.length;
			for (var c = 0; c < len1; c++) {
				if (Value.charAt(i) == Chars[c]) {
					if (c < Repls.length) {
						Ret += Repls[c];
						bFixed = true;
						break;
					}
				}
			}
			if (bFixed === false)
				Ret += Value.charAt(i);
		}
		return Ret;
	},

	length: function (str) {
		return str.length;
	},

	upper: function (str) {
		return str.toUpperCase();
	},

	lower: function (str) {
		return str.toLowerCase();
	},

	padr: function (val, len, padc) {
		var xlen = val.length;
		var diff = len - xlen;
		if (diff < 1)
			return val.substring( 0, len);
		var xval = val;
		for (var i = 0; i < diff; i++)
			xval += padc;
		return xval;
	},

	padl: function (val, len, padc) {
		var xlen = val.length;
		var diff = len - xlen;
		if (diff < 1)
			return val.substring( 0, len);
		var xval = '';
		for (var i = 0; i < diff; i++)
			xval += padc;
		xval = xval + val;
		return xval;
	},
	
	ltrimstr: function (num, len, dec) {
		return this.ltrim(gx.num.str(num, len, dec));
	},
	
	ltrim: function (str) {
		return str.toString().replace(/^ */, '');
	},

	rtrim: function (str) {
		return str.toString().replace(/ *$/, '');
	},

	trim: function (str) {
		return this.rtrim(this.ltrim(str));
	},

	chr: function (num) {
		return String.fromCharCode(num);
	},

	like: function (str1, str2) {
		if (str2 === null) {return false; }
		str2 = str2.replace(new RegExp("([\\.\\\\\\+\\*\\?\\[\\^\\]\\$\\(\\)\\{\\}\\=\\!\\<\\>\\|\\:\\-])", "g"), "\\$1");
		var rexp = new RegExp(str2.replace(/%/g, '.*').replace(/_/g, '.'))
		return (rexp.test(str1) );
	},

	compare: function (str1, str2) {
		return this.rtrim(str1).localeCompare(this.rtrim(str2));
	},

	concat: function (str1, str2, sep) {
		return this.rtrim(str1) + sep + str2;
	},

	space: function (n) {
		var buffer = '';
		for (var i = 0; i < n; i++) { buffer += ' '; }
		return buffer;
	},

	substring: function (str, from, len) {
		if (len < 0)
			return str.toString().substring(from - 1);
		else
			return str.toString().substring(from - 1, from - 1 + len);
	},

	tostring: function (str) {
		return str.toString();
	},

	toformattedstring: function (str) {
		return str.toString().replace('.', gx.decimalPoint);
	},

	newline: function () {
		return '\n';
	},

	escapeMapping: {
		"\b": '\\b',
		"\t": '\\t',
		"\n": '\\n',
		"\f": '\\f',
		"\r": '\\r',
		'"': '\\"',
		"\\": '\\\\'
	},

	escapeRegex: {
		start: /["\\\x00-\x1f]/,
		end: /([\x00-\x1f\\"])/g
	},

	escapeFn: function (a, b) {
		var c = gx.text.escapeMapping[b];
		if (c) {
			return c;
		}
		c = b.charCodeAt();
		return "\\u00" +
			Math.floor(c / 16).toString(16) + (c % 16).toString(16);
	},

	escapeString: function (s) {
		if (this.escapeRegex.start.test(s)) {
			return '"' + s.replace(this.escapeRegex.end, this.escapeFn) + '"';
		}
		return '"' + s + '"';
	},

	indexOf: function (str, value, fromIdx) {
		if (fromIdx > str.length)
			return 0;
		if (fromIdx <= 0)
			fromIdx = 1;
		return str.indexOf(value, fromIdx - 1) + 1;
	},

	lastIndexOf: function (str, value, fromIdx) {
		if (fromIdx > str.length)
			return 0;
		if (fromIdx <= 0)
			fromIdx = str.length;
		return str.lastIndexOf(value, fromIdx - 1) + 1;
	},

	endsWith: function (str, suffix) {
		return str.indexOf(suffix, str.length - suffix.length) !== -1;
	},

	startsWith: function (str, value) {
		return this.indexOf(str, value) == 1;
	},

	contains: function (str, value) {
		return this.indexOf(str, value) > 0;
	},

	charAt: function (str, value) {
		return str.charAt(value - 1);
	}
};
/* END OF FILE - ..\js\gxtext.js - */
/* START OF FILE - ..\js\gxnum.js - */

gx.num = function () {
	var FULL_WIDTH_NUMERALS = /[\uFF10-\uFF19]|[\uFF0C-\uFF0E]|\u2015|\u30FC|\uFF0F/g;
	
	var operation = function (name, defaultOp, a, b) {
		var io = gx.lang.instanceOf,
			dec = typeof (gx.num.dec) == "undefined" ? null : gx.num.dec.bigDecimal,
			thSep = gx.thousandSeparator,
			decPoint = gx.decimalPoint;

		if (typeof(a) == "string")
			a = gx.num.parseFloat(a, thSep, decPoint);
		if (typeof(b) == "string")
			b = gx.num.parseFloat(b, thSep, decPoint);

		if (io(a, dec) && io(b, Number))
			return a[name](new dec(b.toString())).toString();
		else if (io(a, Number) && io(b, dec))
			return new dec(a.toString())[name](b).toString();
		if (io(a, Number) && io(b, Number) || typeof (gx.num.dec) == "undefined")
			return defaultOp(a, b);
		else
			return a[name](b);
	};

	return {
		str: function (num, len, dec) {
			if (typeof (num) === 'string')
				return num;
			var sNum;
			if (typeof (len) == 'undefined')
				len = 10;
			if (typeof (dec) == 'undefined' || (len - 1 <= dec))
				dec = 0;
			sNum = num.toFixed(dec);
			return sNum.length <= len ? gx.text.padl(sNum, len, ' ') : gx.text.padr('', len, '*');
		},

		compare: function(num1, num2) {
			if (typeof(num1) === 'number' && typeof(num2) === 'number') {
				if (num1 > num2)
					return 1;
				if (num1 === num2)
					return 0;
				return -1;
			}

			if (typeof(num1) === 'number') {
				num1 = new gx.num.dec.bigDecimal(num1.toString());
			}

			if (typeof(num2) === 'number') {
				num2 = new gx.num.dec.bigDecimal(num2.toString());
			}
			if (gx.lang.instanceOf(num1, gx.num.dec.bigDecimal) && gx.lang.instanceOf(num2, gx.num.dec.bigDecimal))
				return num1.compareTo(num2);
			else
				return num1 - num2; //error?
		},

		maxNumericPrecision: function () {
			return 15;
		},

		extractValue: function (picture, strnum) {
			strnum = gx.num.replaceFullWidthNumerals(strnum);
			if (gx.lang.instanceOf(strnum, Number) || this.overflowNumber(strnum))
				return strnum;
			var pchars,
				value = (strnum === undefined ? '' : strnum);
			if (picture) {
				if (picture.charAt(0) == '+' || picture.charAt(0) == '-')
					pchars = picture.replace(/[\+\-\d,*\.*Z*\s]+/, '');
				else
					pchars = picture.replace(/[\d,*\.*Z*\s]+/g, '');

				if (picture.lastIndexOf('.') != picture.indexOf('.'))
					value = gx.text.replaceAll(value, '.', '');

				for (var i = 0; i < pchars.length; i++)
					value = value.replace(pchars.charAt(i), '');
			}
			return gx.text.trim(value);
		},

		formatNumber: function (number, decimals, picture, digits, sign, errorOnBadNumber) {
			if (!picture) {
				return number ? number.toString() : '';
			}
			if (gx.lang.emptyObject(number))
				number = '0';
			var thSep = picture.indexOf(',') != -1 ? gx.thousandSeparator : '',
				decSep = gx.decimalPoint,
				psplit,
				blankWhenZero = false,
				LenDec = gx.numericLenDec( picture),
				integers = LenDec.Integers;

			decimals = LenDec.Decimals;
			if (typeof (number) == "string" && thSep)
				number = gx.text.replaceAll(number, thSep, '');
			if (typeof (number) == "string")
				number = number.replace(decSep, '.');

			if (gx.num.overflowNumber(number))
				return number;
			try {
				number = (decimals === 0) ? gx.num.trunc(number, 0).toString() : gx.num.setScale(number, decimals);
			} catch (e) { number = number.toString(); }
			var f = number.split('.');
			var i, j;
			if (!f[0]) f[0] = '0';
			if (!f[1]) f[1] = '';

			if (errorOnBadNumber) {
				if (f[1].length > decimals && f[1].replace(/0*$/, '').length > decimals) {
					throw "InvalidNumber";
				}
				else {
					if ((sign && f[0].charAt(0) == '-' && f[0].replace(/0*/, '').length > integers) ||
						(!sign && f[0].charAt(0) == '-') ||
						(f[0].replace(/[+]?0*/, '').length > integers))
						throw "InvalidNumber";
				}
			}
			var integerInput = f[0].substring(0, integers);
			if (number < 0)
				sign = true;
			if (f[1].length < decimals) {
				var g = f[1];
				for (i = f[1].length + 1; i <= decimals; i++) {
					g += '0';
				}
				f[1] = g;
			}
			var signChar = '';
			if (sign && integerInput.charAt(0) == '-') {
				signChar = '-';
				integerInput = integerInput.substring(1);
			}
			if (thSep && integerInput.length > 3) {
				var h = integerInput;
				integerInput = '';
				for (j = 3; j < h.length; j += 3) {
					i = h.slice(h.length - j, h.length - j + 3);
					integerInput = thSep + i + integerInput + '';
				}
				j = h.substr(0, (h.length % 3 === 0) ? 3 : (h.length % 3));
				integerInput = j + integerInput;
			}
			decSep = (!f[1]) ? '' : decSep;

			if (decimals > 0) {
				psplit = picture.split('.');
				if (psplit[1] == gx.text.padr('', decimals, 'Z'))
					blankWhenZero = true;
			}
			else {
				psplit = new Array(picture);
				if (psplit.length > 0 && gx.text.replaceAll(gx.text.replaceAll(psplit[0], ',', ''), 'Z', '').length === 0)
					blankWhenZero = true;
			}

			//parte decimal
			var nidx = 0;
			var decPart = '';
			if (psplit.length > 1) {
				var dpic = psplit[1];
				for (i = 0; i < dpic.length; i++) {
					var chd = dpic.charAt(i);
					if (chd == '9' || chd == 'Z')
						if (f[1].length > nidx) {
							decPart = decPart + f[1].charAt(nidx);
							nidx++;
						}
						else
							decPart = decPart + '0';
					else if (chd != '.' && chd != ',')
						decPart = decPart + chd;
				}
			}

			//parte entera
			var intPart = '';
			var epic = psplit[0];
			nidx = integerInput.length - 1;
			for (i = epic.length - 1; i >= 0; i--) {
				var ch = epic.charAt(i);
				if (ch == '9' || ch == 'Z')
					if (nidx >= 0) {
						if (!(ch == 'Z' && Number(integerInput.substring(0,nidx+1)) === 0))
							intPart = integerInput.charAt(nidx) + intPart;
						nidx--;
					}
					else
						intPart = (ch == '9' ? '0' : '') + intPart;
				else if (ch != 'Z' && ch != ',')
					intPart = ch + intPart;
				else if (ch == ',' && integerInput.charAt(nidx) == thSep) {
					intPart = integerInput.charAt(nidx) + intPart;
					nidx--;
				}
			}
			if (blankWhenZero && (intPart == '0' || intPart === '') && decPart.replace(/0+$/, '').length === 0)
				return '';
			else
				return signChar + intPart + (!decPart ? '' : (decSep + decPart));
		},

		add: function (a, b) {
			return operation('add', function (a, b) { return a + b; }, a, b);
		},

		subtract: function (a, b) {
			return operation('substract', function (a, b) { return a - b; }, a, b);
		},

		multiply: function (a, b) {
			return operation('multiply', function (a, b) { return a * b; }, a, b);
		},

		divide: function (a, b) {
			return operation('divide', function (a, b) { return a / b; }, a, b);
		},

		negate: function (a) {
			if (gx.lang.instanceOf(a, Number) || typeof (gx.num.dec) == "undefined")
				return -a;
			else
				return a.negate();
		},

		pow: function (a, b) {
			return operation('pow', function (a, b) { return Math.pow(a, b); }, a, b);
		},

		mod: function (a, b) {
			return operation('remainder', function (a, b) { return a % b; }, a, b);
		},

		setScale: function (SVal, Dec) {
			if (gx.lang.instanceOf(SVal, Number))
				return SVal.toFixed(Dec);

			if (typeof (SVal) == "string")
				SVal = gx.text.trim(SVal);
			if (SVal.length < this.maxNumericPrecision() || typeof (gx.num.dec) == "undefined") {
				if (SVal.length === 0 && Dec === 0) {
					return '0';
				}
				else {
					var f = SVal.split('.');
					var i;
					if (!f[1]) f[1] = '';

					if (f[1].length < Dec) {
						var g = f[1];
						for (i = f[1].length + 1; i <= Dec; i++) {
							g += '0';
						}
						f[1] = g;
						return f[0] + ((f[1] === '') ? '' : '.') + f[1];
					}
					else {
						return Number(parseFloat(SVal)).toFixed(Dec);
					}
				}
			}
			else
				return new gx.num.dec.bigDecimal(SVal).setScale(Dec, gx.num.dec.ROUND_UP).toString();
		},

		parseFloat: function (S, ThSep, DecPoint) {
			if (gx.lang.instanceOf(S, Number) || this.overflowNumber(S))
				return S;
			var N = this.toInvariant(S, ThSep, DecPoint);
			if (N.length > this.maxNumericPrecision() && typeof (gx.num.dec) != "undefined")
				return new gx.num.dec.bigDecimal(N);
			else
				return parseFloat(N);
		},

		toInvariant: function (S, ThSep, DecPoint) {
			if (typeof (S) == 'number' || (typeof (gx.num.dec) != "undefined" && S instanceof gx.num.dec.bigDecimal))
				return S;
			else
				return gx.text.replaceAll(S, ThSep, '').replace(DecPoint, '.');
		},

		parseInt: function (S, Radix, ThSep) {
			if (typeof (S) == 'number')
				return S;
			var N = S;
			N = gx.text.replaceAll(S, ThSep, '');
			return parseInt(N, Radix);
		},

		overflowNumber: function (S) {
			var regExp = /\*(\**)/;
			return regExp.test(S);
		},

		urlDecimal: function (Control, ThSep, DecPoint) {
			if (typeof(Control) != 'undefined') {
				var value = (typeof (Control.value) != 'undefined') ? Control.value : Control;
				value = this.parseFloat(value, ThSep, DecPoint);
				return value.toString();
			} else {
				return '';
			}
		},

		random: function () {
			return Math.random();
		},

		intval: function (num) {
			var result = 0;
			if (typeof (num) != 'undefined') {
				num = num.toString();
			}
			else {
				num = '';
			}
			if (num.length < gx.num.maxNumericPrecision() || typeof (gx.num.dec) == 'undefined') {
				result = parseInt(num, 0);
			}
			else {
				result = new gx.num.dec.bigDecimal(num).setScale(0, gx.num.dec.ROUND_UP);
			}
			if (isNaN(result))
				result = 0;
			return result;
		},

		val: function (str) {
			str = gx.text.trim(str).replace(',', '.');
			var result = this.parseFloat(str);
			if (isNaN(result))
				result = 0;
			return result;
		},

		trunc: function (num, dec) {
			var result = num;
			num = num.toString();

			var decSep = num.indexOf('.');

			if (decSep != -1) {
				var intPart = num.substring(0, decSep);

				if (dec === 0)
					return Number(intPart);

				var floatPart = num.substring(decSep + 1, decSep + 1 + dec);					

				num = intPart + '.' + floatPart;

				result = gx.num.parseFloat(num);
				if (isNaN(result))
					result = 0;
			}
			return result;
		},

		round: function (n, d){
			if (d >= 0)			
				return parseFloat(gx.num.decimalAdjust('round', n, -d).toFixed(d));
			else
				return gx.num.roundNeg(n,d);
		},
		
		decimalAdjust: function(type, value, exp) {
			// If the exp is undefined or zero...
			if (typeof exp === 'undefined' || +exp === 0) {
				return Math[type](value);
			}
			value = +value;
			exp = +exp;
			// If the value is not a number or the exp is not an integer...
			if (isNaN(value) || !(typeof exp === 'number' && exp % 1 === 0)) {
				return NaN;
			}
			// Shift
			value = value.toString().split('e');
			value = Math[type](+(value[0] + 'e' + (value[1] ? (+value[1] - exp) : -exp)));
			// Shift back
			value = value.toString().split('e');
			return +(value[0] + 'e' + (value[1] ? (+value[1] + exp) : exp));
		},
						
		roundNeg: function (n, d) {			
			n = n.toString();
			var xx = n.indexOf('.');
			var zstr = '0000000000000000000000';
			var theInt = '';
			var theFrac = '';
			var theNo = '';
			var nx = 0;
			var xt = parseInt(d, 0) + 1;
			var rstr = '' + zstr.substring(1, xt);
			var rfac = '.' + rstr + '5';
			var rfacx = parseFloat(rfac);
			var result;
			if (xx == -1) {
				theFrac = zstr;
				theInt = "" + n;
			}
			else if (xx === 0) {
				theInt = '0';
				nx = 0 + parseFloat(n) + parseFloat(rfacx);
				n = nx + zstr;
				theFrac = '' + n.substring(1, n.length);
			}
			else {
				nx = parseFloat(n) + rfacx;				
				theInt = nx.toString().substring(0, xx);
				n = '' + nx + zstr;
				theFrac = '' + n.substring(xx + 1, xx + 1 + parseInt(d, 0));
			}
			theFrac = theFrac.substring(0, parseInt(d, 0));
			theNo = theInt + '.' + theFrac;
			result = parseFloat(theNo);
			if (isNaN(result))
				result = 0;
			return result;
		},

		normalize_decimal_sep: function(Picture, ThSep, DecPoint, Value){			
			var pointIdx = Value.lastIndexOf(DecPoint);
			if (Picture.indexOf('.') >= 0 && DecPoint == ',' && pointIdx == -1 && Value.lastIndexOf('.') == Value.indexOf('.')) {
				Value = Value.replace('.', DecPoint);
			} else if (Picture.indexOf(ThSep) == -1 &&  DecPoint == '.' && pointIdx == -1 && Value.lastIndexOf(',') == Value.indexOf(',')) {
				Value = Value.replace(',', DecPoint);
			}
			return Value;
		},
		
		valid_decimal: function (Elem, ThSep, DecPoint, Dec) {
			var ctrlValue = Elem.value;
			var pointIdx = ctrlValue.lastIndexOf(DecPoint);
			var validNumber = true;
			
			var validStruct = gx.O.getValidStructFld(Elem);
			ctrlValue = this.normalize_decimal_sep(gx.rtPicture(validStruct, Elem), ThSep, DecPoint, ctrlValue);
			if (!gx.lang.emptyObject(validStruct))
				ctrlValue = gx.num.extractValue(gx.rtPicture(validStruct, Elem), ctrlValue);

			var gx_DecRegExp = new RegExp("^[ ]*((([+-]{1}[0-9]+)||([0-9]*))(\\" + ThSep + "[0-9]{3})*(\\" + DecPoint + "[0-9]*)?)?[ ]*$");
			if (ctrlValue) {
				if (gx_DecRegExp.test(ctrlValue)) {
					pointIdx = ctrlValue.lastIndexOf(DecPoint);
					var newvalue = ctrlValue;
					if (pointIdx != -1)
						newvalue = ctrlValue.slice(0, pointIdx + parseInt(Dec, 10) + 1);
					try {
						if (!gx.lang.emptyObject(validStruct))
							newvalue = gx.num.formatNumber(newvalue, validStruct.dec, gx.rtPicture(validStruct, Elem), validStruct.len, validStruct.sign, true);
						if (DecPoint != '.' && Elem.tagName == 'SELECT')
							newvalue = gx.num.toInvariant(newvalue, ThSep, DecPoint);
					} catch (e) { validNumber = false; }
					if (validNumber && newvalue != gx.text.trim(Elem.value)) {
						Elem.value = newvalue;
						if (navigator.userAgent.indexOf("Firefox/2") != -1)
							//WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
							Elem.onchange();
					}
				}
				else {
					validNumber = false;
				}
			}
			else
				validNumber = true;
			if (!validNumber) {
				gx.csv.setFormatError(Elem);
				gx.fn.alert(Elem, gx.getMessage("GXM_badnum"));
			} else {
				gx.csv.setFormatError(Elem, false);
			}
		},

		valid_integer: function (Elem, ThSep) {
			var gx_IntRegExp, ctrlValue, validNumber;
			var vStruct = gx.O.getValidStructFld(Elem);
			var vStructEO = gx.lang.emptyObject(vStruct);
			ctrlValue = Elem.value;
			if (!vStructEO)
				ctrlValue = gx.num.extractValue(gx.rtPicture(vStruct, Elem), ctrlValue);
				
			if (!vStructEO && gx.rtPicture(vStruct, Elem).indexOf(',') != -1)				
				gx_IntRegExp = new RegExp("^[ ]*([+-]{1}[0-9]+||[0-9]*)(\\" + ThSep + "[0-9]{3})*[ ]*$");
			else
				gx_IntRegExp = new RegExp("^[ ]*(([+-]{1}[0-9]+)||([0-9]*))[ ]*$");
				
			validNumber = true;				
			if (ctrlValue) {
				if (gx_IntRegExp.test(ctrlValue)) {
					try {
						if (!vStructEO)
							ctrlValue = gx.num.formatNumber(ctrlValue, vStruct.dec, gx.rtPicture(vStruct, Elem), vStruct.len, vStruct.sign, true);
					} catch (e) { validNumber = false; }
					if (ctrlValue != gx.text.trim(Elem.value)) {
						Elem.value = ctrlValue;
						if (navigator.userAgent.indexOf("Firefox/2") != -1)
							//WA For FF 2.0 bug (https://bugzilla.mozilla.org/show_bug.cgi?id=357684)
							Elem.onchange();
					}
				}
				else {
					validNumber = false;
				}
			}
			else {
				validNumber = (Elem.type === 'number' && typeof(Elem.validity) !== 'undefined')? Elem.validity.valid: true;
			}
				
			if (!validNumber) {
				gx.csv.setFormatError(Elem);
				gx.fn.alert(Elem, gx.getMessage("GXM_badnum"));
			} else {
				gx.csv.setFormatError(Elem, false);
			}
		},
		replaceFullWidthNumerals: function(s) {
			if (typeof (s) === 'string') {
				return s.replace( FULL_WIDTH_NUMERALS,
					function(m){
						if (m.charCodeAt() == 8213 || m.charCodeAt() == 12540) {
							return String.fromCharCode(45);
						}
						return String.fromCharCode( m.charCodeAt() - 0xFEE0 );
					}
				);
			}
			return s;
		}
	};
	
	
}();
/* END OF FILE - ..\js\gxnum.js - */
/* START OF FILE - ..\js\gxcolor.js - */
gx.color = {
	rgb: function (r, g, b) {
		return (r * 256 * 256) + g * 256 + b;
	},

	css: function (Color) {
		if (Color.substring(0, 3) == 'rgb')
			return eval(Color);
		return (Color.charAt(0) == '#') ? parseInt(Color.substring(1), 16) : 0;
	},

	html: function (num) {
		var hexColor = this.toHex(num);
		if (gx.lang.emptyObject(hexColor)) {
			hexColor = "000000";
		}
		hexColor = gx.text.padl(hexColor, 6, "0");
		var htmlColor = {};
		htmlColor.Hexa = hexColor;
		htmlColor.Html = '#' + hexColor;
		htmlColor.R = parseInt(hexColor.substring(0, 2), 16);
		htmlColor.G = parseInt(hexColor.substring(2, 4), 16);
		htmlColor.B = parseInt(hexColor.substring(4, 6), 16);
		return htmlColor;
	},

	fromRGB: function (R, G, B) {
		var htmlColor = {};
		if ((typeof(R) != 'undefined') && (typeof(G) != 'undefined') && (typeof(B) != 'undefined')) {
			htmlColor.Hexa = this.toHex(R) + this.toHex(G) + this.toHex(B);
			htmlColor.Html = '#' + htmlColor.Hexa;
			htmlColor.R = R;
			htmlColor.G = G;
			htmlColor.B = B;
		}
		return htmlColor;
	},

	ARGBToHex: function (argb) {
		/*jshint bitwise:false */
		//var A = this.toHex((argb >> 24) & 0xFF);
		var R = this.toHex((argb >> 16) & 0xFF);
		var G = this.toHex((argb >> 8) & 0xFF);
		var B = this.toHex(argb & 0xFF);
		return R + G + B;
	},

	toHex: function (num) {
		if (num === undefined)
			return "000000";
		if (num < 0) {
			return gx.color.ARGBToHex(num);
		}
		var hexChars = "0123456789ABCDEF";
		if (num === 0)
			return num + '0';
		var j = 0;
		var hexStr = "";
		while (num !== 0) {
			j = num % 16;
			num = (num - j) / 16;
			hexStr = hexChars.charAt(j) + hexStr;
		}
		if ((hexStr.length % 2) !== 0)
			hexStr = '0' + hexStr;
		return hexStr;
	}
};
/* END OF FILE - ..\js\gxcolor.js - */
/* START OF FILE - ..\js\gxgrid.js - */

gx.grid = (function ($) {
	return {
		drawAtServer: false,

		deleteMethods: {
			images: 0,
			menu: 1,
			none: 2
		},

		deletePositions: {
			left: 0,
			right: 1,
			bottomR: 2,
			bottomL: 3,
			topR: 4,
			topL: 5
		},

		deleteMethod: null,
		deleteImage: null,
		undeleteImage: null,
		deletePosition: null,
		deletePositionFree: null,
		deleteTooltip: null,
		deleteTitle: null,
		lastFocusCtrl: null,

		styles: {
			none: 0,
			uniform: 1,
			header: 2,
			report: 3,
			"0": "none",
			"1": "uniform",
			"2": "header",
			"3": "report"
		},

		getImplClass: function (gridObj, implClass) {
			if (implClass) {
				gx.lang.inherits(gx.ui.grid, gx.uc.UserControl, true);
				gx.lang.inherits(gx.ui.grid, (gridObj.isResponsive) ? gx.grid.responsiveGrid : gx.grid.impl, true);
				gx.lang.inherits(implClass, gx.ui.grid, true);
				var implObj = new implClass(gx.$);
				if (gridObj) {
					implObj.ParentObject = gridObj.parentObject;
					implObj.ControlName = gridObj.gridName;
					gridObj.parentObject.setUserControl(implObj);
				}
				return implObj;
			}
			if (gridObj.isResponsive) {
				return new gx.grid.responsiveGrid('gx');
			}
			return new gx.grid.impl('gx');
		},

		validGridColsValue: function (gCols) {
			var validValue = gCols;
			if (gCols != undefined)
				validValue = gCols;
			else
				validValue = 1;
			return (validValue != 0) ? validValue : 9999;
		},


		setActiveGridRow: function(grid, cRow) {
			if (typeof(grid) === 'string') {
				grid = gx.O.getGrid(grid);
				grid = (grid)? grid.grid: null;
			}
			if (grid && grid.gxAllowSelection) {
				gx.csv.currentGridSelection = grid;
				if (typeof(cRow) !== 'undefined') {
					grid.toggleRowHoverById(grid.gxHoveredRowId, false);
					grid.gxHoveredRowId = parseInt(cRow, 10) - 1;
					if (!gx.grid.clearActiveGridHandlerInstalled) {
						gx.fx.obs.addObserver('gx.onclick', this, gx.grid.clearActiveGridHandler);
						gx.grid.clearActiveGridHandlerInstalled = true;
					}
				}
			}
		},

		clearActiveGrid: function (grid) {
			if (!grid || gx.csv.currentGridSelection === grid.grid) {
				delete gx.csv.currentGridSelection;
				delete gx.grid.clearActiveGridHandlerInstalled;
				gx.fx.obs.deleteObserver('gx.onclick', this, gx.grid.clearActiveGridHandler);
			}
		},

		clearActiveGridHandler: function (evtObj) {
			var ctrl = gx.evt.source(evtObj.event),
				gridId = gx.fn.rowGridId(ctrl),
				gridObj = gx.fn.getGridObj(gridId);
			if (!gridObj || !gridObj.grid.gxAllowSelection) {
				gx.grid.clearActiveGrid();							
			}
		},
		
		handleKeyUpEvt: function (event) {
			var activeGrid = gx.csv.currentGridSelection,
				handled = false;
			if (!activeGrid || !activeGrid.gxAllowSelection || activeGrid.gxAllowHovering)
				return handled;			
			switch (event.keyCode) {							
				case 38://up arrow	
				case 40: //down arrow 					
					activeGrid.ownerGrid.setSelection(activeGrid.ownerGrid.getSelection(), true);
					gx.evt.cancel(event, true);	
					handled = true;
					break;									
			}
			return handled;
		},
		
		handleKeyPressEvt: function (event) {
			var activeGrid = gx.csv.currentGridSelection,
				handled = false;
			if (!activeGrid || (!activeGrid.gxAllowHovering && !activeGrid.gxAllowSelection))
				return handled;
			var allowHovering = activeGrid.gxAllowHovering;
			switch (event.keyCode) {							
				case 38://up arrow											
					if (allowHovering)
						handled = activeGrid.setPreviousRowHovered();						
					else 
						activeGrid.ownerGrid.setPreviousRowSelected(false);		
					gx.evt.cancel(event, true);
					break;
				case 40: //down arrow 						
					if (allowHovering)
						handled = activeGrid.setNextRowHovered();										
					else
						activeGrid.ownerGrid.setNextRowSelected(false);		
					gx.evt.cancel(event, true);
					break;
				case 13: //enter - Set grid Selection and fires onlineactive
					handled = activeGrid.ownerGrid.setSelection(activeGrid.gxHoveredRowId) && activeGrid.gxOnLineActivate;
					break;				
			}
			return handled;
		},

		grid: function (parentObj, gLvl, gLvlName, gId, gName, rgName, cName, gCmpCtx, gIsInMaster, pName, gKey, gFreestyle, gCols, aSelect, aHover, gRows, gPaging, 
			gDragable, gSetsCtx, gBondColl, gWidth, gWidthUnit, gHeight, gHeightUnit,  newRowtext, pageSizeParm, gHasAddlines, gHasFEL, gImplClass, gOnLineActEvt, aCollap, gBondCollName, 
			gResponsive, gResponsiveCols, InfiniteScrolling, ScrollType, isAbstract, InverseLoading) {

			var GRID_CLASS = "gx-grid",
				STANDARD_GRID_CLASS = "gx-standard-grid",
				FREESTYLE_GRID_CLASS = "gx-freestyle-grid",
				RESPONSIVE_GRID_CLASS = "gx-responsive-grid", 
				GRID_FIXED_HEIGHT_CLASS = "gx-grid-fixed-height", 
				SCROLL_ALERT_SHOW_TIMEOUT = 500,
				SCROLL_ALERT_HIDE_TIMEOUT = SCROLL_ALERT_SHOW_TIMEOUT * 3,
				SCROLL_GRID = 0,
				SCROLL_FORM = 1;

			var GRID_INFINITE_SCROLLING_CONTAINER_CLASS = 'gx-infinite-scrolling-container',
				GRID_INFINITE_SCROLLING_ELEMENT_CLASS = 'gx-infinite-scrolling-element';

			var propertyValueResolverFnName = function (propName) {
				return rgName.toUpperCase() + (gIsInMaster ? '_MPAGE' : '') + "_" + propName;
			};
			var propertyValueResolverFunction = (function (propertyFn) {
				return (function (parentGridRow) {
					var ownerGrid = this.parentObject.getGridById(gId, parentGridRow || gx.fn.currentGridRow(gId));
					return propertyFn.call(this, ownerGrid || this);
				}).closure(this);
			}).closure(this);
			this.parentObject = parentObj;
			this.parentObject['sub' + gName + '_Rows'] = propertyValueResolverFunction(function (ownerGrid) {
				return ownerGrid.grid.pageSize / ownerGrid.grid.gxGridCols
			});
			this.parentObject[propertyValueResolverFnName('nFirstRecordOnPage')] = propertyValueResolverFunction(function (ownerGrid) {
				return ownerGrid.grid.firstRecordOnPage;
			});
			this.parentObject[propertyValueResolverFnName('nEOF')] = propertyValueResolverFunction(function (ownerGrid) {
				return ownerGrid.grid.eof;
			});
			this.gridLvl = gLvl;
			this.gridLvlName = gLvlName;
			this.gridId = gId;
			this.gridName = gName;
			this.realGridName = rgName;
			this.containerName = cName || this.gridName + "Container";
			this.parentName = pName || "";
			this.pagingParms = [];
			this.lvlKey = gKey || [];
			this.isFreestyle = gFreestyle || false;
			this.isResponsive = gResponsive || false;
			this.allowSelection = aSelect || false;
			this.allowHovering = this.allowSelection && aHover || false;
			this.allowCollapsing = aCollap || false;
			this.collapsed = false;
			this.sortable = true;
			this.selectionColor = null;
			this.hoverColor = null;
			this.visible = true;
			this.refreshTimer = null;
			this.pageSizeParm = pageSizeParm || false;
			this.hasAddlines = gHasAddlines || false;
			this.hasForEachLine = gHasFEL || false;
			this.width = (gWidth != undefined) ? gWidth : 0;
			this.widthUnit = gWidthUnit || '';
			this.height = (gHeight != undefined) ? gHeight : 0;
			this.heightUnit = gHeightUnit || '';
			this.gridCols = (gCols != undefined) ? gCols : 1;
			this.gridCols = (this.gridCols != 0) ? this.gridCols : 9999;
			this.gridRows = (gRows != undefined) ? gRows : 5;
			this.gridResponsiveCols = gResponsiveCols || [1, 1, 1, 1];
			this.usePaging = gPaging || false;
			this.usePaging = this.usePaging && !this.isFreestyle;
			this.eof = 1;
			this.firstRecordOnPage = 0;
			this.defaultDragable = gDragable || false;
			this.defaultSetsContext = gSetsCtx || false;
			this.boundedCollType = gBondColl || '';
			this.boundedCollName = gBondCollName || '';
			this.contextMenu = null;
			this.gxContainerCtrl = null;
			this.lastRefreshParms = "";
			this.gxComponentContext = gCmpCtx;
			this.isMasterPageGrid = gIsInMaster;
			this.htmlTags = "";
			this.onLineActivate = gOnLineActEvt;
			this.addingRows = false;
			this.deleteMethod = gx.grid.deleteMethod;
			this.DatePickersControls = [];
			this.GridUserControls = [];
			this.GridComponents = [];
			this.GridControls = [];
			this.IsValidState = [];
			this.implClass = gImplClass;
			this.grid = gx.grid.getImplClass(this, gImplClass);
			this.grid.ownerGrid = this;
			this.grid.parentGxObject = this.parentObject;
			this.grid.gxLvl = this.gridLvl;
			this.grid.gxId = this.gridId;
			this.grid.gxGridName = this.gridName;
			this.grid.gxGridObject = this.containerName;
			this.grid.gxParentName = this.parentName;
			this.grid.gxIsFreestyle = this.isFreestyle;
			this.grid.gxWidth = this.width;
			this.grid.gxWidthUnit = this.widthUnit;
			this.grid.gxHeight = 0;
			this.grid.gxAllowSelection = this.allowSelection;
			this.grid.gxAllowHovering = this.allowHovering;
			this.grid.gxAllowCollapsing = this.allowCollapsing;
			this.grid.gxCollapsed = this.collapsed;
			this.grid.gxSortable = this.sortable;
			this.grid.gxSelectionColor = this.selectionColor;
			this.grid.gxHoverColor = this.hoverColor;
			this.grid.gxVisible = this.visible;
			this.grid.gxGridCols = this.gridCols;
			this.grid.gxGridResponsiveCols = this.gridResponsiveCols;
			this.grid.gxCmpContext = this.gxComponentContext;
			this.grid.gxHtmlTags = this.htmlTags;
			this.grid.gxIsMasterPageGrid = this.isMasterPageGrid;
			this.grid.gxDragable = this.defaultDragable;
			this.grid.gxHasAddlines = this.hasAddlines;
			this.grid.gxHasForEachLine = this.hasForEachLine;
			this.grid.gxOnLineActivate = this.onLineActivate;
			this.grid.gxNewRowText = (newRowtext != undefined) ? newRowtext : "New Row";
			this.grid.beforeRenderCallbacks = [];
			this.grid.isAbstract = isAbstract;
			this.isUsercontrol = gx.lang.instanceOf(this.grid, gx.uc.UserControl);
			this.useUserControlModelValues = function () {
				return this.isUsercontrol && !this.grid.useNativeChildControls;
			};
			this.currentBuffer = this.grid.gxBuffer;
			this.parentGrid = null;
			this.childGrids = [];
			this.hiddens = [];
			this.grid.selectedRows = [];
			this.oldCmps = {};
			this.ColumnPropertiesAfterRender = [];
			this.grid.useHiddensForControlValues = this.isUsercontrol && (this.grid.useHiddensForControlValues || this.grid.useHiddensForControlValues === 'undefined');
			this.gxCreateGridCode = (function (pRowId) {
				var prop,
					i,
					gridControl = new gx.grid.grid(this.parentObject, this.gridLvl, this.gridLvlName, this.gridId, this.gridName + '_' + pRowId, this.gridName, this.containerName + '_' + pRowId, this.gxComponentContext, this.isMasterPageGrid, this.parentName, this.lvlKey, this.isFreestyle, this.gridCols, this.allowSelection, this.allowHovering, this.gridRows, this.usePaging, this.defaulDragable, this.defaultSetsContext, this.boundedCollType, this.width, this.widthUnit, this.height, this.heightUnit, this.grid.gxNewRowText, this.pageSizeParm, this.hasAddlines, this.hasForEachLine, this.implClass, this.onLineActivate, this.allowCollapsing, this.boundedCollName, this.isResponsive, this.gridResponsiveCols, false, SCROLL_GRID, this.grid.isAbstract, this.InverseLoading),
					baseGridImpl = this.grid,
					newGridImpl = gridControl.grid;
					
				newGridImpl.ControlLvl = this.gridLvl;
				newGridImpl.GridId = this.gridId;
				newGridImpl.GridRow = pRowId;
				newGridImpl.GridBaseName = this.gridName;

				if (baseGridImpl.Properties) {
					for (prop in baseGridImpl.Properties) {
						newGridImpl.setProp(prop, baseGridImpl.Properties[prop], baseGridImpl[prop], baseGridImpl.PropTypes[prop]);
					}
				}
				if (baseGridImpl.DynProperties) {
					for (i=0, len=baseGridImpl.DynProperties.length; i<len; i++) {
						prop = baseGridImpl.DynProperties[i];
						newGridImpl.setDynProp(prop, baseGridImpl.Properties[prop], baseGridImpl[prop], baseGridImpl.PropTypes[prop], true);
					}
				}
				return gridControl;
			}).closure(this);
			this.gxAddColumnsCode = [];
			this.grid.usePaging = this.usePaging;
			this.grid.eof = this.eof;
			this.grid.firstRecordOnPage = this.firstRecordOnPage;
			this.postingVariables = [];
			this.InfiniteScrolling = InfiniteScrolling;
			this.InverseLoading = InverseLoading;
			this.ScrollType = ScrollType;
			this.isAbstract = isAbstract;

			this.addColumnDinCode = function (func, args) {
				this.gxAddColumnsCode.push(function () { func.apply(this, args); });
			}

			this.addSingleLineEdit = function (colAttId, colId, colHtmlName, colTitle, colTooltip, colAttName, colType, colWidth, colWidthUnit, colMLength, colSize, colAlign, hasClick, suggestInfo, hcAttId, hcAttName, colVisible, colDecimals, setCtx, isPassword, cssClass, hasTheme, columnClass, columnHeaderClass) {
				this.addColumnDinCode(this.addSingleLineEdit, arguments);
				var newCol = this.newColumn(colTitle, colType, colAlign, colWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxTooltip = colTooltip;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxColSize = colSize;
				newCol.gxSetsContext = setCtx;
				newCol.gxCssClass = cssClass;
				newCol.gxColumnClass = columnClass;
				newCol.gxColumnHeaderClass = columnHeaderClass;
				newCol.gxControl = new gx.html.controls.singleLineEdit();
				newCol.gxControl.column = newCol;
				newCol.gxControl.isPassword = isPassword;
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addPostingVar = function (varName) {
				this.postingVariables.push(varName);
			}

			this.addMultipleLineEdit = function (colAttId, colId, colHtmlName, colTitle, colAttName, colType, colWidth, colWidthUnit, colHeight, colHeightUnit, colMLength, colSize, colAlign, hasClick, colVisible, setCtx, colFormat, columnClass) {
				this.addColumnDinCode(this.addMultipleLineEdit, arguments);
				var newCol = this.newColumn(colTitle, colType, colAlign, colWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxSetsContext = setCtx;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.multipleLineEdit();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.heightUnit = colHeightUnit;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addBlob = function (colAttId, colId, colHtmlName, colTitle, colAttName, colType, bDisplay, cHeight, cWidth, cHUnit, cWUnit, colVisible, setCtx, columnClass) {
				this.addColumnDinCode(this.addBlob, arguments);
				var newCol = this.newColumn(colTitle, colType, "left", cWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxWidthUnit = cWUnit;
				newCol.gxSetsContext = setCtx;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.blob();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.height = cHeight;
				newCol.gxControl.width = cWidth;
				this.grid.addColumn(newCol);
			}

			this.addRadioButton = function (colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, colVertical, colVisible, setCtx, columnClass) {
				this.addColumnDinCode(this.addRadioButton, arguments);
				var newCol = this.newColumn(colTitle, colType, "left", '');
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxSetsContext = setCtx;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.radio();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.vertical = colVertical;
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addComboBox = function (colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, rtEnabled, colVisible, setCtx, colWidth, colWidthUnit, columnClass) {
				this.addColumnDinCode(this.addComboBox, arguments);
				var newCol = this.newColumn(colTitle, colType, "left", colWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxSetsContext = setCtx;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.comboBox();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.rtEnabled = (rtEnabled == 1);
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addListBox = function (colAttId, colId, colHtmlName, colTitle, colAttName, colType, hasClick, rtEnabled, colVisible, setCtx, colWidth, colWidthUnit, columnClass, colRows) {
				this.addColumnDinCode(this.addListBox, arguments);
				var newCol = this.newColumn(colTitle, colType, "left", colWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxSetsContext = setCtx;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.listBox();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.rows = (colRows !== undefined ? colRows : 4);
				newCol.gxControl.rtEnabled = (rtEnabled == 1);
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addCheckBox = function (colAttId, colId, colHtmlName, colTitle, colCaption, colAttName, colType, checkedVal, unCheckedVal, hasClick, colVisible, setCtx, colWidth, colWidthUnit, columnClass) {
				this.addColumnDinCode(this.addCheckBox, arguments);
				var newCol = this.newColumn(colTitle, colType, "left", colWidth);
				newCol.visible = colVisible;
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxAttName = colAttName;
				newCol.gxChecked = checkedVal;
				newCol.gxUnChecked = unCheckedVal;
				newCol.gxSetsContext = setCtx;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxColumnClass = columnClass;
				newCol.gxControl = new gx.html.controls.checkBox();
				newCol.gxControl.column = newCol;
				newCol.gxControl.checkedValue = checkedVal;
				newCol.gxControl.uncheckedValue = unCheckedVal;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.visible = newCol.visible;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addBitmap = function (colAttId, colHtmlName, colId, colWidth, colWidthUnit, colHeight, colHeightUnit, hasClick, jsCode, colTitle, cssClass, columnClass) {
				this.addColumnDinCode(this.addBitmap, arguments);
				var newCol = this.newColumn(colTitle, "", "left", colWidth);
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxControl = new gx.html.controls.image();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.width = colWidth;
				newCol.gxControl.widthUnit = colWidthUnit;
				newCol.gxControl.height = colHeight;
				newCol.gxControl.heightUnit = colHeightUnit;
				newCol.gxControl.clickEvent = hasClick;
				newCol.gxCssClass = cssClass;
				newCol.gxColumnClass = columnClass;
				this.grid.addColumn(newCol);
			}

			this.addVideo = function (colAttId, colHtmlName, colId, colWidth, colWidthUnit, colHeight, colHeightUnit, hasClick, jsCode, colTitle, cssClass, columnClass) {
				this.addColumnDinCode(this.addVideo, arguments);
				var newCol = this.newColumn(colTitle, "", "left", colWidth);
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxControl = new gx.html.controls.video();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.width = colWidth;
				newCol.gxControl.widthUnit = colWidthUnit;
				newCol.gxControl.height = colHeight;
				newCol.gxControl.heightUnit = colHeightUnit;
				newCol.gxControl.clickEvent = hasClick;
				newCol.gxCssClass = cssClass;
				newCol.gxColumnClass = columnClass;
				this.grid.addColumn(newCol);
			}

			this.addAudio = function (colAttId, colHtmlName, colId, colWidth, colWidthUnit, colHeight, colHeightUnit, hasClick, jsCode, colTitle, cssClass, columnClass) {
				this.addColumnDinCode(this.addAudio, arguments);
				var newCol = this.newColumn(colTitle, "", "left", colWidth);
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxControl = new gx.html.controls.audio();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.width = colWidth;
				newCol.gxControl.widthUnit = colWidthUnit;
				newCol.gxControl.height = colHeight;
				newCol.gxControl.heightUnit = colHeightUnit;
				newCol.gxControl.clickEvent = hasClick;
				newCol.gxCssClass = cssClass;
				newCol.gxColumnClass = columnClass;
				this.grid.addColumn(newCol);
			}

			this.addFile = function (colAttId, colHtmlName, colId, colWidth, colWidthUnit, colHeight, colHeightUnit, hasClick, jsCode, colTitle, cssClass, columnClass) {
				this.addColumnDinCode(this.addVideo, arguments);
				var newCol = this.newColumn(colTitle, "", "left", colWidth);
				newCol.htmlName = colHtmlName;
				newCol.gxId = colId;
				newCol.gxAttId = colAttId;
				newCol.gxWidthUnit = colWidthUnit;
				newCol.gxControl = new gx.html.controls.file();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.width = colWidth;
				newCol.gxControl.widthUnit = colWidthUnit;
				newCol.gxControl.height = colHeight;
				newCol.gxControl.heightUnit = colHeightUnit;
				newCol.gxControl.clickEvent = hasClick;
				newCol.gxCssClass = cssClass;
				newCol.gxColumnClass = columnClass;
				this.grid.addColumn(newCol);
			}

			this.addTextBlock = function (colHtmlName, hasClick, colId) {
				this.addColumnDinCode(this.addTextBlock, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxId = colId;
				newCol.htmlName = colHtmlName;
				newCol.gxControl = new gx.html.controls.textBlock();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.gxControl.clickEvent = hasClick;
				this.grid.addColumn(newCol);
			}

			this.addLabel = function (colHtmlName) {
				this.addColumnDinCode(this.addLabel, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.htmlName = colHtmlName;
				newCol.gxControl = new gx.html.controls.label();
				newCol.gxControl.column = newCol;
				this.grid.addColumn(newCol);
			};

			this.addButton = function (ControlId, HtmlName, BorderStyle, GxEvent, EventName) {
				this.addColumnDinCode(this.addButton, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.htmlName = HtmlName;
				newCol.gxId = ControlId;
				newCol.gxControl = new gx.html.controls.button();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.addGrid = function (GridCtrl) {
				this.addColumnDinCode(this.addGrid, arguments);
				this.childGrids.push(GridCtrl);
				var newCol = this.newColumn("", "", "left");
				newCol.htmlName = GridCtrl.getContainerControlId();
				newCol.gxControl = new gx.html.controls.grid();
				newCol.gxControl.column = newCol;
				this.grid.addColumn(newCol);
			}

			this.addUsercontrol = function (ControlId, LastId, ClassName, ContainerName, ControlName, FieldName, ShowFunc, C2VFuncs, V2CFuncs, ColVisible) {
				this.addColumnDinCode(this.addUsercontrol, arguments);
				var colTitle = "",
					gxO = this.parentObject;
				if (gxO.GridUCsProps && gxO.GridUCsProps[ControlName]) {
					colTitle = gxO.GridUCsProps[ControlName].title || "";
				}
				var newCol = this.newColumn(colTitle, "", "left");
				newCol.gxUCId = ControlId;
				newCol.gxUCLastId = LastId;
				newCol.gxUCClassName = ClassName;
				newCol.gxUCContainerName = ContainerName;
				newCol.gxUCControlName = ControlName;
				newCol.gxUCFieldName = FieldName;
				newCol.gxShowFunc = ShowFunc;
				newCol.gxC2VFuncs = C2VFuncs;
				newCol.gxV2CFuncs = V2CFuncs;
				newCol.visible = ColVisible
				newCol.gxControl = new gx.html.controls.userControl();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				newCol.htmlName = ControlName.toUpperCase();
				newCol.isUserControl = true;
				this.grid.addColumn(newCol);
			}

			this.startContainer = function () {
				this.addColumnDinCode(this.startContainer, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.userControlContainer();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endContainer = function () {
				this.addColumnDinCode(this.endContainer, arguments);
				this.currentBuffer.append("</div>");
			}

			this.addWebComponent = function (ControlName) {
				this.addColumnDinCode(this.addWebComponent, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.webComponent();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.addEmbeddedPage = function (ControlName) {
				this.addColumnDinCode(this.addEmbeddedPage, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.embeddedPage();
				newCol.gxControl.column = newCol;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.addHtmlCode = function (Code) {
				this.addColumnDinCode(this.addHtmlCode, arguments);
				this.currentBuffer.append(Code);
			}

			this.startTable = function (CtrlName, TId, Width) {
				this.addColumnDinCode(this.startTable, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxId = TId;
				newCol.htmlName = CtrlName + '_' + TId;
				newCol.gxControl = new gx.html.controls.table();
				newCol.gxControl.column = newCol;
				newCol.gxControl.width = Width;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endTable = function () {
				this.addColumnDinCode(this.endTable, arguments);
				this.currentBuffer.append("</table>");
			}

			this.startRow = function (Title, Align, Valign, Bgcolor, Bordercolor, Class) {
				this.addColumnDinCode(this.startRow, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.row();
				newCol.gxControl.column = newCol;
				newCol.gxControl.title = Title;
				newCol.gxControl.align = Align;
				newCol.gxControl.verticalAlign = Valign;
				newCol.gxControl.backColor = Bgcolor;
				newCol.gxControl.borderColor = Bordercolor;
				newCol.gxControl.cssClass = Class;
				newCol.gxControl.ownCssClass = Class;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endRow = function () {
				this.addColumnDinCode(this.endRow, arguments);
				this.currentBuffer.append("</tr>");
			}

			this.startCell = function (Title, Align, Valign, Bgcolor, Bordercolor, Height, Width, Colspan, Rowspan, Class) {
				this.addColumnDinCode(this.startCell, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.cell();
				newCol.gxControl.column = newCol;
				newCol.gxControl.title = Title;
				newCol.gxControl.align = Align;
				newCol.gxControl.verticalAlign = Valign;
				newCol.gxControl.backColor = Bgcolor;
				newCol.gxControl.borderColor = Bordercolor;
				newCol.gxControl.height = Height;
				newCol.gxControl.width = Width;
				newCol.gxControl.colSpan = Colspan;
				newCol.gxControl.rowSpan = Rowspan;
				newCol.gxControl.cssClass = Class;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endCell = function () {
				this.addColumnDinCode(this.endCell, arguments);
				if (this.isResponsive) {
					this.currentBuffer.append("</div>");
				}
				else {
					this.currentBuffer.append("</td>");
				}
			}

			this.startGroup = function (Id, Caption, Height, Width, ClassName) {
				this.addColumnDinCode(this.startGroup, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.htmlName = Id;
				newCol.gxControl = new gx.html.controls.group();
				newCol.gxControl.column = newCol;
				newCol.gxControl.id = Id;
				newCol.gxControl.caption = Caption;
				newCol.gxControl.height = Height;
				newCol.gxControl.width = Width;
				newCol.gxControl.cssClass = ClassName;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endGroup = function () {
				this.addColumnDinCode(this.endGroup, arguments);
				this.currentBuffer.append("</fieldset>");
			}

			this.startDiv = function (TId, CtrlName, Height, Width) {
				this.addColumnDinCode(this.startDiv, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxId = TId;
				newCol.htmlName = CtrlName + '_' + TId;
				newCol.gxControl = new gx.html.controls.div();
				newCol.gxControl.column = newCol;
				newCol.gxControl.width = Width;
				newCol.gxControl.height = Height;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endDiv = function () {
				this.addColumnDinCode(this.endDiv, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.divEnd();
				newCol.gxControl.column = newCol;
				this.grid.addColumn(newCol);
			}

			this.startFormGroup = function (TId, CtrlName, Height, Width) {
				this.addColumnDinCode(this.startFormGroup, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxId = TId;
				newCol.htmlName = CtrlName + '_' + TId;
				newCol.gxControl = new gx.html.controls.formGroup();
				newCol.gxControl.column = newCol;
				newCol.gxControl.width = Width;
				newCol.gxControl.height = Height;
				newCol.gxControl.dataType = newCol.type;
				this.grid.addColumn(newCol);
			}

			this.endFormGroup = function () {
				this.addColumnDinCode(this.endFormGroup, arguments);
				var newCol = this.newColumn("", "", "left");
				newCol.gxControl = new gx.html.controls.formGroupEnd();
				newCol.gxControl.column = newCol;
				this.grid.addColumn(newCol);
			}

			this.newColumn = function (colTitle, colType, colAlign, colWidth) {
				var columnType = this.getColumnType(colType);
				var newCol = new gx.grid.column(colTitle, columnType, colWidth, colAlign);
				this.currentBuffer = newCol.buffer;
				newCol.htmlName = '';
				newCol.gxId = '';
				newCol.gxAttId = '';
				newCol.gxAttName = '';
				return newCol;
			}

			this.getColumnType = function (colType) {
				var columnType;
				switch (colType) {
					case 'decimal':
					case 'int':
						columnType = gx.types.numeric;
						break;
					case 'date':
						columnType = gx.types.date;
						break;
					case 'dtime':
						columnType = gx.types.dateTime;
						break;
					case 'boolean':
						columnType = gx.types.bool;
						break;
					case 'GeneXus\\Geolocation':
						columnType = gx.types.geolocation;
						break;
					default:
						columnType = gx.types.character;
						break;
				}
				return columnType;
			}

			this.addOldComponent = function (rowId, ctrlId) {
				if (typeof (this.oldCmps[rowId]) == 'undefined') {
					this.oldCmps[rowId] = [];
				}
				this.oldCmps[rowId].push(ctrlId);
			}

			this.updateOldComponents = function () {
				var len = this.grid.rows.length;
				for (var i = 0; i < len; i++) {
					delete this.oldCmps[this.grid.rows[i].gxId];
				}
				for (var rowId in this.oldCmps) {
					var rowCmps = this.oldCmps[rowId];
					while (rowCmps.length > 0) {
						var ctrlName = rowCmps.shift();
						gx.fn.deleteHidden(ctrlName);
					}
					delete this.oldCmps[rowId];
				}
			}

			this.addHidden = function (CtrlName) {
				this.hiddens.push(CtrlName);
			}

			this.addHiddenControl = function (CtrlName, CtrlValue, Persistent) {
				gx.fn.setHidden(CtrlName, CtrlValue);
				if (Persistent != true)
					this.addHidden(CtrlName);
			}

			this.clearHiddens = function () {
				for (var i=0; i<this.hiddens.length; i++) {
					var ctrlName = this.hiddens[i];
					gx.fn.deleteHidden(ctrlName);
				}
				this.hiddens = [];
			}

			var gridAttributes = {};
			this.setHtmlTags = function (GridProps) {
				gx.lang.apply(gridAttributes, GridProps);

				var HtmlTags = "";
				var HtmlTagsStyle = " style=\"";
				HtmlTagsStyle += gridAttributes.Visible == "0" ? "display:none;" : "";
				HtmlTags += " class=\"" + gridAttributes.Class + "\"";

				var eo = gx.lang.emptyObject;

				HtmlTagsStyle += !eo(gridAttributes.Background) ? ("background:" + gridAttributes.Background + ";") : "";
				HtmlTagsStyle += !eo(gridAttributes.Backcolor) && gridAttributes.Backcolor != "0" ? ("background-color:" + gx.color.html(gridAttributes.Backcolor).Html + ";") : "";
				HtmlTagsStyle += !eo(gridAttributes.Bordercolor) && gridAttributes.Bordercolor != "0" ? ("border-color:" + gx.color.html(gridAttributes.Bordercolor).Html + ";") : "";
				HtmlTagsStyle += !eo(gridAttributes.Borderwidth) && gridAttributes.Borderwidth != "0" ? (" border-width:" + gridAttributes.Borderwidth + ";") : "";

				HtmlTagsStyle += !eo(gridAttributes.Width) && gridAttributes.Width != "0" ? (" width:" + gx.dom.addUnits(gridAttributes.Width, (this.width == gridAttributes.Width)? this.widthUnit: '') + ";") : "";
				HtmlTagsStyle += !eo(gridAttributes.Height) && gridAttributes.Height != "0" ? ("max-height:" + gx.dom.addUnits(gridAttributes.Height, (this.height == gridAttributes.Height)? this.heightUnit: '') + ";") : "";

				HtmlTags += !eo(gridAttributes.Align) ? (" align=\"" + gridAttributes.Align + "\"") : "";
				HtmlTags += !eo(gridAttributes.Tooltiptext) ? (" title=\"" + gridAttributes.Tooltiptext + "\"") : "";				
				HtmlTags += !eo(gridAttributes.Cellpadding) ? (" data-cellpadding=\"" + gridAttributes.Cellpadding + "\"") : "";
				HtmlTags += !eo(gridAttributes.Cellspacing) ? (" data-cellspacing=\"" + gridAttributes.Cellspacing + "\"") : "";			

				HtmlTags += HtmlTagsStyle + "\"";

				this.htmlTags = gx.text.trim(HtmlTags);
				this.grid.gxHtmlTags = this.htmlTags;

				if (!eo(gridAttributes.Width)) {
					this.grid.gxWidth = gridAttributes.Width;
				}
				if (!eo(gridAttributes.Height)) {
					this.grid.gxHeight = gridAttributes.Height;
				}
			}

			var gridStyles = {};
			this.setGridStyles = function (props) {
				gx.lang.apply(gridStyles, props);
			
			this.grid.header = props.Header;
				this.visible = (gridStyles.Visible != undefined) ? gx.lang.gxBoolean(gridStyles.Visible) : true;
				this.setSortable(((gridStyles.Sortable != undefined) ? gx.lang.gxBoolean(gridStyles.Sortable) : true));
				this.background = (gridStyles.Background != undefined) ? gridStyles.Background : '';
				this.cssClass = (gridStyles.Class != undefined) ? gridStyles.Class : '';
				this.titleBackstyle = (gridStyles.Backcolorstyle != undefined) ? gridStyles.Backcolorstyle : gx.grid.styles.none;
				this.titleFont = (gridStyles.Titlefont != undefined) ? gridStyles.Titlefont : '';
				this.linesFont = (gridStyles.Linesfont != undefined) ? gridStyles.Linesfont : '';
				this.borderWidth = (gridStyles.Borderwidth != undefined) ? gridStyles.Borderwidth : '';
				this.toolTipText = (gridStyles.Tooltiptext != undefined) ? gridStyles.Tooltiptext : '';
				try {
					this.backcolor = (gridStyles.Backcolor != undefined) ? gx.color.html(gridStyles.Backcolor).Html : '';
					this.titleBackcolor = (gridStyles.Titlebackcolor != undefined) ? gx.color.html(gridStyles.Titlebackcolor).Html : '';
					this.titleForecolor = (gridStyles.Titleforecolor != undefined) ? gx.color.html(gridStyles.Titleforecolor).Html : '';
					this.linesBackcolorOdd = (gridStyles.Backcolorodd != undefined) ? gx.color.html(gridStyles.Backcolorodd).Html : '';
					this.linesBackcolorEven = (gridStyles.Backcoloreven != undefined) ? gx.color.html(gridStyles.Backcoloreven).Html : '';
					this.bordercolor = (gridStyles.Bordercolor != undefined) ? gx.color.html(gridStyles.Bordercolor).Html : '';
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'setGridStyles');
				}
				this.borderWidth = (gridStyles.Borderwidth != undefined) ? gridStyles.Borderwidth : '';
				this.toolTipText = (gridStyles.Tooltiptext != undefined) ? gridStyles.Tooltiptext : '';

				this.grid.gxCssClass = "";
				this.grid.gxTitleClass = "";
				this.grid.gxFooterClass = "";
				this.grid.gxOddLlinesClass = "";
				this.grid.gxEvenLinesClass = "";

				this.grid.gxBackColor = this.backcolor;
				this.grid.gxTitleBackColor = this.titleBackcolor;
				this.grid.gxTitleForeColor = this.titleForecolor;
				this.grid.gxTitleBackstyle = this.titleBackstyle;
				this.grid.gxTitleFont = this.titleFont;
				this.grid.gxLinesFont = this.linesFont;
				this.grid.gxBackground = this.background;
				this.grid.gxLinesBackcolorOdd = this.linesBackcolorOdd;
				this.grid.gxLinesBackcolorEven = this.linesBackcolorEven;
				this.grid.gxBorderWidth = this.borderWidth;
				this.grid.gxBordercolor = this.bordercolor;
				this.grid.gxToolTipText = this.toolTipText;
				this.grid.gxVisible = this.visible;

				if (this.cssClass != "") {
					this.grid.gxCssClass = this.cssClass;
					this.grid.gxTitleClass = this.cssClass + "Title";
					this.grid.gxFooterClass = this.cssClass + "Footer";
					if (this.titleBackstyle == gx.grid.styles.none) {
						this.grid.gxOddLlinesClass = this.cssClass + "Odd";
						this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
					}
					else if (this.titleBackstyle == gx.grid.styles.uniform) {
						this.grid.gxOddLlinesClass = this.cssClass + "Uniform";
						this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
					}
					else if (this.titleBackstyle == gx.grid.styles.header) {
						this.grid.gxOddLlinesClass = this.cssClass + "Odd";
						this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
					}
					else if (this.titleBackstyle == gx.grid.styles.report) {
						if (this.isFreestyle && (this.gridCols <= 0)) {
							this.grid.gxOddLlinesClass = this.cssClass + "Odd";
							this.grid.gxEvenLinesClass = this.grid.gxOddLlinesClass;
						}
						else {
							this.grid.gxOddLlinesClass = this.cssClass + "Odd";
							this.grid.gxEvenLinesClass = this.cssClass + "Even";
						}
					}
				}
			}

			this.setSortable = function (sortable) {
				if (this.sortable != sortable) {
					this.sortable = sortable;
					var len = this.grid.columns.length;
					for (var i = 0; i < len; i++) {
						this.grid.columns[i].sortable = sortable;
					}
				}
			}

			this.lastRowId = 0;
			this.addRow = function (rowProps) {
				var z, length, lenAux, commonProps;
				var rowId = this.lastRowId++;
				var gxRowIdx = gx.grid.rowId(rowId + 1);
				var row = new gx.grid.row(rowId, rowProps, gxRowIdx, this.grid.gxParentRowId);
				row.gxCmpContext = this.gxComponentContext;
				row.Grids = rowProps.Grids;
				row.ownerGrid = this;
				row.gxLvl = this.gridLvl;
				this.setRowHiddens(rowProps.Hiddens);
				var columns = this.grid.columns;						
				var len = columns.length;
				for (var i = 0; i < len; i++) {
					var column = columns[i];
					if (rowId !== 0) {
						commonProps = this.grid.rows[0].gxProps[i];
						length = rowProps.Props[i].length;
						lenAux = (this.grid.rowsValues)? commonProps.length - 1:commonProps.length;
						for (z = length; z < lenAux; z++) {
							row.gxProps[i].push(commonProps[z]);
						}
					}
					var colProps = rowProps.Props[i];
					var colValue = colProps[colProps.length - 1];
					var rValues = this.grid.rowsValues;				
					if (rValues && !this.autoRefreshing) {
						var rowValue = rValues[rowId];
						if (rowValue !== undefined && rowValue.length > 0) 						
							colValue = rValues[rowId][i];
					}			
					row.values[i] = colValue;
					if (this.grid.rowsValues) {
						row.gxProps[i].push(colValue);
					}
					if (this.parentObject.isTransaction()) {
						var idxInKey = this.columnIndexInKey(column.gxAttId);
						if (idxInKey != -1) {
							row.gxKeyValues[idxInKey] = colValue;
						}
					}
				}
				if (this.isFreestyle) {
					row.IsNew = true;
					this.installChildGrids(row);
				}
				this.grid.addRow(row);
				return row;
			}

			this.installChildGrids = function (row) {
				var len = this.childGrids.length;
				for (var i = 0; i < len; i++) {
					var gxChildGrid = this.childGrids[i];
					var rowGrid = gxChildGrid.gxCreateGridCode(row.gxId);
					rowGrid.grid.parentGxObject = this.parentObject;
					var cntName = ((!rowGrid.isMasterPageGrid) ? this.grid.gxCmpContext : 'MP') + rowGrid.realGridName + 'Container';
					rowGrid.gxContainerDivName = cntName + 'Div_' + row.gxId;
					rowGrid.gxContainerDataName = cntName + 'Data_' + row.gxId;
					rowGrid.gxContainerValuesName = cntName + 'DataV_' + row.gxId;
					row.gxGrids.push(rowGrid);
					rowGrid.parentGrid = this;
					rowGrid.parentRow = row;
					this.parentObject.setGrid(rowGrid);
					gxChildGrid.copyPropertiesTo(rowGrid);
					rowGrid.grid.gxCmpContext = this.grid.gxCmpContext;
					rowGrid.grid.gxParentRowId = row.gxId;
					this.installChildGridColumns(rowGrid, gxChildGrid);
				}
			}

			this.installChildGridColumns = function (Grid, gxChildGrid) {
				var len = gxChildGrid.gxAddColumnsCode.length;
				for (var i = 0; i < len; i++) {
					gxChildGrid.gxAddColumnsCode[i].call(Grid);
				}
			}

			this.copyPropertiesTo = function (RowGrid) {
				RowGrid.cssClass = this.cssClass;
				RowGrid.titleBackstyle = this.titleBackstyle;
				RowGrid.titleBackcolor = this.titleBackcolor;
				RowGrid.linesBackcolorOdd = this.linesBackcolorOdd;
				RowGrid.linesBackcolorEven = this.linesBackcolorEven;
				RowGrid.grid.gxCssClass = this.grid.gxCssClass;
				RowGrid.grid.gxTitleClass = this.grid.gxTitleClass;
				RowGrid.grid.gxOddLlinesClass = this.grid.gxOddLlinesClass;
				RowGrid.grid.gxEvenLinesClass = this.grid.gxEvenLinesClass;
				RowGrid.grid.gxAllowCollapsing = this.grid.gxAllowCollapsing;
				RowGrid.grid.gxCollapsed = this.grid.gxCollapsed;
			}

			this.setRowHiddens = function (hiddens) {
				if (hiddens && this.parentObject.isTransaction()) {
					for (var name in hiddens)
						gx.fn.setHidden(name, hiddens[name]);
				}
			}

			this.executeEvent = function (EventName, rowId) {
				gx.evt.setGridEvt(this.gridId.toString(), rowId);
				this.instanciateRow(rowId);
				this.parentObject[EventName].call(this.parentObject, rowId);
			}

			this.getHiddenName = function (HiddenName) {
				var gridRow = '';
				if (this.parentRow) {
					gridRow = '_' + this.parentRow.gxId;
				}
				return this.grid.gxCmpContext + this.realGridName.toUpperCase() + (this.isMasterPageGrid ? '_MPAGE' : '') + "_" + HiddenName + gridRow;
			}

			this.updatePagingVars = function (Eof, FirstRecordOnPage) {
				if (Eof == undefined && FirstRecordOnPage == undefined) {
					this.grid.eof = gx.fn.getHidden(this.getHiddenName("nEOF"));
					this.grid.firstRecordOnPage = gx.fn.getHidden(this.getHiddenName("nFirstRecordOnPage"));
				}
				else {
					this.grid.eof = Eof;
					this.grid.firstRecordOnPage = FirstRecordOnPage;
				}
			}

			this.setPagingVars = function (Eof, FirstRecordOnPage) {
				this.grid.eof = Eof;
				this.grid.firstRecordOnPage = FirstRecordOnPage;
				gx.fn.setHidden(this.getHiddenName("nEOF"), Eof);
				gx.fn.setHidden(this.getHiddenName("nFirstRecordOnPage"), FirstRecordOnPage);
			}

			this.clearDefaultEventHandlers = function () {
				var len = 0;
				if (this.defaultDragable || this.defaultSetsContext) {
					len = this.grid.rows.length;
					for (var i = 0; i < len; i++) {
						var trId = this.containerName + 'Row_' + this.grid.rows[i].gxId;
						if (this.defaultDragable)
							gx.fx.dnd.deleteSource(trId);
						if (this.defaultSetsContext)
							gx.fx.ctx.deleteSetter(trId);
					}
				}
				len = this.grid.columns.length;
				for (var i = 0; i < len; i++) {
					var currCol = this.grid.columns[i];
					if (currCol.gxSetsContext == true) {
						var len1 = this.grid.rows.length;
						for (var j = 0; j < len1; j++) {
							gx.fx.ctx.deleteSetter(currCol.htmlName + '_' + this.grid.rows[j].gxId);
						}
					}
				}
			}

			this.setDefaultEventHandlers = function () {
				var len = 0;
				var firstNewRow = (this.additiveResponse) ? this.firstAdditiveRow : 0;
				var evtTypes = this.getRowAsTypes();
				if (this.defaultDragable || this.defaultSetsContext) {
					if (!gx.lang.emptyObject(this.boundedCollType)) {
						var divId = this.grid.gxCmpContext + this.containerName + "Div";
						var callback = (function () {
							return this.returnGridData();
						}).closure(this);
						if (this.defaultDragable)
							gx.fx.dnd.addSource(this.parentObject, divId, this.cssClass, [this.boundedCollType], callback);
						if (this.defaultSetsContext)
							gx.fx.ctx.addSetter(this.parentObject, divId, this.cssClass, [this.boundedCollType], callback);
					}
					else {
						len = this.grid.rows.length;
						for (var i = firstNewRow; i < len; i++) {
							var trId = this.gxComponentContext + this.containerName + 'Row_' + this.grid.rows[i].gxId;
							var rowCtrl = gx.dom.byId(trId);
							if (rowCtrl != null) {
								rowCtrl.gxGrid = this.containerName;
								rowCtrl.gxGridName = this.gridName;
								rowCtrl.gxId = this.grid.rows[i].gxId;
							}
							trId = this.containerName + 'Row_' + this.grid.rows[i].gxId;
							var callback = (function (rCtrl) {
								return this.returnRowData(rCtrl);
							}).closure(this);
							if (this.defaultDragable)
								gx.fx.dnd.addSource(this.parentObject, trId, this.cssClass, evtTypes, callback);
							if (this.defaultSetsContext)
								gx.fx.ctx.addSetter(this.parentObject, trId, this.cssClass, evtTypes, callback);
						}
					}
				}
				if (this.parentGrid) {
					var ctx = gx.fx.ctx.setters[this.gxComponentContext + this.realGridName + "ContainerTbl"];
					len = this.grid.rows.length;
					for (var i = firstNewRow; i < len; i++) {
						var trId = this.containerName + 'Row_' + this.grid.rows[i].gxId;
						if (ctx && ctx.hdl)
							gx.fx.ctx.addSetter(this.parentObject, trId, this.cssClass, evtTypes, ctx.hdl);
					}
				}
				if (!this.additiveResponse)
				{
					len = this.grid.columns.length;
					for (var i = 0; i < len; i++) {
						var currCol = this.grid.columns[i];
						if (currCol.gxSetsContext == true) {
							var len1 = this.grid.rows.length;
							for (var j = firstNewRow; j < len1; j++) {
								var cellCtrl = gx.dom.el(this.gxComponentContext + currCol.htmlName + '_' + this.grid.rows[j].gxId, true);
								if (cellCtrl != null) {
									cellCtrl.gxHtmlName = currCol.htmlName;
									gx.fx.ctx.addSetter(this.parentObject, currCol.htmlName + '_' + this.grid.rows[j].gxId, "", [currCol.gxAttName], this.returnColumnContext);
								}
							}
						}
					}
				}
			}
			
			this.infinite_scrolling_ensure_loading_scroll = function() {
				if (!this.mock_element) {
					var $gridTable = $('#' + this.getGridInnerTableId());
					this.mock_element = $('<div class="gx-grid-loading" style="visibility:hidden;">' + gx.getMessage("GXM_Loading") + '</div>');						
					this.mock_element.insertAfter($gridTable);
				}
			}

			this.infinite_scrolling_before_scroll = function() {
				this.infinite_scrolling_ensure_loading_scroll();
				if (this.isScrolling !== true) {
					this.mock_element.css('visibility', 'visible');
					this.isScrolling = true;
				}
			}

			this.hide_loading_message = function() {
				if (this.mock_element) {
					this.mock_element.css('visibility', 'hidden');
				}
			}
			
			this.remove_loading_message = function() {
				if (this.mock_element) {
					$(this.mock_element).remove();
					this.mock_element = undefined;
				}
			}
			
			this.infinite_scrolling_after_scroll = function() {
				var gridTblid = this.getGridInnerTableId(),
					$table = $('#' + gridTblid);
				this.fixColumnsWidth( this.fixedColumnsWidth); 
				this.isScrolling = false;
				this.hide_loading_message();
			}
			
			this.fixColumnsWidth = function( colWidth) {
				if (this.isFreestyle)
					return;
				var gridTblid = this.getGridInnerTableId(),
					$table = $('#' + gridTblid);
					rows = $table.find('tbody tr[data-gxrendering_row]'); 
				$.each( rows, 
					function ( i, r) {
						$(r).children().map(function(ii, v) { 
							v.style.width = colWidth[ii] + 'px';
							v.style.maxWidth = colWidth[ii] + 'px';
						});
					}
				);
				rows.removeAttr('data-gxrendering_row');
			}
			
			this.unInstallScrollListener = function() {
				if (this.ScrollingElement) {
					$(this.ScrollingElement).scrollTop(0);
					this.remove_loading_message();
					this.ScrollingElement.removeEventListener("scroll", this.ScrollingHandler,  {passive: true});
				}
			}
			
			this.installScrollListener = function(ScrollingElement, gridTblid, $body, selector) {
				var scrollingThreshold = gx.grid.scrollingThreshold || 4;
				var scrollNextDemand = (function () {
					var totalHeight,
						scrollTop,
						viewportHeight,
						$window,
						newPosition,
						lastPosition;

					if (this.InverseLoading) {
						return ScrollingElement.scrollTop <= ScrollingElement.clientHeight * 30 / 100;
					}
					else {
						if (this.ScrollType == SCROLL_FORM) {
							$window = $(window);
							totalHeight = $(document).height();
							scrollTop = windowScrollPosition();
							viewportHeight = $window.height();
						}
						else {
							totalHeight = ScrollingElement.scrollHeight;
							scrollTop = ScrollingElement.scrollTop;
							viewportHeight = ScrollingElement.clientHeight;
						}

						newPosition = scrollTop;
						lastPosition = scrollHandling.lastPosition;
						scrollHandling.lastPosition = newPosition;
						if (newPosition < lastPosition) {
							return false;
						}
						return (totalHeight - scrollTop - viewportHeight) < (viewportHeight * scrollingThreshold);
					}
				}).closure(this);

				var _this = this;
				var scrollHandling = {
					allow: true,
					reallow: function () {
						scrollHandling.allow = true;
						if (scrollHandling.runAfterReallow) {
							scrollHandling.runAfterReallow = false;
							_this.ScrollingHandler();
						}
					},
					lastPosition: 0,
					runAfterReallow: false,
					delay: 300
				};
				this.ScrollingHandler = function(){
					gx.lang.requestAnimationFrame(function () {
						if (scrollHandling.allow) {
							var Ogrid = _this,
								grid = Ogrid.grid;
							if (Ogrid.isScrolling !== true && !grid.isLastPage() && scrollNextDemand()) {
								Ogrid.infinite_scrolling_before_scroll();
								grid.changeGridPage('NEXT', false);
							}
							scrollHandling.allow = false;
							setTimeout(scrollHandling.reallow, scrollHandling.delay);
						}
						else {
							scrollHandling.runAfterReallow = true;
						}
					});
				};
				this.infinite_scrolling_ensure_loading_scroll();
				ScrollingElement.addEventListener('scroll', this.ScrollingHandler, {passive: true});
			}

			this.installFixedGridHeader = function() {		
				if (!this.usePaging && !this.InfiniteScrolling && !this.isFreestyle && this.grid.gxHeight && this.grid.rows.length > 0) {
					var containerControl =  this.getContainerControl();
					if (containerControl) {
						var $containerControl = $(containerControl);
						var _this = this,
							gridTblid = this.getGridInnerTableId(),
							$table = $('#' + gridTblid),
							$bodyCells = $table.find('tbody tr:first').children(),
							$body = $('#' + gridTblid + '> tbody'),
							$theadTR = $('#' + gridTblid + '> thead > tr'),
							$thead = $('#' + gridTblid + '> thead'),
							isOldIE = gx.util.browser.isOldIE();
						if (!this.fixedContainerWidth)
							this.fixedContainerWidth = $table.width();
						if (!this.fixedColumnsWidth)
							this.fixedColumnsWidth = $bodyCells.map(function() {	return $(this).width(); }).get();

						//$table.find('tbody tr').each(function(i, v) { $(v).height($(v).height()); });
						
						$containerControl.addClass( GRID_INFINITE_SCROLLING_CONTAINER_CLASS);
						
						if (!this.width || isOldIE) { //A width must be always set							
							if (!isOldIE) {
								$table.width(this.fixedContainerWidth + $.position.scrollbarWidth() + 2);
							}
							else
							{ 
								//IE7 IMPLEMENTATION HACK
								$containerControl.addClass('gx-grid-fixed-header-ie7');
								$containerControl.wrap("<div style='position:relative;'>");							
								$table.css('width', '');								
								$containerControl.width(this.fixedContainerWidth + $.position.scrollbarWidth() + 2);									
								var theadPosition = $thead.position();
								$theadTR.css('top', theadPosition.top);	
								var theaderHeight = $theadTR.outerHeight(true);								
								$containerControl.css('paddingTop', gx.dom.addUnits(theaderHeight, 'px'));
								$table.attr('data-bkgstyle', '');
								var backColor = $table.css('background-color'),
									thbackColor =  $theadTR.css('background-color');
								if (backColor && (!thbackColor || thbackColor === 'transparent'))
								{									
									$theadTR.css('background-color', backColor);
								}
							}
						}
						
						if (this.fixedColumnsWidth.length > 0) {
							$table.find('thead tr').children().each(function(i, v) { $(v)[0].style.width = _this.fixedColumnsWidth[i] + 'px'});
							this.fixColumnsWidth( this.fixedColumnsWidth);
						}
						
						$body.addClass(GRID_INFINITE_SCROLLING_ELEMENT_CLASS);

						var $ScrollingElement = (!isOldIE)? $body: $containerControl;
						$table.css('max-height', '');
						$ScrollingElement.css({"max-height": gx.dom.addUnits(this.grid.gxHeight, (this.grid.gxHeight == this.height)? this.heightUnit: 'px')});	

					}
				}
			}

			var windowScrollPosition = function () {
				var supportPageOffset = window.pageXOffset !== undefined;
				var isCSS1Compat = ((document.compatMode || "") === "CSS1Compat");

				return supportPageOffset ? window.pageYOffset : isCSS1Compat ? document.documentElement.scrollTop : document.body.scrollTop;
			}

			this.handleInfiniteScrolling = function() {
				if ( this.InfiniteScrolling) {
					var containerControl =  this.getContainerControl();
					if (containerControl) {
						var $containerControl = $(containerControl);
						$containerControl.removeClass( GRID_INFINITE_SCROLLING_CONTAINER_CLASS);
						if ( this.grid.rows.length > 0) {
							var _this = this,
								gridTblid = this.getGridInnerTableId();
								
							var ScrollingElement;
							if (this.ScrollType == SCROLL_FORM) {
								ScrollingElement = window;
								this.fixedColumnsWidth = [];
							}
							else {
								if (this.ScrollingHeight) {
									$(ScrollingElement).css({"height": this.ScrollingHeight});
								}
								var $table = $('#' + gridTblid),
								$bodyCells = $table.find('tbody tr:first').children(),
								$body = $('#' + gridTblid + '>tbody');
								var fixedColVisibleCount = $.grep(this.grid.columns, function(el) {return el.visible == true;}).length;
								if (this.fixedColVisibleCount != fixedColVisibleCount) {
									this.fixedColVisibleCount = fixedColVisibleCount;
									if (!this.isFreestyle) {
										this.fixedColntainerWidth = $table.width();
										this.fixedColumnsWidth = $bodyCells.map(function() { return this.offsetWidth; }).get();
									}
								}
								$containerControl.addClass( GRID_INFINITE_SCROLLING_CONTAINER_CLASS);
								if (!this.isFreestyle) {
									$table.width(this.fixedColntainerWidth + $.position.scrollbarWidth() + 2);
								}
								if (!this.isFreestyle && this.fixedColumnsWidth.length > 0) {
									$table.find('thead tr').children().each(function(i, v) { $(v)[0].style.width = _this.fixedColumnsWidth[i] + 'px'; });
									this.fixColumnsWidth( this.fixedColumnsWidth); 
								}
								ScrollingElement = $body.length > 0 ? $body[0] : containerControl;
								$(ScrollingElement).addClass(GRID_INFINITE_SCROLLING_ELEMENT_CLASS);
							}
							if (this.ScrollingHeight && this.ScrollType != SCROLL_FORM) {
								$(ScrollingElement).css({"height": this.ScrollingHeight});
							}
							this.ScrollingElement = ScrollingElement;
							this.infinitScrollingInstalled = true;				
							var selector = this.InverseLoading ? this.grid.firstItemSelector : this.grid.lastItemSelector;
							var before_scroll = this.infinite_scrolling_before_scroll.closure(this),
								ScrollingHeight;
								if (!this.ScrollingHeight && (this.isFreestyle || (this.grid.rows.length >= this.grid.pageSize && this.grid.pageSize > 0))) {
								if (this.ScrollType != SCROLL_FORM) {
									ScrollingHeight = $(ScrollingElement).height() - 2;
									$(ScrollingElement).css({"height": ScrollingHeight});
								}
								this.ScrollingHeight = ScrollingHeight;
							}
							if (ScrollingElement) {
								var autoScrollCounter = 0;
								var MAX_NUMBER_OF_AUTO_LOAD_FORCING_SCROLL = 10;
								var scrollNext = (function () {
									var doNext = false;
									if (autoScrollCounter == MAX_NUMBER_OF_AUTO_LOAD_FORCING_SCROLL) {
										autoScrollCounter = 0;
										return false;
									}
									if (this.InverseLoading) {
										doNext = ScrollingElement.scrollTop == 0;
									}
									else {
										if (this.ScrollType == SCROLL_FORM) {
											if (gx.popup.ispopup())
												doNext = (document.body.scrollHeight < document.body.clientHeight);
											else
												doNext = (document.body.scrollHeight <= document.body.clientHeight);
										}
										else {
											doNext = (ScrollingElement.clientHeight == ScrollingElement.scrollHeight);
										}
									}
									
									if (doNext) {
										autoScrollCounter++;
									}
									return doNext;
								}).closure(this);

								var fncNextPage = function() {
									if (!this.grid.isLastPage() && scrollNext()) {
										before_scroll();
										return this.grid.changeGridPage('NEXT', false).then(function() {
											if (_this.InverseLoading) {
												ScrollingElement.scrollTop = ScrollingElement.scrollHeight;
											}
											fncNextPage();
										});
									}
								}.closure( this);
								gx.lang.requestAnimationFrame((function (ScrollingElement, gridTblid, $body, selector) {
									fncNextPage();
									this.installScrollListener(ScrollingElement, gridTblid, $body, selector);
								}).closure(this, [this.ScrollingElement, gridTblid, $body, selector]))
							}
						}
					}
				}
			}

			this.returnColumnContext = function (colControl) {
				var Value = '';
				if (colControl.nodeName == "SPAN")
					Value = gx.dom.spanValue(colControl);
				else
					Value = gx.fn.getControlValue_impl(colControl.id);
				if (Value != null)
					return Value;
				return "";
			}

			this.returnRowData = function (rowCtrl) {
				var dragObj = {};
				var row = this.grid.getRowByGxId(rowCtrl.gxId);
				if (row) {
					var len = this.grid.columns.length;
					for (var i = 0; i < len; i++) {
						var colAttName = this.grid.columns[i].gxAttName;
						if (colAttName != "")
							dragObj[colAttName] = row.values[i];
					}
				}
				return dragObj;
			}

			this.returnGridData = function () {
				var gridData = [];
				var len = this.grid.rows.length;
				for (var i = 0; i < len; i++) {
					var dragObj = {};
					gridData[i] = dragObj;
					var row = this.grid.rows[i];
					var len1 = this.grid.columns.length;
					for (var j = 0; j < len1; j++) {
						var colAttName = this.grid.columns[j].gxAttName;
						if (colAttName != "")
							dragObj[colAttName] = row.values[j];
					}
				}
				return gridData;
			}

			this.doDrop = function (dropObj) {
				var rowsQty = (dropObj.length != undefined) ? ropObj.length : 1;
				this.getNewRows(rowsQty, null, function (rows) { this.addDropedRows(rows, dropObj); });
			}

			this.addDropedRows = function (rowsProps, dropObj) {
				if (rowsProps.gxHiddens) {
					gx.fn.setJsonHiddens(null, rowsProps.gxHiddens);
				}
				var rowsProps = rowsProps.gxContainer ? rowsProps.gxContainer : rowsProps;
				var len = dropObj.length;
				if (len != undefined) {
					for (var i = 0; i < len; i++)
						this.setDroppedRow(rowsProps[i], dropObj[i]);
				}
				else
					this.setDroppedRow(rowsProps[0], dropObj);
				this.setNewRows(rowsProps);
			}

			this.setDroppedRow = function (rowProps, dropRow) {
				var len = this.grid.columns.length;
				for (var i = 0; i < len; i++) {
					var colProps = rowProps.Props[i];
					var colAttName = this.grid.columns[i].gxAttName;
					var droppedValue = '';
					if ((colAttName != "") && (dropRow[colAttName] != undefined))
						droppedValue = dropRow[colAttName];
					colProps.Value = droppedValue;
					colProps.FormattedValue = droppedValue;
				}
			}

			this.getRowAsTypes = function () {
				var types = [];
				var len = this.grid.columns.length;
				for (var i = 0; i < len; i++) {
					var colAttName = this.grid.columns[i].gxAttName;
					if (colAttName != "")
						types.push(colAttName);
				}
				return types;
			}

			this.addRows = function (rowsProps) {
				var len = rowsProps.Count;
				this.grid.rowsValues = rowsProps.values;
				for (var i = 0; i < len; i++) {
					var rowProps = rowsProps[i];
					this.addRow(rowProps);
				}
			}

			this.lastRowIsModified = function () {
				if (this.grid.rows.length == 0)
					return false;
				var lastRow = this.grid.rows[this.grid.rows.length - 1];
				if (lastRow.gxExists())
					return true;
				if (!lastRow.gxIsMod())
					return false;
				else
					return true;
			}

			this.getNewRows = function (rows, event, handler) {
				var newRowHdl = (handler != undefined) ? handler : this.setNewRows;
				var keyEvent = gx.util.browser.isFirefox() ? 'keypress' : 'keydown';
				if (event == null || (((event.type == keyEvent && (event.charCode == 32 || event.keyCode == 32 || event.keyCode == 13)) || event.type == 'click') && (this.grid.rows.length == 0 || this.lastRowIsModified()))) {
					gx.csv.pkDirty = false;
					gx.ajax.newRows(this.gxComponentContext, this.isMasterPageGrid, this.realGridName, rows + this.lastRowId, this.lastRowId + 1, (gx.grid.rowId(this.lastRowId + 1) + this.grid.gxParentRowId), this.grid.gxParentRowId, newRowHdl);
					gx.csv.pkDirty = false;
					if (event != null)
						gx.evt.cancel(event, true);
				}
				else if ((event != null) && ((event.keyCode == 32) || (event.keyCode == 13))) {
					gx.evt.cancel(event, true);
				}
			}

			this.setNewRows = function (rowProps) {
				return this.setNewRows_impl(rowProps, function(rowProps) {
					this.refreshGrid( {loadChildGrids:false} );
					if (this.grid.execShowFunction) {
						this.grid.execShowFunction();
					}
				});
			}

			this.loadNewRows = function (rowProps) {
				if (rowProps.gxHiddens) {
					gx.fn.setJsonHiddens(null, rowProps.gxHiddens);
				}
				var rowProps = rowProps.gxContainer ? rowProps.gxContainer : rowProps;
				return this.setNewRows_impl(rowProps, function(rowProps) { 
					this.loadGrid({
						rowProps: rowProps, 
						isPostback:true, 
						addRows:true
					});
				});
			}

			this.setNewRows_impl = function (rowProps, loadGridfn) {
				if (rowProps.gxHiddens) {
					gx.fn.setJsonHiddens(null, rowProps.gxHiddens);
				}
				var rowProps = rowProps.gxContainer ? rowProps.gxContainer : rowProps;
				var row;
				if (rowProps.Count != undefined) {
					var i = 0;
					if (!this.grid.rowsValues)
						this.grid.rowsValues = [];
					this.grid.rowsValues = this.grid.rowsValues.concat(rowProps.values);
					for (i = 0; i < rowProps.Count; i++) {
						row = this.addRow(rowProps[i]);
						gx.fn.setCurrentGridRow(this.gridId, row.gxId);
					}
					if (rowProps.Count > 0) {
						this.addingRows = true;
						loadGridfn.call( this, rowProps);
						this.addingRows = false;
						this.setFocusFirstControl(rowProps[0]);
					}
				}
				return row;
			}

			this.gxNewRowFocused = function (Ctrl) {
				Ctrl.style.textDecoration = 'underline';
				var firstGridCtrl = gx.fn.firstGridControl(this.gridId);
				gx.evt.onfocus(Ctrl, firstGridCtrl, this.gxComponentContext, this.isMasterPageGrid, '9999', this.gridId);
			}

			this.rowKeyPressed = function (keyEvent) {
				var eventSource = gx.evt.source(keyEvent);
				if (eventSource != undefined) {
					if (keyEvent.ctrlKey && keyEvent.keyCode == 46/*DEL*/) {
						this.setRowDeleted(eventSource);
						gx.evt.cancel(keyEvent, true);
					}
				}
			}

			this.gxHasDuplicateKey = function () {
				var keys = [];
				var rows = this.grid.rows;
				var len = rows.length;
				for (var i = 0; i < len; i++) {
					var row = rows[i];
					if ((row.gxExists() || row.gxIsMod()) && !row.gxDeleted()) {
						var rowKey = "";
						var len1 = row.gxKeyValues.length;
						for (var j = 0; j < len1; j++) {
							rowKey += row.gxKeyValues[j].toString();
						}
						if (keys[rowKey] != undefined)
							return true;
						keys[rowKey] = 1;
					}
				}
				return false;
			}

			this.columnIndexInKey = function (colIdx) {
				var len = this.lvlKey.length;
				for (var i = 0; i < len; i++) {
					if (this.lvlKey[i] == colIdx)
						return i;
				}
				return -1;
			}

			this.refreshVars = [];
			this.addRefreshingVar = function (validStruct) {
				if (gx.lang.emptyObject(validStruct))
					return;
				var eventName = "";
				var filterVarChangedFn = function () {
					this.filterVarChanged();
				};

				this.refreshVars[this.refreshVars.length] = validStruct;
				if (validStruct.fld) {
					var varCtrl = gx.dom.el(this.gxComponentContext + validStruct.fld, false, true);
					if (varCtrl != undefined) {
						if (gx.lang.emptyObject(validStruct.hc)) {
							if (varCtrl.type == "radio" || varCtrl.type == "checkbox")
								eventName = "click";
							else if (varCtrl.tagName == "SELECT")
								eventName = "change";
							else if (gx.evt.eachKeyAutorefreshType(validStruct.type))
								eventName = ["keyup", "input"];
							else 
								eventName = "blur";

							if (eventName != "") {
								if (varCtrl.type == "radio") {
									var radioGroup = gx.dom.byName(this.gxComponentContext + validStruct.fld);
									var len = radioGroup.length;
									for (var i = 0; i < len; i++) {
										gx.evt.attach(radioGroup[i], eventName, filterVarChangedFn, this);
									}
								}
								else {
									if (varCtrl.type == "search")
										eventName = [eventName, "search"];
										gx.evt.attach(varCtrl, eventName, filterVarChangedFn, this);
								}
							}
						}
					}
				}
				else {
					var vcMap = this.parentObject.VarControlMap[validStruct.rfrVar];
					if (vcMap) {
						var ucVStruct = this.parentObject.getValidStructFld(vcMap.id);
						if (ucVStruct && ucVStruct.isuc) {
							for (var ucKey in ucVStruct.ucInstances) {
								if (ucVStruct.ucInstances.hasOwnProperty(ucKey)) {
									var uc = ucVStruct.ucInstances[ucKey];
									uc.autoRefreshFn = filterVarChangedFn.closure(this);
								}
							}
						}
					}
				}
			}
			
			this.refreshParms = [];
			this.addRefreshingParm = function (validStruct) {
				if (gx.lang.emptyObject(validStruct))
					return;
				this.refreshParms[this.refreshParms.length] = validStruct;
			}

			this.doRefresh = function() {
				var refreshParms = this.getRefreshParmsUrl();
				this.callAsyncRefresh(refreshParms);
			}
			
			this.filterVarChanged = function () {
				if (this.parentObject.autoRefresh && !gx.grid.drawAtServer) {
					var refreshParms = this.getRefreshParmsUrl();
					if (this.lastRefreshParms != refreshParms) {
						this.lastRefreshParms = refreshParms;
						this.callAsyncRefresh();
					}
				}
				else {
					this.parentObject.conditionsChanged = this.conditionsChanged();
				}
			}

			this.conditionsChanged = function () {
				var varsLen = this.refreshVars.length;
				for (var i = 0; i < varsLen; i++) {
					var vStruct = this.refreshVars[i];
					if (typeof (vStruct.rfrVar) == 'undefined') {
						var oldValue = gx.fn.getHidden(this.gxComponentContext + 'GXH_' + vStruct.fld);
						var newValue = vStruct.val();
						if (oldValue !== undefined && oldValue != newValue) {
							return true;
						}
					}
				}
				return false;
			}

			this.getRefreshParmsUrl = function (firstTime) {
				return this.getParmsValues(firstTime, this.refreshParms).join(',');
			}
	
			this.getParmsValues = function (firstTime, inputVars) {
				var gxOld = gx.O,
					colType,						
					validStruct,
					varsLen = inputVars.length,
					parms = [];
				gx.setGxO(this.parentObject);								
				
				for (var i = 0; i < varsLen; i++) {
					var vStruct = inputVars[i];
					if (vStruct) {
						if (typeof (vStruct.c2v) == 'function')
							vStruct.c2v();
						if (typeof (vStruct.v2bc) == 'function')
							vStruct.v2bc.call(gx.O);
						if (typeof (vStruct.rfrVar) != 'undefined') {
							validStruct = gx.fn.vStructForVar(vStruct.rfrVar);
							if (!validStruct) {
								validStruct = gx.fn.getVarControlMapForVar(vStruct.rfrVar);
								if (validStruct && !firstTime) {
									var ucVStruct = this.parentObject.getValidStructFld(validStruct.id);
									if (ucVStruct && ucVStruct.isuc) {
										var gRow = ((ucVStruct && ucVStruct.grid) ? gx.fn.currentGridRowImpl(ucVStruct.grid) : undefined);
										var uc = ucVStruct.getUCInstance(gRow) || ucVStruct.uc; 
										uc.execC2VFunctions();
									}
								}
							}
							if (validStruct && (typeof (vStruct.rfrProp) == 'undefined' || this.isValueProperty(vStruct.rfrProp))) {
								colType = validStruct.type;
							}
						}
					}
					if (typeof (vStruct.rfrVar) != 'undefined') {
						var filterValue = ctrlName = colVStruct = undefined;
						if (typeof (vStruct.rfrProp) != 'undefined') {
							var col;
							if (typeof (vStruct.gxAttId) != 'undefined')
								col = this.grid.getColumnByGxAttId(vStruct.gxAttId);
							if (!col) {
								col = this.grid.getColumnForVar(vStruct.rfrVar);
							}

							if (col) {
								var propName = vStruct.rfrProp.toLowerCase();
								filterValue = col.hasOwnProperty(propName) ? col[propName] : col.gxControl[propName];
								if (this.isValueProperty(propName) && col.gxControl.type == gx.html.controls.types.image)
									filterValue = gx.util.removeBaseUrl(filterValue);
								colVStruct = this.parentObject.getValidStruct(col.gxId);
								if (colVStruct && this.isValueProperty(propName))
									colType = colVStruct.type;
							}
							else {
								filterValue = "";
							}
						}
						else {
							if (typeof (this.parentObject.VarControlMap[vStruct.rfrVar]) != 'undefined') {
								ctrlName = this.parentObject.VarControlMap[vStruct.rfrVar].id;
							}
							if (!gx.lang.emptyObject(this.parentObject[vStruct.rfrVar])) {
								filterValue = this.parentObject[vStruct.rfrVar];
							}
							else
							if (typeof(filterValue) == 'undefined' && typeof(ctrlName) != 'undefined') {
								filterValue = gx.fn.getHidden(this.gxComponentContext + ctrlName);
							}
							if (typeof(filterValue) == 'object' && colType != 'date' && colType != 'dtime') {
								filterValue = gx.json.serializeJson(filterValue);
							}
						}
						parms.push(this.getFormattedParm(filterValue, colType));
					}
					else {
						if (typeof(vStruct.gxGrid) == 'string')	{
							var Grid = gx.O.getGridByBaseName(vStruct.gxGrid);
							if (typeof(vStruct.rfrProp) == 'string' && vStruct.rfrProp == 'Rows')
								parms.push(Grid ? Grid.grid.pageSize : 9999);					
						}
						else
						{
							if (!gx.lang.emptyObject(vStruct.hc)) {
								var hcValue = gx.fn.getHidden(this.gxComponentContext + 'GXH_' + vStruct.fld);
								var v = (firstTime && typeof(hcValue) !== 'undefined')? hcValue: this.parentObject[vStruct.hc];													
								parms.push(encodeURIComponent(v));					
							}
							else
								parms.push(this.getFormattedVStructParm(vStruct));
							gx.fn.setHidden(this.gxComponentContext + 'GXH_' + vStruct.fld, vStruct.val());
						}
					}
				}
				if (this.parentObject.IsComponent) {
					parms.push(encodeURIComponent(this.parentObject.CmpContext));
				}
				gx.setGxO(gxOld);
				return parms;
			}

			this.initRefreshParms = function () {
				if (this.parentObject.autoRefresh) {
					this.lastRefreshParms = this.getRefreshParmsUrl(true);
				}
			}

			this.isValueProperty = function (rfrProp) {
				return (typeof (rfrProp) != 'undefined') && rfrProp.toLowerCase() == 'value';
			}

			this.getFormattedVStructParm = function (vStruct) {
				var value;
				if (vStruct.type == 'date' || vStruct.type == 'dtime') {
					var Control = gx.dom.el(this.gxComponentContext + vStruct.fld);
					if (typeof(Control.value) != 'undefined')
						value = Control.value;
					else
						value = gx.dom.spanValue(Control) || Control;
				}
				else {
					value = vStruct.val();
				}			
				return this.getFormattedParm(value, vStruct.type);
			}
			
			this.getFormattedParm = function (value, type) {
				if (type === 'date') {				
					value = gx.date.urlDate(value, gx.dateFormat);
				}
				else if (type === 'dtime') {				
					value = gx.date.urlDateTime(value, gx.dateFormat);
				}
				return encodeURIComponent(value);
			}

			this.callAsyncRefresh = function (refreshParms, timeout) {			
				if (!gx.evt.refreshGridCallback)
					gx.evt.refreshGridCallback = [];
				if (this.refreshTimer != null) {
					window.clearTimeout(this.refreshTimer);
					this.refreshTimer = null;
					gx.evt.setReady(true);
				}
				gx.evt.setReady(false);
				var AsyncRefreshInitiator = gx.util.executionContext.getContext();
				this.refreshTimer = window.setTimeout((function () {
					if( gx.util.executionContext.changedContext(AsyncRefreshInitiator))
						return;
					if (this.autoRefreshing || gx.evt.processing) {
						this.callAsyncRefresh(refreshParms);
					}
					else {
						gx.fx.obs.addObserver('grid.onafterrefresh', gx.evt, gx.evt.notifyRefreshGrid, {single:true});
						if (typeof(refreshParms) === 'undefined') {
							refreshParms = this.getRefreshParmsUrl();
						}
						gx.ajax.refreshGrid(this, refreshParms);
						gx.evt.setReady(true);
					}
				}).closure(this), timeout || 400);
			}

			this.updatePropsHidden = function (newProps) {
				var propsCtrlName = this.getDataHiddenName();
				gx.fn.setHidden(propsCtrlName, newProps);
			}

			this.updatePagingVarsAfterRefresh = function (gridRows) {
				if (this.usePaging) {
					var eof = this.grid.gxGridName.toUpperCase() + "_nEOF";
					var firstPage = this.grid.gxGridName.toUpperCase() + "_nFirstRecordOnPage";
					this.setPagingVars(gridRows[eof], gridRows[firstPage]);
				}
			}
			this.getSelection = function () {
				if (this.allowSelection) {
					var len = this.grid.rows.length;
					for (var i = 0; i < len; i++) {
						var row = this.grid.rows[i];
						if (row.selected) {
							return i;
						}
					}
				}
				return -1;
			}

			this.setNextRowSelected = function(fireEvt) {
				var idx = Math.min(this.getSelection() + 1, this.grid.rows.length);
				this.setSelection(idx, fireEvt);
				this.grid.keepGridItemVisible(idx);
			}

			this.setPreviousRowSelected = function(fireEvt) {
				var idx = Math.max(this.getSelection() - 1, 0);
				this.setSelection(idx, fireEvt);
				this.grid.keepGridItemVisible(idx);
			}
			
			this.setProperty = function( Property) {
				if (Property.Selectedindex) {
					var nRow = Number(Property.Selectedindex);
					if (nRow == -1)
						this.setSelection(nRow);
					else {
						return this.setSelectionRowCtrl(this.grid.getRowByPos( nRow));
					}
				}
				return false;
			}

			this.setSelection = function (idx, fireEvt) {
				if (this.allowSelection) {
					if (idx == -1) {
							this.grid.setRowSelected( undefined, '', undefined, undefined, fireEvt);
							return true;
					}
					else {
						if (idx >= 0) {
							var rowCtrl = this.getRowCtrlByIdx(idx);
							return this.setSelectionRowCtrl( rowCtrl, fireEvt);
						}
					}
				}
				return false;
			}
			
			this.setSelectionRowCtrl = function (rowCtrl, fireEvt) {
				if (this.allowSelection) {
					if (rowCtrl) {
						this.grid.setRowSelected(rowCtrl, rowCtrl.getAttribute("data-gxrow"), undefined, undefined, fireEvt);
						return true;
					}
				}
				return false;
			}

			this.getRowCtrlByIdx = function (idx) {				
				return gx.dom.el(this.grid.gxCmpContext + this.grid.gxGridObject + "Row_" + gx.grid.rowId(idx + 1));
			} 

			this.blankGridRows = function () {
				if (this.InfiniteScrolling) {
					this.additiveResponse = (this.grid.firstRecordOnPage != 0)
				}
				if (!this.InfiniteScrolling || !this.additiveResponse) {
					this.lastRowId = 0;
					this.grid.rows = [];
					delete this.grid.rowsValues;
				}			
			}

			this.setRowDeleted = function (rowCtrl) {
				var row = null;
				if (typeof (rowCtrl) == 'string') {
					row = this.grid.getRowByGxId(rowCtrl);
				}
				else {
					row = (rowCtrl.gxId == undefined) ? this.getRowFromHtmlCtrl(rowCtrl) : rowCtrl;
				}
				row.setDeleted(!row.gxDeleted());
				this.setRowModified(row.gxId);
				gx.fn.removeGridRow(row.gxId, this.gridId.toString());
				this.refreshGrid({loadChildGrids:false});
				gx.dom.indexElements();
			}

			this.setFocusFirstControl = function (rowProps) {
				for (var i = 0; i < rowProps.Count; i++) {
					var row = this.grid.getRowByGxId(gx.grid.rowId(this.lastRowId) + this.grid.gxParentRowId);
					if (row) {
						var focusCtrl = gx.dom.el(this.grid.gxCmpContext + this.grid.columns[i].htmlName + "_" + row.gxId);
						if (focusCtrl != undefined && gx.fn.isAccepted(focusCtrl)) {
							gx.grid.lastFocusCtrl = this.grid.columns[i].gxId;
							gx.fn.setFocus(focusCtrl);
							break;
						}
					}
				}
			}

			this.instanciateRow = function (cRow) {
				var bkpObj = gx.O;
				var userControls;
				var uc, ucName;
				var i, len;
			
				gx.setGxO(this.parentObject);
				gx.csv.instanciatedRowGrid = this;
				try {
					var row = cRow;
					if (typeof (row) == "string")
						row = this.grid.getRowByGxId(cRow);
					if (row != null) {
						gx.fn.setCurrentGridRow(this.gridId, row.gxId);
						len = row.values.length;
						for (i = 0; i < len; i++) {
							var column = this.grid.columns[i];
							if (column.gxId != '') {
								var validStruct = this.parentObject.getValidStruct(column.gxId);
								if (validStruct) {
									if (this.useUserControlModelValues()) {
										if (validStruct.v2v) {
											validStruct.v2v(this.grid.properties[row.id][column.index].value);
											gx.fn.setHidden(this.grid.properties[row.id][column.index].id, this.grid.properties[row.id][column.index].value);
										}
									}
									else {
										if (typeof (validStruct.c2v) == 'function')
											validStruct.c2v();
									}
								}
							}
						}
					}
					else {
						gx.fn.setCurrentGridRow(this.gridId, cRow);
						len = this.grid.columns.length;
						for (i = 0; i < len; i++) {
							var column = this.grid.columns[i];
							if (column.gxId != '') {
								var validStruct = this.parentObject.getValidStruct(column.gxId);
								if (validStruct && typeof (validStruct.c2v) == 'function') {
									validStruct.c2v();
								}
							}
						}
					}
					
					// Update reference to current row's user control objects
					userControls = this.parentObject.UserControls;
					for (ucName in userControls) {
						if (userControls.hasOwnProperty(ucName)) {
							uc = userControls[ucName];
							if (uc.GridId === this.gridId && uc.GridRow === row.gxId) {
								this.parentObject[uc.DesignContainerName] = uc;
							}
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'instanciateRow');
				}
				gx.setGxO(bkpObj);
				return true;
			}

			this.setRenderProp = function (PropName, HiddenName, PropValue, PropType) {
				this.grid.setProp(PropName, HiddenName, PropValue, PropType);
			}

			this.setRenderDynProp = function (PropName, HiddenName, PropValue, PropType) {
				this.grid.setDynProp(PropName, HiddenName, PropValue, PropType);
			}

			this.addRenderEventHandler = function (EventName, Handler) {
				this.grid.addEventHandler(EventName, Handler);
			}

			this.cleanup = function () {
				gx.grid.clearActiveGrid(this);
				this.parentObject = null;
				this.parentGrid = null;
				this.grid.ownerGrid = null;
				this.grid.parentGxObject = null;
				this.grid.container = null;
				this.grid.ascLabel = null;
				this.grid.descLabel = null;
				this.grid.columns = null;
				this.grid.rows = null;
				this.grid.selectedRows = null;				
				this.grid = null;
				this.unInstallScrollListener();
			}

			this.loadGrid = function (ops) {
				var deferred;
				gx.dbg.logPerf('loadGrid_' + this.gridName);
				var ops = ops || {},
					postProps = ops.rowProps,
					isPostback = ops.isPostback,
					addRows = ops.addRows,
					isNestedLoad = ops.isNestedLoad;
				
				this.isNestedLoad = this.isNestedLoad || isNestedLoad;
				var bkpObj = gx.O;
				gx.setGxO(this.parentObject);
				this.isLoading = true;
				var isTrn = this.parentObject.isTransaction();
				if (isTrn && this.contextMenu == null)
					this.contextMenu = new gx.grid.contextMenu(this);
				if (postProps != undefined) {
					var GRID_nEOF = postProps.GridName ? postProps[postProps.GridName.toUpperCase() + '_nEOF'] : undefined;
					var GRID_nFirstRecordOnPage = postProps.GridName ? postProps[postProps.GridName.toUpperCase() + '_nFirstRecordOnPage'] : undefined;
					var divCtrl = this.getContainerControl();
					if (divCtrl != null) {
						if (this.autoRefreshing)
							this.updatePagingVarsAfterRefresh(postProps);
						else
							this.updatePagingVars(GRID_nEOF, GRID_nFirstRecordOnPage);
						if (this.InfiniteScrolling) {
							this.additiveResponse = (this.grid.firstRecordOnPage != 0)
						}
						if (isPostback) {
							if (!addRows)
								postProps.values = this.getValuesFromHidden();
							if (this.isFreestyle && gx.lang.emptyObject(this.parentRow)) {
								this.backupComponents();
							}
						}
						this.deleteGridData();
						this.grid.setContainerDelayed(divCtrl);
						if (!this.additiveResponse) {
							this.clearHiddens();
						}
						this.setRowsProperty();
						var sel = this.getSelection();
						if (this.autoRefreshing)
							this.updatePagingVarsAfterRefresh(postProps);
						else
							this.updatePagingVars(GRID_nEOF, GRID_nFirstRecordOnPage);
						if (!addRows)
							this.blankGridRows();
						this.setHtmlTags(postProps);
						this.setGridStyles(postProps);
						this.setDeleteMethod(postProps.DeleteMethod);
						this.setSelectionAndHover(postProps.Allowselection, postProps.Selectioncolor, postProps.Allowhover, postProps.Hovercolor, postProps.Selectedindex);
						this.setCollapsing(postProps.Allowcollapsing, postProps.Collapsed);
						this.setSflColumns(postProps.SflColumns);
						this.setColumnsProperties(postProps.Columns);
						if (!addRows)
							this.addRows(postProps);
						this.updateOldComponents();
						this.initRefreshParms();
						var gridTblid = this.getGridInnerTableId();
						var isEmpty = $("#" + gridTblid).attr("data-gx-grid-nodata") !== undefined;
						deferred = this.refreshGrid({
								addRows: addRows && !isEmpty,
								loadChildGrids:null, 
								fromAutoRefresh:this.autoRefreshing
							});
						this.setProperty({Selectedindex: sel + 1});
					}
				}
				else {
					this.clearHiddens();
					this.setRowsProperty();
					this.grid.pageSize = (isTrn || this.isFreestyle) ? 9999 : this.gridRows;
					var divCtrl = this.getContainerControl();
					if (divCtrl != null) {
						this.grid.setContainerDelayed(divCtrl);
						var rowsProps = this.getRowsFromHidden();
						if (rowsProps != null) {
							rowsProps.values = this.getValuesFromHidden();
							this.blankGridRows();
							this.setHtmlTags(rowsProps);
							this.setGridStyles(rowsProps);
							this.setDeleteMethod(rowsProps.DeleteMethod);
							this.setSelectionAndHover(rowsProps.Allowselection, rowsProps.Selectioncolor, rowsProps.Allowhover, rowsProps.Hovercolor, rowsProps.Selectedindex);
							this.setCollapsing(rowsProps.Allowcollapsing, rowsProps.Collapsed);
							this.setSflColumns(rowsProps.SflColumns);
							this.setColumnsProperties(rowsProps.Columns);
							this.updatePagingVars();
							this.addRows(rowsProps);
							this.initRefreshParms();
							this.addingRows = true;
							deferred = this.refreshGrid();
							this.addingRows = false;
						}
						else {
							this.blankGridRows();
							this.updatePagingVars();
							this.initRefreshParms();
							deferred = this.refreshGrid();
						}
					}
					else {
						deferred = this.loadWrappedGridChilds();
					}
				}
				this.isLoading = false;
				gx.setGxO(bkpObj);
				gx.dbg.logPerf('loadGrid_' + this.gridName, "Grid '" + this.gridName + "' loaded");
				return deferred;
			}

			this.loadWrappedGridChilds = function () {
				var deferred = $.Deferred();
				try {
					var rows = gx.fn.getHidden(this.grid.gxCmpContext + "nRC_GXsfl_" + this.gridId);
					if (typeof (rows) != 'undefined') {
						rows = parseInt(rows);
						for (var i = 0; i < rows; i++) {
							var len = this.grid.columns.length;
							for (var j = 0; j < len; j++) {
								var column = this.grid.columns[j];
								if (column.gxControl.type == gx.html.controls.types.userControl) {
									this.addUsercontrolToDraw({ r: gx.grid.rowId(i + 1), c: column });
								}
							}
						}
						this.setupGridUsercontrols(this.GridUserControls);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'loadWrappedGridChilds');
				}
				deferred.resolve();
				return deferred;
			}

			this.getRowsFromHidden = function () {
				var propsCtrlName = this.getDataHiddenName();
				var ctrlsProps = gx.fn.getHidden(propsCtrlName);
				var rowsProps = null;
				gx.json.setNonSerializable(propsCtrlName);
				if (typeof(ctrlsProps) == "string") {
					return gx.json.evalJSON(ctrlsProps);
				}
				if (typeof(ctrlsProps) == "object") {
					return ctrlsProps;
				}
				return null;
			}

			this.deleteGridData = function () {
				var propsCtrlName = this.getDataHiddenName();
				gx.json.setNonSerializable(propsCtrlName);
			}

			this.getValuesFromHidden = function () {
				var valCtrlId = this.getValuesHiddenName();
				var ctrlsValues = gx.fn.getHidden(valCtrlId);
				if (gx.lang.emptyObject(ctrlsValues))
					ctrlsValues = gx.fn.getControlValue(valCtrlId);
				gx.json.setNonSerializable(valCtrlId);
				var rowsValues = null;
				if (ctrlsValues != null && ctrlsValues != "")
					rowsValues = gx.json.evalJSON(ctrlsValues);
				return rowsValues;
			}

			this.getContainerControlId = function () {
				if (this.gxContainerDivName != undefined)
					return this.gxContainerDivName
				return this.grid.gxCmpContext + this.containerName + "Div";
			};

			this.getContainerControl = function () {
				if (!this.gxContainerCtrl) {
					var divCtrl = gx.dom.byId(this.getContainerControlId());
					if (divCtrl) {
						this.gxContainerCtrl = divCtrl;
						divCtrl.setAttribute("data-gxgridid", this.gridId.toString());
						gx.dom.addClass(divCtrl, GRID_CLASS);
						if (this.isResponsive) {
							gx.dom.addClass(divCtrl, RESPONSIVE_GRID_CLASS);
						}
						gx.dom.addClass(divCtrl, this.isFreestyle ? FREESTYLE_GRID_CLASS : STANDARD_GRID_CLASS);
						divCtrl.gxGridName = this.grid.gxGridName;
					}
				}
				return this.gxContainerCtrl;
			}

			this.getHiddenSuffix = function () {
				return (this.grid.gxParentRowId == '') ? '' : '_' + this.grid.gxParentRowId;
			};

			this.getDataHiddenName = function () {
				if (this.gxContainerDataName != undefined)
					return this.gxContainerDataName;
				return this.grid.gxCmpContext + this.containerName + 'Data' + this.getHiddenSuffix();
			}

			this.getValuesHiddenName = function () {
				if (this.gxContainerValuesName != undefined)
					return this.gxContainerValuesName;
				return this.grid.gxCmpContext + this.containerName + "DataV" + this.getHiddenSuffix();
			}

			this.setColumnsProperties = function (props) {
				try {
					if (!gx.lang.emptyObject(props)) {
						var len = props.length;
						for (var i = 0; i < len; i++) {
							var col = this.grid.columns[i];
							for (var prop in props[i]) {
								var pValue = props[i][prop];
								prop = this.fixColumnPropName(prop);
								if (this.isUsercontrol) {
									col[prop] = pValue;
								}
								col[prop.toLowerCase()] = pValue;
							}
							this.checkPromptColumn(col);
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'setColumnsProperties');
				}
			}

			this.checkPromptColumn = function (col) {
				try {
					if (this.isPromptColumn(col)) {
						var ctrl = gx.fn.getAttachedCtrl(col.htmlName);
						if (ctrl && ctrl.info && ctrl.info.controls) {
							var anyVisible = false;
							var anyEnabled = false;
							var depLen = ctrl.info.controls.length;
							for (var j = 0; j < depLen; j++) {
								var depId = ctrl.info.controls[j];
								var depCol = this.grid.getColumnByGxId(depId);
								var enabled = gx.lang.gxBoolean(depCol.enabled);
								var visible = gx.lang.gxBoolean(depCol.visible);
								if (enabled)
									anyEnabled = true;
								if (visible)
									anyVisible = true;
							}
							if (!anyEnabled)
								col.enabled = '0';
							if (!anyVisible)
								col.visible = '0';
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'checkPromptColumn');
				}
			}

			this.fixColumnPropName = function (propName) {
				if (propName == 'Horizontalalignment') {
					return 'align';
				}
				return propName;
			}

			this.setDeleteMethod = function (deleteMethod) {
				var isTrn = this.parentObject.isTransaction();
				if (isTrn) {
					var disableDelete = (this.parentObject.Gx_mode == 'DSP');
					if (!disableDelete && deleteMethod && (deleteMethod == 'none')) {
						disableDelete = true;
					}
					if (disableDelete) {
						this.deleteMethod = gx.grid.deleteMethods.none;
					}
					else {
						this.deleteMethod = gx.grid.deleteMethod;
					}
				}
			}

			this.setSelectionAndHover = function (Allowselection, Selectioncolor, Allowhover, Hovercolor, Selectedindex) {
				try {
					if (typeof(Allowselection) != 'undefined')
						this.allowSelection = gx.lang.gxBoolean(Allowselection);
					if (typeof (Selectioncolor) != 'undefined')
						this.selectionColor = null;
					if (typeof (Hovercolor) != 'undefined')
						this.hoverColor = null;
					if (this.allowSelection && typeof(Selectioncolor) != 'undefined') {
						if (typeof (Allowhover) != 'undefined')
							this.allowHovering = gx.lang.gxBoolean(Allowhover);
						Selectioncolor = eval(Selectioncolor);
						if (typeof (Selectioncolor[0]) != 'undefined')
							this.selectionColor = gx.color.fromRGB(Selectioncolor[0], Selectioncolor[1], Selectioncolor[2]);
						else
							this.selectionColor = gx.color.html(Selectioncolor);
						if (this.allowHovering && typeof(Hovercolor) != 'undefined') {
							Hovercolor = eval(Hovercolor);
							if (typeof (Hovercolor[0]) != 'undefined')
								this.hoverColor = gx.color.fromRGB(Hovercolor[0], Hovercolor[1], Hovercolor[2]);
							else
								this.hoverColor = gx.color.html(Hovercolor);
						}
					}
					this.grid.gxAllowSelection = this.allowSelection;
					this.grid.gxSelectionColor = this.selectionColor;
					this.grid.gxAllowHovering = this.allowHovering;
					this.grid.gxHoverColor = this.hoverColor;
					this.grid.selectedRows = [];
					Selectedindex = Number(Selectedindex || 0);
					if (Selectedindex > 0) {
						this.grid.Selectedindex = Selectedindex - 1;
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'setSelectionAndHover');
				}
			}

			this.setCollapsing = function (Allowcollapsing, Collapsed) {
				try {
					if (Allowcollapsing !== undefined) {
						this.allowCollapsing = gx.lang.gxBoolean(Allowcollapsing);
						this.grid.gxAllowCollapsing = this.allowCollapsing;
					}
					if (Collapsed !== undefined) {
						this.collapsed = gx.lang.gxBoolean(Collapsed);
						this.grid.gxCollapsed = this.collapsed;
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'setCollapsing');
				}
			}

			this.setSflColumns = function (sflColumns) {
				try {
					if (!gx.lang.emptyObject(sflColumns) || sflColumns === 0) {
						this.gridCols = gx.grid.validGridColsValue(parseInt(sflColumns));
						this.grid.gxGridCols = this.gridCols;
						if (this.gridCols > 1 && this.gridRows > 0)
							this.grid.pageSize = (this.gridRows ? this.gridRows : 1) * this.gridCols;
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'setSflColumns');
				}
			}

			this.isPromptColumn = function (column) {
				if (column.gxAttId.indexOf && column.gxAttId.indexOf("prompt_") != -1)
					return true;
				return false;
			}

			this.setRowsProperty = function () {
				var rowsHiddenValue = gx.fn.getHidden(this.getHiddenName("Rows"));
				if (rowsHiddenValue != null) {
					try { this.gridRows = parseInt(rowsHiddenValue, 10); }
					catch (e) {
						gx.dbg.logEx(e, 'gxgrid.js', 'setRowsProperty');
					}
					this.grid.pageSize = this.gridRows * (this.gridCols > 1 ? this.gridCols : 1);
				}
			}

			this.crearInstalledSuggests = function () {
				var len = this.grid.columns.length;
				for (var i = 0; i < len; i++) {
					var column = this.grid.columns[i];
					var vStruct = this.parentObject.getValidStruct(column.gxId);
					if (vStruct && vStruct.gxsgprm && vStruct.gxsgprm.installed) {
						vStruct.gxsgprm.installed = {};
					}
				}
			}

			this.refreshCollection = function (coll) {
				try {
					this.blankGridRows();
					this.updatePagingVars();
					this.initRefreshParms();
					var cLen = coll.length;
					for (var i = 0; i < cLen; i++) {
						var rowProps = { Props: [] };
						var collItem = coll[i];
						var len = this.grid.columns.length;
						for (var j = 0; j < len; j++) {
							var column = this.grid.columns[j];
							rowProps.Props[column.index] = [collItem[column.gxAttName]];
						}
						this.addRow(rowProps);
					}
					this.refreshGrid({
						loadChildGrids:false, 
						fromAutoRefresh:false, 
						fromCollection:true
					});
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'refreshCollection');
				}
			}

			this.refreshGrid = function (ops) {
				var deferred = $.Deferred();

				var ops = ops || {},
					loadChildGrids = ops.loadChildGrids,
					fromAutoRefresh = ops.fromAutoRefresh,
					fromCollection = ops.fromCollection,
					isNestedLoad = ops.isNestedLoad,
					immediateApplyInfiniteScroll = ops.immediateApplyInfiniteScroll;
				
				this.isNestedLoad = this.isNestedLoad || isNestedLoad;
				this.DatePickersControls = [];
				this.GridUserControls = [];
				this.GridComponents = [];
				this.GridControls = [];
				this.ColumnPropertiesAfterRender = [];

				if (!this.additiveResponse) {
					if (!ops.addRows) {
						this.clearDefaultEventHandlers();
					}
					this.clearHiddens();
				}
				this.crearInstalledSuggests();
				this.setRowsProperty();
				if ((this.parentRow != undefined) && (!gx.lang.emptyObj(this.parentRow.Grids))) {
					var gridProps = this.parentRow.Grids[this.realGridName];
					if (gridProps != null) {
						this.setHtmlTags(gridProps);
						this.setGridStyles(gridProps);
						this.setColumnsProperties(gridProps.Columns);
						if (!this.addingRows) {
							if (this.parentRow.IsNew) {
								this.addRows(gridProps);
							}
						}
					}
				}
				var firstTime = false;
				var afterRender = function () {
					this.setupGridControls(this.GridControls);
					this.setupCellAttributes(this.IsValidState);
					this.setupFixedColumnProperties();
					this.setupGridUsercontrols(this.GridUserControls);
					this.installFixedGridHeader();
					var _this = this;
					var gridTblid = this.getGridInnerTableId(),
						last_selector = this.grid.scroll_last_row_selector( this.gridRows),
						first_selector = this.grid.scroll_first_row_selector( this.gridRows)
					this.grid.firstItemSelector = '#' + gridTblid + first_selector;
					this.grid.lastItemSelector = '#' + gridTblid + last_selector;
					var applyInfiniteScrolling = function(arrCmpObj) {
						var fnc = function() {
							if (!_this.InfiniteScrolling) {
								deferred.resolve();
								return;
							}
							if (immediateApplyInfiniteScroll) {
								_this.handleInfiniteScrolling();
							}
							else {
								var containerControl = _this.getContainerControl();
								if (gx.spa.isNavigating()) {
									gx.spa.addObserver('onnavigatecomplete', _this, _this.handleInfiniteScrolling, { single: true });
								}
								else if (!gx.fn.isVisible(containerControl)) {
									gx.dom.getIntersectionObserver(function (IntersectionObserver) {
										var observer = new IntersectionObserver(function () {
											if (gx.fn.isVisible(containerControl)) {
												observer.disconnect()
												_this.handleInfiniteScrolling();
											}
										}, { root: document.body });

										observer.observe(containerControl);
									})
								}
								else {
									gx.ol(_this.handleInfiniteScrolling, _this);
								}
							}
							deferred.resolve();
						};
						var arrOnLoadDeferred = $.map(arrCmpObj, function( gxO, i) {
								return gxO.onLoadDeferred;
						});
						$.when.apply($, arrOnLoadDeferred).done(fnc);
					};
					this.setupGridComponents(this.GridComponents).then( function() {
						var arrCmpObj = $.map(_this.GridComponents, function( cmp, i) {
							return gx.pO.getWebComponent(cmp.p);
						});
					
						if (_this.isFreestyle) {
							_this.loadRowsGrids(firstTime, ops);
						}
						gx.fx.obs.notify('grid.onafterrender', [_this.grid, _this.isNestedLoad]);
						if (_this.isNestedLoad) {
							_this.isNestedLoad = false;
							applyInfiniteScrolling(arrCmpObj);
						}
						else {
							if (_this.additiveResponse) {
								if (!gx.pendingCmps) {
									_this.infinite_scrolling_after_scroll();
								}
								else {
									gx.fx.obs.addObserver('webcom.all_rendered', _this, function (){
										_this.infinite_scrolling_after_scroll();
									});
								}
							}
							else {
								_this.applyTemplateObject().then( function() { 
									applyInfiniteScrolling(arrCmpObj)
								});
							}
						}
						_this.additiveResponse = false;
					});
					this.triggerDatePickersSetup(this.DatePickersControls);
					this.installImageControls();
					this.updateRcdCount();
					this.setDefaultEventHandlers();
					this.setSelection(this.grid.Selectedindex);
				};
				afterRender = afterRender.closure(this);
				this.grid.doSort();
				if (loadChildGrids == false) {
					this.grid.render(firstTime, false, fromCollection, afterRender, ops);
				}
				else {
					firstTime = true;
					this.grid.render(firstTime, fromAutoRefresh, fromCollection, afterRender, ops);
				}
				return deferred;
			};

			this.getGridInnerTableId = function () {
				return this.gxComponentContext + this.containerName + "Tbl";
			},

			this.applyTemplateObject = function () {
				var excludedSelector = (this.isFreestyle && !this.parentObject.IsComponent ? "." + gx.GxObject.WEBCOMPONENT_CLASS_NAME + " *" : "");
				return gx.plugdesign.applyTemplateObject({
					selector:"#" + this.getContainerControl().id, 
					excluded: excludedSelector
				});
			};

			var CMP_BACKUP_CONTAINER_ID = 'gx-wc-bkp_' + gCmpCtx + "_" + gName;
			this.getComponentsBackupContainer = function () {
				var bkpCt = gx.dom.byId(CMP_BACKUP_CONTAINER_ID);
				if (!bkpCt) {
					bkpCt = document.createElement('div');
					bkpCt.id = CMP_BACKUP_CONTAINER_ID;
					bkpCt.style.display = 'none';
					document.body.appendChild(bkpCt);
				}
				return bkpCt;
			};

			this.destroyComponentsBackup = function () {
				var bkpCt = gx.dom.byId(CMP_BACKUP_CONTAINER_ID);
				if (bkpCt) {
					var parent = bkpCt.parentNode;
					if (parent)
						gx.dom.removeControlSafe(bkpCt);
				}
			};

			this.backupComponents = function () {
				try {
					if (!this.additiveResponse) {
						var len1 = this.grid.rows.length;
						for (var i = 0; i < len1; i++) {
							var row = this.grid.rows[i];
							var len2 = this.grid.columns.length;
							for (var j = 0; j < len2; j++) {
								var column = this.grid.columns[j];
								if (column.gxControl.type == gx.html.controls.types.webComponent) {
									var cmpProps = row.gxProps[j];
									var controlName = cmpProps[0];
									var cmpPrefix = this.parentObject.getComponentPrefix(controlName);
									var cmpCtrlId = this.gxComponentContext + 'gxHTMLWrp' + cmpPrefix + row.gxId;
									var cmpCtrl = gx.dom.byId(cmpCtrlId);
									if (cmpCtrl) {
										cmpCtrl.parentNode.removeChild(cmpCtrl); //remove in order to change its parent (not to destroy)
										var bkpCt = this.getComponentsBackupContainer();
										bkpCt.appendChild(cmpCtrl);
									}
								}
							}
							var len3 = row.gxGrids.length;
							for (var k = 0; k < len3; k++) {
								var rowGrid = row.gxGrids[k];
								if (rowGrid && rowGrid.isFreestyle) {
									rowGrid.backupComponents();
								}
							}
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'backupComponents');
				}
			}

			this.getEntireGridColumn = function (colIndex) {
				var container = this.getContainerControl();
				if (!container )
					return [];
				var r = container.firstChild,
					cells = [];
				if (r.querySelectorAll) {
					cells = gx.fn.toArray(r.querySelectorAll("td[data-colindex='" + colIndex + "'], th[data-colindex='" + colIndex + "']"));
				} else {
					var candidateCells = gx.dom.byTag('TD', r),
						candidateHeaders = gx.dom.byTag('TH', r);
					for (var i=0, len=candidateCells.length; i<len; i++) {
						if (candidateCells[i].getAttribute('data-colindex') == colIndex) {
							cells.push(candidateCells[i]);
						}
					}
					for (var i=0, len=candidateHeaders.length; i<len; i++) {
						if (candidateHeaders[i].getAttribute('data-colindex') == colIndex) {
							cells.push(candidateHeaders[i]);
						}
					}
				}
				return cells;
			}
			this.applyPropEntireColumn = function (colIndex, ptyName, ptyValue) {
				var controls = this.getEntireGridColumn(colIndex)
				for (var j = 0; j < controls.length; j++) {
					gx.fn.setCtrlPropertyImpl(controls[j], ptyName, ptyValue);
				}
			}
			this.setupFixedColumnProperties = function () {
				for (var i = 0; i < this.ColumnPropertiesAfterRender.length; i++) {
					var colPtyStruct = this.ColumnPropertiesAfterRender[i];
					this.applyPropEntireColumn(colPtyStruct.colIndex, colPtyStruct.ptyName, colPtyStruct.ptyValue);
				}
			}
			this.addColPropertyAfterRender = function (colIndex, ptyName, ptyValue) {
				var struct = { 'colIndex': colIndex, 'ptyName': ptyName, 'ptyValue': ptyValue },
					ptyHash = 'gxpty' + ptyName + colIndex,
					idx = this.ColumnPropertiesAfterRender[ptyHash];
				
				if (idx) {
					this.ColumnPropertiesAfterRender[idx] = struct;	
				}
				else {
					idx = this.ColumnPropertiesAfterRender.push(struct) - 1;
					this.ColumnPropertiesAfterRender[ptyHash] = idx;
				}
			}
			this.setupCellAttributes = function (CtrlsAndAttributes) {
				//ej CtrlsAndAttributes["CtrlId"] = {"gxvalid":"1", "gxoldvalue":"3"}
				for (var ctrlId in CtrlsAndAttributes) {
					var Props = CtrlsAndAttributes[ctrlId];
					var ctrl = gx.dom.byId(ctrlId);
					if (ctrl) {
						for (var prop in Props)
							ctrl.setAttribute(prop, Props[prop]);
					}
				}
			}
			this.setupGridControls = function (GridControls) {
				for (var i = 0, len = GridControls.length; i < len; i++) {
					var ctrl = GridControls[i];
					var hook = gx.dom.byId(ctrl.hookId);
					var parent = hook.parentNode;
					if (parent) {
						parent.insertBefore(ctrl.el, hook);
						gx.dom.removeControlSafe(hook);
					}
				}
			}

			this.setupGridComponents = (function () {
				var processCodeCallback = function (GridComponents, deferred) {
					var i, len = GridComponents.length;

					for (i = 0; i < len; i++) {
						var cmp = GridComponents[i];
						if (cmp.create === false)
							continue;
						var gxComp = gx.createComponent(cmp.n, cmp.p);
						if (gxComp != null) {
							gx.addComponent(gxComp);
							gxComp.readServerVars();
							if (cmp.load)
								gxComp.onload(undefined, true);
							if (i == len -1) {
								deferred.resolve();
							}
						}
					}
				};

				var showComponents = function (pendingElements) {
					var i, len = pendingElements.length;
					for (i = 0; i < len; i++) {
						gx.dom.removeClass(pendingElements[i], gx.GxObject.WEBCOMPONENT_LOADING_CLASS_NAME);
					}
				};

				return function (GridComponents) {
					var deferred = $.Deferred(),
						i,
						len = GridComponents.length,
						cmpsCode = [];
					if (len == 0)
						deferred.resolve();
					var pendingElements = [];
					for (i = 0; i < len; i++) {
						var cmp = GridComponents[i];
						if (cmp.create === false) {
							var hook = gx.dom.byId(cmp.existingEl);
							if (hook) {
								var parent = hook.parentNode;
								var el = gx.dom.byId(cmp.el);
								gx.dom.removeControlSafe(hook);
								parent.appendChild(el);
								pendingElements.push(el);
							}
							if (i == len -1) {
								deferred.resolve();
							}
						}
						else {
							cmpsCode.push(cmp.c);
						}
					}
					gx.lang.requestAnimationFrame(showComponents.closure(this, [pendingElements]));
					if (cmpsCode.length > 0) {
						gx.html.processCode(cmpsCode.join(""), false, processCodeCallback.closure(this, [GridComponents, deferred]));
					}
					this.destroyComponentsBackup();
					return deferred.promise();
				};
			})();

			this.setupGridUsercontrols = function (GridUserControls) {
				var len = GridUserControls.length;
				gx.uc.StartRender();
				for (var i = 0; i < len; i++) {
					var rowId = GridUserControls[i].r;
					var col = GridUserControls[i].c;
					var userControl = gx.uc.getNew(this.parentObject, col.gxUCId, col.gxUCLastId, col.gxUCClassName, col.gxUCContainerName + '_' + rowId, col.gxUCControlName, col.gxUCFieldName, this.gridLvl, this.gridId, rowId);
					userControl.DesignContainerName = col.gxUCContainerName;
					userControl.setC2ShowFunction(col.gxShowFunc);
					var len1 = col.gxC2VFuncs.length;
					for (var j = 0; j < len1; j++) {
						userControl.addC2VFunction(col.gxC2VFuncs[j]);
					};
					var len2 = col.gxV2CFuncs.length;
					for (var j = 0; j < len2; j++) {
						userControl.addV2CFunction(col.gxV2CFuncs[j], col.gxUCFieldName);
					};
					userControl.setGridProperties();
					userControl.setGridEventHandlers();
					this.parentObject.setUserControl(userControl);
					userControl.execV2CFunctions(true);
					userControl.execShowFunction();
				}
				gx.uc.EndRender();
			}

			this.triggerDatePickersSetup = function (DatePickersControls) {
				var len = DatePickersControls.length;
				for (var j = 0; j < len; j++) {
					var controlId = DatePickersControls[j].CtrlId;
					var controlGrid = DatePickersControls[j].Grid;
					var controlRow = DatePickersControls[j].Row;
					var currentObject = gx.O;
					var validStruct = null;
					var ctrlIds = gx.fn.controlIds();
					var len1 = ctrlIds.length;
					for (var i = 0; i < len1; i++) {
						validStruct = gx.fn.validStruct(ctrlIds[i]);
						if (validStruct.grid == controlGrid) {
							var vControlId = currentObject.CmpContext + validStruct.fld + "_" + controlRow;
							if (vControlId == controlId)
								break;
						}
					}
					if ((validStruct != null) && (validStruct.dp != undefined)) {
						gx.fn.installDatePicker(controlId, validStruct, currentObject, validStruct.dp.f, validStruct.dp.st, validStruct.dp.wn, validStruct.dp.mf, gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec, validStruct.len), validStruct.len, validStruct.dp.dec);
					}
				}
			}

			this.installImageControls = function () {
				var scope = this.gxContainerCtrl;
				var newAdditiveRowsEl = this.grid.newAdditiveRows ? this.grid.newAdditiveRows.get(0) : null;
				if (this.additiveResponse && newAdditiveRowsEl && newAdditiveRowsEl.childNodes[0]) {
					scope = newAdditiveRowsEl;
				}
				var containers = gx.dom.byClass(gx.html.multimediaUpload.gxCssClass, '', scope)
				if (containers[0]) {
					for (var i = 0, len = containers.length; i < len; i++) {
						gx.html.multimediaUpload.createControl(containers[i]);
					}
				}
			}

			this.addComponentToDraw = function (cmpObj) {
				this.GridComponents.push(cmpObj);
			}

			this.addUsercontrolToDraw = function (ucObj) {
				this.GridUserControls.push(ucObj);
			}

			this.addDatepickerToSetup = function (dpObj) {
				this.DatePickersControls.push(dpObj);
			}

			this.addControlToReuse = function (ctrl) {
				var parent = ctrl.el.parentNode;
				if (parent) {
					gx.dom.removeControlSafe(ctrl.el);
				}
				this.GridControls.push(ctrl);
			}

			this.loadRowsGrids = function (firstTime, opts) {
				opts = opts || {};
				var addRows = this.additiveResponse || opts.addRows;
				var len = this.grid.rows.length;
				var i = addRows ? this.firstAdditiveRow : 0;
				for (; i < len; i++) {
					this.loadRowGrids(this.grid.rows[i], firstTime);
				}
			}

			this.loadRowGrids = function (row, firstTime) {
				var len = row.gxGrids.length;
				for (var i = 0; i < len; i++) {
					var rowGrid = row.gxGrids[i];
					rowGrid.grid.setContainerDelayed(gx.dom.byId(rowGrid.gxContainerDivName));
					if (firstTime) {
						if ((rowGrid.parentRow != undefined) && (!gx.lang.emptyObj(rowGrid.parentRow.Grids))) {
							var propsCtrlName = rowGrid.getDataHiddenName();
							var gridProps = rowGrid.parentRow.Grids[rowGrid.realGridName];
							gx.fn.setHidden(propsCtrlName, gx.json.serializeJson(gridProps));
						}
						rowGrid.loadGrid( {isNestedLoad:true});
					}
					else {
						rowGrid.refreshGrid({isNestedLoad:true});
					}
					row.IsNew = false;
				}
			}

			this.updateRcdCount = function () {
				if (this.hasForEachLine || this.parentObject.isTransaction()) {
					var gridSuffix = (this.grid.gxParentRowId == "") ? "" : "_" + this.grid.gxParentRowId;				
					gx.fn.setHidden(this.grid.gxCmpContext + "nRC_GXsfl_" + this.gridId + gridSuffix, this.lastRowId.toString());
				}
				var rowId = gx.fn.getHidden(this.grid.gxCmpContext + this.gridName.toUpperCase() + "_ROW");
				if ((this.lastRowId == 0) || (parseInt(rowId, 10) > this.lastRowId)) {
					this.grid.instanciateSelectionVars('0000')
					gx.fn.setCurrentGridRow(this.gridId, '');
				}
			}

			this.updateControlValue = function (vStruct, modifRow, cRow) {
				try {
					var gxgrid = this;
					cRow = cRow || gx.fn.currentGridRow(vStruct.grid).toString();
					var iRow = cRow;
					var rLen = cRow.length;
					if (rLen > 4) {
						var pRow = cRow.substring(4, rLen);
						gxgrid = gx.fn.gridObj(this.gxComponentContext, this.gridName + '_' + pRow, this.isMasterPageGrid);
						if (!gxgrid)
							return;
						iRow = cRow.substring(0, 4);
					}
					var gridRow = parseInt(iRow, 10) - 1;
					if (modifRow == true)
						gxgrid.setRowModified(cRow);
					var colIdx = gxgrid.getColumnIndexByName(vStruct.fld);
					var ctrl = gx.dom.el(this.gxComponentContext + vStruct.fld + "_" + cRow);
					gxgrid.updateRowValue(colIdx, gridRow, ctrl);
					return gxgrid;
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxgrid.js', 'updateControlValue');
				}
				return null;
			}

			this.persistControlValue = function (ControlId, Value, validStruct) {
				var _Idx = ControlId.lastIndexOf("_");
				if (_Idx != -1) {
					var htmlName = ControlId.substring(0, _Idx);
					var rowGxId = ControlId.substring(_Idx + 1);
					var row = this.grid.getRowByGxId(rowGxId);
					if (row) {
						var column = this.grid.getColumnByHtmlName(htmlName);
						if (column) {
							var pValue = this.parentObject[validStruct.gxvar];
							if (validStruct.type == "decimal" && gx.lang.instanceOf(pValue, Number))
								pValue = pValue.toFixed(validStruct.dec);
							row.values[column.index] = pValue;
							if (!row.gxProps[column.index])
								row.gxProps[column.index] = {};
							var cellCtrl = gx.dom.el(ControlId);
							if (cellCtrl && cellCtrl.tagName == 'SELECT') {
								row.gxProps[column.index].Values = gx.dom.comboBoxToObj(cellCtrl);
							}
							row.gxProps[column.index].Value = pValue;
							row.gxProps[column.index].FormattedValue = Value;
						}
					}
				}
			}

			this.getColumnIndexByName = function (htmlName) {
				var cols = this.grid.columns;
				var len = cols.length;
				for (var i = 0; i < len; i++) {
					if (cols[i].htmlName == htmlName)
						return i;
				}
				return -1;
			}

			this.setRowModified = function (cRow) {
				gx.fn.setHidden(this.grid.gxCmpContext + "nIsMod_" + this.gridLvl.toString() + "_" + cRow, 1);
				if (this.parentGrid != null) {
					this.parentGrid.setRowModified(this.grid.gxParentRowId);
				}
				this.grid.showDeleteImage(cRow);
			}
			this.validateRow = function (eventCtrl) {
				if (eventCtrl) {
					try {
					var gxgridid = eventCtrl.getAttribute("data-gxgridid");
					gx.fn.setCurrentGridRow(gxgridid, eventCtrl.gxrow);
					var lastGridCtrl = gx.fn.lastGridControl(gxgridid);
						gx.csv.validControls(gx.csv.lastId, lastGridCtrl + 1, true, gx.O);
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxgrid.js', 'validateRow');
					}
				}
			}

			this.updateRowValue = function (colIdx, rowId, ctrl) {
				var row = this.grid.getRowById(rowId);
				var column = this.grid.columns[colIdx];
				if (ctrl.type == "checkbox") {
					if (ctrl.checked) ctrl.value = column.gxChecked;
					else ctrl.value = column.gxUnChecked;
				}				
				var validStruct = this.parentObject.getValidStruct(this.grid.columns[colIdx].gxId);
				var pValue = validStruct.val(row.gxId);
				row.values[colIdx] = pValue;
				if (!gx.lang.emptyObject(row.gxProps[colIdx])) {
					row.gxProps[colIdx].Value = pValue;
					row.gxProps[colIdx].FormattedValue = gx.fn.getControlValue(this.grid.columns[colIdx].htmlName + "_" + row.gxId, 'screen');
				}
				if (this.parentObject.isTransaction()) {
					var idxInKey = this.columnIndexInKey(column.gxAttId);
					if (idxInKey != -1) {
						row.gxKeyValues[idxInKey] = pValue;
					}
				}
				if (column.gxControl.type == gx.html.controls.types.blob) {
					gx.fn.setControlValue(this.grid.gxCmpContext + column.htmlName + "_" + row.gxId + "_gxBlob", pValue);
				}
			}

			this.expandCollapse = function (imgCtrl, event) {
				gx.evt.cancel(event, true);
				var gridTbl = gx.dom.byId(this.getGridInnerTableId());
				if (gridTbl != null) {
					if (this.collapsed) {
						$(gridTbl).removeAttr("data-gx-sr-only");
						imgCtrl.src = gx.ajax.getImageUrl(gx, 'collapseImage');
					}
					else {
						$(gridTbl).attr("data-gx-sr-only", "");
						imgCtrl.src = gx.ajax.getImageUrl(gx, 'expandImage');
					}
					this.collapsed = !this.collapsed;
					this.grid.gxCollapsed = this.collapsed;
					var gridNameCollapse;
					if (this.parentGrid) {
						var lastIndex = this.gridName.lastIndexOf("_");
						var gridNumber = this.gridName.substring(lastIndex);
						gridNameCollapse = this.gxComponentContext + this.realGridName.toUpperCase() + "_Collapsed" + gridNumber;
					}
					else
						gridNameCollapse = this.gxComponentContext + this.realGridName.toUpperCase() + "_Collapsed";
					gx.fn.setHidden(gridNameCollapse, (this.collapsed) ? "1" : "0");
				}
			}

			this.getRowFromHtmlCtrl = function (rowCtrl) {
				var rowId = rowCtrl.gxrow;
				if (gx.lang.emptyObject(rowId)) {
					var _Idx = rowCtrl.id.lastIndexOf("_");
					rowId = rowCtrl.id.substring(_Idx + 1);
				}
				return this.grid.getRowByGxId(rowId);
			}

			this.showContextMenu = function (rowCtrl, contextEvent) {
				this.contextMenu.show(rowCtrl, contextEvent);
			}
		},

		contextMenu: function (parentGrid) {
			this.gxgrid = parentGrid;
			this.controlName = this.gxgrid.containerName + "ContextMenu"
			this.rowClicked = null;
			this.contextEvent = null;
			this.eventSource = null;
			var buffer = new gx.text.stringBuffer();

			this.show = function (eventCtrl, cEvent) {
				this.gxgrid.validateRow(eventCtrl);
				this.contextEvent = cEvent;
				this.eventSource = gx.evt.source(this.contextEvent);
				gx.evt.cancel(cEvent, true);

				this.rowClicked = eventCtrl;
				this.startMenu();

				buffer.append("<div class=\"").append("menuItem").append("\" id=\"").append("deleteRow").append("\" align=\"center\">").append(gx.getMessage("GXM_deleterow")).append("</div>");
				//buffer.append("<div class=\"").append("menuItem").append("\" id=\"").append("undeleteRow").append("\" align=\"center\">").append("Undelete row").append("</div>");

				this.endMenu();
			}

			this.startMenu = function () {
				buffer.clear();

				var menuCoords = this.getMenuCoords();

				buffer.append("<div onclick=\"").append(this.gxgrid.grid.gridObject() + ".contextMenu.contextMenuClicked(event);").append("\" onmouseover=\"");
				buffer.append(this.gxgrid.grid.gridObject() + ".contextMenu.switchContextMenu();").append("\" onmouseout=\"").append(this.gxgrid.grid.gridObject() + ".contextMenu.switchContextMenu();").append("\" oncontextmenu=\"gx.evt.cancel(event, true);");
				buffer.append("\" style=\"").append("position:absolute;width:100;background-Color:menu; border: outset 1px gray;");
				buffer.append("top:" + menuCoords.top + "; left:" + menuCoords.left + ";").append("\">");
			}

			this.endMenu = function () {
				buffer.append("</div>");

				var ContextControl = gx.dom.byId(this.controlName);
				if (ContextControl == null) {
					ContextControl = document.createElement("SPAN");
					ContextControlShadow = document.createElement("SPAN");
					ContextControlShadow2 = document.createElement("SPAN");
					IFrameControl = document.createElement("IFRAME");
					ContextControl.id = this.controlName;
					ContextControlShadow.id = this.controlName + "Shadow";
					ContextControlShadow2.id = this.controlName + "Shadow2";
					IFrameControl.id = this.controlName + "GXiFrameIEHack";
					IFrameControl.src = "about:blank";
					IFrameControl.style.zIndex = 1;
					IFrameControl.style.visibility = "hidden";
					IFrameControl.style.position = "absolute";
					IFrameControl.frameBorder = "0";

					document.body.appendChild(ContextControl);
					document.body.appendChild(ContextControlShadow);
					document.body.appendChild(ContextControlShadow2);
					document.body.appendChild(IFrameControl);
				}
				if (gx.dom.shouldPurge())
					gx.dom.purge(ContextControl, true);
				ContextControl.innerHTML = buffer.toString();
			}

			this.hide = function () {
				this.rowClicked = null;
				this.contextEvent = null;
				gx.dom.removeControl(gx.dom.byId(this.controlName));
			}

			this.getMenuCoords = function () {
				var posx = 0;
				var posy = 0;
				var e = this.contextEvent;
				if (e.pageX || e.pageY) {
					posx = e.pageX;
					posy = e.pageY;
				}
				else if (e.clientX || e.clientY) {
					posx = e.clientX + document.body.scrollLeft + document.documentElement.scrollLeft;
					posy = e.clientY + document.body.scrollTop + document.documentElement.scrollTop;
				}

				return { left: posx, top: posy };
			}

			this.contextMenuClicked = function (mouseEvent) {
				var eSource = gx.evt.source(mouseEvent);
				this.handleContextMenuAction(eSource.id);
				this.hide();
			}

			this.handleContextMenuAction = function (actionId) {
				switch (actionId) {
					case "deleteRow":
						this.gxgrid.setRowDeleted(this.rowClicked);
						break;
					case "undeleteRow":
						this.gxgrid.setRowDeleted(this.rowClicked);
						break;
					default:
						break;
				}
			}

			this.switchContextMenu = function () {
				//Cambia la clase del elemento seleccionado para hacerle un highlight
			}
		},
		
		getPaddedRowId: function (nRowId) {
			var str = "" + nRowId;
			var pad = "0000";
			return pad.substring(0, pad.length - str.length) + str;
		},
	
		rowId: function (idx) {
			var strIdx = idx.toString();
			while (strIdx.length < 4) {
				strIdx = "0" + strIdx;
			}
			return strIdx;
		},

		_init: function () {
			if (!this.deleteMethod) {
				this.deleteMethod = this.deleteMethods.images;
			}

			if (!this.baseDeleteImage) {
				this.baseDeleteImage = this.deleteImage;
			}

			if (this.deleteImage && (this.deleteMethod == this.deleteMethods.images)) {
				this.deleteImage = gx.ajax.getImageUrl(this, 'baseDeleteImage');
			}
			else {
				this.deleteImage = gx.util.resourceUrl(gx.basePath + gx.staticDirectory + 'delete_16x.jpg', true);
			}

			if (!this.baseUndeleteImage) {
				this.baseUndeleteImage = this.undeleteImage;
			}

			if (this.undeleteImage && (this.deleteMethod == this.deleteMethods.images)) {
				this.undeleteImage = gx.ajax.getImageUrl(this, 'baseUndeleteImage');
			}
			else {
				this.undeleteImage = this.deleteImage;
			}

			if (!this.deletePosition) {
				this.deletePosition = this.deletePositions.left;
			}

			if (!this.deletePositionFree) {
				this.deletePositionFree = this.deletePositions.topL;
			}

			if (this.deleteTooltip) {
				this.deleteTooltip = gx.getMessage(this.deleteTooltip);
			}
			else {
				this.deleteTooltip = '';
			}

			if (this.deleteTitle) {
				this.deleteTitle = gx.getMessage(this.deleteTitle);
			}
			else {
				this.deleteTitle = '';
			}
		},

		_deinit: function () {
			this.lastFocusCtrl = null;
		}
	};
})(gx.$);
/* END OF FILE - ..\js\gxgrid.js - */
/* START OF FILE - ..\js\JavaScripTable.js - */
gx.grid.impl = (function ($) {
	return function (id) {
		var STYLE_ELEMENT_ATT_REGEX = /style="([^"]*)"/ig;

		this.basePath = gx.basePath;
		this.imgsDir = gx.staticDirectory;

		this.columns = [];
		this.columnsHtmlName = [];
		this.columnsGxId = [];
		this.columnsGxAttId = [];
		this.rows = [];
		this.rowsById = [];
		this.rowsByGxId = [];
		this.fixedValues = [];
		this.width = '';
		this.align = '';
		this.border = '0';
		this.padding = '1';
		this.spacing = '0';
		this.sortColumn = -1;
		this.ascSort = true;
		this.usePaging = true;
		this.eof = 1;
		this.firstRecordOnPage = 0;
		this.pageSize = 9999;
		this.currentPage = 1;
		this.gxLvl = 0;
		this.gxGridName = "";
		this.gxGridObject = null;
		this.gxBuffer = new gx.text.stringBuffer();
		this.gxParentRowId = "";
		this.gxHoveredRowId = null;

		this.tableClass = '';
		this.headerClass = '';
		this.footerClass = '';
		this.editControlClass = '';
		this.navigationClass = '';
		this.navigationLinkClass = '';
		this.highlightedNavigationLinkClass = '';
		this.columnAutoHeaderClass = '';
		this.columnHeaderTextClass = '';
		this.oddRowClass = '';
		this.oddRowCellClass = '';
		this.evenRowClass = '';
		this.evenRowCellClass = '';
		this.rowsValues = [];
		this.pagingButtonFirstClass = "PagingButtonsFirst";
		this.pagingButtonPreviousClass = "PagingButtonsPrevious";
		this.pagingButtonNextClass = "PagingButtonsNext";
		this.pagingButtonLastClass = "PagingButtonsLast";
		this.pagingButtonDisabled = "gx-grid-paging-disabled";
		this.pagingBarClass = "gx-grid-paging-bar";
		this.selectedRowClass = "gx-row-selected";
		
		this.rendered = false;

		if (typeof (Image) != 'undefined') {
			this.ascLabel = new Image();
			this.descLabel = new Image();
		} else {
			this.ascLabel = null;
			this.descLabel = null;
		}

		this.id = id;
		this.container = null;

		this.setContainerDelayed = function (gxContainer) {
			this.container = gxContainer;
		}

		this.addColumn = function (column) {
			if (column.isGxRemove()) {
				column.visible = false;
			}
			var len = this.columns.length;
			column.index = len;
			column.table = this;
			this.columns[len] = column;
			if (typeof (column.htmlName) != 'undefined')
				this.columnsHtmlName[column.htmlName] = column;
			if (typeof (column.gxId) != 'undefined')
				this.columnsGxId[column.gxId] = column;
			if (typeof (column.gxAttId) != 'undefined')
				this.columnsGxAttId[column.gxAttId] = column;
			return column;
		}

		this.getColumnByIndex = function (index) {
			return this.columns[index];
		}

		this.getColumnByCtrlType = function (ctrlType) {
			return $.map(this.columns, function( col) {
				return col.gxControl.type == ctrlType ? col : null;
			});
		}

		this.addRow = function (row, refresh) {
			row.table = this;
			if (row == null) {
				return;
			}

			this.rows[this.rows.length] = row;
			if (typeof (row.id) != 'undefined')
				this.rowsById[row.id] = row;
			if (typeof (row.gxId) != 'undefined')
				this.rowsByGxId[row.gxId] = row;
			if (gx.lang.booleanValue(refresh)) {
				this.render();
			}
			return row;
		}

		this.getColumnByHtmlName = function (htmlName) {
			var column, varCxt;
			column = this.columnsHtmlName[htmlName];
			if (typeof (column) == 'undefined' && typeof (this.gxCmpContext) != 'undefined' && this.gxCmpContext.length < htmlName.length) {
				varCxt = htmlName.substring(0, this.gxCmpContext.length);
				if (varCxt == this.gxCmpContext) {
					htmlName = htmlName.substring(this.gxCmpContext.length, htmlName.length);
					column = this.columnsHtmlName[htmlName];
				}
			}
			return column;
		}

		this.getColumnByGxId = function (id) {
			return this.columnsGxId[id];
		}
		this.getColumnByGxAttId = function (id) {
			return this.columnsGxAttId[id];
		}

		this.getColumnForVar = function (varName) {
			for (var i = 0; i < this.columns.length; i++) {
				var vStruct = this.parentGxObject.getValidStruct(this.columns[i].gxId);
				if (vStruct) {
					if (vStruct.gxvar == varName) {
						return this.columns[i];
					}
				}
			}
			return null;
		},

		this.getRowById = function (id) {
			return this.rowsById[id];
		}

		this.getRowByGxId = function (gxId) {
			return this.rowsByGxId[gxId];
		}

		this.setSort = function (column, asc) {
			if (column == this.sortColumn) {
				if (asc == null) {
					this.ascSort = !this.ascSort;
				} else {
					this.ascSort = gx.lang.booleanValue(asc);
				}
			} else {
				this.sortColumn = column;
				this.ascSort = (asc == null ? true : gx.lang.booleanValue(asc));
			}
			this.doSort();
			this.ownerGrid.refreshGrid({ immediateApplyInfiniteScroll: true });
		}

		this.doSort = function () {
			if (this.sortColumn != -1) {
				this.rows.sort(this.sort);
			}
		}

		this.getControlName = function (row, column) {
			return this.gxCmpContext + column.htmlName + '_' + row.gxId;
		}

		this.getControlId = function (row, column) {
			return this.getControlName(row, column);
		}

		this.getRowCount = function () {
			return this.rows.length;
		}

		this.getMaxPage = function () {
			return Math.ceil(this.getRowCount() / this.pageSize);
		}

		this.isGxTrn = function () {
			return this.parentGxObject.isTransaction();
		}

		this.gridObject = function () {
			return "gx.fn.gridObj('" + this.gxCmpContext + "','" + this.gxGridName + "'," + this.gxIsMasterPageGrid.toString() + ")";
		}

		this.deleteImgId = function (rowId) {
			return this.gxCmpContext + 'delete' + this.gxGridName + '_' + rowId;
		}

		this.showDeleteImage = function (rowId) {
			if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images) {
				var isGxTrn = this.isGxTrn();
				if (isGxTrn) {
					var imgCtrl = gx.dom.byId(this.deleteImgId(rowId));
					if (imgCtrl) {
						if (!gx.fn.isVisible(imgCtrl)) {
							imgCtrl.style.display = 'inline';
							if (imgCtrl.parentNode.nodeName == 'A') {
								imgCtrl.parentNode.style.display = 'inline';
							}
						}
					}
				}
			}
		}

		this.appendDeleteHeader = function (buffer, position) {
			if (!this.gxIsFreestyle && (this.ownerGrid.deleteMethod != gx.grid.deleteMethods.none)) {
				var isGxTrn = this.isGxTrn();
				var correctPosition = false;
				if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu) {
					if (position == gx.grid.deletePositions.left) {
						correctPosition = true;
					}
					else {
						return;
					}
				}
				else if (gx.grid.deletePosition == position) {
					correctPosition = true;
				}
				if (isGxTrn && correctPosition) {
					var text = '&nbsp;';
					if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images) {
						text = gx.grid.deleteTitle;
					}
					buffer.append('<th class="' + this.columnAutoHeaderClass + '">' + text + '</th>');
				}
			}
		}

		this.appendDeleteImage = function (buffer, row, position) {
			if (this.ownerGrid.deleteMethod != gx.grid.deleteMethods.none) {
				var isGxTrn = this.isGxTrn();
				if (isGxTrn) {
					var isDeleted = false;
					var canDelete = false;
					if ((this.parentGxObject.Gx_mode != 'DSP') && (this.parentGxObject.Gx_mode != 'DLT')) {
						isDeleted = row.gxDeleted();
						canDelete = (row.gxIsMod() || row.gxExists());
					}
					var imgId = this.deleteImgId(row.gxId);
					var correctPosition = false;
					if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu) {
						if (position == gx.grid.deletePositions.left) {
							correctPosition = true;
						}
						else {
							return;
						}
					}
					else {
						if (!this.gxIsFreestyle && (gx.grid.deletePosition == position)) {
							correctPosition = true;
						}
						else if (this.gxIsFreestyle) {
							var posFree = gx.grid.deletePositionFree;
							if (position == gx.grid.deletePositions.left) {
								correctPosition = ((posFree == gx.grid.deletePositions.topL) || (posFree == gx.grid.deletePositions.bottomL));
							}
							else if (position == gx.grid.deletePositions.right) {
								correctPosition = ((posFree == gx.grid.deletePositions.topR) || (posFree == gx.grid.deletePositions.bottomR));
							}
							position = posFree;
						}
					}
					if (correctPosition) {
						var tagStart = '<' + this.CELL_TAG + ' class="gx-remove-row gx-remove-row-' + this.deleteImageAlign(position) + ' gx-remove-row-' + this.deleteVerticalAlign(position) + '" style="text-align:' + this.deleteImageAlign(position) + ';vertical-align:' + this.deleteVerticalAlign(position) + '">';
						var tagEnd = '</' + this.CELL_TAG + '>';
						var imgSrc = '';
						var showHidden = false;
						if (isDeleted && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)) {
							imgSrc = gx.grid.undeleteImage;
						}
						else if (canDelete && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images)) {
							imgSrc = gx.grid.deleteImage;
						}
						else if (isDeleted && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu)) {
							imgSrc = gx.grid.deleteImage;
						}
						else {
							imgSrc = gx.grid.deleteImage;
							showHidden = true;
						}
						var tooltip = '';
						buffer.append(tagStart);
						if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images) {
							var firstGridCtrl = gx.fn.firstGridControl(this.ownerGrid.gridId);
							tooltip = gx.grid.deleteTooltip;
							buffer.append("<a gxfocusable=\"1\" href=\"javascript:" + this.gridObject() + ".setRowDeleted('" + row.gxId + "');\"");
							buffer.append(" onfocus=\"gx.evt.onfocus(this," + firstGridCtrl + ",'" + this.ownerGrid.gxComponentContext + "'," + this.ownerGrid.isMasterPageGrid + ",'" + row.gxId + "'," + this.ownerGrid.gridId + ")\"");
							var aStyle = '';
							if (showHidden) {
								aStyle += 'display:none;';
							}
							if (aStyle) {
								buffer.append(" style=\"" + aStyle + "\"");
							}
							buffer.append(">");
						}
						buffer.append('<img id="' + imgId + '" src="' + imgSrc + '"');
						if (tooltip) {
							buffer.append(' title="' + tooltip + '"');
						}
						buffer.append(' style="border-style: none;');
						if (showHidden) {
							buffer.append('display:none;');
						}
						buffer.append('"');
						buffer.append(' class="gx-grid-delete"/>');
						if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.images) {
							buffer.append('</a>');
						}
						buffer.append(tagEnd);
					}
				}
			}
		}

		this.deleteVerticalAlign = function (position) {
			if (this.gxIsFreestyle) {
				if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu) {
					return 'middle';
				}
				var styleAlign = 'top';
				if ((position == gx.grid.deletePositions.bottomL) || (position == gx.grid.deletePositions.bottomR)) {
					styleAlign = 'bottom';
				}
				return styleAlign;
			}
			return 'middle';
		}

		this.deleteImageAlign = function (position) {
			if (this.gxIsFreestyle) {
				if (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu) {
					return 'left';
				}
				var styleAlign = 'right';
				if ((position == gx.grid.deletePositions.bottomL) || (position == gx.grid.deletePositions.topL)) {
					styleAlign = 'left';
				}
				return styleAlign;
			}
			return 'center';
		}

		this.getRowByPos = function( nPos)
		{
			return this.container.querySelector( ' tbody>tr:nth-child(' + nPos+')');
		}

		this.scroll_last_row_selector = function(rows) {
			if (this.ownerGrid.additiveResponse) {
				return ' tbody tr:nth-last-child('+ Math.min(rows / 2, 1) +')';
			}
			return ' tbody tr:last-child';
		}
		
		this.scroll_first_row_selector = function() {
			return ' tbody tr:first-child';
		}
		this.ROW_TAG = "tr";
		this.CELL_TAG = "td";
		this.ROW_BASE_CLASS = "";

		this.getRowRenderingProps = function (even, rowDeleted) {
			var gxRowTag = this.ROW_TAG;
			var baseRowClass = this.ROW_BASE_CLASS;
			if (this.gxIsFreestyle) {
				gxRowTag = this.CELL_TAG;
			}

			var rowClass = baseRowClass;
				rowClass += (rowClass ? " " : "") + (even ? this.evenRowClass : this.oddRowClass) + (rowDeleted ? ' RowDeleted' : '');

			return {
				cls: rowClass,
				tag: gxRowTag
			};
		};

		this.simpleAppendFn = function (tag) {
			return function (buffer) {
				buffer.append(tag);
			};
		};

		this.appendGridStyle = function (buffer) {
			var styleRegex = STYLE_ELEMENT_ATT_REGEX;
			var styleMatches = styleRegex.exec(this.gxHtmlTags);
			if (styleMatches && styleMatches.length > 1) {
				buffer.append(styleMatches[1]);
			}

			if (!gx.lang.emptyObject(this.gxBackground)) {
				buffer.append(";background-image:url('" + gx.util.resourceUrl(this.gxBackground, true) + "');");
			}
			if (!gx.lang.emptyObject(this.gxBorderWidth)) {
				buffer.append(";border: solid " + this.gxBorderWidth + "px ");
			}
			if (!gx.lang.emptyObject(this.gxBordercolor)) {
				buffer.append(this.gxBordercolor + ";");
			}
			else
				buffer.append(";");

			if (this.ownerGrid.width > 0) {
				buffer.append("width:" + this.ownerGrid.width + this.ownerGrid.widthUnit + ";");
			}

		};

		this.appendGridAttributes = function (buffer) {
			buffer.append(this.gxHtmlTags.replace(STYLE_ELEMENT_ATT_REGEX, ""));

			if (this.gxAllowCollapsing) {
				if (this.gxCollapsed) {
					buffer.append(" data-gx-sr-only ");
				}
			}
		};

		this.appendGridClassAttribute = function (buffer) {
			if (this.gxHtmlTags.indexOf("class=") == -1)
				buffer.append(" class=\"" + this.gxCssClass + "\"");
		};

		this.appendCollapsingWrapperStart = function (buffer) {
			buffer.append('<div valign="top" ><div>');
			buffer.append("<img class=\"collapse-icon\" style=\"cursor:pointer;\" src=\"");
			if (this.gxCollapsed) {
				buffer.append(gx.ajax.getImageUrl(gx, 'expandImage'));
			}
			else {
				buffer.append(gx.ajax.getImageUrl(gx, 'collapseImage'));
			}
			buffer.append("\" onclick=\"" + this.gridObject() + ".expandCollapse(this, event);" + "\"></div><div>");
		};

		this.appendCollapsingWrapperEnd = function (buffer) {
			buffer.append("</div></div>");
		};

		this.appendContainerStart = function(tableId, buffer) {
			buffer.append("<table ");
			this.appendGridClassAttribute(buffer);
			buffer.append(" id=\"" + tableId + "\" ");
			if (!gx.lang.emptyObject(this.gxToolTipText)) {
				buffer.append("title=\"" + this.gxToolTipText + "\" ");
			}

			buffer.append("style=\"");
			this.appendGridStyle(buffer);
			buffer.append("\" ");
			this.appendGridAttributes(buffer);
			if (!this.isAbstract) {
				buffer.append('data-bkgstyle="');
				buffer.append(gx.grid.styles[this.gxTitleBackstyle]);
				buffer.append('" ');
			}
			buffer.append(">");
			if (!gx.lang.emptyObject(this.header)) {
				buffer.append("<caption>");
				buffer.append(this.header);
				buffer.append("</caption>");					
			}
		};

		this.appendContainerEnd = this.simpleAppendFn("</table>");

		this.appendHeaderText = function (columnCount, buffer) {
			if (!gx.lang.emptyObject(this.headerText)) {
				buffer.append("<tr><td colspan=\"" + columnCount + "\" class=\"" + this.headerClass + "\">" + this.headerText + "</td></tr>");
			}
		};

		this.appendFooterText = function (renderedColumnCount, buffer) {
			if (!gx.lang.emptyObject(this.footerText)) {
				buffer.append("<tr><td colspan=\"" + renderedColumnCount + "\" class=\"" + this.footerClass + "\">" + this.footerText + "</td></tr>");
			}
		};

		this.appendHeader = function (visibleColumnsArray, buffer) {
			var colsLen = visibleColumnsArray.length;
			var cursorPointer = "cursor:" + (document.createTextRange ? "hand" : "pointer") + ";";
			var images = [];
			var ascLabelSrc = gx.ajax.getImageUrl(gx, 'ascImage');
			var descLabelSrc = gx.ajax.getImageUrl(gx, 'descImage');
			var cHIndex = 0;
			var headerStyle;

			buffer.append("<thead>");
			buffer.append("<tr>");

			this.appendDeleteHeader(buffer, gx.grid.deletePositions.left);

			for (var i = 0; i < colsLen; i++) {
				var column = visibleColumnsArray[i],
					columnClass = [column.gxColumnClass, column.columnheaderclass || "", this.columnAutoHeaderClass].join(" ");

				buffer.append("<th class=\"" + columnClass + "\"");
				headerStyle = 'white-space:nowrap;';
				if (!gx.lang.gxBoolean(column.visible))
					headerStyle += 'display:none;';
				if (column.width) {
					if (!column.gxWidthUnit)
						column.gxWidthUnit = 'px';
					headerStyle += "width:" + column.width + column.gxWidthUnit + ";";
				}
				if (column.align)
					headerStyle += "text-align:" + column.align + ";";
				if (!gx.lang.emptyObject(this.gxTitleBackColor) && (this.gxTitleBackstyle == gx.grid.styles.header || this.gxTitleBackstyle == gx.grid.styles.report)) {
					headerStyle += "background-color:" + this.gxTitleBackColor + ";";
					this.gxRealTitleBackColor = this.gxTitleBackColor;
				}
				if (!gx.lang.emptyObject(this.gxBackColor) && (this.gxTitleBackstyle == gx.grid.styles.uniform)) {
					headerStyle += "background-color:" + this.gxBackColor + ";";
					this.gxRealTitleBackColor = this.gxBackColor;
				}
				if (!gx.lang.emptyObject(this.gxTitleForeColor)) {
					headerStyle += "color:" + this.gxTitleForeColor + ";";
				}
				if (!gx.lang.emptyObject(this.gxTitleFont)) {
					headerStyle += this.gxTitleFont;
				}
				if (column.titlefontunderline)
					headerStyle += "text-decoration: underline;";					
				else if (column.titlefontstrikethru)
					headerStyle += "text-decoration: line-through;";				
				if (column.titlefontbold)
					headerStyle += "font-weight: bold;";
				if (column.titlefontitalic)
					headerStyle += "font-style: italic;";
				if (column.titlebackcolor)
					headerStyle += "background-color:" + gx.color.html(column.titlebackcolor).Html + ";";
				if (column.titleforecolor)
					headerStyle += "color:" + gx.color.html(column.titleforecolor).Html + ";";
				buffer.append(" style=\"" + headerStyle + ";\"");
				buffer.append(" data-colindex=\"" + cHIndex + "\"");
				buffer.append(">");

				cHIndex++;

				if (gx.lang.emptyObject(gx.text.trim(column.title))) {
					buffer.append("&nbsp;");
				}
				else {
					buffer.append("<span");
					if (column.gxTooltip) {
						buffer.append(" title=\"" + column.gxTooltip + "\"");
					}
					headerStyle = "";
					if (column.sortable) {
						headerStyle = cursorPointer;
						buffer.append(" onclick=\"" + this.gridObject() + ".grid.setSort(" + column.index + ");\" onMouseOver=\"window.status='" + this.sortMessage + "';return true;\" onMouseOut=\"window.status='';return true;\"");
					}
					buffer.append(">");

					buffer.append(column.title);

					if (this.ascLabel != null && this.descLabel != null) {
						this.ascLabel.src = ascLabelSrc;
						this.descLabel.src = descLabelSrc;
						if (column.sortable && this.sortColumn == column.index) {
							buffer.append("&nbsp;" + this.handleLabel(((this.ascSort) ? this.ascLabel : this.descLabel), images));
						}
					}
					buffer.append("</span>");
				}
				buffer.append("</th>");
			}

			this.appendDeleteHeader(buffer, gx.grid.deletePositions.right);

			buffer.append("</tr>");
			buffer.append("</thead>");
		};

		this.appendBodyWrapperStart = this.simpleAppendFn("<tbody>");

		this.appendBodyWrapperEnd = this.simpleAppendFn("</tbody>");

		this.appendFooterWrapperStart = this.simpleAppendFn("<tfoot>");

		this.appendFooterWrapperEnd = this.simpleAppendFn("</tfoot>");

		this.appendRowStart = this.simpleAppendFn("<tr>");

		this.appendRowEnd = this.simpleAppendFn("</tr>");

		this.appendRowBreaksWrapperStart = this.simpleAppendFn("<table width='100%' data-cellspacing='0' data-cellpadding='0'><tbody>");

		this.appendRowBreaksWrapperEnd = this.simpleAppendFn("</tbody></table></td>");

		this.appendRowPrefix = gx.emptyFn;

		this.appendCellPrefixStart = gx.emptyFn;

		this.appendCellPrefixEnd = gx.emptyFn;

		this.beforeRender = function () {
			this.tableClass = this.gxCssClass;
			this.evenRowClass = this.gxEvenLinesClass;
			this.oddRowClass = this.gxOddLlinesClass;
			this.headerClass = this.gxTitleClass;
			this.columnAutoHeaderClass = this.headerClass;
			this.columnHeaderTextClass = this.headerClass;
			this.evenRowCellClass = this.evenRowClass;
			this.oddRowCellClass = this.oddRowClass;
			$.each(this.beforeRenderCallbacks, function (i , f)
				{
					f();
				}
			);
			this.beforeRenderCallbacks = [];
		};
		
		this.drawEmptyContent = function() {
			var ownerGrid = this.ownerGrid;
			var gridTblid = ownerGrid.getGridInnerTableId();
			if (ownerGrid.emptyText) {
				if ($('#' + gridTblid + ' + .gx-text-gridnodata').length === 0) {					
					var el = $(document.createElement('div'))
						.addClass('GridNoDataText gx-text-gridnodata')						
						.text(ownerGrid.emptyText);						
					el.insertAfter($('#' + gridTblid));
				}
			}
			if (this.rows.length === 0) {
				$('#' + gridTblid).attr('data-gx-grid-nodata','');
			}
			else {
				$('#' + gridTblid).removeAttr('data-gx-grid-nodata');
			}
		};

		this.purgeGrid = function () {
			var len, i;

			var events = ['onblur', 'onclick', 'onfocus', 'onchange'];
			var inputs = gx.dom.byTag('input', this.container);
			for (i = 0, len = inputs.length; i < len; i++)
				gx.dom.purgeElement(inputs[i], events);
			var textAreas = gx.dom.byTag('textarea', this.container);
			for (i = 0, len = textAreas.length; i < len; i++)
				gx.dom.purgeElement(textAreas[i], events);
			var selects = gx.dom.byTag('select', this.container);
			for (i = 0, len = selects.length; i < len; i++)
				gx.dom.purgeElement(selects[i], events);
			var spans = gx.dom.byTag('span', this.container);
			for (i = 0, len = spans.length; i < len; i++)
				gx.dom.purgeElement(spans[i], events);
			var imgs = gx.dom.byTag('img', this.container);
			for (i = 0, len = imgs.length; i < len; i++)
				gx.dom.purgeElement(imgs[i], events);
		};

		this.render = function (firstTime, fromAutoRefresh, fromCollection, afterRenderCallback, ops) {
			firstTime = !!firstTime;

			var tableId = this.ownerGrid.getGridInnerTableId(),
				container = this.container;

			this.beforeRender();

			if (this.ownerGrid.additiveResponse) {
				this.doSort();
			}

			var gridHtml = this.drawGrid(tableId, firstTime, fromAutoRefresh, fromCollection, ops);

			if (gx.dom.shouldPurge()) {
				this.purgeGrid();
			}

			var activeEl = gx.dom.getActiveElement(),
				activeElTagName = activeEl ? activeEl.tagName.toUpperCase() : "",
				restoreActiveEl = activeEl && 
									(activeEl.id || activeEl.name) && 
									activeElTagName != "FORM" && 
									gx.dom.isChildNode(activeEl, container),
				caretOffset = gx.dom.getCaretOffset( activeEl);
			
			this.setGridHtml(this.container, gridHtml, ops);
			
			if (!this.gxIsFreestyle)
				this.ownerGrid.instanciateRow(gx.fn.currentGridRowImpl(this.ownerGrid.gridId));  //We restore current active row because if we do not do it, all struct values are lost.

			if (this.ownerGrid.additiveResponse) {
				if (this.sortColumn != -1) {
					this.ownerGrid.handleInfiniteScrolling();
				}
			}
			if (restoreActiveEl) {
				setTimeout(function () {
					var newActiveEl = gx.dom.el(activeEl.id || activeEl.name, false, true);
					if (newActiveEl) {
						gx.csv.disableFocus = true;
						if (newActiveEl.offsetWidth > 0 && newActiveEl.offsetHeight > 0) {
							gx.fn.setFocus(newActiveEl, function() {
								gx.dom.setCaretOffset( newActiveEl, caretOffset);
							});
						}
					}
				}, 10);
			}

			this.drawEmptyContent();
			this.afterRender(tableId);

			// Call after render callback
			afterRenderCallback();

			this.rendered = true;
		};

		this.setGridHtml = function (container, gridHtml, opts) {
			opts = opts || {};
			gx.csv.IgnoreBlur = true;

			var newRows, $newRows;
			var inverseLoading = this.ownerGrid.InverseLoading;
			var hook;
			var $children;
			var addRowsOnly = this.ownerGrid.additiveResponse || opts.addRows;
			if (addRowsOnly) {
				if ( this.sortColumn !== -1) {
					container.innerHTML = gridHtml;					
					gx.plugdesign.applyTemplateObject({
						selector: container
					});
				}
				else {
					if (this.gxIsFreestyle) {
						newRows = document.createElement("div");
						newRows.className = "gx-sr-only";
						newRows.innerHTML = gridHtml;
						newRows.setAttribute("data-gx-grid-rendering-additive-rows", "");
						$newRows = $(newRows);
						if (inverseLoading) {
							hook = this.firstItemSelector;
						}
						else {
							hook = this.lastItemSelector;
						}
						if (inverseLoading) {
							$newRows.insertBefore(hook);
						}
						else {
							$newRows.insertAfter(hook);
						}
					}
					else {
						if (inverseLoading) {
							$newRows = $(gridHtml).insertBefore(this.firstItemSelector);
						}
						else {
							newRows = $(gridHtml).insertAfter(this.lastItemSelector);
						}
					}
					this.newAdditiveRows = $newRows;
					gx.plugdesign.applyTemplateObject({
						selector: $newRows, 
						deferred:true
					}).then((function () {
						if (this.newAdditiveRows) {
							$children = this.newAdditiveRows.children();
							if (inverseLoading) {
								$children.insertBefore(this.newAdditiveRows);
							}
							else {
								$children.insertAfter(this.newAdditiveRows);
							}
							this.newAdditiveRows.trigger("gx-grid:after-additive-rows-render");
							this.newAdditiveRows.remove();
							delete this.newAdditiveRows;
						}
					}).closure(this));
				}
			}
			else {
				container.innerHTML = gridHtml;
			}
			gx.csv.IgnoreBlur = false;
		};

		this.afterRender = function () {
			if (!this.rendered) {
				this.defineEventHandlers();
			}

		};

		this.drawGrid = function (tableId, firstTime, fromAutoRefresh, fromCollection, opts) {
			opts = opts || {};
			var isGxTrn = this.isGxTrn();
			var hasRowBreaks = this.gxIsFreestyle && (this.gxGridCols > 1);

			var buffer = new gx.text.stringBuffer();
			var visibleColumnsArray = this.columns;
			var renderedColumnCount = visibleColumnsArray.length;
			var i, row, column, colHtmlCode, vAlign, columnDefaultVisible, columnProps, gxCtrl;

			var addRowsOnly = this.ownerGrid.additiveResponse || opts.addRows;

			if (!this.gxIsFreestyle && isGxTrn) {
				renderedColumnCount++;
			}

			var firstRow, lastRow, maxPage;
			if (addRowsOnly || opts.immediateApplyInfiniteScroll) {
				firstRow = (this.firstRecordOnPage == '0' || this.sortColumn != -1) ? 0 : this.lastRenderedRow;
				lastRow = this.rows.length;
				this.ownerGrid.firstAdditiveRow = firstRow;
			}
			else {	
				if (Number(this.pageSize) !== 0) { //pageSize != 0
					maxPage = this.getMaxPage();
					if (this.currentPage <= 0) {
						this.currentPage = 1;
					}
					else if (this.currentPage > maxPage) {
						this.currentPage = maxPage;
					}
					firstRow = Math.max(this.pageSize * (this.currentPage - 1), 0);
					lastRow = Math.min(firstRow + this.pageSize, this.rows.length);
				}
				else {
					firstRow = 0;
					lastRow = this.rows.length;
				}
			}

			if (this.gxAllowCollapsing) {
				this.appendCollapsingWrapperStart(buffer);
			}

			var colsLen = visibleColumnsArray.length;
			if (!this.gxIsFreestyle && (lastRow > firstRow)) {
				for (var j = 0; j < colsLen; j++) {
					column = visibleColumnsArray[j];
					columnDefaultVisible = gx.lang.gxBoolean(column.visible);
					if (columnDefaultVisible) {
						var rtVisible = false;
						for (i = firstRow; i < lastRow && !rtVisible; i++) {
							row = this.rows[i];
							gxCtrl = column.gxControl;
							columnProps = row.gxProps[column.index];
							if (!fromCollection) {
								gxCtrl.setProperties.apply(gxCtrl, columnProps);
							}
							if (gxCtrl.visible) {
								rtVisible = true;
							}
						}
						if (!rtVisible) 
							column.visible = false;
					}
				}
			}
			if (!addRowsOnly || this.sortColumn != -1) {
				this.appendContainerStart(tableId, buffer);
				this.appendHeaderText(renderedColumnCount, buffer);
				if (!this.gxIsFreestyle) {
					this.appendHeader(visibleColumnsArray, buffer);
				}
				this.appendBodyWrapperStart(buffer);
			}
			var even = true;

			var renderRow = function() {
				even = !even;
				row = this.rows[i];
				if (firstTime && i === firstRow && !gx.fn.currentGridRowImpl(this.gxId)) {
					gx.fn.setCurrentGridRow(this.gxId, row.gxId);
				}
				var rowDeleted = row.gxDeleted();
				var rowHtml = new gx.text.stringBuffer();
				var rowProps = this.getRowRenderingProps(even, rowDeleted, i, firstRow, lastRow);

				var freestyleRowBreak = hasRowBreaks && this.gxIsFreestyle && (((i > 0) && (i % this.gxGridCols === 0)) || ((i === 0) && (this.gxGridCols > 0)));
				if (freestyleRowBreak) {
					if (i > 0) {
						this.appendRowEnd(buffer, i, firstRow, lastRow);
					}
					this.appendRowStart(buffer, i, firstRow, lastRow);
				}
				// Resolve row backcolor
				var backColor = "";
				if (this.gxTitleBackstyle == gx.grid.styles.report)
					backColor = (even) ? this.gxLinesBackcolorEven : this.gxLinesBackcolorOdd;
				if (this.gxTitleBackstyle == gx.grid.styles.header)
					backColor = this.gxLinesBackcolorOdd;
				if (this.gxTitleBackstyle == gx.grid.styles.uniform)
					backColor = this.gxBackColor;

				if (!this.gxIsFreestyle || (this.gxIsFreestyle && hasRowBreaks)) {
					this.appendRowPrefix(rowHtml, i, firstRow, lastRow);
					rowHtml.append("<" + rowProps.tag + " id='" + this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId + "'");
					if (!this.gxIsFreestyle) {
						rowHtml.append(" data-gxrendering_row=\"\"");
					}
					if (this.gxIsFreestyle && hasRowBreaks) {
						rowHtml.append(" data-gxrow=\"" + row.gxId.toString() + "\"");
						vAlign = this.columns[1].gxControl.verticalAlign;
						if (vAlign) {
							rowHtml.append(" data-cell-valign=\"" + vAlign + "\"");
						}
					}
					else
						rowHtml.append(" data-gxrow=\"" + row.gxId.toString() + "\"");
					rowHtml.append(" class=\"" + rowProps.cls + "\"");

					if (row.selected) {
						rowHtml.append(" data-selected=\"1\"");
					}

					var rStyle = "";
					if (backColor) {
						rStyle = "background-color:" + backColor + ";";
					}
					if (!gx.lang.emptyObject(this.gxLinesFont)) {
						rStyle += this.gxLinesFont;
					}
					if (rStyle) {
						rowHtml.append(" style=\"" + rStyle + "\" ");
					}
					rowHtml.append(">");
					buffer.append(rowHtml.toString());
				}
				if (this.gxIsFreestyle) {
					if (hasRowBreaks) {
						this.appendRowBreaksWrapperStart(buffer, row);
					}
					colHtmlCode = this.gxBuffer.toString();
					buffer.append(colHtmlCode);
				}

				if (!this.gxIsFreestyle)
					this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);

				this.appendCellPrefixStart(buffer, i, firstRow, lastRow, row, rowProps);
				for (var j = 0; j < colsLen; j++) {
					column = visibleColumnsArray[j];
					columnDefaultVisible = gx.lang.gxBoolean(column.visible);
					columnProps = row.gxProps[column.index];
					var columnValue = row.values[column.index];

					gxCtrl = column.gxControl;
					if (this.gxIsFreestyle && gxCtrl.type == gx.html.controls.types.row) {
						if (column.index === 0) {
							gxCtrl.isFreestyleRow = true;
						}
					}
					gxCtrl.setGridData({
						grid: this.ownerGrid,
						row: row,
						gridId: this.gxId,
						gridRow: row.gxId
					});
					if (!fromCollection) {
						gxCtrl.setProperties.apply(gxCtrl, columnProps);
						if (gxCtrl.isFreestyleRow) {
							gxCtrl.cssClass = rowProps.cls;
						}
					}
					else {
						delete gxCtrl.formattedValue;
						gxCtrl.value = columnValue;
						gxCtrl.id = column.htmlName + "_" + gxCtrl.gridRow;
						//Set all column properties (design and runtime properties)
					}
					
					if (firstTime)
						delete gx.usrPtys[gxCtrl.id];
					else {
						if (gx.usrPtys[gxCtrl.id] !== undefined) {
							var Pty;
							for (Pty in gx.usrPtys[gxCtrl.id]) {
								if (Pty == 'enabled')
									gxCtrl.rtEnabled = true;
								gxCtrl.setIndividualProp(Pty, gx.usrPtys[gxCtrl.id][Pty]);
							}
						}
					}
					if (rowDeleted) {
						gxCtrl.rtEnabled = true;
						gxCtrl.enabled = false;
					}

					var vStruct = this.parentGxObject.getValidStruct(column.gxId);
					if (typeof(columnProps.Value) !== 'undefined')//Column Value is invariant, but gxCtrl.value is language dependant.
					{
						if (gx.decimalPoint != '.' && vStruct && vStruct.type == "decimal" && typeof (columnProps.Value) == "string")
							gxCtrl.value = columnProps.Value.replace('.', gx.decimalPoint);
						else
							gxCtrl.value = columnProps.Value;
					}
					if (typeof(columnProps.FormattedValue) !== 'undefined')
						gxCtrl.formattedValue = columnProps.FormattedValue;
					if (typeof (gxCtrl.formattedValue) === 'undefined')
					{
						if (fromCollection && vStruct && vStruct.v2c)
						{
							gxCtrl.persistValue();
							vStruct.v2c(row.gxId);
							gxCtrl.formattedValue = gx.fn.getControlValue(gxCtrl.id);
						}
						else
							gxCtrl.formattedValue = gxCtrl.value;
					}


					if (columnProps.Values)
						gxCtrl.possibleValues = columnProps.Values.v;
					if (this.gxIsFreestyle && gxCtrl.type == gx.html.controls.types.row && column.index === 0) {
						gxCtrl.id = this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId;
						if (isGxTrn && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu)) {
							gxCtrl.oncontextmenu = this.gridObject() + ".showContextMenu(this, event);";
						}
						if (backColor)
							gxCtrl.style += "background-color:" + backColor + ";";
					}
					if (!this.gxIsFreestyle) {
						buffer.append('<' + this.CELL_TAG + ' class="gx-attribute ' + (gxCtrl.columnClass || '') + '" data-cell-valign="' + column.valign + '"');
						buffer.append(' data-colindex="' + j + '"');
						var rowStyle = '';
						if (!columnDefaultVisible) {
							rowStyle += 'display:none;';
							if (gxCtrl.visible && !column.isGxRemove() && !this.ownerGrid.isPromptColumn(column))
								this.ownerGrid.addColPropertyAfterRender(j, "Visible", 1);
						}
						if (column.width) {
							if (!column.gxWidthUnit)
								column.gxWidthUnit = 'px';
							rowStyle += "width:" + column.width + column.gxWidthUnit + ";";
						} else if (column.gxColSize) {
							gxCtrl.colSize = column.gxColSize;
						}
						if (column.align)
							rowStyle += "text-align:" + column.align + ";";
						if (gxCtrl.style)
							rowStyle += gxCtrl.style;
						if (rowStyle)
							buffer.append(" style=\"" + rowStyle + "\" ");
						buffer.append(">");
					}
					buffer.append(gxCtrl.getHtml());
					if (this.gxIsFreestyle && gxCtrl.type == gx.html.controls.types.row && column.index === 0) {
						this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);
					}
					gxCtrl.persistValue();

					if (!this.gxIsFreestyle) {
						buffer.append("</" + this.CELL_TAG + ">");
					}
					if (this.gxIsFreestyle) {
						if (column.index == this.columns.length - 1)
							this.appendDeleteImage(buffer, row, gx.grid.deletePositions.right);
						colHtmlCode = column.buffer.toString();
						buffer.append(colHtmlCode);
					}
				}
				this.appendCellPrefixEnd(buffer, i, firstRow, lastRow);

				if (this.gxIsFreestyle && hasRowBreaks) {
					this.appendRowBreaksWrapperEnd(buffer);
				}
				else
					this.appendDeleteImage(buffer, row, gx.grid.deletePositions.right);
			}
			if (this.ownerGrid.InverseLoading) {
				for (i = lastRow - 1; i >= firstRow; i--)
					renderRow.apply(this);
			}
			else {
				for (i = firstRow; i < lastRow; i++)
					renderRow.apply(this);
			}
			
			if (this.gxIsFreestyle && (this.gxGridCols > 0) && hasRowBreaks) {
				this.appendRowEnd(buffer);
			}
			this.lastRenderedRow = lastRow;
			if (!addRowsOnly) {
				this.appendBodyWrapperEnd(buffer);

				this.appendFooterWrapperStart(buffer);
				var gxShowNavBar = (!this.ownerGrid.InfiniteScrolling) && (isGxTrn || this.hasPagingButtons());
				if (gxShowNavBar) {
					this.appendNavigationBar(renderedColumnCount, buffer);
				}

				this.appendFooterText(renderedColumnCount, buffer);

				this.appendFooterWrapperEnd(buffer);
				this.appendContainerEnd(buffer);

				if (this.gxAllowCollapsing) {
					this.appendCollapsingWrapperEnd(buffer);
				}
			}
			var gridHtml = buffer.toString();
			buffer.clear();
			buffer = null;

			return gridHtml;
		};

		this.defineEventHandlers = function () {
			if (!this.gxIsFreestyle){
				gx.evt.attach(this.container, 'mouseover', this.mouseOverHandler, this);
				gx.evt.attach(this.container, 'mouseout', this.mouseOutHandler, this);
			}				

			if (this.isGxTrn() && (this.ownerGrid.deleteMethod == gx.grid.deleteMethods.menu))
				gx.evt.attach(this.container, 'contextmenu', this.contextMenuHandler, this);

			gx.evt.attach(this.container, 'mousedown', this.mouseDownHandler.closure(this, [], true), this);
			
			gx.evt.attach(this.container, 'click', this.clickHandler, this);

			if (this.isGxTrn())
				gx.evt.attach(this.container, 'keydown', this.keyDownHandler, this);
		};

		this.isGridRow = function (el) {
			return el && el.tagName.toLowerCase() == this.ROW_TAG && el.getAttribute("data-gxrow") != null && $(el).closest('.gx-grid')[0] == this.container;
		};

		this.getTargetRow = function (el, parent) {
			var row = el;
			while (row && gx.dom.isChildNode(row, this.container)) {
				if (this.isGridRow(row) && (!parent || (parent == "body" && row.parentNode.tagName == "TBODY") || (parent == "header" && row.parentNode.tagName == "THEAD")))
					return row;
				row = gx.dom.findParentByTagName(row, this.ROW_TAG);
			}
		};

		this.mouseOverHandler = function (event) {
			if (!gx.runtimeTemplates && this.gxAllowHovering) {
				var row = this.getTargetRow(gx.evt.source(event));
				if (row && row.getAttribute('data-selected') != '1') {
					this.toggleRowHoverById(this.gxHoveredRowId, false);
					this.startRowHover(row);
					this.gxHoveredRowId = parseInt(row.getAttribute('data-gxrow').substring(0,4), 10) - 1;
				}
			}
		};

		this.mouseOutHandler = function (event) {			
			if (!gx.runtimeTemplates && this.gxAllowHovering) {
				var row = this.getTargetRow(gx.evt.source(event));
				if (row && row.getAttribute('data-selected') != '1')
					this.endRowHover(row);
			}
		};

		this.contextMenuHandler = function (event) {
			var row = this.getTargetRow(gx.evt.source(event));
			if (row)
				this.ownerGrid.showContextMenu(row, event);
		};

		this.mouseDownHandler = function (event, updateUI) {			
			var row = this.getTargetRow(gx.evt.source(event));
			if (row){
				updateUI = (typeof(updateUI) === 'undefined') ? this.gxAllowSelection && !this.gxIsFreestyle: updateUI;
				this.setRowSelected(row, row.getAttribute('data-gxrow'), false, updateUI);
			}
		};

		this.keyDownHandler = function (event) {
			var row = this.getTargetRow(gx.evt.source(event));
			if (row)
				this.ownerGrid.rowKeyPressed(event);
		};

		this.clickHandler = function (event) {
			var source = gx.evt.source(event);
			if (source.parentNode && gx.dom.hasClass(source.parentNode, this.pagingBarClass)) {
				gx.evt.waitGridRefresh( function() { this.pagingHandler(source, event)}.closure(this));
			}
		};

		this.pagingHandler = function(source, event) {
			var pagingDirection = '';

			gx.evt.cancel(event, true);
			if (!gx.dom.hasClass(source, this.pagingButtonDisabled)) {
				if (gx.dom.hasClass(source, this.pagingButtonFirstClass)) {
					pagingDirection = 'FIRST';
				}
				else if (gx.dom.hasClass(source, this.pagingButtonPreviousClass)) {
					pagingDirection = 'PREV';
				}
				else if (gx.dom.hasClass(source, this.pagingButtonNextClass)) {
					pagingDirection = 'NEXT';
				}
				else if (gx.dom.hasClass(source, this.pagingButtonLastClass)) {
					pagingDirection = 'LAST';
				}
				
				this.changeGridPage(pagingDirection);
			}
		};

		this.changeGridPage = function (pagingDirection, force) {
			var deferred = $.Deferred();
			var hiddenName = this.gxGridName.toUpperCase() + "PAGING",
				ownerGrid = this.ownerGrid,
				eventName = '',
				gridId;
			if (pagingDirection) {
				if (!ownerGrid.InfiniteScrolling)
					this.mask();
				if (gx.pO.fullAjax) {
					gx.setGxO(this.parentGxObject);
					eventName = "E" + ownerGrid.realGridName.toUpperCase() + "_" + pagingDirection + "PAGE" + (ownerGrid.isMasterPageGrid ? "_MPAGE" : "");
					if (ownerGrid.parentGrid) {
						gridId = ownerGrid.parentGrid.gridId;
					}
				}
				else {
					gx.fn.setHidden(this.gxCmpContext + hiddenName, pagingDirection);
					eventName = this.gxCmpContext + "E" + hiddenName + '.';
				}
				var afterFnc = function() {
					this.unmask();
					deferred.resolve();
				}
				gx.evt.execEvt( undefined, undefined, eventName, gx.evt.dummyCtrl, gridId, undefined, undefined, false, afterFnc.closure(this), force);
				return deferred.promise();
			}
		}
		
		var SELECTED_ROW_ATTR = 'data-gxselected';
		this.setRowSelected = function (rowCtrl, cRow, defer, updateUI, fireEvt) {
			gx.grid.setActiveGridRow(this, cRow);

			updateUI = (updateUI === undefined) || updateUI;
			fireEvt = (fireEvt === undefined) || fireEvt;

			var doSelect = function () {
				var oldGxO = gx.O;
				if (gx.lang.emptyObject(this.parentGxObject))
					return;
				if (updateUI && !gx.runtimeTemplates) {
					if (rowCtrl.gxOriginalBackcolor === undefined)
						rowCtrl.gxOriginalBackcolor = rowCtrl.style.backgroundColor;					
				}
				this.instanciateSelectionVars(cRow);
								
				var newSelectedRow = this.getRowByGxId(cRow);
								
				var i,
					aRows = this.selectedRows || [],
					selectedRows = [];
								
				if (newSelectedRow)
					aRows.push(newSelectedRow)				
				
				for (i = 0; i < aRows.length; i++) {
					var row = aRows[i];
					row.selected = (row.gxId == cRow);
					if (!row.selected) {
						if (updateUI) {
							var currRowCtrl = gx.dom.el(this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId);
							if ((currRowCtrl != null) && (currRowCtrl.gxSBackcolor !== undefined)) {
								if (!gx.runtimeTemplates) {
									currRowCtrl.style.backgroundColor = currRowCtrl.gxSBackcolor;							
								}
							}
							gx.dom.removeClass(currRowCtrl, this.selectedRowClass);
							$(currRowCtrl).removeAttr(SELECTED_ROW_ATTR);
						}
					}
					else {
						if (updateUI) {
							if (!gx.runtimeTemplates) {
								rowCtrl.gxSBackcolor = (rowCtrl.gxOriginalBackcolor !== undefined) ? rowCtrl.gxOriginalBackcolor : rowCtrl.style.backgroundColor;
								if (this.gxSelectionColor)
									rowCtrl.style.backgroundColor = this.gxSelectionColor.Html;
							}
							gx.dom.addClass(rowCtrl, this.selectedRowClass);
							$(rowCtrl).attr(SELECTED_ROW_ATTR, '');
						}
						selectedRows.push(row);
					}					
				}

				for (i = 0; i < selectedRows.length; i++) {
					this.instanciateSelectedRow(selectedRows[i], !fireEvt);					
				}
				gx.setGxO(oldGxO);
			};

			if (defer && (updateUI || gx.O.isTransaction()))
				setTimeout(doSelect.closure(this), 100);
			else
				doSelect.call(this);
		}

		this.instanciateSelectionVars = function (rowId) {			
			gx.setGxO(this.parentGxObject);
			gx.fn.setCurrentGridRow(this.gxId, rowId);
			gx.fn.setHidden(this.gxCmpContext + this.gxGridName.toUpperCase() + "_ROW", rowId.substring(0, 4));			
		}

		this.instanciateSelectedRow = function (row, skipEventFire) {
			this.selectedRows = [row];
			this.setSelectedRowVars(row);
			if (this.gxOnLineActivate && !this.ownerGrid.isLoading) {
				gx.csv.instanciatedRowGrid = this.ownerGrid;
				if (!skipEventFire) {
					var gxO = this.parentGxObject;
					if (gxO.fullAjax) {
						var isServerEvent = gxO.isServerEvent(this.gxOnLineActivate);						
						gx.evt.dispatcher.dispatch(gxO.getServerEventName(this.gxOnLineActivate), gxO, this.ownerGrid.gridId, row.gxId, isServerEvent);
					}
					else
						gxO[this.gxOnLineActivate].call(gxO, row.gxId);
				}
			}
		}

		this.setSelectedRowVars = function (row) {
			var gxObj = this.parentGxObject;
			var len = this.columns.length;
			for (var i = 0; i < len; i++) {
				var column = this.columns[i];
				var validStruct = gxObj.GXValidFnc[column.gxId];
				if (validStruct != null) {
					if (validStruct.c2v) {
						validStruct.c2v(row.gxId);
					}
				}
			}
		}

		this.scrollIntoView = function(elem, centerIfNeeded, paddingTop) {
			function withinBounds(value, min, max, extent) {
				if (false === centerIfNeeded || max <= value + extent && value <= min + extent) {
					return Math.min(max, Math.max(min, value));
				} else {
					return (min + max) / 2;
				}
			}
			var area;
			function makeArea(left, top, width, height) {
				return {
					"left": left,
					"top": top,
					"width": width,
					"height": height,
					"right": left + width,
					"bottom": top + height,
					"translate": function(x, y) {
						return makeArea(x + left, y + top, width, height);
					},
					"relativeFromTo": function(lhs, rhs) {
						var newLeft = left,
							newTop = top;
						lhs = lhs.offsetParent;
						rhs = rhs.offsetParent;
						if (lhs === rhs) {
							return area;
						}
						for (; lhs; lhs = lhs.offsetParent) {
							newLeft += lhs.offsetLeft + lhs.clientLeft;
							newTop += lhs.offsetTop + lhs.clientTop;
						}
						for (; rhs; rhs = rhs.offsetParent) {
							newLeft -= rhs.offsetLeft + rhs.clientLeft;
							newTop -= rhs.offsetTop + rhs.clientTop;
						}
						return makeArea(newLeft, newTop, width, height);
					}
				};
			} 

			var parent;
			area = makeArea(elem.offsetLeft, elem.offsetTop, elem.offsetWidth, elem.offsetHeight);
			while ((parent = elem.parentNode)) {
				var clientLeft = parent.offsetLeft + parent.clientLeft;
				var clientTop = parent.offsetTop + parent.clientTop + paddingTop;                
				area = area.relativeFromTo(elem, parent).
				translate(-clientLeft, -clientTop);
				parent.scrollTop = withinBounds(
					parent.scrollTop,
					area.bottom - parent.clientHeight + paddingTop, area.top,
					parent.clientHeight);

				// Determine actual scroll amount by reading back scroll properties.
				area = area.translate(clientLeft - parent.scrollLeft,
					clientTop - parent.scrollTop);
				elem = parent;
			}
		}
				
		this.keepGridItemVisible = function (idx, alignToTop) {						
			var isOldIE = gx.util.browser.isOldIE(),
				$container = $(this.ownerGrid.getContainerControl()),
				$scrollingElement = (!isOldIE)? $('#' + this.ownerGrid.getContainerControlId() + " > table > tbody"): $container.closest('.gx-grid-fixed-header-ie7');
			
			if ($scrollingElement.length > 0 && $scrollingElement[0].offsetHeight < $scrollingElement[0].scrollHeight) {
				var rowCtrl = this.ownerGrid.getRowCtrlByIdx(idx);
				if (rowCtrl) {
						var paddingTop = (isOldIE)? parseInt($container.css('paddingTop'), 10): 0;
					this.scrollIntoView(rowCtrl, alignToTop, paddingTop);											
				}
			}
		}

		this.setNextRowHovered = function () {
			return this.toggleRowHoverById(this.gxHoveredRowId + 1, true, false);
		}

		this.setPreviousRowHovered = function () {
			return this.toggleRowHoverById(this.gxHoveredRowId - 1, true, true);
		}

		this.toggleRowHoverById = function (idx, enabled, alignToTop) {
			var rowCtrl = this.ownerGrid.getRowCtrlByIdx(idx),
				handled = false;
			if (rowCtrl) {
				handled = true;
				if (enabled) {
					this.toggleRowHoverById(this.gxHoveredRowId, false);
					this.startRowHover(rowCtrl);
					this.gxHoveredRowId = idx;
					this.keepGridItemVisible(idx, alignToTop);					
				}
				else {					
					this.endRowHover(rowCtrl);					
				}
			}
			return handled;
		}

		this.getRowByDOMCtrl = function (rowCtrl) {
			var rowId = parseInt(rowCtrl.getAttribute('data-gxrow').substring(0,4), 10) - 1;
			return this.getRowById(rowId);
		}
		
		this.startRowHover = function (rowCtrl) {					
			if (gx.runtimeTemplates) {
				$(rowCtrl).addClass('gx-row-hovered'); //When grid line is hovered by keyboard.
				return;
			}

			if (rowCtrl.gxOriginalBackcolor === undefined)
				rowCtrl.gxOriginalBackcolor = rowCtrl.style.backgroundColor;
		
			var row = this.getRowByDOMCtrl(rowCtrl);
			if (this.gxAllowHovering && this.gxHoverColor && !row.selected) {				
				rowCtrl.gxHBackcolor = rowCtrl.style.backgroundColor;
				rowCtrl.style.backgroundColor = this.gxHoverColor.Html;				
			}
		
		}

		this.endRowHover = function (rowCtrl) {
			if (gx.runtimeTemplates) {
				$(rowCtrl).removeClass('gx-row-hovered');
				return;
			}
			var row = this.getRowByDOMCtrl(rowCtrl);
			if (this.gxAllowHovering && !row.selected) {
				if (rowCtrl.gxHBackcolor !== undefined) {
					rowCtrl.style.backgroundColor = rowCtrl.gxHBackcolor;					
				}
			}
		
		}

		this.hasPagingButtons = function () {
			return (this.usePaging && this.pageSize > 0 && (!this.isFirstPage() || !this.isLastPage()));
		}

		this.appendNavBarRowStart = function (navColSpan, buffer) {
			if (gx.lang.emptyObject(this.gxRealTitleBackColor))
				buffer.append('<tr><td colspan="' + navColSpan + '" class="' + this.navigationClass + '" style="text-align: center;">');
			else
				buffer.append('<tr><td colspan="' + navColSpan + '" class="' + this.navigationClass + '" style="text-align: center;background-color:' + this.gxRealTitleBackColor + ';">');
		};

		this.appendNavBarRowEnd = function (buffer) {
			buffer.append("</td></tr>");
		};

		this.appendNavigationBar = function (renderedColumnCount, buffer) {
			var rowCount = this.getRowCount(),
				navColSpan = renderedColumnCount,
				drawPagingButtons = (rowCount > 0 || (rowCount === 0 && !this.isFirstPage())) && this.usePaging,
				mode = this.parentGxObject.Gx_mode,
				drawNewRowLink = (this.isGxTrn() && !this.gxHasAddlines && !(mode == 'DSP' || mode == 'DLT'));
				
			this.navigationClass = this.gxFooterClass;
			if (this.gxIsFreestyle && this.gxGridCols > 1) {
				navColSpan = this.gxGridCols;
			}

			if (drawPagingButtons || drawNewRowLink) {
				this.appendNavBarRowStart(navColSpan, buffer);
			}

			if (drawPagingButtons) {
				buffer.append('<div class="' + this.pagingBarClass + '" style="padding-bottom:5px;">');

				if (this.currentPage <= 0) {
					this.currentPage = 1;
				}

				buffer.append(this.buildPagingButton(this.pagingButtonFirstClass, !this.isFirstPage(), gx.getMessage("GXM_first")));
				buffer.append(this.buildPagingButton(this.pagingButtonPreviousClass, !this.isFirstPage(), gx.getMessage("GXM_previous")));
				buffer.append(this.buildPagingButton(this.pagingButtonNextClass, !this.isLastPage(), gx.getMessage("GXM_next")));
				buffer.append(this.buildPagingButton(this.pagingButtonLastClass, !this.isLastPage(), gx.getMessage("GXM_last")));
				buffer.append("</div>");
			}

			if (drawNewRowLink) {
				buffer.append(this.buildLink("[" + this.gxNewRowText + "]", this.gridObject() + ".getNewRows(1,event);", this.gxNewRowText, this.gxGridObject + "_NewRow", this.gridObject() + ".gxNewRowFocused(this);"));
			}

			if (drawPagingButtons || drawNewRowLink) {
				this.appendNavBarRowEnd(buffer);
			}
		};

		this.buildPagingButton = function(CSSClass, Enabled, Title) {
			var btnStyle = 'padding-left:20px;padding-bottom:5px;', //It is in the default Themes now. It is here just for older kbs.
				style = 'style="' + btnStyle + (Enabled ? '' : 'opacity:.7;cursor:default') + '"',
				disabledClass = (Enabled ? '' : ' ' +  this.pagingButtonDisabled),
				disabledAttr = (Enabled ? '' : ' disabled');
			return '<button type="button" class="' + CSSClass + disabledClass + '"' + style + ' title="' + Title + '"' + disabledAttr + '/>';
		};

		this.buildLink = function(text, onclick, statusMsg, linkId, onfocusCode) {
			var cursorPointer = "cursor:" + (document.createTextRange ? "hand" : "pointer") + ";",
				linkClass = this.navigationLinkClass,
				highlightedLinkClass = this.highlightedNavigationLinkClass,
				linkStr = (linkId !== undefined) ? "id=\"" + linkId + "\"" : "";
			return "<a class='gx_newrow' type='gxlink' style='text-decoration:none;' tabindex='0' onfocus=\"" + onfocusCode + "\" onblur=\"this.style.textDecoration = 'none';\"><span " + linkStr +
						" style=\"" + cursorPointer + "\" class=\"" + linkClass + "\" onclick=\"" + onclick + "\" " +
						"onMouseOver=\"this.className='" + highlightedLinkClass + "';window.status='" + statusMsg + "';return true;\" " +
						"onMouseOut=\"this.className='" + linkClass + "';window.status='';return true;\">" + text + "</span></a>";
		};

		this.isLastPage = function () {
			var isEOF = this.eof;
			return (isEOF != "0");
		}

		this.isFirstPage = function () {
			var isFirst = gx.lang.emptyObject(this.firstRecordOnPage) ? "0" : this.firstRecordOnPage;
			return (isFirst == "0");
		}

		this.getWebImageTag = function (source) {
			return "<img border=\"0\" src=\"/" + this.basePath + this.imgsDir + source.toString() + "\"/>";
		}

		var imgId = 0;
		this.handleLabel = function (label) {
			if (label.src) {
				var id = "img" + imgId;
				imgId++;
				return "<img name='" + id + "' border='0' src='" + label.src + "'>";
			} else {
				return label;
			}
		}

		this.sort = function (row1, row2) {

			if (row1.table.isGxTrn()) {
				if ((!row1.gxExists() && !row2.gxExists()) && (!row1.gxIsMod() && !row2.gxIsMod())) {
					return 0;
				}
				else if ((!row1.gxExists() && row2.gxExists()) || (!row1.gxIsMod() && row2.gxIsMod())) {
					return 1;
				}
				else if ((row1.gxExists() && !row2.gxExists()) || (row1.gxIsMod() && !row2.gxIsMod())) {
					return -1;
				}
			}

			var theGrid = row1.table;
			var column = theGrid.getColumnByIndex(theGrid.sortColumn);
			var values1, values2;

			values1 = row1.values[theGrid.sortColumn];
			values2 = row2.values[theGrid.sortColumn];

			if (!gx.lang.instanceOf(values1, Array)) {
				values1 = [values1];
			}
			if (!gx.lang.instanceOf(values2, Array)) {
				values2 = [values2];
			}

			var prepare;
			switch (column.type) {
			case gx.types.numeric:
				prepare = function (value) {
						value = gx.num.parseFloat(value, gx.thousandSeparator, gx.decimalPoint);
						if (isNaN(value)) {
							value = 0;
						}
						return value;
					}
				break;
			case gx.types.date:
			case gx.types.dateTime:
				prepare = function (value) {
						try { value = new gx.date.gxdate(value).Value; }
						catch (e) {
							gx.dbg.logEx(e, 'JSTable.js', 'sort');
						}
						return value.valueOf();
					}
				break;
			case gx.types.bool:
				prepare = function (value) {
						return gx.lang.booleanValue(value) ? 1 : 0;
					}
				break;
			default:
				prepare = function (value) {
						return String(value).replace(/<[^\>]*\>/g, "").toUpperCase();
					}
				break;
			}

			var maxIndex = Math.max(values1.length, values2.length);
			var comp = 0;
			for (var i = 0; (comp === 0) && (i < maxIndex) ; i++) {
				var var1 = values1[i];
				if (var1 == null) {
					comp = -1;
				}
				var var2 = values2[i];
				if (var2 == null) {
					comp = 1;
				}
				if (comp === 0) {
					var1 = prepare(var1);
					var2 = prepare(var2);
					if (typeof var1.localeCompare == 'function')
						comp = (var1 == var2) ? 0 : var1.localeCompare(var2);
					else
						comp = (var1 == var2) ? 0 : (var1 > var2) ? 1 : -1;
				}
				if (comp !== 0) {
					comp *= (theGrid.ascSort ? 1 : -1);
				}
			}
			return comp;
		};
		
		this.mask = function() {
			var container = this.container || (typeof (this.getContainerControl) === "function" && this.getContainerControl());
			if (container.firstChild) {
				gx.dom.mask(container.firstChild);
			}
		};
		
		this.unmask = function() {
			var container = this.container || (typeof (this.getContainerControl) === "function" && this.getContainerControl());
			if (container.firstChild) {
				gx.dom.unmask(container.firstChild);
			}
		};
	};
})(gx.$);

gx.grid.column = function (title, type, width, align, valign) {
	this.table = null;
	this.index = -1;
	this.title = title || "";
	this.type = (typeof (type) != 'undefined') ? type : gx.types.character;
	this.width = width || "";
	this.align = align || 'left';
	this.valign = valign || 'middle';
	this.htmlName = null;
	this.visible = true;
	this.enabled = true;
	this.sortable = true;
	this.colspan = 1;
	this.rowspan = 1;
	this.gxId = -1;
	this.gxAttId = -1;
	this.gxAttName = "";
	this.gxWidthUnit = '';
	this.gxChecked = undefined;
	this.gxUnChecked = undefined;
	this.buffer = new gx.text.stringBuffer();
	this.isGxRemove = function () {
		if (this.gxAttName)
			return (this.gxAttName.indexOf("GxRemove") != -1) || (this.gxAttName.indexOf("nRcdDeleted") != -1);
		else
			return false;
	}
};

gx.grid.row = function (id, rowProps, rowId, parentRowId) {
	this.table = null;
	this.id = id;
	this.gxParentRowId = parentRowId || "";
	this.gxId = rowId + this.gxParentRowId;
	this.gxCmpContext = "";
	this.values = [];
	this.selected = false;
	this.gxLvl = 0;
	this.gxProps = rowProps.Props || [];
	this.gxRenderProps = rowProps.RenderProps || [];
	this.gxGrids = [];
	this.gxKeyValues = [];

	this.gxExists = function () {
		var rowExistCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nRcdExists_" + this.gxLvl + "_" + this.gxId);
		if (rowExistCtrlValue != null) {
			return (Number(rowExistCtrlValue) !== 0); //rowExistCtrlValue!=0
		}
		return false;
	}

	this.gxIsMod = function () {
		var rowIsModCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nIsMod_" + this.gxLvl + "_" + this.gxId);
		if (rowIsModCtrlValue != null) {
			return (Number(rowIsModCtrlValue) !== 0);//rowIsModCtrlValue!=0
		}
		return false;
	}

	this.gxDeleted = function () {
		var rowDeletedCtrlValue = gx.fn.getHidden(this.gxCmpContext + "nRcdDeleted_" + this.gxLvl + "_" + this.gxId);
		if (rowDeletedCtrlValue != null) {
			return (Number(rowDeletedCtrlValue) !== 0);//rowDeletedCtrlValue!=0
		}
		return false;
	}

	this.setDeleted = function (boolDel) {
		var intDel = (boolDel ? 1 : 0);
		gx.fn.setHidden(this.gxCmpContext + "nRcdDeleted_" + this.gxLvl + "_" + this.gxId, intDel);
	}
};
/* END OF FILE - ..\js\JavaScripTable.js - */
/* START OF FILE - ..\js\ResponsiveGrid.js - */
gx.grid.responsiveGrid = (function ($) {
	var SIZES = ["xs", "sm", "md", "lg"],
		ROW_CLASS = "row";

	return function (id) {
		var grid = new gx.grid.impl(id);

		grid.appendContainerStart = function (tableId, buffer) {
			buffer.append("<div ");
			this.appendGridClassAttribute(buffer);
			buffer.append(' id="' + tableId + '" ');
			if (!gx.lang.emptyObject(this.gxToolTipText)) {
				buffer.append('title="' + this.gxToolTipText + '" ');
			}

			buffer.append('style="');
			this.appendGridStyle(buffer);
			buffer.append('" ');
			this.appendGridAttributes(buffer);
			buffer.append(">");
		};
		
		grid.getRowByPos = function( nPos)
		{
			return this.container.querySelector((this.gxGridCols > 1 ? ' >DIV' : ' ') + '>DIV[data-gxrow]:nth-child(' + nPos + ')');
		}

		grid.scroll_last_row_selector = function() {
			return (this.gxGridCols > 1 ? ' >DIV' : ' ') + '>DIV[data-gxrow]:last';
		}

		grid.scroll_firt_row_selector = function() {
			return (this.gxGridCols > 1 ? ' >DIV' : ' ') + '>DIV[data-gxrow]:first';
		}
	
		grid.ROW_TAG = "div";
		grid.CELL_TAG = "div";
		grid.ROW_BASE_CLASS = "row";

		grid.getRowRenderingProps = function (even, rowDeleted) {
			var gxRowTag = this.ROW_TAG,
				baseRowClass = this.ROW_BASE_CLASS,
				gridResponsiveCols = this.gxGridResponsiveCols;
			if (this.gxIsFreestyle) {
				gxRowTag = this.CELL_TAG;
				baseRowClass = $.map(SIZES, function (size, i) {
					return ["col-", size, "-", (Math.floor(12 / (gridResponsiveCols[i] || 12)) || 1)].join("");
				}).join(" ");
			}

			var rowClass = baseRowClass;
			if (!this.gxIsFreestyle) {
				rowClass += " " + (even ? this.evenRowClass : this.oddRowClass) + (rowDeleted ? ' RowDeleted' : '');
			}

			return {
				cls: rowClass,
				tag: gxRowTag
			};
		};

		grid.appendGridClassAttribute = function (buffer) {
			buffer.append(" class=\"" + this.gxCssClass + "\"");
		};
		
		grid.appendGridAttributes = function (buffer) {
			if (this.gxAllowCollapsing) {
				if (this.gxCollapsed) {
					buffer.append(" data-gx-sr-only ");
				}
			}
		};

		grid.appendContainerEnd = grid.simpleAppendFn("</div>");

		grid.appendHeaderText = gx.emptyFn;

		grid.appendFooterText = gx.emptyFn;

		grid.appendHeader = gx.emptyFn;

		grid.appendBodyWrapperStart = gx.emptyFn;

		grid.appendBodyWrapperEnd = gx.emptyFn;

		grid.appendFooterWrapperStart = grid.simpleAppendFn("<div>");

		grid.appendFooterWrapperEnd = grid.simpleAppendFn("</div>");

		grid.appendRowStart = function (buffer, i, firstRow) {
			if (i == firstRow && this.ownerGrid.additiveResponse !== true) {
				buffer.append('<div class="' + ROW_CLASS + '">');
			}
		};

		grid.appendRowEnd = function (buffer, i, firstRow, lastRow) {
			if (i == lastRow && this.ownerGrid.additiveResponse !== true) {
				buffer.append('</div>');
			}
		};

		grid.appendRowBreaksWrapperStart = function (buffer, row) {
			buffer.append('<div>');
			this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);
		};

		grid.appendRowBreaksWrapperEnd = grid.simpleAppendFn("</div></div>");

		grid.appendRowPrefix = function (buffer, i, firstRow) {
			if (i == firstRow) {
				return;
			}

			var gridResponsiveCols = this.gxGridResponsiveCols;
			var useClearfix = false;
			var visibleSizes = $.map(SIZES, function (size, j) { 
				if ((gridResponsiveCols[j] != 1 && (i % gridResponsiveCols[j] === 0)) || (gridResponsiveCols[j] === 0 && (i % 12 === 0))) {
					useClearfix = true;
					return "visible-" + size;
				}
				else {
					return "";
				}
			}).join(" ");

			if (useClearfix) {
				buffer.append('<div class="clearfix ' + visibleSizes + '"></div>');
			}
		};

		grid.appendCellPrefixStart = function (buffer, i, firstRow, lastRow, row) {
			var rowDeletedClass = row.gxDeleted() ? " RowDeleted" : "";
			if (this.gxGridCols == 1) {
				buffer.append('<div id="' + this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId + '" data-gxrow="' + row.gxId.toString() + '" class="row' + rowDeletedClass + '"><div class="col-xs-12">');
				this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);
			}
		};

		grid.appendCellPrefixEnd = function (buffer) {
			if (this.gxGridCols == 1) {
				buffer.append('</div></div>');
			}
		};

		grid.appendNavBarRowStart = function (navColSpan, buffer) {
			buffer.append('<div class="' + this.ROW_BASE_CLASS + '"><div class="col-xs-12 ' + this.navigationClass + '">');
		};
		
		grid.appendNavBarRowEnd = function (buffer) {
			buffer.append('</div></div>');
		};


		return grid;
	};
})(gx.$);
/* END OF FILE - ..\js\ResponsiveGrid.js - */
/* START OF FILE - ..\js\FlexGrid.js - */
gx.grid.flexGrid = function ($) {
	var $container;

	var gxDom = gx.dom;

	this.useNativeChildControls = true;
	
	this.show = function () {
		var gridHtml;

		$container = $('#'+this.getContainerControl().id);

		gridHtml = this.drawGrid(this.gxGridObject + "Tbl", !this.IsPostBack);

		this.setGridHtml($container.get(0), gridHtml);

		if (this.gxWidth) {
			$container.width(gxDom.addUnits(this.gxWidth, this.gxWidthUnit));
		}

		if (this.gxHeight) {
			$container.height(gxDom.addUnits(this.gxHeight, this.gxHeightUnit));
		}
	};

	this.destroy = function () {
		if ($container) {
			$container.hide();
		}
	};
	
	// Overrides
	this.appendGridAttributes = function (buffer) {
		gx.grid.flexGrid.prototype.appendGridAttributes.apply(this, arguments);
		buffer.append(" data-gx-flex");
	};

	
	var flexPropertiesDefaults = {
		"flex-direction": "row",
		"flex-wrap": "no-wrap",
		"justify-content": "flex-start",
		"align-items": "flex-start",
		"align-content": "flex-start"
	};
	
	var appendNonDefaultStyleProperty = function (buffer, property, value) {
		if (flexPropertiesDefaults[property] !== value) {
			buffer.append(property + ": " + value + ";");
		}
	};
	
	this.appendGridStyle = function (buffer) {
		gx.grid.flexGrid.prototype.appendGridStyle.apply(this, arguments);
		appendNonDefaultStyleProperty(buffer, "flex-direction", this.FlexDirection);
		appendNonDefaultStyleProperty(buffer, "flex-wrap", this.FlexWrap);
		appendNonDefaultStyleProperty(buffer, "justify-content", this.JustifyContent);
		appendNonDefaultStyleProperty(buffer, "align-items", this.AlignItems);
		appendNonDefaultStyleProperty(buffer, "align-content", this.AlignContent);
	};

	this.getRowRenderingProps = function () {
		return {
			cls: "",
			tag: this.ROW_TAG
		};
	};

	this.appendRowStart = gx.emptyFn;

	this.appendRowEnd = gx.emptyFn;

	this.appendRowPrefix = gx.emptyFn;
	
	this.appendRowBreaksWrapperStart = function (buffer, row) {
		this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);
	};

	this.appendRowBreaksWrapperEnd = this.simpleAppendFn("</div>");

	this.appendCellPrefixStart = function (buffer, i, firstRow, lastRow, row) {
		if (this.gxGridCols == 1) {
			buffer.append('<div id="' + this.gxCmpContext + this.gxGridObject + "Row_" + row.gxId + '" data-gxrow="' + row.gxId.toString() + '">');
			this.appendDeleteImage(buffer, row, gx.grid.deletePositions.left);
		}
	};

	this.appendCellPrefixEnd = function (buffer) {
		if (this.gxGridCols == 1) {
			buffer.append('</div>');
		}
	};


	this.appendNavBarRowStart = function (navColSpan, buffer) {
		buffer.append('</div></div><div class="' + this.navigationClass + '">');
	};
	
	this.appendNavBarRowEnd = function (buffer) {
		buffer.append('</div>');
	};
	
	this.scroll_last_row_selector = function() {
		return ' > DIV[data-gxrow]:last';
	}

	this.scroll_firt_row_selector = function() {
		return ' > DIV[data-gxrow]:first';
	}
	
}
gx.lang.inherits(gx.grid.flexGrid, gx.grid.responsiveGrid);
/* END OF FILE - ..\js\FlexGrid.js - */
/* START OF FILE - ..\js\gxfrmutl.js - */
gx.GxObject = (function($) {
	var GX_EVENT_CONTROL_DATA_ATTR = "data-gx-evt-control",
	GX_EVENT_CONDITION_DATA_ATTR = "data-gx-evt-condition",
	GX_EVENT_DATA_ATTR = "data-gx-evt",
	GX_EVENT_CODE_DATA_ATTR = "data-gx-evt-code",
	GX_EVENT_CONTEXT_DATA_ATTR = "data-gx-context",
	GX_EVENT_CONTROL_DELAYED_ATTR = "data-gx-click-delay",
	GX_EVENT_EXCLUDED_CTRLTYPES = ['dyncombo', 'combo'],
	GX_EVENT_EVENT_IN_PROGRESS = "data-gx-evt-inprogress",
	GX_DATA_RAW_VALUE_ATTR = "data-gx-raw-value",
	WEBCOMPONENT_CLASS_NAME = 'gxwebcomponent',
	WEBCOMPONENT_LOADING_CLASS_NAME = 'gxwebcomponent-loading',
	WEBCOMPONENT_BODY_CLASS_NAME = 'gxwebcomponent-body';
	
	var gxObject = function () {
		this.onLoadDeferred = $.Deferred();
		this._isTrn = null;
		this.Gx_mode = "";
		this.ServerClass = "";
		this.ReadonlyForm = false;
		this.ObjectType = "web";
		this.MasterPage = null;
		this.IsMasterPage = false;
		this.IsComponent = false;
		this.AjaxSecurity = true;
		this.OnSessionTimeout = gx.timeoutActions.ignore;
		this.JustCreated = false;
		this.CmpContext = "";
		this.WebComponents = [];
		this.Grids = [];	
		this.GridsUpper = [];
		this.UserControls = {};
		this.GridUCsProps = {};
		this.GridUCsEvts = {};
		this.UCBindings = {};
		this.UCBindingsHiddens = {};
		this.GXValidFnc = [];
		this.GXLastCtrlId = 0;
		this.GXCtrlIds = [];
		this.MsgList = [];
		this.CmpControls = {};
		this.VarControlMap = {};
		this.FormBCs = {};
		this.GridBCs = {};
		this.LvlOlds = [];
		this.Events = {};
		this.EvtParms = {};
		this.InternalParms = {};
		this.hasEnterEvent = false;
		this.focusOnlyNEmb = false;
		this.autoRefresh = false;
		this.conditionsChanged = false;
		this.fromValid = 0;
		this.toValid = 0;
		this.getValidStructFld_cache = {};
		this.cmpRegex = gxObject.CONTROL_CMP_REGEX;
		this.rowPatternRegex = /_([0-9]{4})+$/;
		this.postEventPopupCommands = [];
		this.targetsCounter = 9996;
		this.feedbackTimeoutId = 0;
		this.feedbackCallCounter = 0;
		gx.lang.apply(this, new gx.util.Observable());
	};
	gxObject.GX_EVENT_CONTROL_DATA_ATTR = GX_EVENT_CONTROL_DATA_ATTR;
	gxObject.GX_EVENT_CONDITION_DATA_ATTR = GX_EVENT_CONDITION_DATA_ATTR;
	gxObject.GX_EVENT_DATA_ATTR = GX_EVENT_DATA_ATTR;
	gxObject.GX_EVENT_CODE_DATA_ATTR = GX_EVENT_CODE_DATA_ATTR;
	gxObject.GX_EVENT_CONTEXT_DATA_ATTR = GX_EVENT_CONTEXT_DATA_ATTR;
	gxObject.GX_EVENT_CONTROL_DELAYED_ATTR = GX_EVENT_CONTROL_DELAYED_ATTR;
	gxObject.GX_EVENT_EXCLUDED_CTRLTYPES = GX_EVENT_EXCLUDED_CTRLTYPES;
	gxObject.GX_EVENT_EVENT_IN_PROGRESS = GX_EVENT_EVENT_IN_PROGRESS;

	gxObject.WEBCOMPONENT_CLASS_NAME = WEBCOMPONENT_CLASS_NAME;
	gxObject.WEBCOMPONENT_LOADING_CLASS_NAME = WEBCOMPONENT_LOADING_CLASS_NAME;
	gxObject.WEBCOMPONENT_BODY_CLASS_NAME = WEBCOMPONENT_BODY_CLASS_NAME;
	gxObject.CONTROL_CMP_REGEX = /((?:(?:MP)?W[0-9]{4})*)((?:MP)?W[0-9]{4})([0-9]{4})?/;
	return gxObject;
})(gx.$);


gx.fn = (function($) {
	var CMP_CTRL_REGEX = /((?:(?:MP)?W[0-9a-zA-Z\-]{4}[\S]*)*)gxHTMLWrp((?:MP)?W[0-9]{4}[\S]*)*/;
	var CONTAINER_CLASS_SELECTOR = '.gx_usercontrol, .gxwebcomponent';

	var cleanComponentName = function (name) {
		name = name.replace(/\\/g, ".");
		if (gx.gen.isDotNet()) {
			return name.replace(/\.aspx$/, "");
		}
		return name;
	};

	var sortFormElements = (function () {
		var comparisonFn = function (a, b) {
			if (a.gxIndex < b.gxIndex) 
				return -1;
			if (a.gxIndex > b.gxIndex)
				return 1;
			return 0;
		};

		return function (elems) {
			return gx.fn.toArray(elems).sort(comparisonFn);
		};
	})();

	return {
		attachedControls: function () {
			return gx.attachedControls;
		},

		cancelWindow: function (Parms){
			this.closeWindow(Parms, { ignoreCmds: gx.config.popup.ignoreCmdsOnCancel});
		},

		closeWindow: function (Parms, opts, gxO) {
			opts = opts || {};
			gxO = gxO || gx.O;
			if (typeof (Parms) == 'string') {
				if (this.closeFromServer(Parms, opts.parmsMetadata)) {
					return;
				}
				Parms = [];
			}
			if (!Parms) {
				Parms = [];
			}
			if (gx.popup.ispopup()) {
				var popupObj = gx.popup.getPopup();
				var popupurl = popupObj.url ? gx.util.noParmsUrl(popupObj.url) : "";
				if (!popupObj.frameWindow || (popupObj.frameWindow.location.href.search(popupurl + "(\\?.*)?$") != -1) || gx.grid.drawAtServer) {					
					popupObj.close(Parms, opts, gxO);
					return;
				}
			}
			if (location.href.indexOf('gxCalledAsPopup') != -1) {
				this.closeWindowImpl();
				return;
			}
			var sCaller = gx.ajax.getCallerUrl(gx.popup.popuplvl());

			if (!gx.lang.emptyObject(sCaller)) {
				gx.ajax.windowClosed(-1);
				var url = gx.absoluteurl(sCaller);
				if (gx.spa.started) {
					gx.spa.redirect(url);
					gx.ajax.enableForm(gxO);
				}
				else {
					gx.evt.redirecting = true;
					location.href = url;
				}
			}
			else {
				this.closeWindowImpl();
			}
		},

		closeWindowImpl: function () {
			if (gx.util.browser.isIE()) {
				window.close();
			}
			else {
				if (history.length > 0)
					history.back();
				else
					window.location.assign("about:blank");
			}
		},

		closeFromServer: function (Parms, ParmsMetadata) {
			try {
				if (window.parent && window.parent.gx) {
					if (gx.popup.ispopup() && !(gx.grid.drawAtServer || window.parent.gx.grid.drawAtServer))
						gx.fn.closeWindow(gx.json.evalJSON(Parms, true), { parmsMetadata: gx.json.evalJSON(ParmsMetadata, true) });
					else
						window.parent.gx.fn.closeWindow(gx.json.evalJSON(Parms, true), { parmsMetadata: gx.json.evalJSON(ParmsMetadata, true) });
					return true;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'closeFromServer');
			}
			return false;
		},

		closeWindowServerScript: function (Parms, ParmsMetadata, cliNavSupported) {
			gx.evt.execLoad=false;
			if (cliNavSupported) {
				gx.evt.clinav = true;
				gx.ajax.pushReferer(gx.popup.popuplvl());
			}
			this.closeWindow(Parms, { parmsMetadata: ParmsMetadata });
		},
		
		invalidEmptyValue: function (Values) {
			if (gx.lang.emptyObject(Values.s)) {
				var len = Values.v.length;
				for (var i = 0; i < len; i++) {
					if (Values.v[i][0] === Values.s) {
						return false;
					}
				}
				return true;
			}
			return false;
		},

		trimSelectValue: function (Value, Type) {
			if (Type == 'int')
				return gx.text.trim(Value);
			else
				return gx.text.rtrim(Value);
		},

		selectedDescription: function (Values, Type) {
			var len = Values.v.length;
			for (var i = 0; i < len; i++) {
				if (this.trimSelectValue(Values.v[i][0], Type) === Values.s) {
					return Values.v[i][1];
				}
			}
			return null;
		},

		setGridCheckBoxValue: function (ControlId, sRow, Value, Checked) {
			this.setCheckBoxValue(ControlId + "_" + sRow, Value, Checked)
		},

		setGridDecimalValue: function (ControlId, sRow, Value, Dec, DecPoint) {
			return this.setGridControlValue(ControlId, sRow, Value);
		},

		setGridControlValue: function (ControlId, sRow, PValue, GXCtrlFormat) {
			if (sRow !== undefined)
				return this.setControlValue(ControlId + "_" + sRow, PValue, GXCtrlFormat);
		},

		setVarValues: function (VarIds, VarValues) {
			var len = VarIds.length;
			for (var i = 0; i < len; i++) {
				var validStruct = gx.fn.vStructForVar(VarIds[i]);
				if (validStruct && validStruct.v2v) {
					validStruct.v2v(VarValues[i]);
				}
				else {
					eval(VarIds[i] + '="' + VarValues[i] + '"');
				}
			}
		},
		refreshControlOldValue: function( Ctrl) {
			if ($(Ctrl).attr(gx.csv.GX_OLD_VALUE_ATTRIBUTE) !== undefined) {
				var CtrlValue = gx.fn.getControlValue(Ctrl.type == "radio" ? Ctrl.name : gx.dom.id(Ctrl));
				gx.fn.setControlOldValue(Ctrl, CtrlValue);
			}
		},
		setControlOldValue: function (Ctrl, Value) {
			if (Ctrl) {
				var ControlId = Ctrl.id;
				var vStruct = gx.O.getValidStructFld(ControlId);
				Value = gx.applyPicture(vStruct, Value, Ctrl);
				if (vStruct && vStruct.gxgrid) {					
					vStruct.gxgrid.IsValidState[ControlId] = vStruct.gxgrid.IsValidState[ControlId] || {};
					vStruct.gxgrid.IsValidState[ControlId][gx.csv.GX_OLD_VALUE_ATTRIBUTE] = Value;					
				}

				if (Ctrl.type == 'radio') {
					var radios = gx.dom.byName(Ctrl.name);
					var rLen = radios.length;
					for (var i = 0; i < rLen; i++) {
						radios[i].setAttribute(gx.csv.GX_OLD_VALUE_ATTRIBUTE, Value);
					}
				}
				else {					
					Ctrl.setAttribute(gx.csv.GX_OLD_VALUE_ATTRIBUTE, Value);
				}
			}
		},

		setControlGxValid: function (Ctrl, Value) {
			if (Ctrl && Ctrl.id) {
				var ControlId = Ctrl.id;
				var vStruct = gx.O.getValidStructFld(ControlId);
				if (vStruct && vStruct.gxgrid) {
					if (vStruct.gxgrid.IsValidState[ControlId])
						vStruct.gxgrid.IsValidState[ControlId].gxvalid = Value;
					else
						vStruct.gxgrid.IsValidState[ControlId] = { "gxvalid": Value };
				}
				Ctrl.setAttribute(gx.csv.GX_VALID_ATTRIBUTE, Value);
			}
		},

		setControlValue: function (ControlId, Value, GXCtrlFormat) {
			ControlId = gx.csv.ctxControlId(ControlId);
			this.setControlValueAny(ControlId, Value, GXCtrlFormat);
		},

		setControlValueAny: function (ControlId, Value, GXCtrlFormat) {
			var validStruct = gx.O.getValidStructFld(ControlId),
				Control, isPwd = false;
			Control = gx.dom.el(ControlId, (validStruct && (validStruct.ctrltype == "edit" || validStruct.ctrltype == 'checkbox' || validStruct.ctrltype == 'combo')));

			if (validStruct) {
				if ((validStruct.type == 'dtime' || validStruct.type == 'date')) {
					if (Value === '')
						Value = gx.date.nulldate_toc(validStruct.len, validStruct.dec);
					else {
						if (typeof (Value) == 'string')
							Value = new gx.date.gxdate(Value);
					}
				} else if (gx.lang.isFixedCharacterType(validStruct.type)) {
					Value = gx.text.rtrim(Value);
				}
			}
			if (Value instanceof gx.date.gxdate) {
				if (!gx.lang.emptyObject(validStruct))
					Value = gx.date.formatDateTime(validStruct.dec, validStruct.len, gx.dateFormat, Value);
			} else if (gx.lang.instanceOf(Value, Number) || (typeof (gx.num.dec) != "undefined" && Value instanceof gx.num.dec.bigDecimal)) {
				if (!gx.lang.emptyObject(validStruct)) {
					Value = gx.num.formatNumber(Value, validStruct.dec, gx.rtPicture(validStruct, Control), validStruct.len, validStruct.sign, false);
				}
			} else if (typeof (Value) == 'string' && !gx.lang.emptyObject(validStruct)) {
				isPwd = (validStruct.isPwd != undefined);
				if (isPwd) {
					if (Control != null && Control.nodeName == "SPAN")
						Value = gx.text.formatString(Value, validStruct.len, validStruct.isPwd);
				} else
				{
					Value = gx.text.formatString(Value, validStruct.len, validStruct.isPwd, gx.rtPicture(validStruct, Control));
				}
			}
			this.persistGridControlValue(ControlId, Value);
			var CtrlFormat = GXCtrlFormat || 0;
			if ((Control != null) && (Control.nodeName != "SPAN")) {
				this.setControlValue_impl(Control, Value, GXCtrlFormat);
				if (gx.csv.settingUIparms !== true) {
					gx.fn.setControlOldValue(Control, Value);
				}
			}
			else
				gx.fn.setHidden(ControlId, Value);
			var spanCtrl = ControlId;
			if ((Control != null) && (Control.nodeName == "SPAN")) {
				spanCtrl = Control;
			}
			var isMultiline = false;
			if (validStruct)
				isMultiline = validStruct.multiline;
			else
				isMultiline = ((Control != null) && (Control.tagName == 'TEXTAREA'));
			if (isPwd) {
				this.setControlValue_span_safe(spanCtrl, gx.text.formatString(Value, validStruct.len, validStruct.isPwd, gx.rtPicture(validStruct, Control), GXCtrlFormat, isMultiline));
			} else {
				this.setControlValue_span_safe(spanCtrl, Value, GXCtrlFormat, isMultiline);
			}
		},

		setDecimalValue: function (ControlId, Value, Dec, DecPoint) {
			this.setControlValue(ControlId, Value);
		},

		toDecimalValue: function (Value, ThSep, DecPoint) {
			return gx.num.parseFloat(Value, ThSep, DecPoint);
		},

		toDatetimeValue: function (Value, sFmt) {
			return new gx.date.gxdate(Value, sFmt);
		},

		setCheckBoxValue: function (ControlId, Value, Checked) {
			try {
				ControlId = gx.csv.ctxControlId(ControlId);
				var Control = gx.dom.byId(ControlId);
				if (!Control)
					Control = gx.dom.form()[ControlId];
				if (Control) {
					Control.checked = (Value.toString() == Checked.toString());
					Control.value = Value;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setCheckBoxValue');
			}
		},

		persistGridControlValue: function (ControlId, Value, vStruct) {
			var _Idx = ControlId.lastIndexOf("_");
			if (_Idx != -1) {
				var validStruct;
				if (vStruct)
					validStruct = vStruct;
				else
					validStruct = gx.O.getValidStructFld(ControlId.substring(0, _Idx));

				if (validStruct && validStruct.gxgrid) {
					var rowGxId = ControlId.substring(_Idx + 1);
					if (rowGxId.length > 4) {
						var pRow = rowGxId.substring(4, rowGxId.length);
						var grid = gx.O.getGrid(validStruct.gxgrid.gridName + '_' + pRow);
						if (grid)
							grid.persistControlValue(ControlId, Value, validStruct);
					}
					else {
						validStruct.gxgrid.persistControlValue(ControlId, Value, validStruct);
					}
				}
			}
		},

		setControlValue_span_safe: function (Control, Value, GXCtrlFormat, Multiline) {			
			if (typeof (Control) == 'string')
				Control = gx.dom.byId('span_' + Control);			
			if (Control && Control.nodeName !== "SPAN") {
				var controlId = "span_";
				if (typeof (Control) == 'string')
					controlId += Control;
				else
					controlId += gx.dom.id(Control);
				Control = gx.dom.byId(controlId);
			}
			if (Control == null)
				return;
			var Ctrls = gx.dom.bySelector('[data-name="' + Control.id + '"]');
			if (Ctrls.length < 2) {
				Ctrls = [Control];
			}
			$.each( Ctrls, function( i, Ctrl) {
				gx.fn.setControlValue_fmt(Ctrl, Value, GXCtrlFormat, Multiline);
			});			
		},

		setControlValue_fmt: function (Control, Value, GXCtrlFormat, Multiline) {
			try {
				if (Control != null) {
					if (GXCtrlFormat == 1) {
						var gxlink = Control.getAttribute('data-gxlink');
						if (!gx.lang.emptyObject(gxlink)) {
							//HTML textblock con evento asociado
							if (Control.firstChild != null && Control.firstChild.nodeName == 'A')
								Control = Control.firstChild;
						}
						gx.html.setInnerHtml(Control, Value, true);
					}
					else {
						if (GXCtrlFormat == 0 && typeof (Value) == 'string')
							Value = Value.replace(/ +/g, ' ');
						var ParentControl = Control;
						while (Control.firstChild != null && Control.firstChild.nodeName != '#text')
							Control = Control.firstChild;
						if (GXCtrlFormat == 0 && (Control.firstChild == null || Control.firstChild.nodeName != '#text') && Control.nodeName != 'A')
							gx.html.setInnerText(ParentControl, Value, GXCtrlFormat, Multiline);
						else
							gx.html.setInnerText(Control, Value, GXCtrlFormat, Multiline);
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setControlValue_fmt');
			}

		},

		setControlValue_impl: function (Control, Value, GXCtrlFormat) {
			var i, len, Ctrl;
			if (typeof (Control) == 'string') {
				Control = gx.dom.el(Control);
			}
			if (Value instanceof gx.date.gxdate) {
				Value = Value.getString();
			}
			if (Control != null) {
				var Ctrls = gx.dom.byName(Control.id);
				if (Ctrls.length < 2 || Control.type === 'radio') {
					Ctrls = [Control];
				}
				$.each( Ctrls, function( i, Ctrl) {
					if (Ctrl.type === 'radio') {
						gx.fn.setRadioValue(Ctrl.name, Value);
					}
					else 
					{
						if (gx.dom.isEditControl(Ctrl) || Ctrl.type == "textarea") {
							var restoreTextSelection = Ctrl.value !== Value && gx.dom.getActiveElement() === Ctrl && Ctrl.selectionStart !== Ctrl.selectionEnd && Ctrl.selectionEnd > 0;	
							Ctrl.value = Value;					
							if (restoreTextSelection)
								gx.fn.setSelection(Ctrl);						
						}
						else {
							if (Ctrl.value != undefined)
								Ctrl.value = Value;
							else {
								gx.fn.setControlValue_span_safe(Ctrl, Value, GXCtrlFormat);
							}
						}
					}
				});
			}
		},

		setGridComboBoxValue: function (ControlId, sRow, Value) {
			this.setComboBoxValue(ControlId + "_" + sRow, Value);
		},

		setComboBoxValue: function (ControlId, Value) {
			var isIE = gx.util.browser.isIE();
			ControlId = gx.csv.ctxControlId(ControlId);
			var Ctrl = gx.dom.byId(ControlId);
			if (!Ctrl)
				return;
			var sType = '';
			var vStruct = gx.O.getValidStructFld(ControlId);
			if (!gx.lang.emptyObject(vStruct))
				sType = vStruct.type;
			if (sType == 'int')
				Value = gx.text.trim(Value);
			else if (sType == 'date' && Value instanceof gx.date.gxdate)
				Value = Value.getStringWithFmt("Y4MD");
			else if (sType != 'decimal')
				Value = gx.text.rtrim(Value);
			var descText = Value;
			var selected = false;
			try {
				var len = Ctrl.options.length;
				var selectedopt;
				for (var i = 0; i < len; i++) {
					var opt = Ctrl.options[i];					
					var isSelected = gx.lang.isNumericType(sType) ? (Number(opt.value) == Number(Value)) : (gx.text.trim(opt.value) == gx.text.trim(Value));
					if (isSelected) {
						if (typeof (opt.innerText) != 'undefined')
							descText = opt.innerText;
						else
							descText = opt.text;
						Ctrl.selectedIndex = i;
						selected = true;
						opt.setAttribute('selected', 'selected');
						selectedopt = opt;
						if (isIE) {
							break;
						}
					}
					else if (!isIE) {
						opt.removeAttribute('selected');
					}
				}
				if (selectedopt && selectedopt.value != Ctrl.value && gx.util.browser.isFirefox()) {
					gx.dom.redrawControl(Ctrl);
				}
				if (!selected)
					Ctrl.selectedIndex = 0;
				if (vStruct.grid > 0)
					this.persistGridControlValue(ControlId, Value, vStruct);
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setComboBoxValue');
			}
			this.setControlValue_span_safe(ControlId, descText, 0);
		},

		loadRadioButton: function (control, values, selectedValue) {
			var $parent = $(control).parent().closest('.gx-radio-button'),
				$control = $(control),
				$newControl;

			$newControl = $(gx.html.controls.applyTemplate("radio", {
				id: control.name,
				className: $parent.attr("class"),
				style: $parent.attr("style"),
				title: control.title,
				isDisabled: control.disabled,
				gxoch0: $control.attr("data-gxoch0"),
				values: $.map(values, function (item, i) {
					return {
						itemId: control.name + "_" + i,
						itemValue: item[0],
						itemDesc: item[1],
						isSelected: (gx.text.trim(selectedValue.toString()) == gx.text.trim(item[0].toString()))
					};
				})
			}));
			
			$parent.replaceWith($newControl);
			gx.plugdesign.applyTemplateObject($newControl);
		},

		loadComboBox: function (ctrlId, values) {
			this.setComboValues(ctrlId, values);
		},

		setGridComboValues: function (ControlId, adata) {
			var ctrlGrid = this.controlGridId(ControlId);
			if (ctrlGrid == 0)
				this.setComboValues(ControlId, adata);
			else {
				for (var i = 1; i < 999; i++) {
					var currentRowStr = gx.text.padl(i.toString(), 4, '0');
					var Control = gx.dom.el(ControlId + "_" + currentRowStr);
					if (Control == null)
						break;
					this.setComboValues(Control.name, adata);
				}
			}
		},

		setComboValues: function (ControlId, adata) {
			var Ctrl = gx.dom.el(ControlId),
				browser = gx.util.browser;
			if (Ctrl == null)
				return;
			var currValue = '';
			if (Ctrl.selectedIndex != -1)
				currValue = Ctrl.options[Ctrl.selectedIndex].value;
			while (Ctrl.options.length > adata.length)
				Ctrl.remove(Ctrl.options.length - 1);
			while (adata.length > Ctrl.options.length) {
				var E = document.createElement("OPTION");
				Ctrl.options.add(E);
			}
			var len = adata.length;
			for (var i = 0; i < len; i++) {
				var E = Ctrl.options[i];
				E.value = adata[i][0];
				if (browser.isIE() && browser.ieVersion() >= 9) {
					if (E.innerText != adata[i][1])
						E.innerText = adata[i][1];
				}
				else {
					if (E.text != adata[i][1])
						E.text = adata[i][1];
				}
				if ( Number(E.value) ? (Number(E.value) == Number(currValue)) : gx.text.trim(E.value) == gx.text.trim(currValue))
					Ctrl.selectedIndex = i;
			}
			if (Ctrl.options.length == 0)
				Ctrl.selectedIndex = -1;
			else {
				if (Ctrl.selectedIndex == -1 || Ctrl.selectedIndex > Ctrl.options.length - 1) {
					Ctrl.options[0].selected = true;
				}
			}
		},

		getControlRefById: function (id) {
			var VStr = this.validStruct(id);
			if (VStr) {
				if (VStr.grid == 0)
					return this.getControlRef(VStr.fld, false);
				else
					return this.getControlGridRef(VStr.fld, VStr.grid);
			}
			return null;
		},

		getControlRef: function (ControlId, avoidPref) {
			//Critical function, changes here impact performance
			if (!avoidPref)
				ControlId = gx.csv.ctxControlId(ControlId);
			if (ControlId == 'FORM')
				return document;
			var Control = gx.dom.el(ControlId);
			if (Control != null)
				return Control;
			return null;
		},

		getControlRef_list: function (ControlId) {
			var ControlList = gx.dom.byName(ControlId);
			if (ControlList != null)
				return ControlList;
			var Control = gx.dom.byId(ControlId);
			if (Control != null)
				return [Control];
			return null;
		},

		screen_CtrlRef: function (ControlId) {
			var Control = this.getControlGridRef(ControlId, this.controlGridId(ControlId));
			if (!gx.lang.emptyObject(Control)) {
				if (Control.type == 'hidden')
					Control = gx.dom.byId("span_" + gx.dom.id(Control));
				return Control;
			}
			return null;
		},

		screen_CtrlId: function (ControlId) {
			return this.getControlGridId(ControlId, this.controlGridId(ControlId));
		},

		getControlGridId: function (ControlId, GridId, CurrentRow) {
			ControlId = gx.csv.ctxControlId(ControlId);
			var el = gx.dom.el(ControlId);
			if (el)
				return ControlId;
			try {
				if (GridId == 0)
					return ControlId;
				if (CurrentRow == undefined)
					CurrentRow = this.currentGridRow(GridId);
				return ControlId + "_" + CurrentRow;
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getControlGridId');
			}
		},

		getControlGridRef: function (ControlId, GridId, CurrentRow) {
			var el;
			ControlId = gx.csv.ctxControlId(ControlId);
			if (GridId == 0 || ControlId.search(gx.csv.CTRL_ROW_INDEX_REGEXP) !== -1) {
				el = gx.dom.el(ControlId);
				if (el)
					return el;
			}
			try {
				if (GridId == 0)
					return null;
				if (CurrentRow == undefined)
					CurrentRow = this.currentGridRow(GridId);
				el = gx.dom.el(ControlId + "_" + CurrentRow);
				if (el)
					return el;
				else {
					var cmpData = gx.O.getComponentData(ControlId);
					if (cmpData) {
						return gx.dom.el('gxHTMLWrp' + cmpData.Prefix + CurrentRow);
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getControlGridRef');
			}
		},

		setCurrentGridRowSafe: function (GridId, Row) {
			var gridObj = gx.fn.getGridObj(GridId, Row);
			if (gridObj && gridObj.grid.rows.length >= Row) {
				return gx.fn.setCurrentGridRow( GridId, Row);
			}	
			return undefined;
		},
		
		setCurrentGridRow: function (GridId, Row) {
			if (Row != '0000') {
				try {
					return gx.currentRows[GridId] = Row;
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setCurrentGridRow');
				}
			}
			return undefined;
		},

		currentGridRowImpl: function (GridId) {
			try {
				return gx.currentRows[GridId];
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'currentGridRowImpl');
			}
			return undefined;
		},

		currentGridRow: function (GridId) {
			var Ret = this.currentGridRowImpl(GridId);
			return (Ret == undefined) ? '0001' : Ret;
		},

		gridDuplicateKey: function (CtrlId) {
			var _GXValidStruct = gx.fn.validStruct(CtrlId);
			if (_GXValidStruct != undefined) {
				var gxgrid = _GXValidStruct.gxgrid;
				if (gxgrid != null) {
					gxgrid = gxgrid.updateControlValue(_GXValidStruct, true);
					if (gxgrid)
						return gxgrid.gxHasDuplicateKey();
				}
			}
			return false;
		},

		firstGridControl: function (GridId, gxO) {
			var ctrlIds = gx.fn.controlIds();
			var len = ctrlIds.length;
			for (i = 0; i < len; i++) {
				var _GXValidStruct = gx.fn.validStruct(ctrlIds[i], gxO);
				if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId)
					return ctrlIds[i];
			}
			return -1;
		},

		lastGridControl: function (GridId, gxO) {
			var ctrlIds = gx.fn.controlIds();
			for (i = ctrlIds.length - 1; i >= 0; i--) {
				var _GXValidStruct = gx.fn.validStruct(ctrlIds[i], gxO);
				if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId)
					return ctrlIds[i];
			}
			return -1;
		},
		
		getGridDateTimeValue: function (ControlId, sRow, ThSep, DecPoint) {
			var ctrlVal = this.getControlValue(ControlId + "_" + sRow);
			return new gx.date.gxdate(ctrlVal, gx.dateFormat);
		},

		getGridDecimalValue: function (ControlId, sRow, ThSep, DecPoint) {
			return this.getDecimalValue(ControlId + "_" + sRow, ThSep, DecPoint);
		},

		getGridIntegerValue: function (ControlId, sRow, ThSep) {
			return this.getIntegerValue(ControlId + "_" + sRow, ThSep);
		},

		getGridControlValue: function (ControlId, sRow) {
			return this.getControlValue(ControlId + "_" + sRow);
		},

		getControlValue: function (ControlId, mode, gxO, vStruct) {
			return this.getControlValue_impl(gx.csv.ctxControlId(ControlId, gxO), mode, gxO, vStruct);
		},

		getControlValue_impl: (function () {
			var IGNORED_CONTROLS_REGEX = /_CMPPGM$/g;

			var firstDefinedValue = function(val1, val2) {
				return (val1 != undefined)? val1: val2;
			};
			return function (ControlId, mode, gxO, vStruct) {
				if (mode == "hidden_only") {
					return gx.fn.getHidden(ControlId);
				}
				
				if (ControlId.search(IGNORED_CONTROLS_REGEX) >= 0) {
					return (mode === 'nohidden') ? null : gx.fn.getHidden(ControlId);
				}

				gxO = gxO || gx.O;
				var value;

				vStruct = vStruct || (gxO ? gxO.getValidStructFld(ControlId) : null);
				
				if (!vStruct || !vStruct.gxgrid || !vStruct.gxgrid.grid || !vStruct.gxgrid.grid.useHiddensForControlValues)
				{
					var Control;
					if (vStruct && (vStruct.ctrltype == "edit" || vStruct.ctrltype == 'checkbox' || vStruct.ctrltype == 'combo'))
						Control = gx.dom.byId(ControlId);
					else 
						Control = gx.dom.el(ControlId, false, true);

					if (Control != null && gxO) {
						if (vStruct && !Control.gxtype) {
							Control.gxtype = { type: vStruct.type, len: vStruct.len, dec: vStruct.dec };
						}
						if (Control.type == "checkbox" && vStruct.values && vStruct.values.length && vStruct.values.length > 1) {
							value = (Control.checked) ? vStruct.values[0] : vStruct.values[1];
						}
						else {
							if ((Control.type == "hidden") || (Control.type == "text") || (Control.type == "textarea") || (Control.type == "checkbox"))
								value = Control.value;
							else {
								if (Control.type == 'radio')
									value = gx.fn.getRadioValue(gx.dom.byName(ControlId));
								else {

									if (Control.nodeName == 'SELECT' && Control.options.length > 0) {
										if (Control.selectedIndex != -1)
											value = (mode == 'screen') ? Control.options[Control.selectedIndex].text : Control.options[Control.selectedIndex].value;
										else
											value = (mode == 'screen') ? Control.options[0].text : Control.options[0].value;
									}
									else {
										if (vStruct && (vStruct.type != 'date') && (vStruct.type != 'dtime') && (vStruct.type != 'bits') && (vStruct.type != 'audio') && (vStruct.type != 'video') && (vStruct.type != 'binaryfile'))
											value = Control.value;
									}
									if (Control.nodeName == 'IMG' || (Control.nodeName == 'INPUT' && Control.type == 'image'))
										value = Control.getAttribute('src');
								}
							}
						}
						if (value !== undefined)
							return (vStruct && vStruct.type == 'boolean') ? gx.lang.gxBoolean(value) : value
					}

					Control = gx.dom.byId("span_" + ControlId);
					if (Control != null) {
						var hidVal = gx.fn.getHidden(ControlId);
						var spanVal = gx.fn.getControlValue_span(Control);
						return (mode == 'screen')? firstDefinedValue(spanVal, hidVal): firstDefinedValue(hidVal, spanVal);
					}

					Control = gx.dom.form()[ControlId];
					if (Control != null)
						return this.getControlValueInt(Control);

					ControlList = gx.dom.byName(ControlId);
					if (ControlList != null) {
						var len = ControlList.length;
						for (var i = 0; i < len; i++) {
							Control = ControlList[i];
							if (Control != null)
								return this.getControlValueInt(Control);
						}
						Control = ControlList[0];
						if (Control)
							return Control.value;
					}
				}
				if (Control == null)
					return (mode === 'nohidden') ? null : gx.fn.getHidden(ControlId);
				return "";
			}
		})(),

		setRadioValue: function (ControlId, Value) {
			ControlId = gx.csv.ctxControlId(ControlId);
			var Control = gx.dom.byName(ControlId);
			if (Control == null)
				return;
			var len = Control.length;
			for (var i = 0; i < len; i++) {
				var jCtrl = $(Control[i]);
				if (gx.text.ltrim(Control[i].value) == gx.text.ltrim(Value)) {
					jCtrl.attr('checked', "");
					jCtrl.prop('checked', true);
					return;
				}
			}			
		},

		getRadioValue: function (Control) {
			var len = Control.length;
			for (var i = 0; i < len; i++) {
				if (Control[i].checked)
					return Control[i].value;
			}
			return '';
		},

		getRadioSelected: function (RadioCrlName) {
			var Control = gx.dom.byName(RadioCrlName);
			var len = Control.length;
			for (var i = 0; i < len; i++) {
				if (Control[i].checked)
					return Control[i];
			}
			return null;
		},
		
		getControlValueInt: function (Control) {
			if (Control.length != undefined && Control.tagName != "SELECT" && typeof (Control[0]) != 'undefined' && Control[0].type == 'radio')
				return this.getRadioValue(Control);
			if (Control.type == "checkbox")
				return Control.checked;
			if (Control.tagName == "SPAN") {
				var hidVal = gx.fn.getHidden(gx.dom.id(Control));
				if (hidVal != undefined)
					return hidVal;
				else
					return gx.fn.getControlValue_span(Control);
			}
			if (Control.tagName == "INPUT" && Control.type == "text") {
				var CtrlId = gx.dom.id(Control);
				if (gx.O) {
					var vStruct = gx.O.getValidStructFld(CtrlId);
					if (vStruct && typeof (gx.rtPicture(vStruct, Control)) != 'undefined') {
						if (vStruct.type == 'int')
							return this.getIntegerValue(CtrlId, gx.rtPicture(vStruct, Control).indexOf(',') != -1 ? gx.thousandSeparator : '');
						if (vStruct.type == 'decimal')
							return this.getDecimalValue(CtrlId, gx.rtPicture(vStruct, Control).indexOf(',') != -1 ? gx.thousandSeparator : '', gx.decimalPoint);
					}
				}
			}
			return Control.value;
		},

		getControlValue_span: function (Control) {
			while (Control && !Control.nodeValue) {
				Control = Control.childNodes[0];
			}
			if (Control && Control.nodeValue)
				return Control.nodeValue;
			return '';
		},
		
		getDateTimeArrayValue: function (ControlId) {
			try {
				var dt;
				var initDate = function(value, dtFormat) {
					if (!gx.lang.emptyObject(value)) {						
						$.each(value, function( i, dateStr) {
							value[i] = new gx.date.gxdate(dateStr, dtFormat);
						});						
					}
					return "";
				}
				
				var ctrlVal = this.getControlValue(ControlId, 'nohidden');
				dt = initDate(ctrlVal, gx.dateFormat);
				if (!dt) {
					ctrlVal = gx.fn.getHidden(gx.csv.ctxControlId(ControlId));
					dt = initDate(ctrlVal, "Y4MD");
				}
				return dt;
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getDateTimeArrayValue');
			}
			return "";
		},
		
		getDateValue: function (ControlId) {
			return this.getDateTimeValue(ControlId);
		},

		getDateTimeValue: function (ControlId) {
			try {
				var ctrlVal = this.getControlValue(ControlId, 'nohidden');
				if (!gx.lang.emptyObject(ctrlVal))
					return new gx.date.gxdate(ctrlVal, gx.dateFormat);
				ctrlVal = gx.fn.getHidden(gx.csv.ctxControlId(ControlId));
				return new gx.date.gxdate(ctrlVal, "Y4MD");
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getDateValue');
			}
			return "";
		},

		getIntegerValue: function (ControlId, ThSep, mode) {
			var nIntVal = 0;
			var validStruct = gx.O ? gx.O.getValidStructFld(ControlId) : null;
			var controlValue = this.getControlValue(ControlId, mode, undefined, validStruct);
			if (validStruct && controlValue)
				controlValue = gx.num.extractValue(gx.rtPicture(validStruct), controlValue);
			if ( gx.lang.isArray(controlValue))
				return controlValue;
			controlValue = (typeof(controlValue) != 'undefined') ? controlValue.toString() : '';

			if (controlValue.length === 0 && validStruct && validStruct.emptyAsNull === 'Blank') {
				return controlValue;
			}

			if (controlValue.length < gx.num.maxNumericPrecision() || typeof (gx.num.dec) == "undefined") {
				nIntVal = gx.num.parseInt(controlValue, 10, ThSep);
			}
			else {
				nIntVal = new gx.num.dec.bigDecimal(gx.text.replaceAll(controlValue, ThSep, '')).setScale(0, gx.num.dec.ROUND_UP).toString();
			}
			return isNaN(nIntVal) ? 0 : nIntVal;
		},

		getDecimalValue: function (ControlId, ThSep, DecPoint, mode) {
			var validStruct = gx.O ? gx.O.getValidStructFld(ControlId) : null;
			var ctrlValue = this.getControlValue(ControlId, mode, undefined, validStruct);
			var Control = gx.dom.el(ControlId, (validStruct && (validStruct.ctrltype == "edit" || validStruct.ctrltype == 'checkbox' || validStruct.ctrltype == 'combo')));
			if (validStruct && ctrlValue)
				ctrlValue = gx.num.extractValue(gx.rtPicture(validStruct, Control), ctrlValue);

			if (typeof(ctrlValue) !== 'undefined' && ctrlValue.length === 0 && validStruct && validStruct.emptyAsNull === 'Blank') {
				return '';
			}
			
			if ( gx.lang.isArray(ctrlValue))
				return ctrlValue;
			var nDecVal = gx.num.parseFloat(ctrlValue || "", ThSep, DecPoint);
			return isNaN(nDecVal) ? 0 : nDecVal;
		},

		getBlobValue: function (ControlId) {
			var blobCtrl = gx.dom.byId("Object_" + ControlId);
			if (blobCtrl != null) {
			    if (blobCtrl.data && !gx.text.endsWith(blobCtrl.data, 'about:blank'))
					return blobCtrl.data;
			}
			else {
				blobCtrl = gx.dom.byId("Link_" + ControlId);
				if (blobCtrl != null)
					return blobCtrl.getAttribute('href');
			}
			return "";
		},

		getVarControlMap: function (gxO, ctrlName) {
			var gxO = gxO || gx.O;
			if (gxO) {
				for (var varName in gxO.VarControlMap) {
					if (typeof (varName) != 'function') {
						var mapping = gxO.VarControlMap[varName];
						if (mapping.id == ctrlName || (gxO.CmpContext + mapping.id) == ctrlName)
							return varName;
					}
				}
			}
			return null;
		},

		getVarControlMapForVar: function (varName) {
			for (var objVar in gx.O.VarControlMap) {
				if (typeof (objVar) == 'string' && objVar == varName) {
					return gx.O.VarControlMap[objVar];
				}
			}
			return null;
		},

		v2c: function (vStruct, value, resetControl, row) {
			vStruct.v2c(row);
			if (typeof(value) === 'undefined') {
				value = vStruct.val(row);
			}
			var ctrl = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid, row);
			gx.plugdesign.controlValueChanged(ctrl, value);
			if (resetControl) {
				ctrl.value = "";
			}
		},

		v2cMap: function (VarName) {
			var mapping = this.getVarControlMapForVar(VarName);
			if (mapping != null) {
				var mapSuffix = '';
				if (typeof (mapping.grid) == 'number' && mapping.grid != 0) {
					mapSuffix = '_' + gx.fn.currentGridRowImpl(mapping.grid);
				}
				gx.fn.setHidden(gx.O.CmpContext + mapping.id + mapSuffix, gx.O[VarName]);
			}
		},

		c2vMap: function (VarName) {
			var mapping = this.getVarControlMapForVar(VarName);
			if (mapping != null) {
				var mapSuffix = '';
				if (typeof (mapping.grid) == 'number' && mapping.grid != 0) {
					mapSuffix = '_' + gx.fn.currentGridRowImpl(mapping.grid);
				}
				gx.O[VarName] = gx.fn.getHidden(gx.O.CmpContext + mapping.id + mapSuffix);
			}
		},

		depsToVars: function (Deps) {
			for (var i = 0; i < Deps.length; i++) {
				var varName = Deps[i];
				var validStruct = gx.fn.vStructForVar(varName);
				if (!gx.lang.emptyObject(validStruct) && typeof (validStruct.c2v) == 'function')
					validStruct.c2v();
				else
					this.c2vMap(varName);
			}
		},

		verticalFormula: function (VarName, Default, GridId, Row, CondsFunc, RowFunc, Deps) {
			var validStruct = gx.fn.vStructForVar(VarName);
			if (!gx.lang.emptyObject(validStruct))
				validStruct.v2c(Row);
			else
				this.v2cMap(VarName);
			var oldRow = gx.fn.currentGridRowImpl(GridId);
			var gridObj = gx.fn.getGridObj(GridId, Row);
			var retVal = 0;
			var anyWithCond = false;
			if (gridObj) {
				var len = gridObj.grid.rows.length;
				for (var i = 0; i < len; i++) {
					var rowObj = gridObj.grid.rows[i];
					var IsRemoved = rowObj.gxDeleted();
					var RecordExists = rowObj.gxExists();
					var RecordIsMod = rowObj.gxIsMod();
					if (!IsRemoved && (RecordExists || RecordIsMod)) {
						gx.fn.setCurrentGridRow(GridId, rowObj.gxId);
						if (Deps && Deps.length > 0)
							this.depsToVars(Deps);
						else if (!gx.lang.emptyObject(validStruct) && typeof (validStruct.c2v) == 'function')
							validStruct.c2v();
						else
							this.c2vMap(VarName);
						if (CondsFunc.call(gx.O)) {
							anyWithCond = true;
							retVal = RowFunc(i, retVal);
						}
					}
				}
				gx.fn.setCurrentGridRow(GridId, oldRow);
				if (Deps && Deps.length > 0)
					this.depsToVars(Deps);
				else if (!gx.lang.emptyObject(validStruct) && typeof (validStruct.c2v) == 'function')
					validStruct.c2v(Row);
				else
					this.c2vMap(VarName);
				if (!anyWithCond)
					retVal = Default;
			}
			else {
				gx.dbg.write('verticalFormula: can´t find grid ' + GridId + ' at row ' + Row);
			}
			return retVal;
		},

		rowValueHandler: function(VarName, Row, LastValue, BooleanHandler, FloatHandler, ThSep, DecPoint) 
		{
			try {
				var structMap = gx.fn.vStructForVar(VarName) || gx.fn.getVarControlMapForVar(VarName);
				var type = (structMap) ? structMap.type: 'decimal';				
				switch(type) {
					case 'boolean':			
						return BooleanHandler(VarName, Row, LastValue);
						break;
					case 'int':	
					case 'decimal':
						var v = gx.num.parseFloat(gx.O[VarName], ThSep, DecPoint);
						if (Row == 0)
							return v;
						else
							return FloatHandler(VarName, Row, LastValue, v);						
						break;				
					default:
						gx.dbg.write("Warning: Forumula not supported for: ", VarName, type);
						break;
				}
			}			
			catch (e)
			{
				gx.dbg.logEx(e, 'gxfrmutl.js', 'Formula could not be calculated for Field: ' + VarName);
			}
		},
		
		maxFrm: function(VarName, Default, ThSep, DecPoint, GridId, Row, CondsFunc, Deps)
	    {
			var boolHandler = function (VarName, Row, LastValue) {
				return LastValue || gx.O[VarName];
			}
			var floatHandler = function (VarName, Row, LastValue, NewValue) {
				return (NewValue > LastValue) ? NewValue : LastValue;
			}
	        return gx.fn.verticalFormula(VarName, Default, GridId, Row, CondsFunc, function(row, val)
	        {				
				return gx.fn.rowValueHandler(VarName, row, val,boolHandler, floatHandler, ThSep, DecPoint);				
	        }, Deps);
	    },
		
		sumFrm: function(VarName, Default, ThSep, DecPoint, GridId, Row, CondsFunc, Deps)
	    {
			var boolHandler = function (VarName, Row, LastValue) {
				return LastValue || gx.O[VarName];
			}
			var floatHandler = function (VarName, Row, LastValue, NewValue) {
				return NewValue + LastValue;
			}
	        return gx.fn.verticalFormula(VarName, Default, GridId, Row, CondsFunc, function(row, val)
	        {
				return gx.fn.rowValueHandler(VarName, row, val,boolHandler, floatHandler, ThSep, DecPoint);							           
	        }, Deps);
	    },
	   
	    minFrm: function(VarName, Default, ThSep, DecPoint, GridId, Row, CondsFunc, Deps)
	    {
			var boolHandler = function (VarName, Row, LastValue) {
				return LastValue && gx.O[VarName];
			}
			var floatHandler = function (VarName, Row, LastValue, NewValue) {
				return (NewValue < LastValue) ? NewValue : LastValue;
			}
	        return gx.fn.verticalFormula(VarName, Default, GridId, Row, CondsFunc, function(row, val)
	        {
				return gx.fn.rowValueHandler(VarName, row, val,boolHandler, floatHandler, ThSep, DecPoint);			    
	        }, Deps);
	    },

	    averageFrm: function(VarName, Default, ThSep, DecPoint, GridId, Row, CondsFunc, Deps)
	    {
	        return gx.fn.verticalFormula(VarName, Default, GridId, Row, CondsFunc, function(row, val)
	        {
	            var v = gx.num.parseFloat(gx.O[VarName], ThSep, DecPoint);
	            if (row == 0) return v;
	            else return ((val * row) + v) / (row + 1);
	        }, Deps);
	    },

	    countFrm: function(VarName, Default, GridId, Row, CondsFunc, Deps)
	    {
	        return gx.fn.verticalFormula(VarName, Default, GridId, Row, CondsFunc, function(row, val)
	        {	            
	            return (row == 0)? 1: val + 1;
	        }, Deps);
	    },

		serialRule: function (LastCountAtt, CountAtt, GridId, Inc, scope) {
			scope = scope || gx.O;			
			var rowMode = gx.fn.getGridRowMode(gx.fn.gridLvl(GridId), GridId)
			var count, lastCount;
			if (rowMode != 'INS') {
				return scope[LastCountAtt];
			}
			else {			
				if (gx.lang.emptyObject(scope[CountAtt]) ) {
					scope[CountAtt] = scope[LastCountAtt] + Inc;

					var validStruct = gx.fn.vStructForVar(CountAtt);
					if (validStruct)
						validStruct.v2c();

					var vMap = scope.VarControlMap[LastCountAtt];
					if (vMap)
						gx.fn.setControlValue(vMap.id, scope[CountAtt]);
				}
			}
			count = scope[CountAtt] || 0;
			lastCount = scope[LastCountAtt] || 0;
			if (Inc > 0)
				return Math.max(count, lastCount);
			else 
				return Math.min(count, lastCount);
		},

		setReturnParms: function (gxObj, objVars, returnParms, customRenderGrid) {
			try {
				gx.csv.settingUIparms = true;
				var i, len, vStruct, grid;
				if (customRenderGrid) {
					len = returnParms.length;
					for (i = 0; i < len; i++) {
						vStruct = gx.fn.vStructForVar(objVars[i]);
						customRenderGrid.grid.setCellValue.apply(customRenderGrid.grid, [vStruct, returnParms[i]]);
					}
				}
				else {
					if (gxObj && objVars && returnParms) {
						len = objVars.length;
						if (len == returnParms.length) {
							gx.setGxO(gxObj);
							var lastCtrl = null;
							for (i = 0; i < len; i++) {
								var varName = objVars[i];
								if (varName) {
									var varValue = returnParms[i];
									vStruct = gx.fn.vStructForVar(varName);
									if (gx.lang.emptyObject(vStruct)) {
										vStruct = gx.fn.vStructForHC(varName);
									}
									if (vStruct) {
										var ctrl = gx.fn.screen_CtrlRef(gx.csv.ctxControlId(vStruct.fld));
										if (vStruct.v2v) {
											vStruct.v2v(varValue);
											gx.fn.v2c(vStruct, varValue);										
										}
										if (typeof (vStruct.v2bc) === 'function')
											vStruct.v2bc.call(gxObj);
										if (gx.fn.isAccepted(ctrl)) {
											lastCtrl = ctrl;
											gx.evt.onchange_impl(ctrl);
										}
										gxObj.refreshDependantGrids(vStruct);
									}
									else {
										gxObj.setVariable(varName, varValue);
									}
								}
							}
							if (lastCtrl) {
								gx.fn.setFocus(lastCtrl);
							}
						}
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setReturnParms');
			}
			gx.csv.settingUIparms = false;
		},

		isOutputParm: function (parm) {
			if (parm && parm.IOType && (parm.IOType == 'out' || parm.IOType == 'inout')) {
				return true;
			}
			return false;
		},

		checkPopupFocus: function (Ctrl) {
			if (gx.popup.ispopup()) {
				var popup = gx.popup.getPopup();
				if (popup && popup.frameDocument) {
					var ctrlDoc = (Ctrl.ownerDocument ? Ctrl.ownerDocument : Ctrl.document);
					if (ctrlDoc.URL != popup.frameWindow.location.href) {
						popup.setFocusFirst();
						return false;
					}
				}
			}
			return true;
		},

		persistControlProperty: function (ControlId, Property, PValue) {
			var Id = gx.fn.screen_CtrlId(gx.csv.ctxControlId(ControlId));
			if (!gx.usrPtys[Id])
				gx.usrPtys[Id] = {};
			gx.usrPtys[Id][Property.toLowerCase()] = PValue;
		},

		setCtrlProperty: function (ControlId, Property, PValue) {
			if (!gx.O) {
				gx.fx.obs.addObserver('gx.onready', this, gx.fn.setCtrlProperty.closure(this, arguments), { single: true });
				return;
			}
			var Control = null;
			if (ControlId == 'FORM')
				Control = document;
			else
				Control = gx.fn.screen_CtrlRef(gx.csv.ctxControlId(ControlId));
			if (Control == null)
				return;
			this.persistControlProperty(ControlId, Property, PValue);
					var vStruct = gx.O.getValidStructFld(ControlId);
			this.setCtrlPropertyImpl(Control, Property, PValue, vStruct);
		},

		setGridCtrlProperty: function (ControlId, Property, PValue) {
			var Control = gx.fn.screen_CtrlRef(ControlId);
			if (Control == null)
				return;
			this.setCtrlPropertyImpl(Control, Property, PValue);
			var gridId = gx.fn.controlGridId(ControlId)
			if (gridId) {
				var Cell = $(Control)
								.parent()
								.closest("TD", $("[data-gxgridid=" + gridId + "]").get(0))
								.get(0);
				if (!Cell)
					return;
				this.persistControlProperty(ControlId, Property, PValue);
				this.setCtrlPropertyImpl(Cell, Property, PValue);
			}
		},

		getControls: function (Control) {
			var controls = [Control];
			var roNode = this.getRONode(Control.id, false);
			if (roNode)
				controls.push(roNode);
			return $(controls);
		},
		
		setCtrlPropertyImpl: function (Control, Property, PValue, vStruct) {
			if (Control == null)
				return;
			if (Control == document) {
				if (Property == 'Backcolor') {
					Control = document.body;
					this.setCtrlPropertyImpl(gx.dom.form(), Property, PValue);
				}
			}
			vStruct = vStruct || gx.O.getValidStructFld(Control.id);
			if ((Property === "Enabled" || Property === "Visible") && vStruct && vStruct.grid > 0 && gx.fn.rowIsRemoved(vStruct.grid, gx.fn.controlRowId(Control)))
				return;
			var gxCtrlType = (vStruct)? vStruct.ctrltype: null;
			var eventControl = Control;
			var onBeforeEventObject = {
				control: eventControl,
				property: Property,
				value: PValue
			};
			gx.fx.obs.notify("gx.control.onbeforepropertychange", [onBeforeEventObject]);
			if (onBeforeEventObject.cancel) {
				return;
			}

			var $controls, 
				$relatedControls = $();
			switch (Property) {
				case "Picture":
					Control.setAttribute('data-gx-rt-picture', PValue);
					if (vStruct) {
						vStruct.v2c();
						vStruct.c2v();
					}
					break;
				case "Caption":
					this.setCtrlCaption(Control, PValue);
					break;
				case "Tooltiptext":
					Control.title = PValue;
					break;
				case "Invitemessage":
					Control.placeholder = PValue;
					break;
				case "Visible":
					if (Control.nodeName == 'INPUT' && Control.type == 'button') {
						this.setButtonVisibility(Control, !this.propertyValueFalse(PValue));
					}
					else {
						var isCheckbox = Control.type === 'checkbox';
						if (Control.nodeName == 'INPUT') {
							if (isCheckbox && $(Control).parent().is('span:not(.gx-checkbox-wrapper)')) { //Checkbox is always wrapped inside SPAN element. gx-checkbox-wrapper is handled by Templates.
								$relatedControls = $(Control).parent();
							}
							else if (Control.type == 'radio') {
								var $parent = $(Control).parent().closest('.gx-radio-button');
								if ($parent.length > 0) {
									Control = $parent[0];
								}
							}
							var multimediaControl = gx.html.multimediaUpload.getContainer(Control);
							if (multimediaControl) {
								Control = multimediaControl;
							}
						}
						var pValueFalse = this.propertyValueFalse(PValue);
						var disabled = (Control.gxusrdisabled && !isCheckbox) ? Control.gxusrdisabled : false;
						if (pValueFalse) {
							var spanVal = gx.dom.byId('span_' + Control.id);
							this.setVisible(Control, !pValueFalse);
							if (spanVal)
								this.setVisible(spanVal, !pValueFalse);
						}
						else {
							
							var spanVal = this.getRONode(Control.id, disabled);
							if (spanVal)
								this.setVisible(spanVal, disabled);
							this.setVisible(Control, !disabled);
						}
						for (var i = 0; i < $relatedControls.length; i++) {
							this.setVisible($relatedControls[i], !disabled);
						}
						gx.fn.setDateCtrlProperties(Control, !disabled, !pValueFalse );
					}
					gx.fn.checkAttachedProperty(Control.id, Property, gx.lang.gxBoolean(PValue));
					break;
				case "Enabled":
					var pValueFalse = this.propertyValueFalse(PValue);
					if (Control.type === "hidden")
						return;
					if (gxCtrlType === 'textblock') {
						$(Control).toggleClass("gx-disabled", pValueFalse);
					}
					if ((Control.tagName === "SPAN" || Control.tagName === "DIV" && Control.getAttribute('data-gxformat') === '1') && pValueFalse)
						return;
					if (Control.nodeName === 'INPUT' && Control.type === 'radio') {
						var allRadios = gx.dom.byName(Control.name);
						var len = allRadios.length;
						for (var i = 0; i < len; i++) {
							this.setEnabledProperty(allRadios[i], !pValueFalse);
						}						
					} else {
						if ((gx.dom.isEditControl(Control) || Control.type === "textarea" || Control.type === "file" || Control.tagName === "SELECT") && Control.type !== "password") {
							var spanVal = this.getRONode(Control.id, pValueFalse);
							if (gx.fn.isVisible(Control, 0) || (spanVal && gx.fn.isVisible(spanVal, 0))) {
								if (spanVal) this.setVisible(spanVal, pValueFalse);
								this.setEnabledProperty(Control, !pValueFalse);//1.SetEnabled. Debe ejecutarse antes de la setVisible(Control, !pValueFalse), caso textarea multiline que pasa a disabled en el cliente.
								this.setVisible(Control, !pValueFalse);//2.SetVisible
								gx.fn.setDateCtrlProperties(Control, !pValueFalse, true);
								gx.fn.checkAttachedProperty(Control.id, Property, !pValueFalse);//1.SetEnabled
								gx.fn.checkAttachedProperty(Control.id, "Visible", !pValueFalse);//2.SetVisible
							}
							else {
								this.setEnabledProperty(Control, !pValueFalse);
								gx.fn.setDateCtrlProperties(Control, !pValueFalse, false);
								gx.fn.checkAttachedProperty(Control.id, Property, !pValueFalse);
							}
						} else
							this.setEnabledProperty(Control, !pValueFalse);
					}
					break;
				case "Class":
					if (Control == document) {
						var $form = $(gx.dom.form()),
							$body = $(document.body),
							currentGxClass = $form.attr('data-gx-class') || "";

						$body
							.removeClass(currentGxClass)
							.attr('class', PValue + ' ' + $body.attr('class'));
						$form
							.removeClass(currentGxClass)
							.attr({
								'class': PValue + ' ' + $form.attr('class'),
								'data-gx-class': PValue
							});
					}
					else {
						$controls = this.getControls(Control);
						$controls.attr('class', PValue);
						if (PValue.indexOf('Readonly') <= 0 ) {
							//For compatibility reasons, we keep adding Main base class.
							$(this.getRONode(Control.id, false)).attr('class', PValue + ' Readonly' + PValue);
						}
					}
					break;
				case "Columnclass":
					var parentNode = Control.parentNode;
					if (parentNode && parentNode.tagName == "TD") {
						this.setCtrlClass(parentNode, "gx-attribute " + PValue);
					}
					break;
				case "Columnheaderclass":
					var parentNode = Control.parentNode;
					var headerNode;
					if (parentNode && parentNode.tagName == "TD") {
						headerNode = $(parentNode)
										.closest("table")
										.find("th:nth-child(" + (parentNode.cellIndex + 1) + ")")
										.get(0);
						if (headerNode) {
							this.setCtrlClass(headerNode, PValue);
						}
					}
					break;
				case "Link":
					this.setCtrlLink(this.getRONode(Control.id, false) || Control, PValue);
					break;
				case "Linktarget":
					this.setCtrlLinkTarget(this.getRONode(Control.id, false) || Control, PValue);
					break;
				case "Backcolor":
					var htmlColor = gx.color.html(PValue);
					if (htmlColor && Control.gxGridName == undefined) {
						$controls = this.getControls(Control);
						$controls.css('background-color', htmlColor.Html);
					}
					break;
				case "Background":
					$controls = this.getControls(Control);
					$controls.css("background-image", 'url('+PValue+')');						
					break;
				case "Forecolor":									
					var htmlColor = gx.color.html(PValue);
					if (htmlColor) {
						$controls = this.getControls(Control);
						$controls.css("color", htmlColor.Html);						
					}
					break;
				case "Fontbold":
					var pValueFalse = this.propertyValueFalse(PValue);
					$controls = this.getControls(Control);
					$controls.css("fontWeight", (pValueFalse ? 'normal' : 'bold'));								
					break;
				case "Fontitalic":
					var pValueFalse = this.propertyValueFalse(PValue);						
					$controls = this.getControls(Control);
					$controls.css("fontStyle", (pValueFalse ? 'normal' : 'italic'));													
					break;
				case "Fontunderline":
					var pValueFalse = this.propertyValueFalse(PValue);
					$controls = this.getControls(Control);
					$controls.css("textDecoration", (pValueFalse ? 'none' : 'underline'));					
					break;
				case "Fontstrikethru":
					var pValueFalse = this.propertyValueFalse(PValue);
					$controls = this.getControls(Control);
					$controls.css("textDecoration", (pValueFalse ? 'none' : 'line-through'));						
					break;
				case "Fontname":
					$controls = this.getControls(Control);
					$controls.css("fontFamily", PValue);					
					break;
				case "Fontsize":
					$controls = this.getControls(Control);
					$controls.css("fontSize", PValue + 'pt');					
					break;
				case "Filename":
					this.setBlobFilename(Control, PValue);
					break;
				case "Filetype":
					this.setBlobFiletype(Control, PValue);
					break;
				case "URL":
					this.setBlobUrl(Control, PValue);
					break;
				case "IsBlob":
					this.setMultimediaType(Control, PValue);
					break;
				case "Bitmap":
					Control.src = PValue;
					break;
				case "SrcSet":
					if (PValue !== undefined) {
						Control.srcset = PValue;
					}
					break;
				case "Multimedia":
					this.setMultimediaValue(Control.id, PValue);
					break;
				case "Jsonclick":
					Control.jsevent = PValue;
					break;
				case "Source":
					var testValue = PValue;
					var qIdx = testValue.indexOf('?');
					if (qIdx > 0)
						testValue = testValue.substring(0, qIdx);
					if (testValue.indexOf(':') == -1 && testValue.indexOf('/') == -1)
						Control.src = gx.ajax.objectUrl(PValue);
					else
						Control.src = gx.util.resourceUrl(PValue, true);
					gx.evt.attach(Control, "load", gx.dom.autofitIFrame);
					break;
				case "Values":
					if ((Control.tagName == 'SELECT') || gx.dom.isRadio(Control) || (Control.tagName == 'SPAN')) {
						PValue = gx.json.evalJSON(PValue);
						if (Control.tagName == 'SELECT') {
							if (PValue.isset != false) {
								gx.fn.loadComboBox(Control.id, PValue.v);
								gx.fn.setComboBoxValue(Control.id, PValue.s);
							}
						}
						else if (gx.dom.isRadio(Control)) {
							if (PValue.isset != false) {
								gx.fn.loadRadioButton(Control, PValue.v, PValue.s);
							}
						}
						else {
							var ControlId = Control.id.substring(5);
							var sType = '';
							var Value = PValue.s;
							var vStruct = gx.O.getValidStructFld(ControlId);
							if (!gx.lang.emptyObject(vStruct))
								sType = vStruct.type;
							Value = gx.fn.trimSelectValue(Value, sType);
							PValue.s = Value;
							gx.fn.setControlValue_span_safe(ControlId, gx.fn.selectedDescription(PValue, sType));
						}
					}
					break;
				case "Width":
					if (Control.width)
						Control.width = PValue;
					Control.style.width = gx.dom.addUnits(PValue);
					break;
				case "Height":
					if (Control.height)
						Control.height = PValue;
					Control.style.height = gx.dom.addUnits(PValue);
					break;
				case "Ispassword": 
					Control.type = gx.lang.gxBoolean(PValue) ? "password" : "text";
					break;
			}
			var ctrlId = gx.dom.id(Control);
			if (ctrlId) {
				var vStruct = gx.O.getValidStructFld(ctrlId);
				var propHidden = ctrlId + ((vStruct && vStruct.grid && vStruct.grid > 0) ? '' : '_') + Property;
				if (gx.fn.createPtyCondition(Property) || gx.fn.isHidden(propHidden)) {
					PValue = (PValue==true?"1":(PValue==false?"0":PValue));
					gx.fn.setHidden(propHidden, PValue);
				}
			}

			gx.fx.obs.notify("gx.control.onafterpropertychange", [{
				control: eventControl,
				property: Property,
				value: PValue
			}]);
		},
		
		createPtyCondition:function( Property) {
			return ((Property == "Visible" || Property == "Enabled") && gx.O.isTransaction());
		},

		setEnabledProperty: function (Control, Enabled, updateDOM) {
			var ctrlId = gx.dom.id(Control),
				bEnabled = gx.lang.gxBoolean(Enabled);
				
			if (!bEnabled)
				gx.util.addOnce(gx.disabledControls, Control, ctrlId);
			else 
			{
				delete gx.disabledControls[ctrlId];
				if (gx.fn.isAccepted(Control, false))
					return;
			}			
			if (gx.csv.validating == true) {
				if (Enabled && gx.csv.validActivatedControl == null && Control != gx.csv.lastControl) {
					var vStructId = gx.O.getValidStructId(ctrlId);
					if (vStructId > gx.O.fromValid && vStructId <= gx.O.toValid) {
						gx.csv.validActivatedControl = Control;
					}
				}
			}			
			Control.gxusrdisabled = (!Enabled);
			if (Control.gxdisabled) {
				if (Control.gxdisabled == true)
					Control.disabled = true;
				else
					Control.disabled = Control.gxusrdisabled;
			}
			else
				Control.disabled = Control.gxusrdisabled;
			if (updateDOM === undefined || updateDOM) {
				this.setEnabled(Control, Enabled);
			}
		},

		setEnabled: function (el, Value) {
			if (!gx.lang.booleanValue(Value)) {
				gx.dom.addClass(el, "gx-disabled");
			}
			else {
				gx.dom.removeClass(el, "gx-disabled");
			}
			if (this.disabledAsSpan(el)) {
				var roel;
				var dp_el;
				var parent;
				try {
					if (el.type == 'checkbox')
						parent = el.parentNode;
					if (el.type == 'radio') {
						var $parent = $(el).parent().closest('.gx-radio-button');
						parent = $parent[0];
					}
				} catch (e) { }
				if (gx.lang.booleanValue(Value)) {
					//Enable
					if (parent && parent.className.indexOf("Readonly") == 0)
						parent.className = parent.className.substring(8);
					if (this.isVisible(el)) {
						this.setVisible(el, 1);
						roel = this.getRONode(el.id, true);
						if (roel)
							this.setVisible(roel, 0);
					}
				}
				else {
					//Disable
					if (parent && parent.className.indexOf("Readonly") < 0 && !gx.text.startsWith(parent.className, "gx-")) {
						parent.className = "Readonly" + parent.className;
					}

					if (this.isVisible(el) && el.type != 'password' && el.type != 'image' && el.type != 'checkbox' && el.type !== 'radio') {
						roel = this.getRONode(el.id, true);
						if (roel) {
							this.setVisible(el, 0);
							this.setVisible(roel, 1);
							var validStruct = gx.O.getValidStructFld(el);
							var GXCtrlFormat = 0;
							if (!gx.lang.emptyObject(validStruct) && validStruct.format)
								GXCtrlFormat = validStruct.format;
							this.setControlValue_span_safe(roel, gx.fn.getControlValue(gx.dom.id(el), 'screen', undefined, validStruct), GXCtrlFormat, (el.type == "textarea"));
						}
					}
				}
			}
		},

		disabledAsSpan: function (el) {
			var tagName = el.tagName.toUpperCase();
			return (tagName != 'IMG') && !(tagName == "INPUT" && el.type == "button")
		},

		setVisible: function (el, Value) {
			$(el).toggleClass('gx-invisible', !gx.lang.booleanValue(Value))			
			el.style.display = (Value == 0) ? "none" : this.displayByType(el.nodeName);
			var vStruct = gx.O.getValidStructFld(el);
			var parent = el.parentNode;
			if (Value && vStruct && vStruct.gxgrid && !vStruct.gxgrid.grid.gxIsFreestyle && parent.getAttribute('data-colindex') != null) {
				vStruct.gxgrid.applyPropEntireColumn(parent.getAttribute('data-colindex'), "Visible", Value);
			}
			else { //GridCtrl
				var ctrlGrid = gx.fn.rowGridId(el);
				if (ctrlGrid) {
					var elTable = $(el).find('table')[0]
					if (elTable)
						this.setVisible( elTable, Value);
				}
			}

		},

		getRONodePrefix: function() {
			return 'span_';
		},
		
		getRONode: function (id, create) {
			if (gx.lang.emptyObject(id))
				return null;
			var el = gx.dom.byId(id);
			var roelid = this.getRONodePrefix() + id;
			var roel = gx.dom.byId(roelid);
			if (roel != null)
				return roel;
			if (!create || el == null || (el.nodeName === 'INPUT' && (el.type === 'radio' || el.type === 'checkbox')))
				return null;
			var span = document.createElement('SPAN')
			span.setAttribute('id', roelid);
			this.setVisible(span, false);
			span.className = 'Readonly' + el.className;
			var controlValue;
			if (el.nodeName == 'IMG' || (el.nodeName == 'INPUT' && el.type == 'image'))
				controlValue = el.value;
			else
				controlValue = gx.fn.getControlValue(gx.dom.id(el), 'screen');
			span.appendChild(document.createTextNode(controlValue || ''));
			el.parentNode.insertBefore(span, el);
			return span;
		},

		setDateCtrlProperties: function (Control, Enabled, Visible) {
			var dpTrigger = gx.dom.byId(gx.dom.id(Control) + '_dp_trigger');
			if (dpTrigger)
				$(dpTrigger).toggle(Enabled);				
						
			var dpContainer = $(gx.dom.byId(gx.dom.id(Control) + '_dp_container'));
			if (dpContainer) {
				if (Control.Flat)
					$(Control).hide();
				
				var calendar = $( ".calendar", dpContainer);			
				dpContainer.toggle((Enabled && Visible) || (!Enabled && Visible));								
				if (calendar)
					calendar.toggle((Enabled && Visible));				
			}			
		},

		getGridCtrlProperty: function (gridId, ctrlId, prop) {
			try {
				if (gridId != 0) {
					var gridObj = this.getGridObj(gridId);
					if (gridObj) {
						var col = gridObj.grid.getColumnByHtmlName(ctrlId);
						if (col) {
							return col[prop.toLowerCase()];
						}
					}
				}
				else {
					return this.getCtrlProperty(ctrlId, prop);
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getGridCtrlProperty');
			}
			return '';
		},

		getCtrlProperty: function (ControlId, Property) {
			var vStruct = gx.O.getValidStructFld(ControlId);
			var rowId = (vStruct && vStruct.grid > 0) ? "_" + gx.fn.currentGridRowImpl(vStruct.grid) : "";
			var Control = gx.uc.getUserControlObj(gx.uc.userControlContainerId(ControlId + rowId));
			if (Control != null)
				return Control[Property];
			Control = this.screen_CtrlRef(ControlId);
			if (!Control)
				return;
			if (Property === "Picture")
				return gx.rtPicture(vStruct, Control);
			if (Property === "Text")
				return this.getControlValue(ControlId, "screen", undefined, vStruct);
			else if (Property == "Visible" && gx.fn.getRONode(Control.id)) //Un control es visible si el control o su span estan visibles
				return (this.getCtrlProperty_impl(Control, Property) || this.getCtrlProperty_impl(gx.fn.getRONode(ControlId), Property));
			else if (Property == "Enabled" && gx.fn.getRONode(Control.id))  //Un control esta disable si su RONode esta visible
				return !this.getCtrlProperty_impl(gx.fn.getRONode(Control.id), 'Visible');
			else
				return this.getCtrlProperty_impl(Control, Property);
		},

		getCtrlProperty_impl: function (Control, Property) {
			if (Control == null)
				return "";
			switch (Property) {
				case "Tooltiptext": return Control.title;
				case "Invitemessage": return Control.placeholder;
				case "Visible":
					if (Control.nodeName === 'INPUT' && Control.type === 'radio') {
						var $parent = $(Control).parent().closest('.gx-radio-button');
						if ($parent.length > 0) {
							Control = $parent[0];
						}
					}
					return Control.style.display != "none";	
				case "Enabled": 
					if (Control.disabled === undefined) {
						if ($(Control).hasClass('gx-disabled')) {
							return false;
						}
						return true;
					}
					else {
						return !Control.disabled;
					}
				case "Class": return Control.className;
				case "Backcolor": return gx.color.css(Control.style.backgroundColor);
				case "Forecolor": return gx.color.css(Control.style.color);
				case "Width": return gx.dom.dimensions(Control).w;
				case "Height": return gx.dom.dimensions(Control).h;
				case "Caption": return this.getCtrlCaption(Control);
				case "Fontbold": return (Control.style.fontWeight == 'bold');
				case "Fontitalic": return (Control.style.fontStyle == 'italic');
				case "Fontunderline": return (Control.style.textDecoration == 'underline');
				case "Fontstrikethru": return (Control.style.textDecoration == 'line-through');
				case "Fontname": return Control.style.fontFamily;
				case "Filename": return Control.value.split(/(\\|\/)/g).pop();
				case "Fontsize":
					{
						var size = parseInt(Control.style.fontSize);
						if (isNaN(size))
							return 12;
						return size;
					}
				case "Ispassword": return Control.type == "password";
			}
		},

		displayByType: function (NodeName) {
			switch (NodeName) {
				case 'TABLE':
					{
						if (!gx.util.browser.isIE() || (gx.util.browser.ieVersion() >= 8))
							return 'table';
						return 'block';
					}
				case 'P':
				case 'DIV': return 'block';
			}
			return '';
		},

		setCtrlCaption: function (Control, PValue) {
			try {
				var label = gx.html.getFieldLabel(Control);
				if (label) {
					gx.fn.setControlValue_fmt(label, PValue, 0, false);
				}
				else {
					switch (Control.tagName) {
						case 'SPAN':
						case 'DIV':
						case 'FIELDSET':
							var ctrlFormat = Control.getAttribute('data-gxformat');
							var validStruct = gx.O.getValidStructFld(Control);
							if (ctrlFormat == null) {
								if (!gx.lang.emptyObject(validStruct) && validStruct.format)
									ctrlFormat = validStruct.format;
								else
									ctrlFormat = 0;
							}
							var isMultiline = false;
							if (validStruct)
								isMultiline = validStruct.ctrltype ? validStruct.multiline : true;
							gx.fn.setControlValue_fmt(Control, PValue, ctrlFormat, isMultiline);
							return;
						case 'INPUT':
							if (Control.type != 'checkbox')
								Control.value = PValue;
							return;
					}
					if (Control.nodeName == '#document') {
						Control.title = PValue;
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setCtrlCaption');
			}
		},

		getCtrlCaption: function (Control) {
			var label = gx.html.getFieldLabel(Control);
			if (label) {
				return $(label).text();
			}
			else {
				switch (Control.tagName) {
					case 'SPAN':
					case 'DIV':
					case 'FIELDSET':
						var ctrlFormat = Control.getAttribute('data-gxformat');
						if (ctrlFormat != null && ctrlFormat == '1')
							return Control.innerHTML;
						else {
							while (Control.firstChild != null && Control.firstChild.nodeName != '#text')
								Control = Control.firstChild;
							if (typeof (Control.innerText) != 'undefined')
								return Control.innerText;
							return Control.textContent || Control.text;
						}
					case 'INPUT':
						if (Control.type != 'checkbox')
							return Control.value;
						break;
					default:
						return '';
				}
			}
		},

		propertyValueFalse: function (Value) {
			if (typeof (Value) == "string") {
				Value = Value.toLowerCase();
				if ((Value == 'false') || (gx.num.parseFloat(Value) == 0))
					return true;
			}
			return (Value == 0);
		},

		setButtonVisibility: function (Control, Visible) {
			var displayProp = Visible ? '' : 'none';
			var buttonBackground = Control.parentNode;
			if (!gx.lang.emptyObject(buttonBackground) && buttonBackground.nodeName == 'SPAN') {

				buttonBackground.style.display = displayProp;
				var buttonRight = buttonBackground.parentNode;
				if (!gx.lang.emptyObject(buttonRight) && buttonRight.nodeName == 'SPAN') {
					buttonRight.style.display = displayProp;
					var buttonLeft = buttonRight.parentNode;
					if (!gx.lang.emptyObject(buttonLeft) && buttonLeft.nodeName == 'SPAN') {
						buttonLeft.style.display = displayProp;
						var buttonRBtn = buttonLeft.parentNode;
						if (!gx.lang.emptyObject(buttonRBtn) && buttonRBtn.nodeName == 'SPAN')
							buttonRBtn.style.display = displayProp;
					}
				}
			}
			Control.style.display = displayProp;
		},

		setBlobValue: function (ControlId, Value) {
			var Control = gx.dom.byId(ControlId) || gx.dom.byId("Object_" + ControlId);
			this.setBlobUrl(Control, Value);
		},

		setBlobFilename: function (Control, PValue) {
			if (Control != null) {
				var vStruct = gx.O.getValidStructFld(Control);
				if (vStruct) {
					gx.fn.setHidden(vStruct.fld + "_Filename", gx.text.trim(PValue));
				}
			}
		},

		setBlobFiletype: function (Control, PValue) {
			if (Control != null) {
				var vStruct = gx.O.getValidStructFld(Control);
				if (vStruct) {
					gx.fn.setHidden(vStruct.fld + "_Filetype", gx.text.trim(PValue));
				}
				var blobCtrl = Control;
				if (blobCtrl.nodeName == 'INPUT' && blobCtrl.type == 'file')
					blobCtrl = gx.dom.byId("Object_" + Control.id);
				if (blobCtrl != null) {
					PValue = gx.util.getContentType(PValue);
					this.setObjectCtrlType(blobCtrl, PValue);
					gx.fn.setVisible(blobCtrl, true);
				}
			}
		},

		resolveResourceUrl: function (resource, useBlank) {
			if (resource == '')
				return useBlank ? gx.ajax.getImageUrl(gx, 'blankImage') : "";
			else {
				if (!gx.isabsoluteurl(resource)) {
					if (gx.isRelativeToHost(resource)) {
						if (resource.toLowerCase().indexOf("/" + gx.basePath.toLowerCase()) != 0)
							return gx.util.resourceUrl(gx.basePath + resource, false);
					}
					else
						return gx.util.resourceUrl(gx.basePath + gx.staticDirectory + resource, false);
				}
			}
			return resource;
		},

		setBlobUrl: function (Control, PValue) {
			var multimediaCt = gx.html.multimediaUpload.getContainer(Control);
			if (multimediaCt) {
				var link = this.resolveResourceUrl(PValue, false);
				gx.html.multimediaUpload.setPreviewImage(multimediaCt, link);
				gx.html.multimediaUpload.setPreviewLink(multimediaCt, link);
			}
			else {
				if (!PValue.match(/^[a-z]:[\S]*/i)) {
					if (Control != null) {
						var blobCtrl = Control;
						var isInputFile = blobCtrl.nodeName == 'INPUT' && blobCtrl.type == 'file';
						if (PValue === '') {	
							if (PValue === '') {	
								var $el = $(blobCtrl);
								$el.wrap('<form>').closest('form').get(0).reset();
								$el.unwrap();
							}
						}
						if (isInputFile)
							blobCtrl = gx.dom.byId("Object_" + Control.id);
						if (blobCtrl != null) {
							var cType = gx.util.getContentTypeFromExt(PValue);
							blobCtrl = this.setObjectCtrlType(blobCtrl, cType);
						}
						if (blobCtrl != null) {
							if (blobCtrl.tagName == 'IMG') {
								PValue = this.resolveResourceUrl(PValue, true);
								blobCtrl.src = PValue;
							}
							else {
								PValue = PValue || "about:blank";
								blobCtrl.data = PValue;
								gx.fn.setVisible(blobCtrl, true);
								this.resizeObject(blobCtrl);
								gx.dom.redrawControl(blobCtrl);
							}
						}
						else {
							blobCtrl = gx.dom.byId("Link_" + Control.id);
							if (blobCtrl != null) {
								if (PValue != '')
									blobCtrl.style.display = "block";
								else
									blobCtrl.style.display = "none";
								blobCtrl.href = PValue;
							}
						}
					}
				}
			}
		},

		setGridMultimediaValue: function (ControlId, sRow, file, uri) {
			if (sRow !== undefined)
				return this.setMultimediaValue(ControlId + "_" + sRow, file, uri);
		},

		setMultimediaValue: function (ControlId, file, uri) {
			var Control = gx.dom.byId(gx.csv.ctxControlId(ControlId));
			if (Control) {
				var multimediaCt = gx.html.multimediaUpload.getContainer(Control);
				var link = this.resolveResourceUrl(uri || file || "", false);
				if (multimediaCt) {
					var parsedUrl = gx.util.Url.parseWithAnchor(file);
					if (parsedUrl.protocol.search(/^https?:/) >= 0) {
						gx.html.multimediaUpload.setPreviewImage(multimediaCt, link);
					}
					var isBlob = (file == "" && uri == "") || file != "";
					if (!isBlob) {
						var gxiEl = gx.dom.byId(Control.id + "_GXI");
						if (gxiEl)
							gxiEl.value = uri;
					}
					var inputEl = gx.dom.byId(ControlId);
					if (inputEl && file == "")
						inputEl.value = "";
					this.setMultimediaType(Control, isBlob);
					gx.html.multimediaUpload.setPreviewLink(multimediaCt, link);
				}
				else {
					if (Control.tagName == 'IMG' || (Control.tagName == 'INPUT' && Control.type == "image"))
						Control.src = link;
					var parent = Control.parentNode;
					if (parent && parent.tagName == 'A' && gx.dom.isMultimediaElement(Control)) {
						if (link)
							parent.href = link;
						else
							parent.removeAttribute('href')
					}
				}
			}
		},

		setMultimediaType: function (Control, PValue) {
			if (Control) {
				var multimediaCt = gx.html.multimediaUpload.getContainer(Control);
				if (multimediaCt)
					gx.html.multimediaUpload.setType(multimediaCt, gx.lang.gxBoolean(PValue));
			}
		},

		setObjectCtrlType: function (objCtrl, type) {
			var newCtrl = objCtrl;
			if (objCtrl.nodeName == 'IMG' && (!type || type.indexOf('image/') == 0))
				return newCtrl;
			if ((objCtrl.type != type) || (objCtrl.nodeName == 'OBJECT' && type.indexOf('image/') == 0)) {
				if (type.indexOf('image/') == 0)
					newCtrl = gx.html.nodesFromText('<img id="' + objCtrl.id + '">')[0];
				else
					newCtrl = gx.html.nodesFromText('<object style="display:none;" id="' + objCtrl.id + '" type="' + type + '">')[0];
				if (newCtrl) {
					try {
						for (var att in objCtrl.attributes) {
							if (att != "id" && att != "type" && att != "implementation") {
								if (objCtrl[att]) {
									try { newCtrl[att] = objCtrl[att]; }
									catch (e) {
										gx.dbg.logEx(e, 'gxfrmutl.js', 'setObjectCtrlType');
									}
								}
							}
						}
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'setObjectCtrlType');
					}
					var pN = objCtrl.parentNode;
					if (pN) {
						var sibling = null;
						var childs = pN.childNodes.length;
						for (i = 0; i < childs; i++) {
							if (pN.childNodes[i] == objCtrl) {
								if (i < childs - 1)
									sibling = pN.childNodes[i + 1];
								break;
							}
						}
						gx.dom.removeControlSafe(objCtrl);
						if (sibling != null)
							pN.insertBefore(newCtrl, sibling);
						else
							pN.appendChild(newCtrl);
					}
				}
			}
			return newCtrl;
		},

		resizeObject: function (oCtrl) {
			var eo = gx.lang.emptyObject;
			if (!eo(oCtrl.data) && oCtrl.data != 'about:blank') {
				if (eo(oCtrl.width) && eo(oCtrl.height) && eo(oCtrl.style.width) && eo(oCtrl.style.height)) {
					oCtrl.style.width = '200px';
					oCtrl.style.height = '200px';
				}
			}
		},

		restoreLostCtrlOnGridRefresh: function (gridFirstIdx, Control, ctrlChecked) {
			//When isValid is fired and grid is re-rendered, control handler is lost. We try to recover it.
			if (Control.form == null) {
				var ctrlId = gx.dom.id(Control);
				var vStruct = gx.O.getValidStructFld(ctrlId);
				if (vStruct) {
					if (Control.type == 'checkbox' && (!vStruct.gxgrid || (parseInt(gridFirstIdx || 0, 10) === parseInt(vStruct.gxgrid.grid.firstRecordOnPage || 0, 10)))) {
						Control = gx.dom.el(Control.id) || gx.dom.el(Control.name);
						Control.checked = ctrlChecked;
					}
				}
			}
			return Control;
		},

		checkboxClick: function (Id, Control, CheckedValue, UnCheckedValue, gxWCP) {
			var checked = Control.checked,
				gxO = (gxWCP)? gx.getObj(gxWCP): null,
				vStruct = (typeof Id === "object") ? Id : gx.fn.validStruct(Id, gxO),
				gridIdx = (vStruct && vStruct.gxgrid)? vStruct.gxgrid.grid.firstRecordOnPage: 0,
				gridId = (vStruct && vStruct.grid)? vStruct.grid: 0;
			
			var afterValidationFn = (function (forced) {	
				if (!forced && gx.csv.validatingGrid !== gridId)
					return;
				Control = this.restoreLostCtrlOnGridRefresh(gridIdx, Control, checked);
				gx.fn.setControlOldValue(Control, Control.value);
				Control.checked = checked;
				if (checked) {
					Control.value = CheckedValue;
				}
				else {
					Control.value = UnCheckedValue;
				}
				if (vStruct) {
					if (typeof(vStruct.c2v) == 'function')
						vStruct.c2v();
					if (typeof(vStruct.v2bc) == 'function')
						vStruct.v2bc.call(gx.O);
				}
			}).closure(this);

			if (gx.pO.supportAjaxEvents) {
				gx.fx.obs.addObserver('gx.onaftervalidate', this, function( gxEvtKind) { if(gxEvtKind !== gx.evt.types.VALUECHANGED) afterValidationFn();}, { single: true });
			}

			//Calls pending validations.
			gx.fx.obs.notify('gx.validation', null, function () {
				if (gx.evt.fixWebKitOnFocus()) {
					Control.onfocus();
				}

				afterValidationFn.call(this, true);
			});

			if (!gx.pO.fullAjax) {
				afterValidationFn.call(this, true);	
			}			
		},


		setCtrlClass: function (Control, Class) {
			if (Control == null)
				return;
			Control.className = Class;
		},

		setCtrlLink: function (Control, Link) {
			if (Control == null)
				return;
			if (Link == "") {
				this.unsetCtrlLink(Control);
				return;
			}
			if (Control.tagName == "A") {
				Control.href = Link;
				return;
			}
			var childCtrl = Control.firstChild;
			if (childCtrl && childCtrl.tagName == "A") {
				childCtrl.href = Link;
			}
			else {
				var ParentTag = Control.parentNode;
				if (ParentTag.tagName == "A") {
					ParentTag.href = Link;
				}
				else {
					var newA = document.createElement("A");
					newA.href = Link;
					if (childCtrl && childCtrl.nodeName == "#text") {
						if (gx.dom.shouldPurge())
							gx.dom.purge(newA, true);
						newA.innerHTML = childCtrl.nodeValue;
						Control.replaceChild(newA, childCtrl);
					}
					else {
						ParentTag.replaceChild(newA, Control);
						newA.appendChild(Control);
					}
					var target = $(Control).attr('data-gx-link-target');
					if (target)
						$(newA).attr('target', target);
				}
			}
		},

		unsetCtrlLink: function (Control) {
			if (Control == null)
				return;
			var ParentTag = Control.parentNode;
			if (ParentTag.tagName == "A") {
				var ChildNode = ParentTag.firstChild;
				ParentTag2 = ParentTag.parentNode;
				if (ParentTag2 != null) {
					while (ChildNode != null) {
						ParentTag2.insertBefore(ChildNode, ParentTag);
						ChildNode = ParentTag.firstChild;
					}
					gx.dom.removeControlSafe(ParentTag);
				}
			}
		},

		setCtrlLinkTarget: function (Control, target) {
			if (Control == null)
				return;
			var jCtrl = $(Control);
			if (!jCtrl.is('a')) {
				jCtrl = jCtrl.children();
			}
			if (jCtrl.is('a')) {
				jCtrl.attr('target', target);
			}
			$(Control).attr('data-gx-link-target', target);
		},

		isVisible: function (Control, searchUpLevels) {
			if (gx.dom.hasClass(Control, "gx-invisible")) {
				return false;
			}
			if (Control.tagName.toUpperCase() === "INPUT" && Control.type === "hidden") {
				return false;
			}
			if (Control.style.display === "none") {
				return false;
			}
			try {
				var style;
				while (Control && (typeof (searchUpLevels) == 'undefined' || searchUpLevels >= 0)) {
					style = gx.dom.getComputedStyle(Control);
					if (style && (style["visibility"] == 'hidden' || style["display"] == 'none'))
						return false;
					Control = Control.parentNode;
					if (typeof (searchUpLevels) != 'undefined')
						searchUpLevels--;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'isVisible');
			}
			return true;
		},

		gridRowIsMod: function (Lvl, Row) {
			var gxGrid = this.gridObjByLvl(Lvl);
			var row = null;
			if (gxGrid) {	
				gxGrid = gx.O.getGridById( gxGrid.gridId, Row) || gxGrid;			
				var row = gxGrid.grid.getRowByGxId(Row);
				if (row)
					return row.gxIsMod();
				return true;
			}
			var bRet = false;
			try {
				var isMod = this.getControlValue("nIsMod_" + Lvl + "_" + Row);
				bRet = (isMod == 1);
			}
			catch (e) {
				bRet = false;
			}
			return bRet;
		},

		gridObjByLvl: function (Lvl) {
			var objGrids = gx.O.Grids;
			var len = objGrids.length;
			for (var i = 0; i < len; i++) {
				if (objGrids[i].gridLvl == Lvl)
					return objGrids[i];
			}
			return null;
		},

		forceEnableControls: function (Bool) {
			for (var Ctrl in gx.disabledControls) {
				Ctrl = this.getControlRef_list(Ctrl);
				var len = Ctrl.length;
				for (var i = 0; i < len; i++) {
					try {
						if (Ctrl[i].type != 'button' && Ctrl[i].type != 'submit')
							Ctrl[i].disabled = Bool;
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'forceEnableControls');
					}
				}
			}
		},

		alert: function (Ctrl, Message) {
			try {
				var gxballoon = gx.util.balloon.getNew(Ctrl.id);
				gxballoon.setError(Message);
				gxballoon.show();
				gx.csv.invalidForcedCtrl = Ctrl;
			}
			catch (e) {
				gx.util.alert.showError(Message);
			}
		},
		
		getGridRowMode: function (GXLvl, GridId) {			
			return this.getGridRowModeImpl(GXLvl, GridId, this.currentGridRow(GridId));
		},
		
		getGridRowModeImpl: function (GXLvl, GridId, CurrentRow) {			
			var IsRemoved = this.rowIsRemoved(GridId, CurrentRow);
			var RecordExists = this.getControlValue("nRcdExists_" + GXLvl + '_' + CurrentRow);
			if (IsRemoved == "1")
				return "DLT";
			if (RecordExists == "0")
				return "INS";
			return "UPD";
		},
		

		rowIsRemoved: function (GridId, CurrentRow) {
			var gridCtrl = this.getGridObj(GridId);
			if (gridCtrl != null) {
				var gridCtrlRow = gridCtrl.grid.getRowByGxId(CurrentRow);
				if (gridCtrlRow)
					return gridCtrlRow.gxDeleted();
			}
			return false;
		},

		getGridObj: function (GridId, row) {
			return gx.O.getGridById(GridId, row);
		},

		changeCmpContext: function () {
			try {
				gx.O.SetStandaloneVars();
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'changeCmpContext');
			}
		},

		initOld: function (Ctrl) {
			if (gx.oldValues[Ctrl.id] == undefined)
				gx.oldValues[Ctrl.id] = Ctrl.value;
		},

		setFocusOnError: function (ControlId) {
			var ctrlGrid = gx.fn.controlGridId(ControlId);
			var ctrlCmpId = gx.csv.ctxControlId(ControlId);
			var domCtrl = null;
			if (ctrlGrid == 0)
				domCtrl = gx.dom.el(ctrlCmpId);
			else
				domCtrl = gx.fn.getControlGridRef(ctrlCmpId, ctrlGrid);
			if (domCtrl != null) {
				gx.O.AnyError = 1;
				gx.csv.anyError = true;
				domCtrl.setAttribute("data-gxvalid", "0");
				if (gx.csv.stopOnError)
					gx.fn.setFocus(domCtrl);
			}
		},

		usrSetFocus: function (ControlId) {
			gx.usrPendingControl = ControlId;
		},
		
		usrSetFocus_commit: function () {
			if (gx.usrPendingControl) {
				gx.fn.usrSetFocus_impl(gx.usrPendingControl);
				delete gx.usrPendingControl;
			}
		},
		
		usrSetFocus_impl: function (ControlId, deferIfValidating) {
			if (deferIfValidating === undefined)
				deferIfValidating = true;


			var Control = gx.fn.screen_CtrlRef(ControlId);
			if (Control == null) {				
				gx.grid.setActiveGridRow(ControlId, 0);
				return;
			}	
			ControlId = gx.dom.id(Control);
			if (gx.csv.validating == true) {
				if (deferIfValidating) {
					var fnc = function(ControlId) {
						gx.lang.doCallTimeout( gx.fn.usrSetFocus_impl, gx.fn, [ControlId, false], 200);						
					}
					gx.fx.obs.addObserver('gx.onaftervalidate', this, fnc.closure(gx.fn, [ControlId]), { single: true });
				}
				else {
					gx.usrFocusControl = ControlId;
				}
			}
			else {
				gx.fn.setFocus(Control);
				delete gx.usrFocusControl;
			}
		},

		setFocus: function (Control, callback) {
			if (Control) {
				try {
					if (gx.popup.ispopup()) {
						if (gx.util.browser.isIE() && window.parent.document.selection) {
							window.parent.document.selection.empty();
						}
						else if (window.parent.gx.csv.lastControl && window.parent.gx.csv.lastControl.blur) {
							window.parent.gx.csv.lastControl.blur();
						}
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocus');
				}
				try {
					if (!gx.lang.emptyObject(Control.id)) {
						Control = gx.dom.byId(Control.id);
						if (!Control)
							return;
					}
					gx.fn.setFocusSafe(Control, function(Control) { 						
						gx.fn.setSelection( Control);
						Control.forcedFocus = true;
						if (callback)
							callback();
					}); 
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocus');
				}				
			}
		},

		setFocusSafe: function(Control, callback) {
			var setFocusOnload = gx.csv.setFocusOnload;
			if (Control)
			{
				var doSetFocusFn = function(Control, callback) {
					try {
						if (setFocusOnload && callback) {
							gx.fx.obs.addObserver('gx.onafterfocus', this, callback.closure(this, [Control]), { single: true });
						}
						Control.focus();
					}
					catch(e) {}

					if (!setFocusOnload && callback) {
						callback(Control);
					}
				};

				if (gx.spa.isNavigating()) {
					gx.spa.addObserver('onnavigatecomplete', window, function() {
						doSetFocusFn.call(this, Control, callback);
					}, { single: true });
				}
				else {
					var timeout = setFocusOnload ? 500 : 0;
					gx.lang.doCallTimeout(doSetFocusFn, this, [Control, callback], timeout);
				}
			} 
		},

		setFocusInit: function () {
			try {
				gx.csv.lastActiveControl = window.document.activeElement;
			}
			catch (e) { }
			if (!gx.csv.lastActiveControl)
				gx.csv.lastActiveControl = gx.csv.lastControl;
		},
		
		arrayCtrlFocus: function( Control) {
			
			if ( Control && Control.type == 'radio'){
				Control = gx.fn.getRadioSelected( Control.name) || Control;
			}
			return Control;
		},

		setFocusOnload: function ( isLoading) {
			isLoading = isLoading === undefined ? true : false; 
			gx.wpo( function() {
				if (gx.pO.focusOnlyNEmb && top !== self && !gx.popup.ispopup())
					return;

				var Control = null;
				var usrFocusId = gx.pO.getUserFocus();
				if (!gx.lang.emptyObject(usrFocusId)) {
					if (usrFocusId == 'notset')
						return;
					var userControl = gx.pO.getUserControl(gx.uc.userControlContainerId(usrFocusId));
					if (!gx.lang.emptyObject(userControl)) {
						userControl.setFocusBase();
						return;
					}
					else {
						gx.csv.userFocus = gx.fn.getControlRef(usrFocusId);
					}
				}
				if (gx.csv.userFocus == 'notset') {
					return;
				}
				Control = gx.csv.userFocus;
				if (!gx.fn.isAccepted(Control)) {
					if (gx.csv.lastActiveControl && gx.fn.isAccepted(gx.csv.lastActiveControl)) {
						Control = gx.csv.lastActiveControl;
					}
					else {
						var frmFirstEl = gx.fn.firstAcceptedControl(gx.popup.ispopup());
						Control = gx.fn.arrayCtrlFocus(frmFirstEl);
					}
				}

				try {
					if (Control) {
						var disableFocusonLoad = function() {
							gx.csv.setFocusOnload = false;
						}
						gx.csv.lastControl = Control;
						gx.csv.setFocusOnload = isLoading;
						if (gx.fn.isAccepted(Control))
							gx.fn.setFocus(Control, disableFocusonLoad);
						else {
							gx.popup.setFocus();					
							disableFocusonLoad();
						}
					}
					else {
						gx.popup.setFocus();
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setFocusOnload');
				}
			});
		},

		setSelection: function (Control) {
			if (Control && gx.fn.isVisible(Control)) {
				try {
					gx.csv.lastControl = Control;
					if ((gx.dom.isEditControl(Control) || Control.type == "file") && Control.select)
						Control.select();
					else if (Control.nodeName == "TEXTAREA" || Control.nodeName == "SELECT") {
						Control.focus();
						if (Control.select)
							Control.select();
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'setSelection');
				}
			}
		},

		isAccepted: function (Control, triggerNac, gxO) {
			var triggerNac = triggerNac === undefined || triggerNac,
				gxO = gxO || gx.O,
				notAccNodeName = ['FIELDSET'],
				accepted = Control != null 
					&& Control.type
					&& Control.type !== "hidden" 
					&& !Control.disabled
					&& !Control.readOnly
					&& !gx.util.inArray(Control.nodeName, notAccNodeName) 
					&& gx.fn.isVisible(Control);
			if (!accepted) {
				return false;
			}
				if (triggerNac) {
					var ControlId = gx.dom.id(Control),
						vStruct = gxO.getValidStructFld(ControlId),
						sMode = gxO.getVariable("Gx_mode");
					if (gx.csv.lastGrid > 0)
						gxO.setVariable("Gx_mode", gx.fn.getGridRowMode(gx.fn.gridLvl(gx.csv.lastGrid), gx.csv.lastGrid));
					if (!gx.lang.emptyObject(vStruct) && vStruct.nac)
					accepted = !vStruct.nac.call(gxO);
					else
						accepted = true;
					gxO.setVariable("Gx_mode", sMode);
			}

			return accepted;
		},

		enterHasFocus: function () {
			if (gx.csv.lastControl == null)
				return false;
			return gx.evt.isEnterEvtCtrl(gx.csv.lastControl);
		},

		skipFocus: function (skiponenter, lastControl) {
			lastControl = lastControl || gx.csv.lastControl;
			var startEl = gx.fn.getControlIndex(lastControl), el = startEl;
			var gridId = this.controlGridId(lastControl.id || lastControl.name);

			var avoidNewRowBtn = false;
			if (skiponenter && gx.dom.hasClass(lastControl, 'gx_newrow')) {
				el = lastControl.gxControlIdx;
				avoidNewRowBtn = true;
			}

			if (el == -1)
				return true;
			var Control = null;
			var formElements = gx.fn.getFormElements();
			for (Control = gx.fn.searchFocus(++el, true) ; ; Control = gx.fn.searchFocus(++el, true)) {
				if (Control == null || el == formElements.length)
					el = -1;
				else {
					if (skiponenter)
						break;
					if (gx.evt.isEnterEvtCtrl(Control))
						break;
					if (Control.nodeName == 'INPUT' && Control.type != 'submit' && Control.type != 'button' && Control.type != 'image')
						break;
				}
			}

			if (!avoidNewRowBtn && gridId && gx.O.isTransaction()) {
				if (this.controlGridId(Control.id || Control.name) != gridId) {
					var grid = gx.O.getGridById(gridId);
					var newRowEl = gx.dom.byId(grid.containerName + "_NewRow");
					Control = newRowEl.parentNode;
					// Remember the control index of the last editable field in the grid, so it is used when Enter is pressed on NewRow button
					Control.gxControlIdx = startEl;
				}
			}

			gx.fn.setFocus(Control);
		},
		
		getFormElements:function() {
			//Ref: https://developer.mozilla.org/es/docs/Web/API/HTMLFormElement/elements
			return $.makeArray($('button, fieldset, input, img, object, output, select, textarea'));
		},

		getControlIndex: function (Ctrl) {
			var i_max = gx.fn.getFormElements().length - 1;
			var i_min = 0;
			el = this.controlIndex(Ctrl, i_min, i_max);
			return el;
		},

		controlIndex: function (Ctrl, i_min, i_max) {
			if (!document.all) {
				return Ctrl.gxIndex;
			}
			else {
				var elements = gx.fn.getFormElements();
				var i_minsi = elements[i_min].sourceIndex;
				var i_maxsi = elements[i_max].sourceIndex;
				var i_med = parseInt(i_min + ((i_max - i_min) / 2)) + 1;
				var i_medsi = elements[i_med].sourceIndex;
				if ((i_min == i_max) && (Ctrl.sourceIndex == i_minsi) && (Ctrl.sourceIndex == i_maxsi))
					return i_min;

				if (Ctrl.sourceIndex == i_minsi)
					return i_min;
				if (Ctrl.sourceIndex == i_maxsi)
					return i_max;
				if (Ctrl.sourceIndex == i_medsi)
					return i_med;

				if ((Ctrl.sourceIndex > i_medsi) && (Ctrl.sourceIndex < i_maxsi))
					return this.controlIndex(Ctrl, i_med + 1, i_max - 1);

				if ((Ctrl.sourceIndex > i_minsi) && (Ctrl.sourceIndex < i_medsi))
					return this.controlIndex(Ctrl, i_min + 1, i_med - 1);
			}
		},

		searchFocus: function (el, Forward) {
			if (Forward)
				return this.searchFocusFwd(el);
			return this.searchFocusBack(el);
		},

		searchFocusBack: function (el) {
			var elems = sortFormElements(gx.fn.getFormElements());
			for (var i = el; i >= 0; i--) {
				if (gx.fn.isAccepted(elems))
					return elems[i];
			}
			return null;
		},

		searchFocusFwd: function (el) {
			var elems = sortFormElements(gx.fn.getFormElements());
			var len = elems.length;
			for (var i = el; i < len; i++) {
				if (gx.fn.isAccepted(elems[i]))
					return elems[i];
			}
			return null;
		},

		rowGridId: function (ctrl) {
			if (!ctrl || !ctrl.getAttribute)
				return null;
			var id = ctrl.getAttribute("data-gxgridid");
			if (id != null)
				return id;
			return gx.fn.rowGridId(ctrl.parentNode);
		},

		controlRowIndex: function (ctrl) {
			var $parents = $(ctrl).parentsUntil(CONTAINER_CLASS_SELECTOR);
			return $parents.filter('[data-gxrow]').attr("data-gxrow") || "";
		},

		controlRowIdImpl: function (ctrl) {
			if (!ctrl || !ctrl.getAttribute)
				return null;
			var id = ctrl.getAttribute("data-gxrow");
			if (id != null)
				return id;
			return gx.fn.controlRowIdImpl(ctrl.parentNode);
		},
		
		controlRowId: function (ctrl) {			
			var rowId = gx.fn.controlRowIdImpl(ctrl);
			if (rowId === null && ctrl && ctrl.id && ctrl.id.lastIndexOf("_") > 0) { 
				//WA for returning no Abstract grid row. Remove in the future. 
				var _idx = ctrl.id.lastIndexOf("_");
				rowId = ctrl.id.substring(_idx + 1);
			}
			return rowId;
		},

		controlGridId: function (Fld) {
			try {
				var ctrlIds,
					i,
					grids = gx.O.Grids;

				if (grids) {
					for (i = 0, len=grids.length; i < len; i++) {
						if (grids[i].grid.columnsHtmlName[Fld]) {
							return grids[i].gridId;
						}
					}
				}

				ctrlIds = gx.fn.controlIds()
				for (i = 0, len = ctrlIds.length; i < len; i++) {
					var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
					if (gx.O.isSameField(_GXValidStruct, Fld))
						return _GXValidStruct.grid;
				}

				var cData = gx.O.getComponentData(Fld);
				if (cData) {
					var gridObj = gx.fn.gridObjByLvl(cData.lvl);
					if (gridObj)
						return gridObj.gridId;
				}
			}
			catch (e) { }
			return 0;
		},

		oldGridId: function (Name) {
			try {
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (i = 0; i < len; i++) {
					var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
					if (_GXValidStruct != undefined && _GXValidStruct.gxold == Name)
						return _GXValidStruct.grid;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'oldGridId');
			}
			return 0;
		},

		saveLvlOldParm: function (Name, Value) {
			var gxMode = 'no_mode';
			if (gx.csv.validatingGrid != null) {
				if (this.isLvlParmOld(gx.csv.lastGrid, Name)) {
					gxMode = gx.fn.getGridRowMode(gx.fn.gridLvl(gx.csv.lastGrid), gx.csv.lastGrid);
				}
			}
			else if (this.isLvlParmOld(0, Name)) {
				gxMode = gx.O.Gx_mode;
			}
			if (gxMode == 'no_mode')
				return true;
			if ((gxMode == "UPD") || (gx.csv.validatingGrid == null)) {
				window[Name] = Value;
				return true;
			}
			return false;
		},

		isLvlParmOld: function (GridId, Name) {
			try {
				var oldLvl = gx.O.getOldLvl(Name);
				if (oldLvl >= 0) {
					if (GridId > 0) {
						var gridLvl = gx.fn.gridLvl(GridId);
						return (oldLvl < gridLvl);
					}
					return true;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'isLvlParmOld');
			}
			return false;
		},

		gridLvl: function (GridId) {
			try {
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (i = 0; i < len; i++) {
					var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
					if (_GXValidStruct != undefined && _GXValidStruct.lvl != undefined && _GXValidStruct.grid == GridId)
						return _GXValidStruct.lvl;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'gridLvl');
			}
			return 0;
		},

		lvlGrid: function (Lvl) {
			try {
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (i = 0; i < len; i++) {
					var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
					if (_GXValidStruct != undefined && _GXValidStruct.lvl == Lvl)
						return _GXValidStruct.grid;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'lvlGrid');
			}
			return 0;
		},

		vStructId: function (CtrlId) {
			try {
				var ctrlIds = gx.fn.controlIds();
				for (i = 0; i < ctrlIds.length; i++) {
					var validStruct = gx.fn.validStruct(ctrlIds[i]);
					if (validStruct != undefined && validStruct.fld == CtrlId)
						return ctrlIds[i];
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'vStructId');
			}
			return 0;
		},

		getVStruct: function (condFunc, allWCond) {
			try {
				var ret = null;
				if (allWCond) {
					ret = [];
				}
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (i = 0; i < len; i++) {
					var vStruct = gx.fn.validStruct(ctrlIds[i]);
					if (vStruct != undefined && condFunc(vStruct)) {
						vStruct.id = ctrlIds[i];
						if (allWCond) {
							ret.push(vStruct);
						}
						else {
							return vStruct;
						}
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'getVStruct');
			}
			return ret;
		},

		vStructForOld: function (GXVarName) {
			return gx.fn.getVStruct(function (vStruct) {
				return vStruct.gxold == GXVarName;
			});
		},

		vStructForVar: function (GXVarName) {
			return gx.fn.getVStruct(function (vStruct) {
				return vStruct.gxvar == GXVarName;
			});
		},

		vStructForVarWId: function (GXVarName, Id) {
			var vStructs = gx.fn.getVStruct(function (vStruct) {
				return vStruct.gxvar == GXVarName;
			}, true);
			var vStruct = vStructs[0];
			var len = vStructs.length;
			if (len > 1) {
				for (var i = 0; i < len; i++) {
					vStruct = vStructs[i];
					if (vStruct.id == Id) {
						break;
					}
				}
			}
			return vStruct;
		},

		vStructForHC: function (GXVarName) {
			return gx.fn.getVStruct(function (vStruct) {
				return vStruct.hc == GXVarName;
			});
		},

		firstCtrlAfterGrid: function (fromCtrl, gridId) {
			var lastCtrl = gx.fn.lastCtrlId();
			for (var i = fromCtrl; i < lastCtrl; i++) {
				var validStruct = gx.fn.validStruct(i);
				if (validStruct != undefined && validStruct.grid != gridId)
					return i;
			}
			return lastCtrl;
		},

		clearOldKeys: function () {
			gx.oldKeyValues = [];
		},

		oldKey: function (Fld) {
			try {
				return gx.oldKeyValues[Fld];
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'oldKey');
			}
			return '';
		},

		oldGridKey: function (Fld, GridId) {
			try {
				return gx.oldKeyValues[Fld + gx.fn.currentGridRow(GridId)];
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'oldGridKey');
			}
			return '';
		},

		setKey: function (Fld, Var) {
			if (Fld != null) {
				gx.oldKeyValues[Fld] = Var;
			}
		},

		unsetKey: function (Fld) {
			if (Fld != null) {
				gx.oldKeyValues[Fld] = undefined;
			}
		},

		setGridKey: function (Fld, GridId, Var) {
			if (Fld != null) {
				gx.oldKeyValues[Fld + gx.fn.currentGridRow(GridId)] = Var;
			}
		},

		unsetGridKey: function (Fld, GridId) {
			if (Fld != null) {
				gx.oldKeyValues[Fld + gx.fn.currentGridRow(GridId)] = undefined;
			}
		},

		removeGridRow: function (CurrentRow, GridId) {
			var IsRemoved = gx.fn.rowIsRemoved(GridId, CurrentRow);
			try {
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (i = 0; i < len; i++) {
					var _GXValidStruct = gx.fn.validStruct(ctrlIds[i]);
					if (_GXValidStruct != undefined && _GXValidStruct.grid == GridId) {
						var Ctrl = gx.dom.el(_GXValidStruct.fld + "_" + CurrentRow);
						if (Ctrl != null) {
							Ctrl.gxdisabled = IsRemoved;
							Ctrl.disabled = IsRemoved;
						}
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'removeGridRow');
			}
			gx.csv.validGridRow(GridId, CurrentRow);
		},

		controlFiresEvent: function(vStruct) {
			return vStruct && (vStruct.evt || vStruct.triggersEvt);
		},
		
		controlIds: function (gxO) {
			gxO = gxO || gx.O;
			return gxO ? gxO.getControlIds() : [];
		},

		validStruct: function (Ctrl, gxO) {
			gxO = gxO || gx.O;
			return gxO.getValidStruct(Ctrl);
		},

		lastCtrlId: function (filterValidatable) {
			if (filterValidatable === true) {
				// Get the last validatable control
				var controlIds = this.controlIds();
				for (var i = controlIds.length - 1; i >= 0; i--) {
					var vStruct = this.validStruct(controlIds[i]);
					if (vStruct.v2v && (vStruct.isacc === undefined || vStruct.isacc == 1))
						return controlIds[i];
				}
			}
			else
				return gx.O.getLastControlId();
		},

		lastMainLevelCtrlId: function (CtrlId, GridId) {
			return (GridId == 0 && CtrlId == this.lastCtrlId(true));
		},

		vStructsArray: function () {
			return gx.O.GXValidFnc;
		},

		firstAcceptedControl: function (mindButtons) {
			try {
				var vStructs = gx.fn.vStructsArray();
				var ctrlIds = gx.fn.controlIds();
				var len = ctrlIds.length;
				for (var i = 0; i < len; i++) {
					var vStruct = vStructs[ctrlIds[i]];
					if (vStruct != null) {
						var control = gx.fn.getControlGridRef(vStruct.fld, vStruct.grid);
						if (control && gx.fn.isAccepted(control))
							if (mindButtons || (control.type != 'submit' && control.type != 'image' && control.type != 'button' && control.type != 'fieldset'))
								return control;
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'firstAcceptedControl');
			}
			return null;
		},

		enableDisableDelete: function () {
			var btnDelete = gx.dom.byId(gx.csv.cmpCtx + "BTN_DELETE");
			if (btnDelete != null)
				gx.fn.setCtrlPropertyImpl(btnDelete, "Enabled", (gx.getVar("Gx_mode") == 'INS') ? 0 : 1);
		},

		setFocusAfterLoad: function (invalidateForm) {
			if (gx.csv.validating == true || !gx.lang.emptyObject(gx.csv.autoRefreshing))
				return;
			if (invalidateForm)
				gx.csv.invalidateForm();
			gx.csv.onloadFocus = true;
			if (!gx.lang.emptyObject(gx.usrFocusControl)) {
				gx.O.fromValid = gx.csv.lastId;
				gx.fn.setFocus(gx.dom.byId(gx.usrFocusControl));				
				gx.usrFocusControl = '';
			}
			gx.csv.onloadFocus = false;
		},

		disableCtrl: function (ControlId) {
			var fn = function (ctrl) {
				try {
					var len = ctrl.length;
					for (var i = 0; i < len; i++)
						gx.fn.setCtrlPropertyImpl(ctrl[i], "Enabled", 0);
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'disableCtrl');
				}
			};

			var Control = gx.fn.getControlRef_list(ControlId);
			if (Control == null)
				return;
			if (document.gxReadyState == 'complete')
				fn(Control);
			else
				gx.evt.on_ready(this, fn.closure(this, [Control]));
		},

		refreshGridRowBC: function (bcName, bcData) {
			try {
				var bc = gx.O.getGridBC(bcName);
				if (bc) {
					var boundGrid = gx.pO.getGridForColl(bc.gxvar);
					if (gx.csv.validatingGrid && boundGrid && gx.csv.validatingGrid.gridId == boundGrid.gridId) //Validating current grid
					{
						gx.fn.setGridHidden(bcName, bcData);
						bcData = bcData[parseInt(gx.fn.currentGridRow(boundGrid.gridId)) - 1]; //Gets only current row for updating
						gx.O.bcToScreen(bc, bcData);
						return true;
					}
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'refreshGridRowBC');
			}
			return false;
		},

		refreshBC: function (bcName, bcData) {
			bcData = gx.O.applySDTVarMapping( bcData, bcName);
			return this.refreshFormBC(bcName, bcData) || this.refreshGridRowBC(bcName, bcData);
		},

		refreshFormBC: function (bcName, bcData) {
			try {
				var bc = gx.O.getFormBC(bcName) || gx.O.getFormBCForVar(bcName);
				if (bc) {
					gx.setVar(bcName, bcData);
					gx.fn.setGridHidden(bcName, bcData);
					gx.O.bcToScreen(bc, bcData);
					return true;
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'refreshFormBC');
			}
			return false;
		},

		isHidden: function (HiddenName) {
			if (!gx.http.viewStateLoaded) {
				gx.http.loadState();
			}
			return (typeof (gx.http.viewState[HiddenName]) != 'undefined');
		},

		GX_HASH_PREFIX: 'gxhash_',

		getHash: function ( cmpCtx, FldName, rowId) {
			return gx.fn.getHidden( cmpCtx + gx.fn.GX_HASH_PREFIX + FldName + (rowId ? '_' + rowId : '')) || gx.fn.getHidden( cmpCtx + gx.fn.GX_HASH_PREFIX + FldName);
		},

		getHidden: function (HiddenName) {
			if (!gx.http.viewStateLoaded) {
				gx.http.loadState();
			}
			return gx.http.viewState[HiddenName];
		},

		setHidden: function (HiddenName, Value) {
			if (!gx.http.viewStateLoaded) {
				gx.http.loadState();
			}
			gx.http.viewState[HiddenName] = Value;
		},

		setGridHidden: function (HiddenName, Value) {
			var GridHiddenName = HiddenName;
			var GridId = gx.fn.oldGridId(HiddenName);
			if (GridId > 0) {
				GridHiddenName = HiddenName + '_' + gx.fn.currentGridRowImpl(GridId);
			}
			gx.fn.setHidden(GridHiddenName, Value);
		},

		deleteHidden: function (HiddenName) {
			if (gx.http.viewState)
				delete gx.http.viewState[HiddenName];
		},

		setJsonHiddens: function (gxO, gxHiddens, resolveCurrentRow) {
			var updatedUCs = [];
			var Value, ctrlMap;
			resolveCurrentRow = (resolveCurrentRow === undefined) || resolveCurrentRow;
			for (var CtrlName in gxHiddens) {
				if (resolveCurrentRow) {
					gx.fn.setGridHidden(CtrlName, gxHiddens[CtrlName]);
				}
				else {
					gx.fn.setHidden(CtrlName, gxHiddens[CtrlName]);
				}

				var varName = gx.fn.getVarControlMap(gxO, CtrlName);
				Value = gxHiddens[CtrlName];
				if (!gx.lang.emptyObject(varName)) {
					if (gxO) {
						ctrlMap = gxO.VarControlMap[varName];
						if (ctrlMap.type == "date" || ctrlMap.type == "dtime") {
							Value = new gx.date.gxdate(gxHiddens[CtrlName], 'Y4MD');
						}
					}

					gx.setVar(varName, Value);
				}
				if (gx.fn.vStructForOld(CtrlName)) {
					gx.setVar(CtrlName, Value);
				}
				if (gxO && gxO.UCBindingsHiddens[CtrlName]) {
					updatedUCs = updatedUCs.concat(gx.O.UCBindingsHiddens[CtrlName].uc);
				}
			}
			return updatedUCs;
		},

		filterHiddens: function (match, gxHiddens) {
			var hiddens = {};
			for (var h in gxHiddens) {
				if (h && h.search(match) == 0)
					hiddens[h] = gxHiddens[h];
			}
			return hiddens;
		},

		autoRefreshingControl: function (ControlId, cmpCtx) {
			return !gx.lang.emptyObject(gx.csv.autoRefreshing) && (gx.csv.lastControl != null && gx.csv.lastControl.id == (cmpCtx + ControlId));
		},

		setJsonValues: function (gxValuesArr, isValidation, gridId, row, shouldUpdatFn) {
			if (!gxValuesArr)
				return [];
			var oldObj = gx.O,
				len = gxValuesArr.length,
				updatedUCs = [],				
				control,				
				cRow,
				gRow;
			
			var getRow = function(vStruct, evtGridId, evtGridRow) {
				return (vStruct.grid == gridId) ? evtGridRow: gx.fn.currentGridRow(vStruct.grid);
			};
			
			for (var i = 0; i < len; i++) {
				var gxValues = gxValuesArr[i],
					cmpCtx = gxValues.CmpContext,
					isMPage = gx.lang.booleanValue(gxValues.IsMasterPage),
					gxO = gx.setGxO(cmpCtx, isMPage);
				if (!gx.lang.emptyObject(gx.O)) {
					for (var Property in gxValues) {
						if (Property == 'CmpContext' || Property == 'IsMasterPage') {
							continue;
						}
						if (shouldUpdatFn && !shouldUpdatFn(Property)) {
							continue;
						}
						var value = gxValues[Property];
						if (typeof (value) == 'object') {
							if (gx.fn.refreshBC(Property, gxValues[Property]))
								continue;
						}
						if (typeof (value) != "function") {
							var validStruct = gx.fn.vStructForVar(Property) || gx.O.getValidStructFld(Property);
							if (validStruct) {
								if (validStruct.v2v && !gx.fn.autoRefreshingControl(validStruct.fld, cmpCtx)) {
									var grid = gx.O.getGridById(validStruct.grid);
									var additiveResponse = (grid && grid.InfiniteScrolling);
									if (validStruct.grid != 0 ) {
										control = gx.dom.el(Property, false, false);
										cRow = gx.fn.controlRowId(control) || getRow(validStruct, gridId, row);
									}
									if (!additiveResponse) {
										validStruct.v2v(value);
										validStruct.v2c(cRow);										
									}
								}
							}
							else if (Property == "GX_FocusControl" && !isValidation) {
								if ((oldObj.CmpContext == cmpCtx) && (oldObj.IsMasterPage == isMPage))
									gx.usrFocusControl = value;
							}													
							else {								
								//Hide Code
								var validStruct = gx.fn.vStructForHC(Property);
								if (!gx.lang.emptyObject(validStruct) && !gx.lang.emptyObject(validStruct.hc) && !validStruct.grid) {
									if (validStruct.hc == Property) {
										gxO[validStruct.hc] = value;
										gx.fn.setHidden(cmpCtx + "GXH_" + validStruct.fld, value);
									}
									else if (validStruct.hd == Property) {
										gxO[validStruct.hd] = value;
									}
								}
								//HC en grid
								validStruct = gx.fn.vStructForHC(Property);								
								if (!gx.lang.emptyObject(validStruct)) {
									gRow = '';
									if (validStruct.grid != 0) {										
										gRow = getRow(validStruct, gridId, row);
									}
									gx.fn.setHidden(cmpCtx + "GXHC" + validStruct.fld + "_" + gRow, value);									
								}
														
								var ctrlMap = gx.fn.getVarControlMap(gxO, Property);
								if (!gx.lang.emptyObject(ctrlMap))
									gx.setVar(ctrlMap, value);
								else
									gx.setVar(Property, value);
								gx.fn.setGridHidden(Property, value);

								if (gx.O.UCBindings[Property]) {
									updatedUCs = updatedUCs.concat(gxO.UCBindings[Property].uc);
								}
							}
						}
					}
				}
			}
			gx.setGxO(oldObj);
			return updatedUCs;
		},

		getPropertyControlRef: function(Control, rowId, ignoreBlob) {
			var domCtrl = gx.fn.getControlRef(Control, true);
			domCtrl = (domCtrl == null && !ignoreBlob) ? gx.dom.byId("Object_" + Control) : domCtrl; //Blob field
			if (domCtrl == null) {
				domCtrl = gx.fn.screen_CtrlRef(gx.csv.ctxControlId(Control));
			}
			if (domCtrl == null && rowId) {
				domCtrl = gx.dom.el(Control + "_" + rowId);
			}
			return domCtrl;
		},

		setJsonProperties: function (gxPropertiesArr, rowId) {
			//Critical function, changes here impact performance
			var domCtrl, vStruct, GridColumn, isBlob, ControlInGrid;
			if (!gxPropertiesArr)
				return [];
			var oldObj = gx.O,
				len = gxPropertiesArr.length,
				updatedUCs = [];
			for (var i = 0; i < len; i++) {
				var gxProperties = gxPropertiesArr[i],
					cmpCtx = gxProperties.CmpContext,
					isMPage = gx.lang.booleanValue(gxProperties.IsMasterPage),
					isWebComp = !!cmpCtx && !isMPage,
					gxO = gx.setGxO(cmpCtx, isMPage);
				if (!gx.lang.emptyObject(gx.O)) {
					for (var Control in gxProperties) {
						var Grid;
						domCtrl = null;
						if (Control === 'CmpContext' || Control === 'IsMasterPage' || Control === '')
							continue;
						var gxPropValue = gxProperties[Control];
						if (typeof (gxPropValue) != "function") {
							vStruct = gxO.getValidStructFld(Control);
							if (Control == "FORM" || vStruct || Control.indexOf("gxHTMLWrp") >= 0 || Control.indexOf("ContainerDiv") >= 0) {
								isBlob = vStruct && (vStruct.type == "bits" || vStruct.type == "bitstr" || vStruct.type == "audio" || vStruct.type == "video" || vStruct.type == "binaryfile");
								domCtrl = gx.fn.getPropertyControlRef(Control, rowId, !isBlob);
							} else {
								domCtrl = gx.fn.getPropertyControlRef(Control, rowId);
							}
							var ptyHandled = false;
							if (domCtrl && domCtrl.gxGridName) {
								Grid = gx.fn.gridObjFromGxO(domCtrl.gxGridName);
								ptyHandled = Grid.setProperty(gxPropValue);
							}
							if ( !ptyHandled)
							{
								GridColumn = gxO.getGridColumn(Control, rowId);
								if (((domCtrl == null || Grid) && gx.uc.isUserControl(Control, gxO)) || (GridColumn && GridColumn.isUserControl)) {
									ControlInGrid = Control;
									if (GridColumn && GridColumn.isUserControl) {
										ControlInGrid = Control + "_" + rowId;
									}
									gx.uc.setProperties(ControlInGrid, gxPropValue);
									updatedUCs.push(gx.uc.getUserControlObj(gx.uc.userControlContainerId(ControlInGrid)));
								}
								else {
									if (domCtrl == null && GridColumn == null)
										continue;
									for (var Property in gxPropValue) {
										var isObjValue = typeof (gxPropValue[Property]) === "object";
										if (GridColumn && !isObjValue) {
											GridColumn[Property.toLowerCase()] = gxPropValue[Property];
										}
										if (domCtrl) {
											if (!domCtrl.parentElement)
												domCtrl = gx.fn.getPropertyControlRef(Control, rowId);
												
											if (isObjValue) {
												for (var InProperty in gxPropValue[Property]) {
													gx.fn.setCtrlPropertyImpl(domCtrl, InProperty, gxPropValue[Property][InProperty], vStruct);
												}
											}
											else {
												gx.fn.setCtrlPropertyImpl(domCtrl, Property, gxPropValue[Property], vStruct);
											}
											
										}
									}
								}
							}
						}
					}
				}
			}
			gx.setGxO(oldObj);
			return updatedUCs;
		},

		loadJsonGrids: function (PostGrids, isPostback) {
			
			var getControlNameFromProps = function( Props) {
				for (var i = 0; i < Props.length; i++) {
					if (typeof (Props[i]) === 'string') {
						return Props[i];
					}
				}
				return "";
			};
			var parentRowIdfromCtrl = function( CtrlName) {
				var parentrowId = "",
					Idx = CtrlName.lastIndexOf("_"),
					suffix;
				if (Idx !== -1) {
					suffix = CtrlName.substring(Idx + 5);
					parentrowId = suffix ? "_" + suffix : "";
				}
				return parentrowId;
			};			
			var listGridsUCS = function( gGridProps, cmpCtx, UCs) {
				var UCs = UCs || [];
				for (var i=0; i<gGridProps.Count; i++) {
					var x = gGridProps[i];
					for (var gridName in x.Grids) {
						var grid = gx.fn.gridObj(cmpCtx, gridName + "_" + gx.text.padl((i+1).toString(), 4, "0"), false);
						if (grid && grid.isUsercontrol) {
							UCs.push( grid.grid);
						}					
					}
				}
				return UCs;
			};
			var updatedUCs = [];
			if (PostGrids) {
				var len = PostGrids.length,
					grid;
				for (var i = 0; i < len; i++) {
					try {
						var gGridProps = PostGrids[i];
						if (gGridProps.Count != undefined) {
							var cmpCtx = gGridProps.CmpContext;
							var gridName = gGridProps.GridName;
							var vGrid = gx.csv.validatingGrid;
							if (gx.pO.fullAjax || gx.lang.emptyObject(vGrid) || ((vGrid.gxComponentContext != cmpCtx) && (vGrid.gridName != gridName) || !gx.lang.emptyObject(vGrid.boundedCollType))) {
								var inMasterPage = (gGridProps.InMasterPage == "true") ? true : false,
									parentrowId = "",
									CtrlName = "";
								if (gGridProps[0] && gGridProps[0].Props && gGridProps[0].Props[0] && gx.lang.isArray(gGridProps[0].Props[0])){
									CtrlName = getControlNameFromProps(gGridProps[0].Props[0]);
								}
								parentrowId = parentRowIdfromCtrl(CtrlName);
								grid = gx.fn.gridObj(cmpCtx, gridName + parentrowId, inMasterPage);
								if (grid) {
									updatedUCs = updatedUCs.concat(listGridsUCS( gGridProps, cmpCtx));
									if (grid.isUsercontrol) {
										updatedUCs.push(grid.grid);
									}
										if (isPostback) {
										if (!gx.O.Grids[grid.gridName] || !gx.O.Grids[grid.gridName].parentGrid)
										{	
											grid.loadGrid({
												rowProps:gGridProps, 
												isPostback:isPostback
											});
										}
									}
									else {
										grid.updatePropsHidden(gGridProps);
									}
								}
							}
						}
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'loadJsonGrids');
					}
				}
			}
			return updatedUCs;
		},

		getErrorViewerCtrls: function () {
			var gxErrorViewers = gx.dom.byClass('gx_ev');
			if (gxErrorViewers.length == 0) {
				gxErrorViewers = [];
				var spans = gx.dom.byTag("span");
				var len = spans.length;
				for (var i = 0; i < len; i++) {
					if (spans[i].getAttribute('data-gx-id') == "gxErrorViewer")
						gxErrorViewers.push(spans[i]);
				}
			}
			return gxErrorViewers;
		},

		setErrorViewer: function (Messages, clearMessages) {
			clearMessages = (clearMessages === undefined) || clearMessages;
			gx.O.AnyError = 0;
			if (!Messages)
				return;
			try {
				gx.fx.obs.notify('gx.onmessages', [Messages]);
				var errViewers = gx.dom.byClass('gx_ev');
				var vLen = errViewers.length;
				for (var cmpCtx in Messages) {
					var sourceFields;
					var locMessages = Messages[cmpCtx];
					if (!gx.lang.isArray(locMessages)) {
						sourceFields = locMessages.fields;
						locMessages = locMessages.msgs;
					}

					var sourceElements = [];
					if (sourceFields) {
						for (var i = 0, len = sourceFields.length; i < len; i++) {
							if (!gx.lang.isArray(sourceFields[i])) {
								var vStruct = gx.fn.vStructForVar(sourceFields[i].replace(/^gx\.O\./, ""));
								if (vStruct) {
									sourceElements.push(vStruct.fld);
								}
							}
						}
					}
					if (cmpCtx == 'MAIN') {
						cmpCtx = '';
					}
					if (typeof (locMessages) != 'undefined') {
						for (var i = 0; i < vLen; i++) {
							var errViewer = errViewers[i];
							if (errViewer && errViewer.getAttribute('data-gx-id') == (cmpCtx + 'gxErrorViewer')) {
								var html = gx.csv.setFocusOnload ? errViewer.innerHTML : '';
								break;
							}
						}

						var balloons = {};
						for (var Property in locMessages) {
							var ObjMessage = locMessages[Property];
							if (ObjMessage && ObjMessage.type == 1) {
								gx.O.AnyError = 1;
							}
							if (!gx.lang.emptyObject(ObjMessage.text)) {
								if (typeof (ObjMessage) != "function") {
									var attCtrl = gx.fn.screen_CtrlRef(ObjMessage.att);
									var inHiddenGrid = attCtrl && $(attCtrl).is("[data-gxgridid].gx-invisible " + attCtrl.tagName);
									if (ObjMessage.att != "" && ((inHiddenGrid && gx.fn.isVisible(attCtrl, 0)) || gx.fn.isVisible(attCtrl))) {
										var b = balloons[ObjMessage.att];
										if (!b) {
											b = gx.util.balloon.getNew(ObjMessage.att, undefined, ObjMessage.id ? sourceElements : []);
											balloons[ObjMessage.att] = b;
										}
										if (ObjMessage.type == 1)
											b.setError(ObjMessage.text);
										else
											b.setMessage(ObjMessage.text);
									}
									else {
										var className = (ObjMessage.type == 1) ? "gx-error-message" : "gx-warning-message";
										html += '<div class="' + className + '">' + gx.html.encode(ObjMessage.text) + '</div>';

									}
								}
							}
						}
						var focusSet = false;
						for (var att in balloons) {
							var b = balloons[att];
							if (b.show() == false && !focusSet) {
								focusSet = true;
								gx.fn.setFocusOnError(att);
							}
							if (gx.csv.oneAtAtime) {
								break;
							}
						}
						for (var i = 0; i < vLen; i++) {
							var errViewer = errViewers[i];
							if (errViewer && errViewer.getAttribute('data-gx-id') == (cmpCtx + 'gxErrorViewer')) {
								if (errViewer.innerHTML != html) {
									if (gx.dom.shouldPurge()) {
										gx.dom.purge(errViewer, true);
									}

									if (clearMessages) {
										errViewer.innerHTML = html;
									}
									else {
										errViewer.innerHTML += html;
									}

									if (html != '') {
										var ef = gx.fx.dom.highlight(errViewer, [255, 255, 165], 2500);
										ef.play();
										errViewer.effect = ef;
									}
								}
							}
						}
					}
				}
				gx.plugdesign.applyTemplateObject({
					templateSelector: function(t) {
						return t.name === 'errorviewer';
					},
					classMapSelector: function() {
						return false;
					}
				});

				if (gx.config.csv.scrollTopOnError && gx.O.AnyError && !focusSet) {
					window.scrollTo(0, 0);
				}

			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setErrorViewer');
			}
		},

		cmpContextFromCtrl: function (CtrlName) {
			var cmpRegex = CMP_CTRL_REGEX,
				cmpType = cmpRegex.exec(CtrlName);
			if (cmpType) {
				return cmpType[1] + cmpType[2];
			}
			return CtrlName;
		},

		clearCompontHiddens: function (gxComponents) {
			var cmpsCtx = [],
				Component;
			for (Component in gxComponents) {
				if (typeof (gxComponents[Component]) != "function") {
					cmpsCtx.push(gx.fn.cmpContextFromCtrl(Component));
				}
			}
			try {
				gx.O.deleteComponentHiddens(cmpsCtx);
			}
			catch (e) {
				except = true;
				gx.dbg.logEx(e, 'gxfrmutl.js', 'clearCompontHiddens');
			}
		},
		
		setJsonComponents: function (gxComponents, gxComponentsMap, gxHiddens, callback, isPostback) {
			try {
				var toCreate = [];
				var except = false;
				var isDotNet = gx.gen.isDotNet();
				var newComponents = [];
				for (var Component in gxComponents) {
					newComponents.push(Component);
					if (typeof (gxComponents[Component]) != "function") {
						try {
							var cmpHtml = gxComponents[Component];
							if (cmpHtml) {
								var Cmp = gx.dom.byId(Component);
								if (!Cmp && gxComponentsMap) {
									Cmp = gx.dom.byId(gxComponentsMap[Component]);
								}
								if (gx.lang.emptyObject(Cmp)) {
									$( document.body ).append( "<div id='"+ Component +"'></div>" );
									Cmp = gx.dom.byId(Component);
								}
								if (!gx.lang.emptyObject(Cmp)) {
									gx.html.setInnerHtml(Cmp, cmpHtml, false, isPostback);
									var cmpType = gx.fn.cmpContextFromCtrl(Component);
									var cmpName = cleanComponentName(gx.fn.getHidden(cmpType + '_CMPPGM'));
									toCreate.push({ type: cmpType, name: cmpName, html: cmpHtml, container: Cmp });
								}
							}
						}
						catch (e) {
							except = true;
							gx.dbg.logEx(e, 'gxfrmutl.js', 'setJsonComponents');
						}
					}
				}
			}
			catch (e) {
				except = true;
				gx.dbg.logEx(e, 'gxfrmutl.js', 'setJsonComponents');
			}
			if ((toCreate.length == 0 || except) && typeof (callback) == 'function') {
				callback(newComponents);
			}
			else {
				var createCmpDeferreds = $.map(toCreate, function (webComponent) {
					return gx.fn.createComponentAsync(webComponent, gxHiddens);
				});
				
				$.when.apply($, createCmpDeferreds).done(function () {
					callback(newComponents);
				});
			}
		},

		cmpRegexCache: {},

		getCmpRegex: function (cmpCtx) {
			var cmpRegex = this.cmpRegexCache[cmpCtx];
			if (!this.cmpRegexCache[cmpCtx]) {
				cmpRegex = new RegExp("^" + cmpCtx);
				this.cmpRegexCache[cmpCtx] = cmpRegex;
			}
			return cmpRegex;
		},

		processCodeCallback: function (cName, cType, cHiddens, cmpContainer, gxO, deferred) {
			gx.fn.createComponentObj(cName, cType, cmpContainer);
			gx.fn.setJsonHiddens(gxO, cHiddens);
			deferred.resolve();
		},

		createComponentAsync: function (cmp, hiddens) {
			var deferred = $.Deferred();
			var cmpType = cmp.type;
			var cmpName = cmp.name;
			var cmpHtml = cmp.html;
			var cmpContainer = cmp.container;

			deferred.then(function () {
				gx.fx.obs.notify('gx.onafterevent', [gx.csv.lastEvtResponse]);
			});

			try {
				var gxO = gx.O;
				var cmpHiddens = gx.fn.filterHiddens(gx.fn.getCmpRegex(cmpType), hiddens);
				if (!gx.cache.codeLoaded(cmpType + cmpName)) {
					gx.cache.addInlineCode(cmpType + cmpName);
					gx.html.processCode(cmpHtml, false, gx.html.onTypeAvailable, [cmpName, gx.fn.processCodeCallback, [cmpName, cmpType, cmpHiddens, cmpContainer, gxO, deferred]], cmpName);					
				}
				else {
					gx.fn.createComponentObj(cmpName, cmpType, cmpContainer);
					gx.fn.setJsonHiddens(gxO, cmpHiddens);
					deferred.resolve();
				}
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'createComponentAsync');
				deferred.resolve();
			}

			return deferred;
		},

		createComponentObj: function (cmpName, cmpType, cmpContainer) {
			var gxComp = gx.createComponent(cmpName, cmpType, cmpContainer);
			if (gxComp != null) {
				gx.addComponent(gxComp);
			}
		},

		cleanAttachedCtrls: function (gxObject) {
			gx.attachedControls = [];
		},

		getAttachedCtrl: function (ControlId) {
			var len = gx.attachedControls.length;
			for (var j = 0; j < len; j++) {
				var aCtrl = gx.attachedControls[j];
				if (aCtrl.id == ControlId)
					return aCtrl;
			}
			return null;
		},

		attachCtrl: function (ControlId, CtrlInfo) {
			var ctrl = gx.fn.getAttachedCtrl(ControlId);
			if (ctrl == null)
				gx.attachedControls.push({ id: ControlId, info: CtrlInfo });
		},

		doAttachs: function (newComponents) {
			var attachedControls = gx.fn.attachedControls(),
				len = attachedControls.length,
				gxO = gx.O,
				newGxO,
				newCmpContexts = newComponents && newComponents.length ? $.map(newComponents, gx.fn.cmpContextFromCtrl) : undefined,
				aCtrl,
				ArrCtrl,
				len1,
				validStruct,
				arrFld,
				i, j,
				fld;

			for (j = 0; j < len; j++) {
				aCtrl = attachedControls[j];
				if (!newCmpContexts || $.inArray(aCtrl.info.wc, newCmpContexts) >= 0) {
					newGxO = gx.setGxO(aCtrl.info.wc, aCtrl.info.mp);
					if (aCtrl.info.isPrompt && newGxO.isTransaction() && newGxO.Gx_mode == 'DSP') {
						gx.fn.setCtrlPropertyImpl(gx.dom.el(aCtrl.info.wc + aCtrl.info.id), 'Visible', false);
					}
					else {
						if (!aCtrl.attached) {
							ArrCtrl = aCtrl.info.controls;
							len1 = ArrCtrl.length;
							arrFld = [];
							for (i = 0; i < len1; i++) {
								gx.fn.addAttach(ArrCtrl[i], aCtrl);
								validStruct = gx.fn.validStruct(ArrCtrl[i]);
								gx.fn.checkAttachedPropertyVS(validStruct, "Visible", false);
								gx.fn.checkAttachedPropertyVS(validStruct, "Enabled", false);
								arrFld.push(validStruct.fld);
							}
							aCtrl.attached = true;
							$('#' + aCtrl.id).attr('data-gx-attached-ctrl', arrFld.join(" "))
						}
					}
				}
			}
			gx.setGxO(gxO);
		},

		addAttach: function (i, ref) {
			var validStruct = gx.fn.validStruct(i);
			if (validStruct.attachedCtrls == undefined)
				validStruct.attachedCtrls = [];
			validStruct.attachedCtrls.push(ref);
		},

		checkAttachedProperty: function (FieldId, Property, Enable) {
			gx.fn.checkAttachedPropertyVS(gx.O.getValidStructFld(FieldId), Property, Enable);
		},

		checkAttachedPropertyVS: function (validStruct, Property, Enable) {
			if (validStruct == undefined)
				return;
			var attachedCtrls = validStruct.attachedCtrls;
			if (attachedCtrls == undefined)
				return;
			var len = attachedCtrls.length;
			for (var i = 0; i < len; i++)
				gx.fn.checkAttachedControlProperty(attachedCtrls[i], Property, Enable)
		},

		checkAttachedControlProperty: function (attachedCtrls, Property, Enable) {
			var ControlId = attachedCtrls.info.id;
			attachedCtrls = attachedCtrls.info;
			var setCtrlProperty = true;
			var ArrCtrl = attachedCtrls.controls;
			var WC = attachedCtrls.wc;
			var len = ArrCtrl.length;			
			for (var i = 0; i < len; i++) {
				var propValue = gx.fn.getCtrlProperty(WC + gx.fn.validStruct(ArrCtrl[i]).fld, Property);
				setCtrlProperty = (Enable)? propValue == Enable: setCtrlProperty && propValue == Enable;
				if (Enable && setCtrlProperty)										
					break;													
			}				
			if (setCtrlProperty) {				
				gx.fn.setCtrlPropertyImpl(gx.dom.el(WC + ControlId), Property, Enable);
			}
		},

		changeControlOpacity: function (Control, OpacStart, OpacEnd, Milliseconds) {
			var fadeSpeed = Math.round(Milliseconds);
			var controlId = "";
			if (typeof (Control) == 'string')
				controlId = Control;
			else
				controlId = Control.id;
			if (OpacStart > OpacEnd) {
				gx.fn.setOpacity(OpacStart, controlId);
				setTimeout(function () {
					gx.fn.changeControlOpacity(Control, OpacStart - 10, OpacEnd, Milliseconds);
				}, fadeSpeed);
			}
			else if (OpacStart < OpacEnd) {
				gx.fn.setOpacity(OpacStart, controlId);
				setTimeout(function () {
					gx.fn.changeControlOpacity(Control, OpacStart + 10, OpacEnd, Milliseconds);
				}, fadeSpeed);
			}
			else {
				gx.fn.setOpacity(OpacEnd, controlId);
			}
		},

		setOpacity: function (Opacity, ControlId) {
			var control = ControlId;
			if (typeof (ControlId) == "string") {
				if (ControlId == "body")
					control = document.body;
				else
					control = gx.dom.el(ControlId);
			}
			if (control != null) {
				var styleObj = control.style,
					opacityValue = (Opacity == "reset" ? "" : Opacity / 100);
				styleObj.opacity = opacityValue;
				styleObj.MozOpacity = opacityValue;
				styleObj.filter = "alpha(opacity=" + (Opacity == "reset" ? 100 : Opacity) + ")";
			}
		},

		fadeControl: function (Control, Direction, Milliseconds) {
			if (Direction == "in")
				gx.fn.changeControlOpacity(Control, 0, 100, Milliseconds);
			else
				gx.fn.changeControlOpacity(Control, 100, 0, Milliseconds);
		},

		fadeIn: function (Control, Milliseconds) {
			gx.fn.fadeControl(Control, "in", Milliseconds);
		},

		statusMsg: function (Txt) {
			window.status = Txt;
		},

		objectOnload: function (loadGrids, forceAfterLoad) {
			var $body = $(document.body),
				HasEnter = $body.attr('data-HasEnter') === 'true',
				Skiponenter = $body.attr('data-Skiponenter') === 'true';
			gx.evt.onkeypress_hdlr = gx.evt.onkeypress_hdlr || function(event) {
				gx.evt.onkeypress(event, HasEnter, Skiponenter);
			};
			gx.evt.attach(document, ["keydown"], gx.evt.onkeypress_hdlr);
			$(document).on('keyup', function(event) {
				gx.evt.onkeyup(event);
			});
			$(document).on('keyup', 'input[type="text"], input[type="password"], input[type="email"], input[type="number"], input[type="search"], input[type="url"], textarea', function (event) {
				gx.evt.oncontrolvaluechanging(event);
			});
			if (gx.pO != null) {
				gx.pO.onload(loadGrids, forceAfterLoad);
				gx.setGxO(gx.pO);
			}
		},

		objectOnUnload: function (unloadMasterPage) {
			if (gx.pO != null) {
				gx.pO.onunload(unloadMasterPage);
			}
		},

		objectOnpost: function () {
			if (gx.pO != null) {
				gx.pO.onpost();
			}
		},

		objectPostback: function (userControls, newComponents) {
			if (gx.pO != null) {
				gx.pO.postbackLoad(userControls, newComponents);
				gx.fx.obs.notify('gx.onobjectpostback', arguments);
			}
		},

		gridObjFromGxO: function (GridName) {
			return gx.fn.gridObj(gx.O.CmpContext, GridName, gx.O.IsMasterPage);
		},

		gridObj: function (CmpCtx, GridName, InMasterPage) {
			var obj = gx.getObj(CmpCtx, InMasterPage);
			return obj ? obj.getGrid(GridName) : null;			
		},

		installComponents: function (replace, gxHiddens) {
			var cmpObjs = gx.fn.getHidden("GX_CMP_OBJS");
			if (cmpObjs != undefined) {
				var isDotNet = gx.gen.isDotNet();
				for (var cmpCtx in cmpObjs) {
					if (replace || !gx.pO.getWebComponent(cmpCtx)) {
						var cmpType = cleanComponentName(cmpObjs[cmpCtx].toLowerCase());
						var gxComp = gx.createComponent(cmpType, cmpCtx);
						if (gxComp != null) {
							gx.addComponent(gxComp, gxHiddens);
							setTimeout((function (cmp) {
								this.addComponentRemoteFiles(cmp);
							}).closure(this, [gxComp]), 1);
						}
					}
				}
			}
		},

		addComponentRemoteFiles: function (gxComp) {
			var cmpCtrl = gxComp.getContainer();
			if (cmpCtrl) {
				gx.html.processCode(cmpCtrl.innerHTML, true);
				gx.dom.fitToParent(cmpCtrl);
			}
		},

		datePickerFormat: function (Picture, Dec, Len) {
			var dateFmt = gx.dateFormat;
			var D1 = dateFmt.substr(0, 1);
			var D2 = dateFmt.substr(1, 1);
			var D3 = dateFmt.substr(2, 1);

			var DD1 = gx.fn.datePickerDateFormat(D1, Picture);
			var DD2 = gx.fn.datePickerDateFormat(D2, Picture);
			var DD3 = gx.fn.datePickerDateFormat(D3, Picture);
			var DT = gx.fn.datePickerTimeFormat(Dec);
			if (Len > 0 && Dec > 0)
				return DD1 + '/' + DD2 + '/' + DD3 + ' ' + DT;
			else if (Len > 0)
				return DD1 + '/' + DD2 + '/' + DD3;
			else
				return DT;
		},

		datePickerDateFormat: function (FormatPart, Picture) {
			if (FormatPart == 'Y' && Picture.substr(0, 10) == '99/99/9999')
				return '%Y';
			else if (FormatPart == 'Y')
				return '%y';
			else if (FormatPart == 'M')
				return '%m';
			else if (FormatPart == 'D')
				return '%d';
			else return '';
		},

		datePickerTimeFormat: function (Dec) {
			var timeFmt = gx.timeFormat;
			var DPTF, AMPM, TimeFmt;
			if (timeFmt == 12) {
				DPTF = '%I';
				AMPM = ' %p';
			} else if (timeFmt == 24) {
				DPTF = '%H';
				AMPM = '';
			} else {
				DPTF = '';
				AMPM = '';
			}
			if (Dec == 2)
				TimeFmt = '';
			else if (Dec == 5)
				TimeFmt = ':%M';
			else if (Dec == 8)
				TimeFmt = ':%M:%S';
			else
				return '';

			return DPTF + TimeFmt + AMPM;
		},

		installDatePicker: function (ControlId, validStruct, gxo, Flat, ShowsTime, WeekNumbers, MondayFirst, Format, DateLength, TimeLength) {
			var dateType = (!ShowsTime)? 'date': 'datetime';
			var dPicker = new gx.ui.controls.datePicker({ 
				inputId: ControlId,
				triggerId: ControlId + "_dp_trigger",
				inline: Flat, 
				inputType: dateType,
				weeksNumbers: WeekNumbers,
				mondayFirst: MondayFirst,
				format: Format,
				datePartLength: DateLength,
				timePartLength: TimeLength,
				afterChange: gx.fn.datePickerChanged,
				vStruct: validStruct,
				gxO: gxo
			});			
			dPicker.render();			
		},
				
		datePickerChanged: function (calendar, dateObj, control, validStruct, currentObject) {		
			if (!calendar || calendar.dateClicked) {		
				currentObject = currentObject || gx.O;
				if (typeof(validStruct) === 'undefined') {
					var ctrlIds = gx.fn.controlIds();
					var len = ctrlIds.length;
					for (i = 0; i < len; i++) {
						validStruct = gx.fn.validStruct(ctrlIds[i]);
						var sRow = (validStruct.grid != 0) ? '_' + gx.fn.currentGridRow(validStruct.grid) : '';
						var controlId = currentObject.CmpContext + validStruct.fld + sRow;
						if (control.id == controlId)
							break;
					}
				}			
				if ((validStruct != null) && (validStruct.dp != undefined)) {										
					var newValue = (gx.date.isNullDate(dateObj))? gx.date.nulldate_toc(validStruct.len, validStruct.dec) : dateObj.print(gx.fn.datePickerFormat(validStruct.dp.pic, validStruct.dp.dec,
					validStruct.len));					
					if (newValue != control.value) {
						control.setAttribute("data-gxvalid", "0");
						control.value = newValue;
						control.onchange();		
						if (calendar)
							calendar.callCloseHandler();
						if (validStruct.grid > 0) {
							var grid = gx.fn.getGridObj(validStruct.grid) || validStruct.gxgrid;
							grid.setRowModified(gx.fn.currentGridRow(validStruct.grid));
						}
						currentObject.refreshDependantGrids(validStruct);
					}
				}		
			}
		},

		toArray: function (obj) {
			if (gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 8)
			{
				var array = [];
				for (var i = 0, len= obj.length; i < len; i++) {
					array[i] = obj[i];
				}
				return array;
			}
			return Array.prototype.slice.call(obj);
		},

		evalCtxScope : function(objContext, jsEval) {
			var gxOld = gx.O;
			gx.setGxO(objContext);	
			var evalResult = eval(jsEval);
			if (evalResult instanceof Object) {
				evalResult = gx.json.serializeJson(evalResult);
			}				
			gx.setGxO(gxOld);
			return evalResult;		
		}
	};
})(gx.$);


Function.prototype.closure = function (obj, args, appendArgs) {
	var browser = gx.util.browser;
	if (browser.isIE() && browser.ieVersion() < 8) {
		if (!window.__objs) {
			window.__objs = [];
			window.__funs = [];
			window.__args = [];
		}
		var fun = this;
		var objId = obj.__objId;
		if (!objId)
			__objs[objId = obj.__objId = __objs.length] = obj;
		var funId = fun.__funId;
		if (!funId)
			__funs[funId = fun.__funId = __funs.length] = fun;
		if (!args)
			args = [];
		var argsId = args.__argsId;
		if (!argsId)
			__args[argsId = args.__argsId = __args.length] = args;
		obj = null;
		fun = null;
		args = null;
		return function () {
			if (!__funs)
				return;
			var funcArgs = __args[argsId];
			if (appendArgs === true) {
				funcArgs = Array.prototype.slice.call(arguments, 0);
				funcArgs = funcArgs.concat(__args[argsId]);
			}
			if (funcArgs.length == 0 && arguments.length > 0)
				funcArgs = arguments;
			var ret = __funs[funId].apply(__objs[objId], funcArgs);
			if (__objs) {
				try { delete __objs[objId]['__objId']; }
				catch (e)
				{ __objs[objId]['__objId'] = null; }
			}
			if (__funs)
				delete __funs[funId]['__funId'];
			if (__args)
				delete __args[argsId]['__argsId'];
			return ret;
		};
	}
	else {
		var fun = this;
		return function () {
			var funcArgs = args || arguments;
			if (appendArgs === true) {
				funcArgs = Array.prototype.slice.call(arguments, 0);
				funcArgs = funcArgs.concat(args);
			}
			return fun.apply(obj || window, funcArgs);
		};
	}
};

gx.thread = {
	Map: function () {
		this.map = {};

		this.add = function (k, o) {
			this.map[k] = o;
		}

		this.remove = function (k) {
			delete this.map[k];
		}

		this.get = function (k) {
			return k == null ? null : this.map[k];
		}

		this.first = function () {
			return this.get(this.nextKey());
		}

		this.next = function (k) {
			return this.get(this.nextKey(k));
		}

		this.nextKey = function (k) {
			for (i in this.map) {
				if (!k) {
					return i;
				}
				if (k == i) {
					k = null;
				}
			}
			return null;
		}
	},

	Command: function (obj, func, args) {
		if (!gx.thread.Command.LastID) {
			gx.thread.Command.LastID = 0;
		}

		this.id = ++gx.thread.Command.LastID;

		this.execute = function () {
			func.apply(obj, args);
		}

		this.syncExecute = function () {
			new gx.thread.Mutex(this, 'execute');
		}
	},

	Mutex: function (obj, func, args, callback) {
		if (!gx.thread.Mutex.Wait) {
			gx.thread.Mutex.Wait = new gx.thread.Map();
		}

		gx.thread.Mutex.SLICE = function (cmdID, startID) {
			gx.thread.Mutex.Wait.get(cmdID).attempt(gx.thread.Mutex.Wait.get(startID));
		}

		this.attempt = function (start) {
			for (var j = start; j; j = gx.thread.Mutex.Wait.next(j.c.id)) {
				if (j.enter || (j.number && (j.number < this.number || (j.number == this.number && j.c.id < this.c.id))))
					return setTimeout('gx.thread.Mutex.SLICE(' + this.c.id + ',' + j.c.id + ')', 10);
			}
			try {
				retVal = this.c.execute();
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex Call');
			}
			this.number = 0;
			gx.thread.Mutex.Wait.remove(this.c.id);
			if (typeof (callback) == 'function') {
				try {
					callback.call(obj, retVal);
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'Mutex CallBack');
				}
			}
		}

		this.c = new gx.thread.Command(obj, func, args);
		gx.thread.Mutex.Wait.add(this.c.id, this);
		this.enter = true;
		this.number = (new Date()).getTime();
		this.enter = false;
		this.attempt(gx.thread.Mutex.Wait.first());
	}
};

gx.INTERACTIVE_EVT = 'gx.onInteractive';
gx.PARENT_OBJECT_EVT = 'gx.onCreateParentObject';
gx.SETMASTERPAGE_EVT = 'gx.onSetMasterPage';
gx.ONREADY_EVT = 'gx.onready';
gx.ONAFTERLOAD_EVT = 'onafterload';


gx.isInteractive = false;
gx.isReady = false;

gx.isReadyUI = function() {
      return (gx.evt.userReady && gx.isInputEnabled() && gx.ajax.isFormEnabled());
};

gx.goInteractive = function()
{
	gx.isInteractive = true;
	gx.fx.obs.notify(gx.INTERACTIVE_EVT);
};

gx.goReady = function()
{
	gx.isReady = true;
	gx.fx.obs.notify(gx.ONREADY_EVT);
};

gx.goOnload = function()
{
	gx.isLoaded = true;
	gx.fx.obs.notify(gx.ONAFTERLOAD_EVT);
};

gx.observe_run = function(fnc_test, at, ptyctx, pty) {
	ptyctx[pty] = function( fnc, ctx, args)
		{	
			var args = args || [];
			if (fnc_test()) {
				fnc.apply( ctx, args);
			}
			else {
				gx.fx.obs.addObserver(at, ctx, fnc.closure(ctx, args), { single: true});
		}
	}
};

gx.observe_run( function() { return gx.isLoaded }, gx.ONAFTERLOAD_EVT, gx, 'ol');
gx.observe_run( function() { return gx.isReady }, gx.ONREADY_EVT, gx, 'wr');
gx.observe_run( function() { return gx.pO && gx.pO.MasterPage }, gx.SETMASTERPAGE_EVT, gx, 'wmp');
gx.observe_run( function() { return gx.isInteractive }, gx.INTERACTIVE_EVT, gx, 'wi');
gx.observe_run( function() { return gx.pO }, gx.PARENT_OBJECT_EVT, gx, 'wpo');


gx.isabsoluteurl = function (url) {
	return (url.search('://') !== -1);
};
gx.isRelativeToHost = function (url) {
	return url.substr(0, 1) == '/';
};
gx.absoluteurl = function (url) {
	if (!gx.isabsoluteurl(url)) {
		if (url.charAt(0) !== '/') {
			return gx.util.resourceUrl(url, true);
		} else {
			return location.protocol + '//' + location.host + url;
		}
	}
	return url;
};

gx.timeoutActions = {
	ignore: 0,
	warn: 1
};

gx.uc = (function ($) {
	return {
		PostRenderScripts: {},
		gxCssClass: 'gx_usercontrol',
		getNew: function (ParentObject, ControlId, LastId, ClassName, ContainerName, ControlName, FieldName, GridLvl, GridId, GridRow) {
			var subclass = eval(ClassName);
			gx.lang.inherits(subclass, gx.uc.UserControl, true);
			var userCtrl = new subclass($);
			userCtrl.ContainerName = ContainerName;
			userCtrl.DesignContainerName = ContainerName;
			userCtrl.LabelForAttValue = ParentObject.CmpContext + ControlName.toUpperCase() + (GridId ? "_" + GridRow : "")
			userCtrl.setupControl(ParentObject, ControlName, FieldName, ControlId, LastId, GridLvl, GridId, GridRow);
			return userCtrl;
		},

		fromChild: function (Child) {
			var gxUC = gx.pO.getUsercontrolFromChild(Child);
			if (gxUC != null)
				return gxUC;
			if (gx.pO.hasMasterPage()) {
				gxUC = gx.pO.MasterPage.getUsercontrolFromChild(Child);
				if (gxUC != null)
					return gxUC;
			}
			var len = gx.pO.WebComponents.length;
			for (var i = 0; i < len; i++) {
				gxUC = gx.pO.WebComponents[i].getUsercontrolFromChild(Child);
				if (gxUC != null)
					return gxUC;
			}
			return null;
		},

		getUserControlObj: function (ContainerName) {
			var uc = gx.O.getUserControl(ContainerName);
			if (gx.lang.emptyObject(uc)) {
				if (gx.pO.hasMasterPage()) {
					uc = gx.pO.MasterPage.getUserControl(ContainerName);
					if (!gx.lang.emptyObject(uc))
						return uc;
				}
				var len = gx.pO.WebComponents.length;
				for (var i = 0; i < len; i++) {
					uc = gx.pO.WebComponents[i].getUserControl(ContainerName);
					if (!gx.lang.emptyObject(uc))
						return uc;
				}
			}
			return uc;
		},

		CtrlId: function (ContainerId) {
			return ContainerId.replace(/Container$/, '');
		},

		userControlContainerId: function (ControlId) {
			var _Idx = ControlId.lastIndexOf("_");
			if (_Idx != -1) {
				var gridCtrlContainerId = ControlId.substring(0, _Idx) + "Container" + ControlId.substring(_Idx);
				if (gx.dom.byId(gridCtrlContainerId) != null)
					return gridCtrlContainerId;
			}
			if (ControlId.indexOf("ContainerDiv") >= 0)
				return ControlId;
			return ControlId + "Container";
		},

		setProperties: function (ControlId, Properties) {
			var UC = gx.uc.getUserControlObj(gx.uc.userControlContainerId(ControlId));
			if (UC != null) {
				if (Properties.length != undefined) {
					var len = Properties.length;
					for (var i = 0; i < len; i++) {
						for (var Prop in Properties[i]) {
							var PropValue = Properties[i][Prop];
							UC[Prop] = PropValue;
						}
					}
				}
				else {
					for (var Prop in Properties) {
						var PropValue = Properties[Prop];
						UC[Prop] = PropValue;
					}
				}
			}
		},

		isUserControl: function (ControlId, gxO) {
			gxO = gxO || gx.O;
			var ctrlContainer
			if (gx.lang.emptyObj(gxO.UserControls))
				return false;
			if (ControlId instanceof gx.uc.UserControl)
				return true;
			else {
				ctrlContainer = gx.dom.byId(gx.uc.userControlContainerId(ControlId));
				if (ctrlContainer && ctrlContainer.tagName === "DIV" && gx.dom.hasClass(ctrlContainer, gx.uc.gxCssClass))
						return true;
			}
			return false;
		},

		StartRender: function() {
			PostRenderScripts = {};
		},

		pushPostRenderScripts: function(uc) {
			$.each((uc && uc.Scripts) || [], function (i, script) {
				PostRenderScripts[script] = script;
			});
		},

		EndRender: function() {
			var arrScripts = gx.lang.objToArray(PostRenderScripts);
			var normalizedScripts = $.map(arrScripts, function (scriptUrl) {
				return gx.util.resourceUrl(gx.util.resolveUrl(scriptUrl), false);
			});
			gx.http.loadScripts(normalizedScripts, gx.emptyFn, 0, true);
		},

		UserControl: function () {
			this.ParentObject = null;
			this.GridId = ""
			this.GridRow = "";
			this.ControlId = 0;
			this.ControlLvl = 0;
			this.ContainerName = "";
			this.ControlName = "";
			this.LastIdBefore = 0;
			this.Properties = [];
			this.DynProperties = [];
			this.PropTypes = [];
			this.ValidFunctions = [];
			this.V2CFunctions = [];
			this.C2VFunctions = [];
			this.C2ShowFunction = null;
			this.RealControl = null;
			this.IsPostBack = null;

			this.clearFunctions = function () {
				this.ValidFunctions = [];
				this.V2CFunctions = [];
				this.C2VFunctions = [];
				this.C2ShowFunction = null;
			}

			this.me = function () {
				return "gx.getObj('" + this.ParentObject.CmpContext + "', " + this.ParentObject.IsMasterPage.toString() + ").getUserControl('" + this.ContainerName + "')";
			}

			this.getChildContainer = function (Name) {
				var rowSuffix = (this.GridRow != '') ? ('_' + this.GridRow) : '';
				var id = this.DesignContainerName + this.ControlName + "_" + Name + rowSuffix;
				var element = gx.dom.byId(id);
				if (!element) {
					id = this.DesignContainerName + Name + rowSuffix;
					element = gx.dom.byId(id);
				}
				return element;
			}

			this.getContainerControl = function () {
				return gx.dom.byId(this.ContainerName);
			}

			this.getRealControl = function () {
				if (this.RealControl)
					return this.RealControl;
				else 
					return this.getContainerControl();
			}

			this.setupControl = function (ParentObject, ControlName, FieldName, ControlId, LastId, GridLvl, GridId, GridRow) {
				this.ParentObject = ParentObject;
				this.ControlName = ControlName;
				this.ControlId = ControlId;
				this.LastIdBefore = LastId;
				this.ControlLvl = (GridLvl != undefined) ? GridLvl : 0;
				this.GridId = (GridId != undefined) ? GridId : 0;
				this.GridRow = (GridRow != undefined) ? GridRow : "";
				gx.util.pushOnceSorted( this.ControlId, this.ParentObject.GXCtrlIds);
				var ctx_gridRow = GridRow || "_norow";
				
				var vStruct = this.ParentObject.GXValidFnc[this.ControlId];
				if (!vStruct)
				{
					this.ParentObject.GXValidFnc[this.ControlId] = 
					{
						id: this.ControlId,
						lvl: this.ControlLvl,
						fld: FieldName,
						grid: this.GridId,
						op: [],
						ip: [],
						isuc: true,
						uc: this,
						fnc: this.validateControl
					};
					vStruct = this.ParentObject.GXValidFnc[this.ControlId];
				}
				vStruct = this.ParentObject.GXValidFnc[this.ControlId];
				vStruct.ucInstances = vStruct.ucInstances || {};
				vStruct.ucInstances[ctx_gridRow] = this;
				vStruct.getUCInstance = function( sRow) {
					var sRow = sRow || ctx_gridRow;
					return vStruct.ucInstances[sRow];
				} 
			}

			this.addValidFunction = function (Func, VarName, CtrlName) {
				this.ValidFunctions.push(Func);
				var rowSuffix = (this.GridRow == "") ? "" : "_" + this.GridRow;
				this.ParentObject.addUsercontrolBinding(VarName, CtrlName + rowSuffix, this);
			}

			this.validateControl = function () {
				gx.csv.validatingUC = this;
				var len = this.ValidFunctions.length;
				var fn;
				for (var i = 0; i < len; i++) {
					fn = this.ValidFunctions[i];
					if (fn) {
						var bRet = fn.call(gx.O);
						if (!bRet) {
							gx.O.AnyError = 1;
							gx.csv.validatingUC = null;
							return false;
						}
					}
				}
				gx.csv.validatingUC = null;
				return true;
			}

			this.attachEvents = function () {
				try {
					var ctrl = this.getContainerControl();
					if (!gx.lang.emptyObject(document.frames)) {
						var docFrames = document.frames.length;
						if (docFrames > 0) {
							var i = 0;
							for (i = 0; i < docFrames; i++) {
								var frame = document.frames[i];
								if (gx.dom.isChildNode(frame, ctrl) == true) {
									frame.frameElement.onfocus = this.onfocus;
									this.RealControl = frame.frameElement;
									return;
								}
							}
						}
					}
					else {
						ctrl.onfocus = this.onfocus;
						this.RealControl = ctrl;
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'attachEvents');
				}
			}

			this.onfocus = function () {
				gx.evt.onfocus(this.getRealControl(), this.ControlId, this.ParentObject.CmpContext, this.ParentObject.IsMasterPage, this.GridRow, this.GridId);
				gx.csv.lastId = this.ControlId;
				//this.execShowFunction(); No dibuja nuevamente user control.
				if (!gx.csv.anyError)
					this.setFocusBase();
			}

			this.oninput = function () {
				if (this.autoRefreshFn) {
					this.autoRefreshFn();
				}
			}

			this.onchange = function () {
				if (this.GridId > 0) {
					gx.fn.getGridObj(this.GridId).setRowModified(gx.fn.currentGridRow(this.GridId));
				}
			};

			this.setFocusBase = function () {
				if (typeof (this.setFocus) == 'function') {
					this.setFocus();
				}
			}

			this.setHtml = function (InnerHtml) {
				if (gx.dom.shouldPurge())
					gx.dom.purge(this.getContainerControl(), true);
				this.getContainerControl().innerHTML = InnerHtml;
			}

			this.createWebComponent = function (CtrlName, PgmName, Parms, TargetCtrlId, CmpPrefix) {
				this.ParentObject.createWebComponent(CtrlName, PgmName, Parms, this.GridRow, TargetCtrlId, CmpPrefix);
			}

			this.deleteWebComponent = function (CtrlName) {
				var cmpCtx = gx.fn.cmpContextFromCtrl(CtrlName);
				this.ParentObject.deleteComponent(cmpCtx);
			}

			this.notifyContext = function (Types, Obj) {
				gx.fx.ctx.notify(null, Types, Obj);
			}

			this.addV2CFunction = function () {
				var varName,
					ctrlName,
					method,
					member,
					prop;
				if (typeof(arguments[0]) == "function") {
					ctrlName = arguments[1]
					this.V2CFunctions.push(arguments[0]);
					varName = gx.fn.getVarControlMap(this.ParentObject, ctrlName);
					if (varName !== undefined) {
						this.ParentObject.addUsercontrolBinding(varName, ctrlName, this);
					}
				}
				else {
					varName = arguments[0];
					ctrlName = arguments[1];
					method = arguments[2];
					member = arguments[3];
					this.ParentObject.addUsercontrolBinding(varName, ctrlName, this);
					this.V2CFunctions.push(function(UC, gRow, readControlValue){
						var control = ctrlName;
						if (readControlValue) {
							if (gRow) {
								control = ctrlName + "_" + gRow;
							}
							if (member) {
								UC.ParentObject[varName][member] = gx.fn.getControlValue(control);
							}
							else {
								UC.ParentObject[varName] = gx.fn.getControlValue(control);
							}
						}
						var value = UC.ParentObject[varName];
						if (UC.useGxDateForBindings) {
							var varControlMap = gx.fn.getVarControlMapForVar(varName);
							if (varControlMap.type === "date" || varControlMap.type === "dtime") {
								if (typeof value === "string") {
									if (UC.IsPostBack) {
										value = (new gx.date.gxdate(value));
									}
									else {
										value = (new gx.date.gxdate(value, "Y4MD"));
									}
								}
							}
						}
						UC[method](value);
					});
				}
			}

			this.addC2VFunction = function (Func) {
				this.C2VFunctions.push(Func);
			}

			this.setC2ShowFunction = function (ShowFunc) {
				this.C2ShowFunction = ShowFunc;
			}

			this.execV2CFunctions = function (readControlValue) {
				var tCmp = gx.csv.cmpCtx;
				gx.csv.cmpCtx = this.ParentObject.CmpContext;
				var i = 0;
				var funcs = this.V2CFunctions;
				var len = funcs.length;
				for (i = 0; i < len; i++) {
					try {
						funcs[i](this, this.GridRow, readControlValue);
					}
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'execV2CFunctions');
					}
				}
				gx.csv.cmpCtx = tCmp;
			}

			this.execC2VFunctions = function () {
				var tCmp = gx.csv.cmpCtx;
				gx.csv.cmpCtx = this.ParentObject.CmpContext;
				var i = 0;
				var funcs = this.C2VFunctions;
				var len = funcs.length;
				for (i = 0; i < len; i++) {
					try { funcs[i](this, this.GridRow); }
					catch (e) {
						gx.dbg.logEx(e, 'gxfrmutl.js', 'execC2VFunctions');
					}
				}
				gx.csv.cmpCtx = tCmp;
			}
			
			this.sdtV2c = function (sdtMember, row, member, varName, setMethod) {
				var index;
				if (row !== null) {
					index = parseInt(row, 10) - 1;
					if (this.ParentObject[sdtMember][index] !== undefined) {
						this[setMethod](this.ParentObject[sdtMember][index][member]); 
					}
				}
				else {
					this.ParentObject[sdtMember] = gx.fn.getControlValue(varName, null, this.ParentObject);
					this[setMethod](this.ParentObject[sdtMember][member]); 
				}
			}

			this.sdtC2v = function (sdtMember, row, member, varName, getMethod) {
				var index;
				if (row !== null) {
					index = parseInt(row, 10) - 1;
					this.ParentObject[sdtMember][index][member] = this[getMethod]();
				}
				else {
					this.ParentObject[sdtMember][member] = this[getMethod]();
				}
				gx.fn.setControlValue(varName, this.ParentObject[sdtMember]);
			}

			this.execShowFunction = function () {
				if (this.IsPostBack === false) {
					this.IsPostBack = true;
				}
				if (this.IsPostBack === null) {
					this.IsPostBack = false;
				}

				var container = this.getContainerControl();
				try {
					if (this.C2ShowFunction != null && container) {
						this.C2ShowFunction(this);
					}
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'execShowFunction');
				} 	

				if (container) {
					if (this.autoToggleVisibility) {
							var $set = $(container).add("label[for='" + this.LabelForAttValue + "']");
							if (gx.lang.gxBoolean(this.Visible)) {
								$set.show();
							}
							else {
								$set.hide();
							}
					}

					gx.plugdesign.applyTemplateObject({
						selector:"#" + container.id,
						templateSelector: function(t) {
							return t.onDemandInvoke === true;
						}
					});
				}
				gx.uc.pushPostRenderScripts( this);
			}

			this.updateAndShow = function (show) {
				try {
					this.execV2CFunctions(show);
				}
				catch (e) {
					gx.dbg.logEx(e, 'gxfrmutl.js', 'updateAndShow');
				}

				if (show) {
					this.execShowFunction();
				}
			};
			
			this.getEventRow = function () {
				return this.GridRow;
			}

			this.isServerEvent = function (eventName) {
				var gxO = this.ParentObject,
					suffix = gxO.IsMasterPage ? "_MPAGE" : "",
					serverEvtName = this.ControlName.toUpperCase() + suffix + "." + eventName.toUpperCase() + suffix,
					clientEvtName = gxO.getClientEventName(serverEvtName);
				if (clientEvtName) {
					return gxO.isServerEvent(clientEvtName);
				}
				else {
					gx.dbg.logDebug("Client event name couldn't be resolved.");
					return false;
				}
			}

			this.eventHandler = function (gridId, gridRow, Handler) {
				gx.evt.setReady(false);	
				var gxOld = gx.O;
				var endCallBack = function (gxO) {
					gx.setGxO(gxO);
					gx.evt.setReady(true);
				};				
				gx.setGxO(this.ParentObject);
				if (gridId > 0) {
					var objVarName = this.DesignContainerName;
					var cRegex = new RegExp('^(?:' + this.ParentObject.CmpContext + ')?(.+)$');
					var isMatch = cRegex.exec(this.DesignContainerName);
					if (isMatch && isMatch[1]) {
						objVarName = isMatch[1];
					}
					this.ParentObject[objVarName] = this;
					var gridObj = this.ParentObject.getGridById(gridId);
					if (gridObj) {
						gridObj.instanciateRow(gridRow);
					}
				}
				this.execC2VFunctions();
				Handler.call(this.ParentObject, this.getEventRow()).always(endCallBack.closure(this, [gxOld]));
				gx.csv.instanciatedRowGrid = null;
				
			}

			this.addEventHandler = function (EventName, Handler) {
				this[EventName] = (function (callback) {
					var isServerEvent = this.isServerEvent(EventName);
					if (isServerEvent && typeof (callback) === "function") {
						gx.fx.obs.addObserver('gx.onafterevent', this, callback, { single: true });
					}
					this.eventHandler(this.GridId, this.GridRow, Handler);
					if (!isServerEvent && typeof (callback) === "function") {
						callback.call(this);
					}
				}).closure(this);
			}

			this.addProperty = function (PropName, HiddenName) {
				this.Properties[PropName] = HiddenName;
			}

			this.setProp = function (PropName, HiddenName, PropValue, PropType) {
				this.addProperty(PropName, HiddenName);
				this.PropTypes[PropName] = PropType;
				if (gx.lang.isBooleanType(PropType))
					this[PropName] = gx.lang.gxBoolean(PropValue);
				else if (PropType == 'color') {
					if (!gx.lang.emptyObject(PropValue))
						this[PropName] = (typeof (PropValue) == 'number' || typeof (PropValue) == 'string') ? gx.color.html(PropValue) : PropValue;
				}
				else if (gx.lang.isNumericType(PropType)) {
					if (!gx.lang.emptyObject(PropValue)) {
						this[PropName] = gx.num.parseFloat(PropValue);
					}
				}
				else
					this[PropName] = PropValue;
			}

			this.setDynProp = function (PropName, HiddenName, PropValue, PropType, immediate) {
				this.addProperty(PropName, HiddenName);
				this.DynProperties.push(PropName);
				this.PropTypes[PropName] = PropType;
				var doSetDynProp = function () {
					var value = this.getDynPropertyValueFromHidden(PropName, HiddenName);
					if (value === undefined) {
						value = PropValue;
					}
					this.setProp(PropName, HiddenName, value, PropType);
				};

				if (immediate) {
					doSetDynProp.call(this);
				}
				else {
					if (this.ParentObject.CmpContext) {
						var webComRenderHandler = function (gxComponent) {
							if (gxComponent === this.ParentObject) {
								doSetDynProp.call(this);
							}
						};
						gx.fx.obs.addObserver('webcom.render', this, webComRenderHandler);
					}
					else {
						gx.wr(doSetDynProp, this);						
					}
				}
			}

			this.refreshDynProperties = function () {
				for (var i = 0, len = this.DynProperties.length; i < len; i++) {
					var propName = this.DynProperties[i],
						hiddenName = this.Properties[propName];
					this[propName] = this.getDynPropertyValueFromHidden(propName, hiddenName);
				}
			}
			
			this.getDynPropertyValueFromHidden = function(PropName, HiddenName) {
				var value = gx.fn.getHidden(this.getHiddenName(HiddenName));
				if (value === undefined) {
					value = gx.fn.getHidden(this.getHiddenName(PropName));
				}
				return value;
			};

			this.setGridProperties = function () {
				var hiddenPropValue;
				var props = this.ParentObject.getGridUCProperties(this.ControlName);
				var len = props.length;
				for (var i = 0; i < len; i++) {
					var prop = props[i];
					var propValue = prop.v;
					var hiddenName = this.getHiddenName(prop.h);
					hiddenPropValue = gx.fn.getHidden(hiddenName);
					if (propValue === undefined || hiddenPropValue !== undefined) {
						propValue = hiddenPropValue;
						if (prop.t == 'color') {
							propValue = gx.color.html(propValue);
						}
					}
					this.setProp(prop.p, prop.h, propValue, prop.t);
				}
			}

			this.setGridEventHandlers = function () {
				var handlers = this.ParentObject.getGridUCEventHandlers(this.ControlName);
				var len = handlers.length;
				for (var i = 0; i < len; i++) {
					var hdlr = handlers[i];
					this.addEventHandler(hdlr.e, hdlr.h);
				}
			}

			this.getHiddenName = function (HiddenName) {
				var gridRow = '',
					controlName = this.ControlName.toUpperCase();
				if (this.GridRow != '') {
					gridRow = '_' + this.GridRow;
					if (this.ownerGrid) {
						controlName = this.ownerGrid.realGridName.toUpperCase()
					}
				}
				return this.ParentObject.CmpContext + controlName + (this.ParentObject.IsMasterPage ? '_MPAGE' : '') + "_" + HiddenName + gridRow;
			}

			this.saveProperties = function () {
				for (var prop in this.Properties) {
					if (this.hasOwnProperty(prop)) {
						var propValue = this[prop];
						if (typeof (this.Properties[prop]) != 'function') {
							if (typeof (propValue) != 'undefined' && typeof (propValue.R) != 'undefined' && typeof (propValue.G) != 'undefined' && typeof (propValue.B) != 'undefined') {
								propValue = gx.color.rgb(propValue.R, propValue.G, propValue.B);
							}
							if (gx.lang.isBooleanType(this.PropTypes[prop])) {
								propValue = (propValue ? 1 : 0);
							}
							gx.fn.setHidden(this.getHiddenName(this.Properties[prop]), propValue);
						}
					}
				}
			}
		}
	};
})(gx.$);
/* END OF FILE - ..\js\gxfrmutl.js - */
/* START OF FILE - ..\js\gxlast.js - */
gx._init();
if (window.$)
	gx.dbg.write('Warning: Using custom $ version.');
else {
	window.$ = gx.$
	gx.dbg.write('Using jquery from GX distr.');
}
if (!window.$.fn || !window.$.fn.jquery)
	gx.dbg.write('Warning: $ is not a jQuery object instance');
else
	gx.dbg.write('global $ is jquery' + window.$.fn.jquery);
	
/* END OF FILE - ..\js\gxlast.js - */
/* START OF FILE - ..\GenCommon\js\modernizr.js - */
/* Modernizr 2.8.3 (Custom Build) | MIT & BSD
 * Build: http://modernizr.com/download/#-flexbox-csstransitions-history-testprop-testallprops-domprefixes
 */
;



window.Modernizr = (function( window, document, undefined ) {

    var version = '2.8.3',

    Modernizr = {},


    docElement = document.documentElement,

    mod = 'modernizr',
    modElem = document.createElement(mod),
    mStyle = modElem.style,

    inputElem  ,


    toString = {}.toString,    omPrefixes = 'Webkit Moz O ms',

    cssomPrefixes = omPrefixes.split(' '),

    domPrefixes = omPrefixes.toLowerCase().split(' '),


    tests = {},
    inputs = {},
    attrs = {},

    classes = [],

    slice = classes.slice,

    featureName,



    _hasOwnProperty = ({}).hasOwnProperty, hasOwnProp;

    if ( !is(_hasOwnProperty, 'undefined') && !is(_hasOwnProperty.call, 'undefined') ) {
      hasOwnProp = function (object, property) {
        return _hasOwnProperty.call(object, property);
      };
    }
    else {
      hasOwnProp = function (object, property) { 
        return ((property in object) && is(object.constructor.prototype[property], 'undefined'));
      };
    }


    if (!Function.prototype.bind) {
      Function.prototype.bind = function bind(that) {

        var target = this;

        if (typeof target != "function") {
            throw new TypeError();
        }

        var args = slice.call(arguments, 1),
            bound = function () {

            if (this instanceof bound) {

              var F = function(){};
              F.prototype = target.prototype;
              var self = new F();

              var result = target.apply(
                  self,
                  args.concat(slice.call(arguments))
              );
              if (Object(result) === result) {
                  return result;
              }
              return self;

            } else {

              return target.apply(
                  that,
                  args.concat(slice.call(arguments))
              );

            }

        };

        return bound;
      };
    }

    function setCss( str ) {
        mStyle.cssText = str;
    }

    function setCssAll( str1, str2 ) {
        return setCss(prefixes.join(str1 + ';') + ( str2 || '' ));
    }

    function is( obj, type ) {
        return typeof obj === type;
    }

    function contains( str, substr ) {
        return !!~('' + str).indexOf(substr);
    }

    function testProps( props, prefixed ) {
        for ( var i in props ) {
            var prop = props[i];
            if ( !contains(prop, "-") && mStyle[prop] !== undefined ) {
                return prefixed == 'pfx' ? prop : true;
            }
        }
        return false;
    }

    function testDOMProps( props, obj, elem ) {
        for ( var i in props ) {
            var item = obj[props[i]];
            if ( item !== undefined) {

                            if (elem === false) return props[i];

                            if (is(item, 'function')){
                                return item.bind(elem || obj);
                }

                            return item;
            }
        }
        return false;
    }

    function testPropsAll( prop, prefixed, elem ) {

        var ucProp  = prop.charAt(0).toUpperCase() + prop.slice(1),
            props   = (prop + ' ' + cssomPrefixes.join(ucProp + ' ') + ucProp).split(' ');

            if(is(prefixed, "string") || is(prefixed, "undefined")) {
          return testProps(props, prefixed);

            } else {
          props = (prop + ' ' + (domPrefixes).join(ucProp + ' ') + ucProp).split(' ');
          return testDOMProps(props, prefixed, elem);
        }
    }    tests['flexbox'] = function() {
      return testPropsAll('flexWrap');
    };
    tests['history'] = function() {
      return !!(window.history && history.pushState);
    };


    tests['csstransitions'] = function() {
        return testPropsAll('transition');
    };



    for ( var feature in tests ) {
        if ( hasOwnProp(tests, feature) ) {
                                    featureName  = feature.toLowerCase();
            Modernizr[featureName] = tests[feature]();

            classes.push((Modernizr[featureName] ? '' : 'no-') + featureName);
        }
    }



     Modernizr.addTest = function ( feature, test ) {
       if ( typeof feature == 'object' ) {
         for ( var key in feature ) {
           if ( hasOwnProp( feature, key ) ) {
             Modernizr.addTest( key, feature[ key ] );
           }
         }
       } else {

         feature = feature.toLowerCase();

         if ( Modernizr[feature] !== undefined ) {
                                              return Modernizr;
         }

         test = typeof test == 'function' ? test() : test;

         if (typeof enableClasses !== "undefined" && enableClasses) {
           docElement.className += ' ' + (test ? '' : 'no-') + feature;
         }
         Modernizr[feature] = test;

       }

       return Modernizr; 
     };


    setCss('');
    modElem = inputElem = null;


    Modernizr._version      = version;

    Modernizr._domPrefixes  = domPrefixes;
    Modernizr._cssomPrefixes  = cssomPrefixes;



    Modernizr.testProp      = function(prop){
        return testProps([prop]);
    };

    Modernizr.testAllProps  = testPropsAll;


    return Modernizr;

})(this, this.document);
;
/* END OF FILE - ..\GenCommon\js\modernizr.js - */
/* START OF FILE - ..\GenCommon\js\spa.js - */
/*global _gaq:true, Modernizr:true, gx:true  */

gx.spa = (function ($) {
	var CONTENT_PLACEHOLDER_CLASS = 'gx-content-placeholder',
		GX_SPA_REQUEST_HEADER = 'X-SPA-REQUEST',
		GX_SPA_MASTERPAGE_HEADER = 'X-SPA-MP',
		GX_SPA_GXOBJECT_RESPONSE_HEADER = 'X-GXOBJECT',
		GX_SPA_REDIRECT_URL = 'X-SPA-REDIRECT-URL',
		GX_SPA_RETURN = 'X-SPA-RETURN',
		GX_SPA_RETURN_METADATA = 'X-SPA-RETURN-MD',
		SERVER_REQUEST_DEFAULT_TIMEOUT = -1,
		TRANSITION_TIMEOUT = 800,
		SPA_NOT_SUPPORTED_STATUS_CODE = 530,
		ENTERING_FX_CLASS = 'entering',
		LEAVING_FX_CLASS = 'leaving',
		ENTER_FX_DURATION_CLASS = 'enter-fx-duration',
		LEAVE_FX_DURATION_CLASS = 'leave-fx-duration',
		HEAD_ELEMENT_PATTERN = "<head[^>]*>([\\s\\S]*?)<\/head>",
		HEAD_ELEMENT_REGEX = new RegExp(HEAD_ELEMENT_PATTERN, "i"),
		BODY_ELEMENT_PATTERN = "(<body[^>]*>[\\s\\S]*?<\/body>)",
		BODY_ELEMENT_REGEX = new RegExp(BODY_ELEMENT_PATTERN, "i"),
		TITLE_ELEMENT_PATTERN = "<title[^>]*>([\\s\\S]*?)<\/title>",
		TITLE_ELEMENT_REGEX = new RegExp(TITLE_ELEMENT_PATTERN, "i"),
		HASH_END_REGEX = /#.*/,
		HASH_REGEX = /#/;
		
	var navigating = false,
		transitioning = false,
    /* jshint ignore:start */
		initialUrl = window.location.href,
    /* jshint ignore:end */
		initialPop = true,
		ignoredSelectors = {};

	// Used to keep a reference to click and popstate handles.
	var handleClick, handlePopState;

	if ('state' in window.history) {
		initialPop = false;
	}
	
	// Messages can't be cached for SPA.
	gx.wpo( function () {
			if (gx.pO.fullAjax) {
				gx.cache.exceptionsRegEx = /messages\..+\.js/;
			}
		}, this);
	
	var handleNavigationEnd = function () {
		if (!navigating && !transitioning) {
			this.notify('onnavigatecomplete');
		}
	};

	return {
		// Default server request timeout
		timeout: SERVER_REQUEST_DEFAULT_TIMEOUT,
		
		setTimeout: function (timeout) {
			this.timeout = timeout;
		},
		
		isSameApp: function (location, parsedUrl) {
			var samePort = location.port === parsedUrl.port;
			samePort = samePort || (location.port === "" && location.protocol === "http:" && parsedUrl.port === "80");
			samePort = samePort || (location.port === "" && location.protocol === "https:" && parsedUrl.port === "443");
			return location.protocol === parsedUrl.protocol && location.hostname === parsedUrl.hostname && samePort;
		},

		handleClick: function (event) {
			var link = this.getTarget(event),
				selector, $link;

			if (!link)
				return;

			if (link.tagName.toUpperCase() !== 'A')
				return;

			if (link.getAttribute('href') === null || link.getAttribute('href') === undefined)
				return;

			// Ignore _blank, _parent, _top and named targets when they are different from the current browsing context.
			if (link.target && (link.target == '_blank' || (link.target == '_parent' && window.parent != window) || (link.target == '_top' && window.top != window) || (link.target.substr(0, 1) != '_' && window.name != link.target)))
				return;

			// Middle click, cmd click, and ctrl click should open
			// links in a new tab as normal.
			if (event.which > 1 || event.metaKey || event.ctrlKey)
				return;

			var parsedUrl = this.parseUrl(link.href);
			// Ignore cross origin links
			if (!this.isSameApp(location, parsedUrl)) 
				return;

			// Ignore links to resources outside current path (images or other static resources are ignored)
			var targetPath = (parsedUrl.pathname.charAt(0) == '/' ? parsedUrl.pathname : '/' + parsedUrl.pathname);
			if (location.pathname.substring(0, location.pathname.lastIndexOf('/')) !== targetPath.substring(0, targetPath.lastIndexOf('/')))
				return;

			// Ignore anchors on the same page and empty anchor "foo.html#"
			if (parsedUrl.href.search(HASH_REGEX) >= 0 && parsedUrl.href.replace(HASH_END_REGEX,'') === location.href.replace(HASH_END_REGEX,''))
				return;

			// Ignore empty href
			if (link.getAttribute('href') === '')
				return;

			// Ignore javascript: anchors
			if (link.href.indexOf('javascript:') === 0)
				return;
			
			// Hack for ignore Click. Used for HistoryManager
			if (this.ignoreClick) {
				this.ignoreClick = false;
				return;
			}

			$link = $(link);
			for (selector in ignoredSelectors) {
				if (ignoredSelectors.hasOwnProperty(selector)) {
					if ($link.is(selector)) {
						return;
					}
				}
			}
			
			this.navigate({
				url: link.href,
				push: true,
				scrollTo: true,
				direction: 'forward'
			});

			event.preventDefault();
		},

		redirect: function (url, push) {
			delete(gx.referrer);
			push = (push === undefined) || push;
			var parsedUrl = this.parseUrl(url),
				targetPath = (parsedUrl.pathname.charAt(0) == '/' ? parsedUrl.pathname : '/' + parsedUrl.pathname);
			// Ignore cross origin links
			if (!this.isSameApp(location, parsedUrl)) {
				window.location = url;
			}
			// Ignore links to resources outside current path (images or other static resources are ignored)
			else if (location.pathname.substring(0, location.pathname.lastIndexOf('/')) !== targetPath.substring(0, targetPath.lastIndexOf('/'))) {
				window.location = url;
			}
			else {
				gx.referrer = location.href;
				this.navigate({
					url: url,
					push: push,
					scrollTo: true,
					direction: 'forward'
				});
			}
		},

		setLocation: function (url) {
			if (gx.util.browser.isFirefox()) {
				// This is to avoid a FF bug. If location is set in a callback of an AJAX request to the same url,
				// the AJAX response is loaded, instead of the server response to the standard request.
				gx.lang.doCallTimeout( function () {
					this.setStopNavigating(url);
					window.location.href = url;
				}, this, [url], 100);						
			}
			else {
				this.setStopNavigating(url);
				window.location = url;
			}
		},

		canNavigate: function () {
			return !navigating && !transitioning;
		},
		
		isNavigating: function () {
			return !this.canNavigate();
		},

		isNavigatingRaw: function() {
			return navigating;
		},
		
		setStopNavigating: function (url) {
			navigating = false;
			this.notify('onnavigate', [url]);
		},

		navigate: function (options) {
			var timeoutTimer,
				request,
				url = options.url,
				cancelled = false;

			if (!this.canNavigate()) {
				this.setLocation(url);
				return;
			}
			navigating = true;

			this.notify('onbeforenavigate', [url]);

			request = this.request;
			
			// Current request is cancelled if we're already retrieving a page.
			if (request && request.readyState < 4) {
				request.onreadystatechange = gx.emptyFn;
				gx.dbg.logMsg('Request cancelled as data ir already being retrieved: ' + request.readyState);
				request.abort();
			}

			request = gx.http.doCall({
				method: 'GET',
				url: url,
				handler: function (type, responseText, req) {
					var redirectUrl = req.getResponseHeader(GX_SPA_REDIRECT_URL),
						gxObjectClass = req.getResponseHeader(GX_SPA_GXOBJECT_RESPONSE_HEADER);

					if (cancelled) {
						return;
					}

					if (timeoutTimer) {
						clearTimeout(timeoutTimer);
					}

					if (req.status == SPA_NOT_SUPPORTED_STATUS_CODE) {
						this.setLocation(url);
						return;
					}

					if (redirectUrl) {
						this.setStopNavigating(redirectUrl);
						setTimeout(gx.spa.redirect.closure(gx.spa, [redirectUrl]), 100);
						return;
					}

					// If the response does not support SPA, do not push the new URL (for example, a PDF)
					if (options.push && request.readyState > 0 && gxObjectClass) {
						this.updateState();
						this.state = this.createState(options);
						// Replace history entry
						window.history.pushState(null, "", request.responseURL || url);
					}

					this.processResponse.call(this, responseText, req, options);
				},
				beforeSend: function (req) {
					this.notify('onbeforesend', [this.createEvent(req, url), GX_SPA_REQUEST_HEADER, GX_SPA_MASTERPAGE_HEADER]);
					if (this.timeout > 0) {
						timeoutTimer = setTimeout(this.timeoutHandler.closure(this, [req, url]), this.timeout);
					}
					req.setRequestHeader(GX_SPA_REQUEST_HEADER, '1');
				},
				offline: function () {
					if (timeoutTimer)
						clearTimeout(timeoutTimer);
					cancelled = true;
					navigating = false;
				},
				error: function (req) {
					var eventObject = this.createEvent(req, url);
					eventObject.cancel = true; // Cancel by default
					this.notify('onerror', [eventObject]);
					if (eventObject.cancel) {
						this.setLocation(url);
					}
				},
				ajaxHeader: false,
				avoidCache: false,
				handleAllStatusCodes: true,
				obj: this
			});

			this.request = request;

			this.notify('onnavigatestart', [url]);
		},

		processResponse: function (responseText, req, options) {
			var url;
			try {
				url = options.url;
				var parsedUrl = this.parseUrl(url),
					hash = parsedUrl.hash,
					direction = options.direction,
					responseStatus = req.status,
					gxObjectClass = req.getResponseHeader(GX_SPA_GXOBJECT_RESPONSE_HEADER),
					gxReturnCmd = req.getResponseHeader(GX_SPA_RETURN),
					gxReturnCmdMetadata = req.getResponseHeader(GX_SPA_RETURN_METADATA),
					eventObject = this.createEvent(req, url),
					sourceMpObj = gx.pO.MasterPage,
					sourceMpClass = gx.pO.MasterPage ? gx.pO.MasterPage.ServerClass : "",
					targetMpClass = req.getResponseHeader(GX_SPA_MASTERPAGE_HEADER) || "",
					sameMp = !(sourceMpClass === "" || sourceMpClass.toLowerCase() != targetMpClass.toLowerCase()),
					placeholder = this.getContentPlaceholder();

				if (gxReturnCmd !== null) {					
					gx.fn.closeWindowServerScript(gxReturnCmd, gxReturnCmdMetadata, true);	
					return;
				}

				// Do not retry redirect when a server http 500 error ocurrs.
				if (responseStatus === 500) {
					window.history.pushState(null, "", url);
					gx.dom.writeError( req.responseText, gx.getMessage("GXM_runtimeappsrv"), responseStatus);
					return;
				}

				// If the response does not support SPA, redirect (for example, a PDF)
				if (!gxObjectClass) {
					this.setLocation(url);
					return;
				}

				this.notify('onbeforeprocessresponse', [eventObject, responseText, gxObjectClass, sourceMpClass, targetMpClass, sameMp]);

				var contents = this.extractContents(req, !sameMp),
					oldContent = sameMp ? placeholder.firstChild : document.body,
					newContent = contents.body;

				if (!contents.body) {
					this.setLocation(url);
					return;
				}

				this.state = this.createState(options);

				if (options.push) {
					window.history.replaceState(this.state, '', req.responseURL || url);
				}

				if (contents.title) {
					document.title = contents.title;
				}

				this.notify('onbeforecontentreplace', [req, url, contents]);

				gx.cache.removeRemoteFile(gx.getThemeElement().href);
				gx.dom.replaceWithFx(oldContent, newContent, {
					domRemove: false,
					domAdd: sameMp,
					enteringClass: (direction == 'forward' ? ENTERING_FX_CLASS : LEAVING_FX_CLASS),
					leavingClass: (direction == 'forward' ? LEAVING_FX_CLASS : ENTERING_FX_CLASS),
					enterDurationClass: (direction == 'forward' ? ENTER_FX_DURATION_CLASS : LEAVE_FX_DURATION_CLASS),
					leaveDurationClass: (direction == 'forward' ? LEAVE_FX_DURATION_CLASS : ENTER_FX_DURATION_CLASS),
					transitionTimeout: TRANSITION_TIMEOUT,
					transitionEndCallback: (function () {
						newContent = this.replaceContentCallback(req, url, hash, responseText, placeholder, contents, oldContent, newContent, options, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp);
						if (!sameMp) {
							gx.html.processCode(contents.head.innerHTML + contents.body.innerHTML, false, this.processCodeCallback.closure(this, [req, url, hash, responseText, placeholder, contents, oldContent, newContent, options, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp]), null, null, false, true);
						}
						transitioning = false;
						this.notify('ontransitionend', [eventObject, sourceMpObj, sourceMpClass, targetMpClass, sameMp]);					
						this.recoverScrollPosition(options);
						return newContent;
					}).closure(this),
					beforeTransitionStart: (function (applyTransFn) {
						transitioning = true;
						if (sameMp) {
							gx.html.processCode(responseText, false, (function () {
								if (applyTransFn) {
									applyTransFn();
								}
								this.processCodeCallback(req, url, hash, responseText, placeholder, contents, oldContent, newContent, options, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp);
							}).closure(this), null, null, false);
							return true;
						}
					}).closure(this)
				});

			}
			catch (e) {
				gx.dbg.logEx(e, 'gxspa.js', 'processResponse');
				this.setLocation(url);
			}
		},

		replaceContentCallback: function (req, url, hash, responseText, placeholder, contents, oldContent, newContent, options, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp) {
			if (sameMp) {
				if (oldContent.parentNode) {
					this.dettachContent(oldContent);
					oldContent.parentNode.removeChild(oldContent);
				}
			}
			else {
				if (gx.util.browser.isWebkit() || gx.util.browser.isFirefox()) {
					this.dettachContent(document.body);
					$(document.body).remove();
					var newBody = document.createElement('body');
					var attributes = $(newContent).prop("attributes");
					$.each(attributes, function() {
						$(newBody).attr(this.name, this.value);
					});
					document.documentElement.appendChild(newBody);
					newBody.innerHTML = newContent.innerHTML;
					newContent = newBody;
				}
				else {
					document.body = newContent;
					newContent = document.body; // WA for WebKit: After setting document.body, newContent reference is different from document.body
				}
				document.head = contents.head;
			}
			return newContent;
		},

		processCodeCallback: function (req, url, hash, responseText, placeholder, contents, oldContent, newContent, options, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp) {
			var eventObject = this.createEvent(req, url);

			try {
				this.notify('oncontentreplace', [eventObject, responseText, contents, gxObjectClass, sourceMpObj, sourceMpClass, targetMpClass, sameMp]);
			}
			catch (e) {
				gx.dbg.logEx(e, 'gxspa.js', 'processCodeCallback');
				this.setLocation(url);
			}

			var recoverScrollPosition = true;
			if (options.scrollTo) {
				window.scrollTo(0, 0);
				recoverScrollPosition = false;
			}

			// Google Analytics support
			if (options.push && window._gaq)
				_gaq.push(['_trackPageview']);

			if (options.push && window.ga)
				window.ga('send', 'pageview', location.pathname);
			
			// If the URL has a hash in it, make sure the browser
			// knows to navigate to the hash.
			if (hash !== '') {
				// Avoid using simple hash set here. Will add another history
				// entry. Replace the url with replaceState and scroll to target
				// by hand.
				//
				//   window.location.hash = hash
				var parsedUrl = this.parseUrl(url);
				parsedUrl.hash = hash;
				window.history.replaceState(this.state, "", parsedUrl.href);

				var target = gx.dom.el(parsedUrl.hash);
				if (target) {
					target.scrollIntoView(true);
					recoverScrollPosition = false;
				}
			}

			this.setStopNavigating(url);

			if (recoverScrollPosition) {
				this.recoverScrollPosition(options);
			}
		},

		timeoutHandler: function (req, url) {
			var eventObject = this.createEvent(req, url);
			eventObject.cancel = true; // Cancel by default
			this.notify('ontimeout', [eventObject]);
			if (eventObject.cancel) {
				req.abort();
				gx.dbg.logMsg('Request cancelled - timeout expired: ' + req.readyState);
				this.setLocation(url);
			}
		},

		getContentPlaceholder: function () {
			return gx.dom.byClass(CONTENT_PLACEHOLDER_CLASS)[0];
		},

		extractContents: function (req, isDocument) {
			var div = document.createElement('div'),
				contents = {},
				result;
			var headHTML,
				bodyHTML,
				iframe,
				iframeHead;


			if (isDocument) {
				iframe = document.createElement('iframe');
				iframe.src = 'about:blank';
				iframe.style.display = 'none';
				document.body.appendChild(iframe);
				var match = req.responseText.match(HEAD_ELEMENT_REGEX);
				if (match.length > 1) {
					headHTML = match[1];
				}
				match = req.responseText.match(BODY_ELEMENT_REGEX);
				if (match.length > 0) {
					bodyHTML = match[0];
				}
				match = req.responseText.match(TITLE_ELEMENT_REGEX);
				if (match.length > 1) {
					contents.title = match[1];
				}
				if (iframe.contentDocument && iframe.contentDocument.body == null) {
					iframe.contentDocument.write("<body></body>");
				}
				iframe.contentDocument.body.outerHTML = bodyHTML;
				iframeHead = iframe.contentDocument.head;
				iframeHead.innerHTML = headHTML;
				$('head script').each(function (i, script) {
					$(iframeHead).find('script').each(function (j, iframeScript) {
						if (script.getAttribute("data-gx-external-script") === null) {
							if (script.src == iframeScript.src) {
								iframeHead.removeChild(iframeScript);
							}
						}
						else {
							$(script).remove();
						}
					});
				});
				contents.body = iframe.contentDocument.body;
				contents.head = iframeHead;
			}
			else {
				gx.html.setInnerHtml(div, req.responseText, false, false, false);

				result = gx.dom.byClass(CONTENT_PLACEHOLDER_CLASS, 'div', div);
				if (result.length === 0)
					return contents;

				contents.body = result[0].firstChild;

				result = gx.dom.byTag('title', div);
				if (result.length > 0)
					contents.title = result[0].innerText || result[0].textContent;
			}
			return contents;
		},

		handlePopState: function (event) {
			/* jshint unused:vars */
			var state = event.state,
				placeholder = this.getContentPlaceholder();

			if (state && state.source == "gx-spa") {
				// When coming forward from a separate history session, will get an
				// initial pop with a state we are already at. Skip reloading the current
				// page.
				/* jshint ignore:start */
				if (initialPop && initialUrl == state.url)
					return;
				/* jshint ignore:end */

				// When coming from a URL with hash to the same URL without hash
				if (this.state.url === state.url) {
					return;
				}

				var direction = this.state.id < state.id ? 'forward' : 'back';

				this.navigate({
					id: state.id,
					url: state.url,
					push: false,
					scrollPosition: state.scrollPosition,
					direction: direction
				});

				// Force reflow/relayout before the browser tries to restore the
				// scroll position.
				if (placeholder) {
					void (placeholder.offsetHeight);
				}
			}
			
			if (gx.popup.ispopup()) {
				gx.fn.cancelWindow();
			}
		},

		parseUrl: function (url) {
			var a = document.createElement('a');
			a.href = url;
			return a;
		},

		createEvent: function (req, url) {
			return {
				req: req,
				url: url,
				cancel: false
			};
		},
		
		addIgnoredSelector: function (selector) {
			ignoredSelectors[selector] = true;
		},
		
		removeIgnoredSelector: function (selector) {
			delete ignoredSelectors[selector];
		},

		recoverScrollPosition: function (options) {
			// Recover scroll position when transitions and navigation have ended (this.canNavigate() === true)
			var scrollPos = options.scrollPosition;
			if (this.canNavigate() && !options.scrollTo && scrollPos) {
				window.scrollTo(scrollPos.x, scrollPos.y);
			}
		},

		dettachContent: function (oldContent){
			var focusEl = gx.dom.getActiveElement();
			if (focusEl && $.contains(oldContent, focusEl)) {				
				gx.dom.purgeElement(focusEl);
			}
		},

		updateState: function () {
			var state = this.state;
			state.url = location.href;
			state.scrollPosition = {
				x: window.scrollX,
				y: window.scrollY
			};
			window.history.replaceState(state, '', state.url);
		},

		createState: function (options) {
			options = options || {};
			return {
				id: options.id || (new Date()).getTime(),
				source: "gx-spa",
				url: options.url
			};
		},

		getTarget: function (evt) {
			if (evt.target && evt.target.tagName == 'A') {
				return evt.target;
			}
			return gx.dom.findParentByTagName(evt.target, 'A');
		},

		applyConfig: function (config) {
			if (config) {
				if (config.listeners) {
					for (var eventName in config.listeners) {
						var fn = config.listeners[eventName];
						if (typeof (fn) == 'function')
							this.addObserver(eventName, config.listeners.scope || this, fn);
					}
				}
			}
		},

		setBodyClass: function () {
			var className = "Form",
				body = document.body;
			if (body.className) {
				className = body.className.split(" ")[0];
			}
			if (!gx.dom.hasClass(body, className + '-fx')) {
				gx.dom.addClass(body, className + '-fx');
			}
		},

		isSupported: function () {
			// SPA is not enabled when:
			// - FullAjax is disabled
			// - History API is not supported by the browser
			// - The browser is Chrome and the webpage is running inside an iframe (Chrome bug)
			if (gx.util.browser.isIE() && !gx.util.browser.isEdge()) {
				return false;
			}
			return gx.pO && gx.pO.fullAjax && Modernizr.history && !(gx.util.browser.isChrome() && window.parent != window);
		},

		start: function (config) {
			if (this.isSupported() && !this.started) {
				this.applyConfig(config);
				handleClick = this.handleClick.closure(this);
				handlePopState = this.handlePopState.closure(this);
				document.addEventListener('click', handleClick, false);
				window.addEventListener('popstate', handlePopState, false);
				this.state = this.createState({
					url: location.href
				});
				window.history.replaceState(this.state, document.title);
				this.setBodyClass();
				this.started = true;
				this.addObserver('onnavigate', this, handleNavigationEnd);
				this.addObserver('ontransitionend', this, handleNavigationEnd);
			}
		},

		stop: function () {
			if (this.started) {
				document.removeEventListener('click', handleClick, false);
				window.removeEventListener('popstate', handlePopState, false);
				this.started = false;
			}
		}
	};
})(gx.$);

// Mixin with gx.util.Observable
gx.lang.apply(gx.spa, new gx.util.Observable());
/* END OF FILE - ..\GenCommon\js\spa.js - */
/* START OF FILE - ..\GenCommon\js\genexus-core.js - */
gx.core = {};

gx.core.analytics = (function($) {	
	var gaSupport = typeof(window.ga) !== 'undefined';
	
	return {			
		supported: function() {
			if (typeof(window.ga) === 'undefined'){
				console.log("Google Analytics - GA not enabled on this webpage");
				return false;
			}
			return true;
		},
		
		trackView: function(viewName) {
			if (this.supported())
				window.ga('send', 'pageview', viewName);
		},
		
		trackEvent: function(category, action, label, value) {
			if (this.supported())
				window.ga('send', {
						  hitType: 'event',
						  eventCategory: category,
						  eventAction: action,
						  eventLabel: label,
						  eventValue: value
						});	
		},
		
		trackPurchase: function(purchaseInfo) {
			var addProperty = function (obj, propertyName, propertyValue, required, defValue) {
				if (required && (gx.lang.emptyObject(propertyValue)) && defValue == null) {
					console.log("Google Analytics ECommerce - Warning: Property value must be assigned: ", propertyName);
					return false;
				}
	
				if (gx.lang.emptyObject(propertyValue) && required)
					propertyValue = defValue;
				if (!gx.lang.emptyObject(propertyValue)) {
					obj[propertyName] = propertyValue;
					return true;
				}
				return false;
			};

			if (this.supported()){
				window.ga('require', 'ecommerce');
				var pInfo = {},
					i = 0;
				if (addProperty(pInfo, 'id', purchaseInfo.TransactionId, true)) {
					addProperty(pInfo, 'affiliation', purchaseInfo.Affiliation);
					addProperty(pInfo, 'revenue', purchaseInfo.Revenue);
					addProperty(pInfo, 'shipping', purchaseInfo.Shipping);
					addProperty(pInfo, 'tax', purchaseInfo.Tax);
					addProperty(pInfo, 'currency', purchaseInfo.CurrencyCode);
					
					window.ga('ecommerce:addTransaction', pInfo);

					for (i = 0; i < purchaseInfo.Items.length; i++) {
						var pInfoItemSource = purchaseInfo.Items[i];
						var pInfoItem = {};
						if (addProperty(pInfoItem, 'id', purchaseInfo.TransactionId, true) && addProperty(pInfoItem, 'name', pInfoItemSource.Name, true)) {							
							addProperty(pInfoItem, 'sku', pInfoItemSource.Id);
							addProperty(pInfoItem, 'category', pInfoItemSource.Category);
							addProperty(pInfoItem, 'price', pInfoItemSource.Price);
							addProperty(pInfoItem, 'quantity', pInfoItemSource.Quantity);
							addProperty(pInfoItem, 'currency', pInfoItemSource.CurrencyCode);
							window.ga('ecommerce:addItem', pInfoItem);
						}
					};
					window.ga('ecommerce:send');				
				}
			}
		},
		
		setUserId: function(userId) {
			if (this.supported())
				window.ga('set', 'userId', userId);
		}
	}
})(gx.$);

gx.core.audio = (function($) {	
	var initialized;
	var playingSounds = [];
	var playingSoundsMix = [];
		
	var SESSION_TYPE_SOLO = 3;
	var SESSION_TYPE_MIX = 2;
	var SESSION_TYPE_BACKGROUND = 1;

	return {		
		supported: function() {			
			return !(gx.util.browser.isIE() && gx.util.browser.ieVersion() <= 8);
		},

		getSoundVar: function(audioSessionType) {	
			if (audioSessionType == SESSION_TYPE_MIX)
				return playingSoundsMix;
			return playingSounds[audioSessionType];			
		},

		playBackground: function(soundFilePath) {
			this.play(soundFilePath, SESSION_TYPE_BACKGROUND);
		},

		play: function(soundFilePath, audioSessionType) {		
			initialized = true;				
			if (audioSessionType != SESSION_TYPE_MIX) {
				this.stop(audioSessionType);
			}
			if (audioSessionType == SESSION_TYPE_SOLO) {
				this.stop(SESSION_TYPE_MIX);
				this.pauseSound(this.getSoundVar(SESSION_TYPE_BACKGROUND));
			}
			if (audioSessionType == SESSION_TYPE_MIX) {
				this.stop(SESSION_TYPE_SOLO);	
			}
			this.playSound(audioSessionType, soundFilePath).always( function () { 
				if (audioSessionType == SESSION_TYPE_SOLO) {
					this.resumeSound(this.getSoundVar(SESSION_TYPE_BACKGROUND));
				}
			}.closure(this, []));
		},

		playSound: function (audioSessionType, soundFilePath) {
			var deferred = $.Deferred();

			var playSoundVar;
			if (!this.supported()) {				
				playSoundVar = $("<bgsound/>").attr({
					id: 'gxIE7AudioSound_' + audioSessionType,
					loop: '0',
					src: soundFilePath
				});
				$('body').append(playSoundVar);				
			}
			else {
				playSoundVar = new Howl({
					src: [soundFilePath],
					html5: true, // Force to HTML5 so that the audio can stream in (best for large files).	
					onplay: function() {
					},
					onend: function() {
						deferred.resolve();
					},
					onstop: function() {
						deferred.resolve();
					},
					onpause: function() {
						deferred.resolve();
					}
				});
				playSoundVar.play();				
			}
			playingSounds[audioSessionType] = playSoundVar;
			if (audioSessionType == SESSION_TYPE_MIX)
				playingSoundsMix.push(playSoundVar);
			return deferred.promise();
		},

		stop: function(audioSessionType) {					
			if (!audioSessionType) {				
				this.stopSound(this.getSoundVar(SESSION_TYPE_SOLO));
				this.stopSound(this.getSoundVar(SESSION_TYPE_MIX));
				this.stopSound(this.getSoundVar(SESSION_TYPE_BACKGROUND));				
				return;
			}			
			var playSoundVar = this.getSoundVar(audioSessionType);
			this.stopSound(playSoundVar);		
			playingSounds[audioSessionType] = null;
		},

		stopSound: function(sound) {	
			var supported = this.supported();
			sound = (gx.lang.isArray(sound))? sound: [sound];
			$.map( sound, function( soundItem, i ) {
  				soundItem = sound[i];
				if (!supported && soundItem) {
					$(soundItem).attr('src', '');
					$(soundItem).remove();
					soundItem = undefined;					
				}
				if (soundItem && soundItem.stop) {
					soundItem.stop();
				}
			});													
		},

		pauseSound: function(sound) {			
			if (!this.supported()) {
				//console.log("Can't pause sound")
				return;
			}
			if (sound && sound.pause) {
				sound.pause();
			}							
		},

		resumeSound: function(sound) {			
			if (!this.supported()) {
				//console.log("Can't resume sound")
				return;
			}
			if (sound && sound.play) {
				sound.play();
			}							
		},

		
		isPlaying: function(audioSessionType) {			
			if (!this.supported()) {
				return;
			}
			if (!audioSessionType) {
				return  this.isPlaying_impl(this.getSoundVar(SESSION_TYPE_SOLO)) ||
						this.isPlaying_impl(this.getSoundVar(SESSION_TYPE_MIX)) ||
						this.isPlaying_impl(this.getSoundVar(SESSION_TYPE_BACKGROUND));
			}
			return this.isPlaying_impl(this.getSoundVar(audioSessionType));
		},

		isPlaying_impl: function(sound) {
			var soundItem,
				isPlaying = false;
			sound = (gx.lang.isArray(sound))? sound: [sound];
			for (var i = 0; i<sound.length; i++) {
				soundItem = sound[i];
				if (soundItem)
					isPlaying = isPlaying || soundItem.playing();				
			}
		},

		_deinit: function() {
			if (initialized) {
				this.stop(SESSION_TYPE_SOLO);
				this.stop(SESSION_TYPE_MIX);
				//Do not stop background music...
			}
			initialized = false;
		}

		/*getQueue: function() {
			if (!this.supported()) {
				return;
			}
			return playingSound.src;
		}*/
	}
})(gx.$);

gx.core.pwa = (function ($) {
	var deferredPrompt;

	window.addEventListener('beforeinstallprompt', function (e) {
		deferredPrompt = e;

		deferredPrompt.userChoice.then(function (choiceResult) {
			gx.fx.obs.notify('gx.pwa.onpromptchoice', [choiceResult.outcome]);
			deferredPrompt = null;
		});

		gx.fx.obs.notify('gx.pwa.onbeforeinstallprompt');
	});

	function showPrompt() {
		if (deferredPrompt) {
			deferredPrompt.prompt();
		}
	}

	return {
		showPrompt: showPrompt
	};
})(gx.$);

/* END OF FILE - ..\GenCommon\js\genexus-core.js - */
/* START OF FILE - ..\GenCommon\js\templates-helper.js - */
(function ($) {
	var GX_LABEL_CLASS = "gx-label",
		CONTROL_LABEL_CLASS = "control-label",
		LABEL_CLASS_SUFIX = "Label",
		FORM_CONTROL_CLASS = "form-control",
		NAVBAR_TEXT_CLASS = "navbar-text",
		LABEL_CLASS_REGEX = /(gx-form-item|col-(?:xs|sm|md|lg)-\d{1,2})/g;
		
	var registerTemplate = function (cfg) {
		gx.plugdesign.registerTemplate(new gx.plugdesign.Template(cfg));
	};

	var editEnabledHelper = function (control, value) {
		var $span = $(control).parent().find('span');
		if (gx.lang.gxBoolean(value)) {
			$span.parent("p").hide();
		}
		else {
			$span.removeClass(FORM_CONTROL_CLASS);
			var $parent = $span.parent("p");
			if ($parent.length === 0) {
				gx.plugdesign.applyTemplateOnElement("readonly-atts-vars", $span[0], true);
			}
			else {
				$parent.show();
			}
		}
	};
	var editVisibleHelper = function (control, value) {
		var $formGroup = $(".gx-form-group[data-gx-for='" + gx.dom.id(control) + "']");
		if ($formGroup.length === 0) {
			$formGroup = $(control).parents("div.gx-attribute").first();
		}
		
		if  (gx.lang.gxBoolean(value)) {
			$formGroup.show();
		}
		else {
			$formGroup.hide();
		}
	}; 

	var labelClassHelper = function (control, value) {
		value = value.trim();
		var labelEl = gx.html.getFieldLabel(control),
			labelClasses = value.split(" ").join(LABEL_CLASS_SUFIX + " ") + (value ? LABEL_CLASS_SUFIX : ""),
			colClass,
			newClass;

		if (!labelEl)
			return;
		var labelMatch = labelEl.className.match(LABEL_CLASS_REGEX);
		if (labelMatch)
			colClass = labelMatch.join(" ") || "";
		else
			colClass = "";

		newClass = [GX_LABEL_CLASS, colClass, labelClasses, CONTROL_LABEL_CLASS].join(" ");
		if (labelEl.className !== newClass) {
			labelEl.className = newClass;
		}
	};
	
	// Attributes and variables Labels
	registerTemplate({
		name: 'labels',
		selector: 'div.gx-form-group:has(label.' + GX_LABEL_CLASS + ':not([data-gx-sr-only]))',
		excluded: 'div:has(.gx_usercontrol)',
		setContext: function (context, el) {
			var $labelEl = $(el).find("label." + GX_LABEL_CLASS).addClass(CONTROL_LABEL_CLASS);
			context.labelEl = $labelEl[0];
			return context;
		},
		listeners: {
			control: function (context) {
				return $(context.labelEl).attr('for');
			},
			after: {
				"Class": labelClassHelper
			}
		}
	});

	// Attributes and variables
	registerTemplate({
		name: 'atts-vars',
		selector:'.gx-attribute > input, .gx-attribute > select, .gx-attribute > textarea, .gx-attribute > img:first-child',
		initialize: function (context) {
			var el = $("#" + context.id)[0];
			if (el) {
				labelClassHelper(el, el.className.replace(FORM_CONTROL_CLASS, ""));
			}
		},
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Enabled": editEnabledHelper,
				"Visible": editVisibleHelper
			}
		}
	});

	var readonlyVisibleHelper = function (control, value) {		
		var $p = $(control).parent("p");
		if (gx.lang.gxBoolean(value)) {
			$p.show();
		}
		else {
			$p.hide();
		}
		editVisibleHelper(control, value);
	};

	// Readonly attributes/vars
	registerTemplate({
		name: 'readonly-atts-vars',
		selector: '.gx-attribute span[class^="Readonly"]:not(:has(input[type="checkbox"]))',
		template: '<p class="form-control-static">{{{outerHTML}}}</p>',
		outerHTML: true,
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Visible": readonlyVisibleHelper
			}
		}
	});

	var checkboxVisibleHelper = function (control, value) {
		var $checkBoxCt = $(control).parent().closest('.gx-checkbox-wrapper');
		if (gx.lang.gxBoolean(value)) {
			$checkBoxCt.show();
			$checkBoxCt.children().show();
		}
		else {
			$checkBoxCt.hide();
		}
		editVisibleHelper(control, value);
	};
	
	// Password att/vars
	var passwordVisibleHelper = function (control, value) {
		if (gx.lang.gxBoolean(value) && gx.fn.isVisible(control, 0)) {
			$(control).next().show();
		}
		else {
			$(control).next().hide();
		}
		editVisibleHelper(control, value);
	};

	var passwordEnabledHelper = function (control, value) {
		if (gx.lang.gxBoolean(value)) {
			$(control).next().children().first().prop("disabled", false);
		}
		else {
			$(control).next().children().first().prop("disabled", true);
		}
	};

	var isPasswordHelper = function (control, value) {
		var $btn = $('button', $(control).next());
		$btn.attr('title', gx.getMessage(gx.lang.gxBoolean(value) ? "GXM_revealpassword" : "GXM_hidepassword"))
			.children()
			.first()
				.toggleClass("glyphicon-eye-open")
				.toggleClass("glyphicon-eye-close");
	};

	registerTemplate({
		name: 'password-atts-vars',
		selector: '.gx-attribute input[type="password"][data-gx-password-reveal]',
		template:	'<div class="input-group">' +
						'{{$inputEl$}}' +
						'<span class="input-group-btn gx-pwd-reveal-btn">' +
							'<button class="btn btn-default" type="button" title="' + gx.getMessage("GXM_revealpassword") + '">' +
								'<span class="glyphicon glyphicon-eye-open"></span>' + 
							'</button>' +
						'</span>' +
					'</div>',
		setContext: function (context, el) {
			context.inputEl = el;
			return context;
		},
		initialize: function (context) {
			var $el = $("#" + context.id),
				domEl = $("#" + context.id)[0];
			$el.next().on("click", function () {
				gx.fn.setCtrlProperty(domEl.id, "Ispassword", (domEl.type != "password"));
			})
		},
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Visible": passwordVisibleHelper,
				"Enabled": passwordEnabledHelper,
				"Ispassword": isPasswordHelper
			}
		}
	});

	// Checkboxes
	registerTemplate({
		name: 'checkbox',
		selector: '.gx-attribute > input[type="checkbox"], .gx-attribute span > input[type="checkbox"]',
		setContext: function (context, el) {
			context.id = $(el)[0].id;
			return context;
		},
		initialize: function (context) {
			var $el = $("#" + context.id),
				el = $el.get(0),
				$wrapper = $(el).closest('span');
			$wrapper.addClass("gx-checkbox-wrapper");			
		},
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Visible": checkboxVisibleHelper
			}
		}
	});

	// Usercontrol
	registerTemplate({
		name: 'usercontrol',
		onDemandInvoke:true,
		selector: '.gx_usercontrol',
		setContext: function (context, el) {
			context.id = $(el)[0].id;
			return context;
		},
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Visible": editVisibleHelper
			}
		}
	});

	// Datepickers
	var datePickerVisibleHandler = function (control, value, initializing) {
		this.visible = value;
		var $trigger = $(control).parent().find('.input-group-btn');
		if (gx.lang.gxBoolean(value) && gx.fn.isVisible(control, 0)) {
			if (this.enabled || this.enabled === undefined) {
				$trigger.show();
			}
		}
		else {
			$trigger.hide();
		}

		if (!initializing) {
			editVisibleHelper(control, value);
		}
	};
	registerTemplate({
		name: 'datepicker',
		selector: '.dp_container:has(img):has(input)',
		template: ['<div class="dp_container {{alignClass}}" id="{{datePickerCt.id}}">',
						'<div class="input-group">',
							'{{$inputEl$}}',
							'{{$spaneEl$}}',
							'<span class="input-group-btn">',
								'<a class="btn btn-default">',
									'{{$imgEl$}}',
								'</a>',
							'</span>',
						'</div>',
					'</div>'].join(""),
		outerHTML: true,
		setContext: function (context, el) {
			var $el = $(el), 
				align = $el.attr('data-align');
			context.datePickerCt = el;
			context.inputEl = $el.find('input')[0];
			context.imgEl = $el.find('img')[0];
			context.inputElId = context.inputEl.id;
			context.alignClass = (align)? 'pull-' + align: '';
			context.nativeEl = $el.find("#" + context.inputEl.id + '-picker')[0];
			var $span = $("#span_" + context.inputEl.id);
			if ($span.length > 0) {
				var pEl = $span.parent("p")[0];
				context.spaneEl = (pEl) ? pEl : $span;
				if (pEl){ // When readonly, span is outside .dp_container. We must remove it to prevent duplicates
					$(pEl).remove();
				}
			}
			return context;
		},
		initialize: function (context) {
			var $inputEl = $('#' + context.inputElId);
			var parent = $inputEl.parent().closest('.dp_container');
			if (context.nativeEl) {
				parent.append(context.nativeEl);
			}
			parent.find('a').on("click", function (evtObj) { 
				try {
					if (evtObj.target.nodeName != 'IMG') {
						parent.find('img')[0].click();
						return false;
					}
				}
				catch(e) {
					return false;
				}
			});

			var visible = gx.fn.isVisible($inputEl[0], 0);
			var $span = $("#span_" + context.inputEl.id);
			if ($span.length > 0) 
				visible = visible || gx.fn.isVisible($span[0], 0);
			datePickerVisibleHandler.call(this, $inputEl[0], visible, true);
		},
		listeners: {
			control: function (context) {
				return context.inputEl.id;
			},
			after: {
				"Enabled": function (control, value) {
					this.enabled = gx.lang.gxBoolean(value);
					var $trigger = $(control).parent().find('.input-group-btn');
					if (gx.lang.gxBoolean(value)) {
						var visible = this.visible || gx.fn.isVisible(control);
						if (visible || visible === undefined) {
							$trigger.show();
						}
					}
					else {
						$trigger.hide();
					}

					editEnabledHelper(control, value);
				},
				"Visible": datePickerVisibleHandler
			}
		}
	});
	
	var getRootRadioCtrl = function (ctrl) {
		return $(ctrl).parent().closest("span");
	}
	
	var radioCheckedHelper = function(rootRadio) {
		rootRadio.find(':checked').parent('label').button('toggle');
	}
	
	var radioValueHelper = function (control) {
		radioCheckedHelper(getRootRadioCtrl(control));
	};
	
	var radioSetEnabled = function (rootRadio, enabled){
		var radioLabels = rootRadio.find('label');
		if (!enabled) {
			radioLabels.prop('disabled', true);
			rootRadio.find('input, label').css('pointer-events', 'none');
			radioLabels.addClass('disabled');
		}
		else {
			radioLabels.prop('disabled', false);
			radioLabels.removeClass('disabled');
			rootRadio.find('input, label').css('pointer-events', '');
		}
	};
	var radioEnabledHelper = function (el, enabled){
		radioSetEnabled(getRootRadioCtrl(el), enabled);
	}
	
	var radioInitialized = function (rootRadio) {
		return $(rootRadio).prop('initialized');
	}
	//Radio Buttons
	registerTemplate({
		name: 'radio-button',
		selector: '.gx-radio-button:not(.gx-tpl-ignore) label',
		setContext: function (context, el) {
			var rootCtrl = getRootRadioCtrl(el);
			context.name = $(el).children('input').attr('name');
			context.spanEl = rootCtrl;
			if (!radioInitialized(rootCtrl)) {
				rootCtrl.children('label').addClass('gx-radio-label btn btn-default');
				var disabled = $(el).children().prop('disabled');
				radioCheckedHelper(rootCtrl);
				radioSetEnabled(rootCtrl, !(disabled === true || disabled === 'disabled'));
				rootCtrl.find('script').remove();
				rootCtrl.attr('data-toggle', 'buttons');
				var suffix = (rootCtrl.hasClass('gx-radio-button-vertical')) ? '-vertical' : '';
				rootCtrl
					.addClass('btn-group' + suffix)
					.removeClass('gx-radio-button-vertical')
					.css('vertical-align','baseline');
			}			
			return context;
		},
		
		initialize: function (context) {
			if (!radioInitialized(context.spanEl)) {
				context.spanEl.prop('initialized', true);
				context.spanEl.children('label').on('click', function() {
					var $el = $(this).children('input');
					$el.trigger('focus');
					$el.attr('checked', '');
					$el.prop('checked', true);
					gx.evt.onchange($el.get(0));
				});
			}
		},
		
		listeners: {
			control: function (context) {
				return context.name;
			},
			after: {
				"Visible": editVisibleHelper,
				"Enabled": radioEnabledHelper,
				"Value": radioValueHelper
			}
		}
	});
	

	// Prompts
	registerTemplate({
		name: 'prompt',
		selector: function (baseSelector) {
			return $('a:has(img[id*="PROMPT"])', baseSelector)
						.prevUntil("", "input, select");
		},
		template: '<div class="input-group">{{$inputEl$}}<span class="input-group-btn">{{$promptEl$}}</span></div>',
		setContext: function (context, el) {
			context.inputEl = el;
			context.promptEl = $(el)
								.nextUntil("", 'a:has(img[id*="PROMPT"])')
								.addClass("btn btn-default");
			return context;
		},
		listeners: {
			control: function (context) {
				return context.inputEl.id;
			},
			before: {
				"Visible": function (control, value) {
					var $parent = $(control).parent();
					if (gx.lang.gxBoolean(value)) {
						$parent.show();
					}
					else {
						$parent.hide();
					}
				},
				"Enabled": function (control, value) {
					var $trigger = $(control).parent().find('.input-group-btn');
					if (gx.lang.gxBoolean(value)) {
						$trigger.show();
					}
					else {
						$trigger.hide();
					}
				}
			}
		}
	});

	registerTemplate({
		name: 'prompt-trigger',
		selector: 'img[id*="PROMPT"].gx-prompt',
		setContext: function (context, el) {
			context.imgEl = el;
			return context;
		},
		
		listeners: {
			control: function (context) {
				return context.imgEl.id;
			},
			before: {
				"Enabled": function (control, value) {
					var $trigger = $(control).closest('.input-group-btn');
					if (gx.lang.gxBoolean(value)) {
						$trigger.show();
					}
					else {
						$trigger.hide();
					}
				}
			}
		}
	});

	// GeoLocation
	var geolocationVisibleHandler = function (control, value) {
		var $toggleSet = $(control).parent();
		$toggleSet = $toggleSet.add($toggleSet.find("img"));
		if (gx.lang.gxBoolean(value)) {
			$toggleSet.show();
		}
		else {
			$toggleSet.hide();
		}
	};
	registerTemplate({
		name: 'geolocation',
		selector: 'input + img.GeoLocOption',
		template: '<div class="input-group"><div id="{{inputEl.id}}_hook"></div><span class="input-group-btn"><a class="btn btn-default"><div id="{{inputEl.id}}_trigger_hook"></div></a></span></div>',
		setContext: function (context, el) {
			context.inputEl = $(el).prev()[0];
			context.triggerEl = $(el)[0];
			return context;
		},
		initialize: function (context) {
			gx.evt.attach(context.el, 'click',
				function() {
					gx.geolocation.getMyPosition(this);
				}
			);
			$("#" + context.inputEl.id + "_hook").replaceWith(context.inputEl);
			$("#" + context.inputEl.id + "_trigger_hook").replaceWith(context.triggerEl);
			geolocationVisibleHandler.call(this, context.inputEl, gx.fn.isVisible(context.inputEl, 0));
		},
		listeners: {
			control: function (context) {
				return context.inputEl.id;
			},
			before: {
				"Visible": geolocationVisibleHandler,
				"Enabled": function (control, value) {
					var $trigger = $(control).parent().find('.input-group-btn');
					if (gx.lang.gxBoolean(value)) {
						$trigger.show();
					}
					else {
						$trigger.hide();
					}
				}
			}
		}

	});

	// Multimedia upload dialog
	registerTemplate({
		name: 'multimedia-upload',
		selector: '.gx-multimedia-upload .fields-ct',
		template: [	'<div class="row">',
						'<div class="col-sm-4">',
							'<div class="row">',
								'<div class="col-sm-12">',
									'{{$fileOptionLbl$}}',
								'</div>',
								'<div class="col-sm-12">',
									'{{$uriOptionLbl$}}',
								'</div>',
							'</div>',
						'</div>',
						'<div class="col-sm-8">',
							'{{$uriField$}}',
							'{{$fileField$}}',
						'</div>',
					'</div>',
					'<div class="row">',
						'<div class="col-sm-12">',
							'{{$button$}}',
						'</div>',
					'</div>'
		].join(""),
		applyTo: 'inner',
		setContext: function (context, el) {
			var container = $(el).parent().closest(".gx-multimedia-upload")[0];
			var multimediaEls = gx.html.multimediaUpload.getElements(container);
			multimediaEls.fileOptionLbl = multimediaEls.fileOption.parentNode;
			multimediaEls.uriOptionLbl = multimediaEls.uriOption.parentNode;
			gx.lang.apply(context, multimediaEls);
			context.container = container;
			return context;
		},
		initialize: function (context) {
			$(context.button).addClass("btn btn-default Button");
			$(context.uriField).addClass(FORM_CONTROL_CLASS);
		},
		listeners: {
			control: function (context) {
				return gx.html.multimediaUpload.CtrlId(context.container.id);
			},
			after: {
				"Visible": function( el, ptyVal) { 
					editVisibleHelper(el, ptyVal, 7);
				}
			}
		}
	});

	// Navbars
	registerTemplate({
		name: 'navbar',
		selector: '.gx-navbar',
		setContext: function (context, el) {
			context.toggleBtn = $(el).find('.gx-navbar-toggle');
			context.navBarInner = $(el).find('.gx-navbar-inner');
			return context;
		},
		initialize: function (context) {
			context.toggleBtn.attr('data-target', '#' + context.navBarInner.attr("id"));
		}
	});

	gx.spa.addObserver('onnavigatecomplete', window, function() {
		var navBarCollapse = $(".navbar-collapse");
		if (navBarCollapse.collapse) {
			navBarCollapse.collapse('hide');
		}
	});
	
	var navbar_draw = function(context) {
		if (context.anchor.get(0).href == location.href) {
			context.anchor.parent().addClass('active');
		}
		else {
			context.anchor.parent().removeClass('active');
		}
	};
	
	// Navbars Textblock with link
	registerTemplate({
		name: 'navbar-textblock-link',
		selector: 'a.gx-navbar-textblock, .gx-navbar-textblock:has(a)',
		template: '{{$anchor$}}',
		setContext: function (context, el) {
			var attrs = [
				"id", 
				"class", 
				"style", 
				gx.GxObject.GX_EVENT_CONTROL_DATA_ATTR, 
				gx.GxObject.GX_EVENT_CONTEXT_DATA_ATTR, 
				"title"
			];
			var $el = $(el);
			var i;
			context.anchor = $el.children('a');
			if (context.anchor.length === 0 && $el.is('a')) {
				context.anchor = $el;
			}
			for (i=0; i<attrs.length; i++) {
				context.anchor.attr(attrs[i], $el.attr(attrs[i]));
			}
			return context;
		},
		reDraw: navbar_draw,
		initialize: navbar_draw,
		listeners: {
			control: function (context) {
				return context.id;
			},
			before: {
				"Caption": function (control, value) {
					$(control).text(value);
					return true;
				},
				"Link": function (control, value) {
					$(control).attr('href', value);
					return true;
				}
			}
		}
	});

	// Navbars Textblock (text only)
	registerTemplate({
		name: 'navbar-textblock-text',
		selector: 'span.gx-navbar-textblock:not(:has(a))',
		initialize: function (context) {
			$(context.el).addClass(NAVBAR_TEXT_CLASS);
		},
		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Link": function (control, value) {
					var $control = $(control);
					if (value && $control.hasClass(NAVBAR_TEXT_CLASS)) {
						$control.removeClass(NAVBAR_TEXT_CLASS);
						gx.plugdesign.applyTemplateOnElement("navbar-textblock-link", control);
					}
				}
			}
		}
	});
	
	// Navbars Textblock (text only)
	registerTemplate({
		name: 'errorviewer',		
		selector: '.gx_ev div',		
		initialize: function (context) {
			var $errViewerLine = $(context.el),
			$errViewer = $errViewerLine.parent('.gx_ev'),
			posAtt = $errViewer.css("position"),
			floatingPanel = posAtt === 'fixed' || posAtt === 'absolute';
			
			if (floatingPanel) {
				if ($errViewer[0].effect) //WA for disabling Highlight Error Viewer.
					$errViewer[0].effect.end();
				$errViewerLine.addClass('alert alert-dismissible fade in')
				.attr('style', '')
				.attr('role', 'alert')
				.prepend($('<button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>'));		
			}
		}
	});

	//TextArea AutoExpand
	registerTemplate({		
		name: 'textarea-auto-expand',		
		selector: '.gx-attribute > textarea[data-gx-text-maxlines]',
		
		setContext: function (context, el) {
			context.el = $(el);
			return context;
		},
		initialize: function (context) {
			var $el = context.el,
				el = $el[0], $window = $(window), 
				minLines = parseInt($el.attr('rows'), 10),
				maxLines = parseInt($el.attr('data-gx-text-maxlines'), 10);
			$el.css('overflow-x', 'hidden');
			var setRows = function ($ctrl, rows, increment) {
				rows = rows + increment;
				$ctrl.attr('rows', rows);	
				return rows;
			}
			var autoExpand = function() {			
				var scrollPos = $window.scrollTop(),
					rows = parseInt($(this).attr('rows'), 10),
					$this = $(this);
				
				while (rows > minLines && this.scrollHeight >= this.clientHeight)
				{										
					rows = setRows($this, rows, -1);
				}
				while ($(this).val() !== '' && (rows < maxLines) && this.scrollHeight > this.clientHeight)
				{				
					rows = setRows($this, rows, 1);	
				}
				
				$window.scrollTop(scrollPos);
			};
			gx.evt.attach(el, ['input', 'keyup'], autoExpand.closure(el, []));
			gx.evt.on_ready(el, autoExpand.closure(el, []))
		}
	});

	var imageIsScaled = function ($imgEl) {
		var el = $imgEl.get(0),
			computedStyle = gx.dom.getComputedStyle(el),
			imageScaling = computedStyle.getPropertyValue('--gx-image-scaling');
		return imageScaling.trim() === "on";
	};

	var setImageAlignAttr = function ($imgEl) {
		var $baseEl = $imgEl;
		if (imageIsScaled($imgEl)) {
			if ($imgEl.parent('a').length > 0)
				$baseEl = $imgEl.parent('a');
			$baseEl.parent('div[data-align-inner]')
				.parent()
					.parent()
						.attr('data-align-image', '');
		}
	};

	//Images
	registerTemplate({
		name: 'image',
		selector: 'img[data-gx-image]',

		setContext: function (context, el) {
			context.el = $(el);
			return context;
		},
		initialize: function (context) {
			var $el = context.el,
				src = $el.get(0).currentSrc || $el.attr('src');

			if (src && imageIsScaled($el)) {
				$el.css('background-image', 'url(' + src + ')')
			}

			setImageAlignAttr($el);
		},

		listeners: {
			control: function (context) {
				return context.id;
			},
			after: {
				"Bitmap": function (control, value) {
					var $imgEl = $(control);
					if (value && imageIsScaled($imgEl)) {
						$imgEl.css('background-image', 'url(' + value + ')');
					}
					else {
						$imgEl.css('background-image', 'none');
					}
				},

				"Class": function (control) {
					var $imgEl = $(control);
					if (control.src && imageIsScaled($imgEl)) {
						$imgEl.css('background-image', 'url(' + control.src + ')');
					}
					else {
						$imgEl.css('background-image', 'none');
					}
					setImageAlignAttr($imgEl);
				}
			}
		}
	});
}(gx.$));
/* END OF FILE - ..\GenCommon\js\templates-helper.js - */
/* START OF FILE - ..\js\gxui.js - */
gx.ui = (function ($) {
	return {
		grid: function () {
			this.gridContainer = null;
			this.firstTime = true;
			this.autoRefreshing = false;
			this.loadingCollection = false;
			this.properties = [];

			this.setContainerDelayed = function (container) {
				this.gridContainer = container;
				this.ContainerName = gx.dom.id(container);
				this.DesignContainerName = this.ContainerName;
				this.ParentObject.setUserControl(this);
			};

			this.getContainerControl = function () {
				return this.gridContainer;
			};

			this.me = function () {
				return this.gridObject() + '.grid';
			};

			this.render = function (firstTime, fromAutoRefresh, fromCollection, afterRenderCallback) {
				this.clearFunctions();
				this.refreshDynProperties();
				this.properties = [];
				for (var i = 0; i < this.rows.length; i++) {
					this.properties[i] = [];
					var row = this.rows[i];
					for (var j = 0; j < this.columns.length; j++) {
						var column = this.columns[j];
						var columnProps = row.gxProps[column.index];
						var gxCtrl = column.gxControl;
						gxCtrl.grid = this.ownerGrid;
						gxCtrl.row = row;
						gxCtrl.gridId = this.gxId;
						gxCtrl.gridRow = row.gxId;
						if (!fromCollection) {						
							gxCtrl.setProperties.apply(gxCtrl, columnProps);
						}
						else
							gxCtrl.value = columnProps[0];
						this.setRenderProperties(row.gxRenderProps[j], gxCtrl);
						if (!gxCtrl.enabled && gxCtrl.type <= gx.html.controls.types.checkBox) {
							if (gxCtrl.cssClass !== '' && gxCtrl.cssClass.indexOf('Readonly') !== 0)
								gxCtrl.cssClass = 'Readonly' + gxCtrl.cssClass;
						}
						this.properties[i][j] = gx.lang.clone(gxCtrl);
						this.addC2V(column, this.properties[i][j]);
					}
				}
				this.firstTime = firstTime;
				this.autoRefreshing = (fromAutoRefresh ? true : false);
				this.loadingCollection = (fromCollection ? true : false);
				if (this.show) {
					this.setC2ShowFunction(function (othis) {
						othis.show();
						// Call after render callback
						afterRenderCallback();
					});
					if (this.autoRefreshing) {
						this.show();
						// Call after render callback
						afterRenderCallback();
					}
				}
				this.autoRefreshing = false;
			};

			this.addC2V = function (column, cellCtrl) {
				this.addC2VFunction(function (othis) {
					if (column.gxAttName !== '') {
						var validStruct = othis.ParentObject.getValidStruct(column.gxId);
						if (validStruct) {
							othis.ParentObject[validStruct.gxvar] = cellCtrl.value;
						}
						gx.fn.setHidden(cellCtrl.id, cellCtrl.value);
					}
				});
			};

			this.setRenderProperties = function (props, gxCtrl) {
				if (props) {
					for (var prop in props) {
						gxCtrl[prop] = props[prop];
					}
				}
			};

			this.selectRow = function (index) {
				var row = this.rows[index];
				if (row) {
					this.instanciateSelectionVars(row.gxId);
					this.instanciateSelectedRow(row);
				}
			};

			this.getEventRow = function () {
				if (!gx.lang.emptyObject(this.GridRow)) {
					return this.GridRow;
				}
				return '0001';
			};

			this.executeEvent = function (x, y) {
				/*jshint evil:true*/
				if (x < this.columns.length && y < this.rows.length) {
					var gxCtrl = this.properties[y][x];
					var sEventJsCode = gx.html.controls.eventJSCode(gxCtrl.jsScrCode, gxCtrl.eventName, gxCtrl.jsDynCode, gxCtrl.grid, gxCtrl.row);
					if (sEventJsCode !== '') {
						if (!gx.lang.emptyObject(gxCtrl.usrOnclick)) {
							sEventJsCode = 'if(' + gxCtrl.usrOnclick + ') { ' + sEventJsCode + ' }';
						}
						var evtFnc = new Function(sEventJsCode);
						if (typeof (evtFnc) == 'function') {
							evtFnc();
						}
					}
					else {
						if (gxCtrl.clickEvent) {
							var gxO = this.parentGxObject;
							var ctrlRow = gxCtrl.row.gxId;
							this.ownerGrid.instanciateRow(ctrlRow);
							gxO[gxCtrl.clickEvent].call(gxO, ctrlRow);
						}
					}
				}
			};

			this.executeIsValid = function (x, y) {
				if (x < this.columns.length && y < this.rows.length) {
					var gxO = this.parentGxObject,
						gxCtrl = this.properties[y][x],
						vStruct = gxCtrl.vStruct || gxO.GXValidFnc[gxCtrl.column.gxId],
						ctrlRow = gxCtrl.row.gxId;
					if (vStruct && vStruct.isvalid) {
						this.ownerGrid.instanciateRow(ctrlRow);
						gxO[vStruct.isvalid].call(gxO);
					}
				}
			};

			this.addEventHandler = function (EventName, Handler) {
				this[EventName] = (function (callback) {
					var isServerEvent = this.isServerEvent(EventName);
					if (isServerEvent && callback) {
						gx.fx.obs.addObserver('gx.onafterevent', this, callback, { single: true });
					}
					var gridRow = gx.fn.currentGridRow(this.GridId);
					this.eventHandler(this.GridId, gridRow, Handler);
					if (!isServerEvent && callback) {
						callback.call(this);
					}
				}).closure(this);
			};
			
			var suggestProviders = {};
			
			this.requestSuggest = function (x, y, query) {
				var deferred = $.Deferred();
				if (x < this.columns.length && y < this.rows.length) {
					var gxO = this.parentGxObject,
						gxCtrl = this.properties[y][x],
						vStruct = gxCtrl.vStruct || gxO.GXValidFnc[gxCtrl.column.gxId],
						ctrlRow = gxCtrl.row.gxId,
						provider = suggestProviders[ctrlRow + "_" + vStruct.id];

					if (!provider) {
						if (vStruct && vStruct.gxsgprm) {
							this.ownerGrid.instanciateRow(ctrlRow);
							provider = new gx.fx.suggestProvider(gxO, vStruct.gxsgprm[1], null, vStruct.gxsgprm[0]);
							suggestProviders[ctrlRow + "_" + vStruct.id] = provider;
						}
					}
					
					if (provider) {
						gx.fx.updateSuggestParms(vStruct.gxsgprm[2]);
						provider.requestSuggestions([], function () {
							deferred.resolve(provider.values);
						},
						function () {
							deferred.reject();
						}, query);
					}
					else {
						deferred.reject();
					}
				}
				else {
					deferred.reject();
				}
				return deferred.promise();
			};

			this.executeValidate = function (x, y) {
				if (x < this.columns.length && y < this.rows.length) {
					var gxO = this.parentGxObject,
						gxCtrl = this.properties[y][x],
						vStruct = gxCtrl.vStruct || gxO.GXValidFnc[gxCtrl.column.gxId],
						ctrlRow = gxCtrl.row.gxId;
					if (vStruct && vStruct.fnc) {
						this.ownerGrid.instanciateRow(ctrlRow);
						vStruct.fnc.call(gxO);
					}
				}
			};
		}
	};
})(gx.$);
/* END OF FILE - ..\js\gxui.js - */
/* START OF FILE - ..\GenCommon\js\ui-controls.js - */
/*global Mustache:true */
/*global HistoryManager:true */
gx.ui.controls = (function ($) {
	var BaseTabControl = (function () {
		var requiredMethods = [
			"render", 
			"selectTabPageByIndex",
			"hideTabPageByIndex",
			"showTabPageByIndex",
			"getTabPageIndexByControlName",
			"getTabPageControlNameByIndex"
		];

		var checkRequiredMethods = function () {
			for (var i=0; i<requiredMethods.length; i++) {
				if (!this[requiredMethods[i]]) {
					console.error("Missing required method", requiredMethods[i], this);
				}
			}
		};
		
		var selectTabPageByIndex = function (i, ignoreTabChanged, addHistoryPoint) {
			this.selectTabPageByIndex(i);

			this.tabPageSelected(i, ignoreTabChanged, addHistoryPoint);
		};

		return {
			show: function() {
				var activePage = this.ActivePage;

				checkRequiredMethods.call(this);

				if (!this.IsPostBack)
				{
					if (this.HistoryManagement) {
						HistoryManager.Initialize(this);
					}

					if (this.beforeRender) {
						this.beforeRender();
					}
					this.render();

					if (this.ActivePageControlName) {
						activePage = parseInt(this.getTabPageIndexByControlName(this.ActivePageControlName), 10);
					}
					if (!activePage) {
						activePage = 1;
					}

					selectTabPageByIndex.call(this, activePage, true, false);

					if (this.afterRender) {
						this.afterRender();
					}
				}
				else {
					if (this.update) {
						this.update();
					}
				}
				if (this.allways) {
					this.allways();
				}
			},
			
			destroy: function () {
				HistoryManager.RemoveListener(this);
			},
			tabPageSelected: function (i, ignoreTabChanged, addHistoryPoint) {
				if (this.ActivePage === i) {
					return;
				}
				this.ActivePage = i || 1;
				this.ActivePageControlName = this.getTabPageControlNameByIndex(i) || "";

				if (this.HistoryManagement && addHistoryPoint !== false) {
					HistoryManager.AddHistoryPoint(this.ActivePageControlName, true, null, false);
				}

				if (!ignoreTabChanged && this.TabChanged) {
					this.TabChanged();
				}
			},

			// HistoryManager methods ///////////////
			getId: function() {
				return (this.ParentObject ? this.ParentObject.CmpContext || "" + "-" + this.ParentObject.ServerClass || "" : "") + "-" + this.ControlName;
			},

			urlListener: function(){
				var pageCode;
				if (gx.grid.drawAtServer)
					return;

				pageCode = (document.location.hash.length > 0) ? document.location.hash.substr(1) : "";
				selectTabPageByIndex.call(this, pageCode ? this.getTabPageIndexByControlName(pageCode) : 1, false, false);
			},
			/////////////////////////////////////////

			// Methods
			SelectTab: function (i) {
				selectTabPageByIndex.call(this, i, false);
			},

			HideTab: function (i) {
				this.hideTabPageByIndex(i);
			},

			ShowTab: function (i) {
				this.showTabPageByIndex(i);
			}
		};
	})();

	return {
		datePicker: function(opts) {
			this.$input = $('#' + opts.inputId);
			this.$trigger = $('#' + opts.triggerId);
			this.showInLine = opts.inline;
			this.inputType = opts.inputType;
			this.format = opts.format;
			this.datePartLength = opts.datePartLength;
			this.timePartLength = opts.timePartLength;
			this.nativeSupport = gx.HTML5 && (gx.util.browser.isIPhone() || gx.util.browser.isIPad() || (gx.util.browser.isAndroid() && gx.util.browser.isChrome()));		
			this.afterChange = opts.afterChange;
			this.opts = opts;
			
			this.getInputType = function () {					
				if (this.timePartLength > 0 && this.datePartLength === 0)
					return 'time';			
				if (this.datePartLength > 0 && this.timePartLength === 0)
					return 'date';	
				return 'datetime-local';
			};
			
			this.getTimeStep = function () {
				if (this.timePartLength > 6)
					return 1;
				return 60; //Minute
			}
			
			this.resolveValue = function (dType, dateObj) {			
				var valText;			
				if (gx.date.isNullDate(dateObj) && dType !== 'time') {				
					dateObj = new Date();
				}
				if (dType == 'date') {
					dateObj.setMinutes(dateObj.getMinutes() - dateObj.getTimezoneOffset());	
					valText = dateObj.toISOString().slice(0, 10);
				}
				else {
					dateObj.setMinutes(dateObj.getMinutes() - dateObj.getTimezoneOffset());	
					//ISO String Format: "1899-12-31T08:00:00.000Z"
					var sIdx = 0;
					var eIdx = 19;
					if (dType == 'time') {									
						sIdx = 11;
						eIdx = (this.getTimeStep() == 60)? 16: 19;									
					}								
					valText = (new gx.date.gxdate(dateObj)).Value.toISOString().slice(sIdx, eIdx);					
				}			
				return valText;
			}
			
			this.render = function () {
				if (!this.nativeSupport) {
					var ShowsTime = this.opts.inputType !== 'date';
					gx.html.onTypeAvailable('Calendar', this.installCalendar, [this.opts.inputId, this.opts.inline, ShowsTime,  this.opts.weeksNumbers, this.opts.mondayFirst,  this.opts.format]);
					return;
				}
				var $in = this.$input;
				
				var dType = this.getInputType();
				var $dInput = $('<input>');
				$dInput.attr('type', dType);
				if (dType === 'time' || dType === 'datetime-local')
					$dInput.attr('step', this.getTimeStep());		
				
				$dInput.css('position', 'absolute');
				$dInput.css('top', '0');
				$dInput.css('left', '0');
				$dInput.css('opacity', '0');
				$dInput.attr('id', $in.attr('id') + '-picker');				
				this.dtPicker = $dInput;
				$in.parent().append($dInput);
				$dInput.bind('touchstart touchend mousedown mouseup', function(){ return ($in.prop("disabled") !== true) });
				
				var self = this;
				
				var setChanged = function($inDate) {
					var localDateVal = $inDate.val();					
					var dtObj = new gx.date.gxdate(localDateVal, 'Y4MD');	
					var value = (localDateVal !== '')? dtObj.Value: gx.date.nullDate();		
					if (self.afterChange) {					
						self.afterChange(null, value, $in[0], self.opts.vStruct, self.opts.gxO);
					}	
				};
				
				this.$trigger.on('click', function () {		
					var dateObj = gx.date.dateObject($in.val());				
					var isNullDate = gx.date.isNullDate(dateObj);				
					if (!isNullDate){
						var valText = self.resolveValue(dType, dateObj);						
						$dInput.val(valText);	
						setChanged($dInput);
					}
					$dInput.trigger('click').trigger('focus');
				});
				
				gx.evt.attach($dInput[0], 'change', function () {        
					var $this = $(this);
					setChanged($this);
				});

			}
			
			this.installCalendar = function (ControlId, Flat, ShowsTime, WeekNumbers, MondayFirst, Format) {
				var dpCtrl = gx.dom.byId(ControlId),
					$dpCtrl = $(dpCtrl);
				if (!gx.lang.emptyObject(dpCtrl) && dpCtrl.nodeName == 'SELECT')
					return;
				if (Flat === 0) {
					var triggerId = ControlId  + "_dp_trigger",
						trigger = gx.dom.byId(triggerId);					
					if ((trigger && $dpCtrl.css('display') !== 'none' && $dpCtrl.css('visibility') !== 'hidden' && $dpCtrl.css('display') === 'none' || $dpCtrl.css('visibility') === 'hidden') || !trigger) {
						triggerId = ControlId;
					}
					var parentNode = $dpCtrl.parent().closest('.dp_container')[0];
					var displayRight = false;
					Calendar.setup({ inputField: ControlId, parentNode: parentNode, showsTime: ShowsTime, weekNumbers: WeekNumbers, mondayFirst: MondayFirst, ifFormat: Format, button: triggerId, onSelect: gx.fn.datePickerChanged, align: "Bl", singleClick: true, displayRight: displayRight });
				}
				else {
					if (!gx.lang.emptyObject(dpCtrl))
						$dpCtrl.css('display', 'none');
					Calendar.setup({ inputField: ControlId, showsTime: ShowsTime, weekNumbers: WeekNumbers, mondayFirst: MondayFirst, ifFormat: Format, flat: ControlId + "_dp_container", flatCallback: gx.fn.datePickerChanged, align: "Bl", singleClick: true });
				}
			}
		},
		
		actionGroup: (function () {
			return {
				init: function () {
					if ($("[data-gx-base-lib='none']").length > 0) {
						gx.fx.obs.addObserver("gx.onclick", this, function (evtObject) {
							var evt = evtObject.event, 
								dropDownToggle = evt.target,
								ariaExpanded;

							if ($(dropDownToggle).is(".gx-navbar .dropdown>a")) {
								evt.preventDefault();
								ariaExpanded = dropDownToggle.getAttribute("aria-expanded");
								
								var clickOutsideHandler = function (clickOutsideEvtObject) {
									var $dropDown = $(dropDownToggle).next(".gx-dropdown-menu");
									var target = clickOutsideEvtObject.event.target;

									if (!$(target).closest($dropDown).length && target != dropDownToggle) {
										if (dropDownToggle.getAttribute("aria-expanded") === "true") {
											dropDownToggle.setAttribute("aria-expanded", "false");
											gx.fx.obs.deleteObserver("gx.onclick", this, clickOutsideHandler);
										}
									}
								};
								
								if (ariaExpanded === "false") {
									gx.fx.obs.addObserver("gx.onclick", this, clickOutsideHandler);
									dropDownToggle.setAttribute("aria-expanded", "true");
								}
								else {
									gx.fx.obs.deleteObserver("gx.onclick", this, clickOutsideHandler);
									dropDownToggle.setAttribute("aria-expanded", "false");
								}
							}
						});
					}
				},

				dynamicItems: (function () {
					var ACTION_GROUP_TYPE_ATTR = "data-gx-actiongroup-type";

					var navbarDropDowntemplate = '<li class="dropdown" data-gx-dynitem-source="{{containerName}}">' + 
														'<a href="#" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false" class="dropdown-toggle" title="{{TooltipText}}">{{Caption}}<span class="caret"></span></a>' + 
														'<ul class="gx-dropdown-menu dropdown-menu {{Class}}">' + 
														'{{#Children}}' + 
															'{{> navbarItemTemplate}}' + 
														'{{/Children}}' +
														'</ul>' + 
													'</li>';

					var navbarItemTemplate = '<li data-gx-dynitem-source="{{containerName}}">' + 
												'{{#Link}}' + 
													'<a href="{{Link}}" class="gx-navbar-textblock {{Class}}" data-gx-tpl-applied-navbar-textblock-link title="{{TooltipText}}">{{Caption}}</a>' + 
												'{{/Link}}' + 
												'{{^Link}}' + 
													'{{#Children.length}}' + 
														'{{> navbarDropDowntemplate}}' + 
													'{{/Children.length}}' + 
													'{{^Children.length}}' + 
														'<span class="gx-navbar-textblock {{Class}} navbar-text" data-gx-tpl-applied-navbar-textblock-text title="{{TooltipText}}">{{Caption}}</a>' + 
													'{{/Children.length}}' + 
												'{{/Link}}' + 
												'</li>';

					var navbarTemplate = '{{#Children}}' + 
												'{{> navbarItemTemplate}}' + 
											'{{/Children}}';

					var toolbarTemplate = '{{#Children}}' + 
												'{{#Link}}' + 
													'<span class="{{Class}}" title="{{TooltipText}}">' + 
														'<a href="{{Link}}">{{Caption}}</a>' + 
													'</span>' + 
												'{{/Link}}' + 
												'{{^Link}}' + 
													'{{#Children.length}}' + 
														'<div class="btn-group">' + 
															'{{> toolbarItemTemplate}}' + 
														'</div>' + 
													'{{/Children.length}}' + 
													'{{^Children.length}}' + 
														'<span class="{{Class}}" title="{{TooltipText}}">{{Caption}}</span>' + 
													'{{/Children.length}}' + 
												'{{/Link}}' +
											'{{/Children}}';
					
					return function ($) {
						this.preProcessItems = function (pItems) {
							var i, len;
							for (i=0, len = pItems.length; i<len; i++) {
								if (pItems[i].Children) {
									this.preProcessItems(pItems[i].Children);
								}
								else {
									pItems[i].Children = [];
								}
							}
						};
						
						this.getItems = function () {
							return this.items;
						};
						
						this.setItems = function (pItems) {
							this.preProcessItems(pItems);
							this.items = pItems || [];
						};

						this.getType = (function (me) {
							var actionGroupType;
							return function () {
								if (!actionGroupType) {
									actionGroupType = $(me.getContainerControl())
															.closest('[' + ACTION_GROUP_TYPE_ATTR + ']')
															.attr(ACTION_GROUP_TYPE_ATTR);
								}
								return actionGroupType;
							};
						})(this);

						this.renderMenu = function (itemsToRender) {
							var html = "";

							if (!this.IsPostBack) {
								$(this.getContainerControl())
									.after('<li data-gx-dynitem-hook="' + this.ContainerName + '"></li>')
									.css('display', 'none')
									.appendTo(gx.dom.form());
							}
							else {
								$('li[data-gx-dynitem-source="' + this.ContainerName + '"]').remove();
							}
							
							if (itemsToRender.length) {
								html = Mustache.render(navbarTemplate, {
										containerName: this.ContainerName,
										Children: itemsToRender
									},
									{
										navbarItemTemplate: navbarItemTemplate,
										navbarDropDowntemplate: navbarDropDowntemplate
									}
								);
								
								$('li[data-gx-dynitem-hook="' + this.ContainerName + '"]')
									.after(html);
							}
						};

						this.renderToolbar = function (itemsToRender) {
							var html = "";

							if (itemsToRender.length) {
								html = Mustache.render(toolbarTemplate, {
										containerName: this.ContainerName,
										Children: itemsToRender
									},
									{
										toolbarItemTemplate: toolbarTemplate
									}
								);
							}
							$(this.getContainerControl())
								.attr("data-gx-dynitem-container", "")
								.html(html);
						};

						this.show = function() {
							var type = this.getType(),
								itemsToRender = gx.lang.isArray(this.items) ? this.items : [this.items];

							if (type == "menu") {
								this.renderMenu(itemsToRender);
							}
							else if (type == "toolbar") {
								this.renderToolbar(itemsToRender);
							}
						};

						this.destroy = function() {
							var type = this.getType();
							
							if (type == "menu") {
								$('li[data-gx-dynitem-source="' + this.ContainerName + '"]').remove();
								$('li[data-gx-dynitem-hook="' + this.ContainerName + '"]')
									.after(this.getContainerControl())
									.remove();
							}
							else if (type == "toolbar") {
								$(this.getContainerControl()).html("");
							}
						};
					};
				})()
			};
		})(),
		
		defineTabControl: function (tabUserControl) {
			gx.lang.apply(tabUserControl.prototype, BaseTabControl);
			return tabUserControl;
		}
	};
})(gx.$);
/* END OF FILE - ..\GenCommon\js\ui-controls.js - */
