process.stdin.resume();
process.stdin.setEncoding('utf8');

const fSnakeToUpperCamel = function(p){
    return p.replace(/_./g,
            function(s) {
                return s.charAt(1).toUpperCase();
            }
    ).replace(/^[a-z]/g, function (val) {
        return val.toUpperCase();
    });
};

const typeMap = {
    "string" : "string",
    "integer" : "int",
    "boolean" : "bool"
}

const schema = {
                                            "room_id":           {
                                          "type": "integer"
                                        },
                                        "name":              {
                                          "type": "string"
                                        },
                                        "type":              {
                                          "type": "string",
                                          "enum": ["my", "direct", "group"]
                                        },
                                        "role":            {
                                          "type": "string",
                                          "enum": ["admin", "member", "readonly"]
                                        },
                                        "sticky":            {
                                          "type": "boolean"
                                        },
                                        "unread_num":        {
                                          "type": "integer"
                                        },
                                        "mention_num":       {
                                          "type": "integer"
                                        },
                                        "mytask_num":        {
                                          "type": "integer"
                                        },
                                        "message_num":       {
                                          "type": "integer"
                                        },
                                        "file_num":          {
                                          "type": "integer"
                                        },
                                        "task_num":          {
                                          "type": "integer"
                                        },
                                        "icon_path":         {
                                          "type": "string"
                                        },
                                        "last_update_time":  {
                                          "type": "integer"
                                        }
}



var result = "";
var define = "";

Object.keys(schema).map(propName => {
   const isEnumValue = Boolean(schema[propName].enum);
   if (isEnumValue) {
       const enumTypeName = fSnakeToUpperCamel(propName);
       define += `
       public enum ${enumTypeName} {
           ${schema[propName].enum.join(",\n")}
       }
       `
       result += `public ${enumTypeName} ${propName} { get; set; }\n`    
       
   } else {
       result += `public ${typeMap[schema[propName].type]} ${propName} { get; set; }\n`
   }
});

console.log(result + "\n\n" +define);