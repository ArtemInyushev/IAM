module.exports = {
    extends: [
		// add more generic rulesets here, such as:
		// 'eslint:recommended',
		'plugin:vue/vue3-recommended',
		// 'plugin:vue/recommended' // Use this if you are using Vue.js 2.x.
    ],
    rules: {
        "vue/html-indent": ["warn", "tab", {
            "attribute": 1,
            "closeBracket": 0,
		}],
		"vue/max-attributes-per-line": ["error", {
			"singleline": {
			  	"max": 4
			},      
			"multiline": {
			  	"max": 2
			}
		}],
		"vue/html-self-closing": ["error", {
			"html": {
				"void": "never",
				"normal": "any",
				"component": "always"
			},
			"svg": "always",
			"math": "always"
		}]
		// override/add rules settings here, such as:
		// 'vue/no-unused-vars': 'error'
	}
  }