
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"ColorRequiredAttribute",
            content:"ColorRequiredAttribute",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.CustomAttributes/ColorRequiredAttribute',
            title:"ColorRequiredAttribute",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"Program",
            content:"Program",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp/Program',
            title:"Program",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"ColorUniqAttributeAttribute",
            content:"ColorUniqAttributeAttribute",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.CustomAttributes/ColorUniqAttributeAttribute',
            title:"ColorUniqAttributeAttribute",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"LudoGameAPIProccessor",
            content:"LudoGameAPIProccessor",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/LudoGameAPIProccessor',
            title:"LudoGameAPIProccessor",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"PlayerBindingModel",
            content:"PlayerBindingModel",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.BindingModel/PlayerBindingModel',
            title:"PlayerBindingModel",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"HomeController",
            content:"HomeController",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Controllers/HomeController',
            title:"HomeController",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"Startup",
            content:"Startup",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp/Startup',
            title:"Startup",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"PlayerCustomAttribute",
            content:"PlayerCustomAttribute",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.BindingModel/PlayerCustomAttribute',
            title:"PlayerCustomAttribute",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"LudoGame",
            content:"LudoGame",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/LudoGame',
            title:"LudoGame",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"PlayerFormExtractor",
            content:"PlayerFormExtractor",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.BindingModel/PlayerFormExtractor',
            title:"PlayerFormExtractor",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"ILudoGameAPIProccessor",
            content:"ILudoGameAPIProccessor",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/ILudoGameAPIProccessor',
            title:"ILudoGameAPIProccessor",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"LudoControllerTests",
            content:"LudoControllerTests",
            description:'',
            tags:''
        },
        {
            url:'/api/WebAppTests/LudoControllerTests',
            title:"LudoControllerTests",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"Piece",
            content:"Piece",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/Piece',
            title:"Piece",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"Color",
            content:"Color",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.BindingModel/Color',
            title:"Color",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"Winner",
            content:"Winner",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/Winner',
            title:"Winner",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"ErrorViewModel",
            content:"ErrorViewModel",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models/ErrorViewModel',
            title:"ErrorViewModel",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"GameViewModel",
            content:"GameViewModel",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models/GameViewModel',
            title:"GameViewModel",
            description:""
        }
    );
    a(
        {
            id:17,
            title:"LudoController",
            content:"LudoController",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Controllers/LudoController',
            title:"LudoController",
            description:""
        }
    );
    a(
        {
            id:18,
            title:"IPlayerFormExtractor",
            content:"IPlayerFormExtractor",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/IPlayerFormExtractor',
            title:"IPlayerFormExtractor",
            description:""
        }
    );
    a(
        {
            id:19,
            title:"Player",
            content:"Player",
            description:'',
            tags:''
        },
        {
            url:'/api/WebApp.Models.ApplicationModel/Player',
            title:"Player",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();
