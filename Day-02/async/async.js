/* Sync */
function add(x,y){
    console.log("[SP] processing the data");
    var result = x + y;
    console.log("[SP] returning the result");
    return result;
}

function addClient(x,y){
    console.log("[SC] triggering add");
    var result = add(x,y);
    console.log("[SC] result = ", result);
}

/* Async - Callback*/
function addAsync(x,y, onResult){
    console.log("[SP] processing the data");
    setTimeout(function(){
        var result = x + y;
        console.log("[SP] returning the result");
        if (typeof onResult === "function")
            onResult(result);
    },3000);
}

function addAsyncClient(x,y){
    console.log("[SC] triggering add");
    addAsync(x,y, function(result){
        console.log("[SC] result = ", result);
    });
}

/* Async - Promise*/
function add(x,y){
    console.log("[SP] processing the data");
    var promise = new Promise(function(resolve, reject){
        setTimeout(function(){
            if (!x || !y){
                reject(new Error("Invalid arguments"));
                return;
            }
            var result = x + y;
            console.log("[SP] returning the result");
            resolve(result);
        },3000);
    });
    return promise;
}

var p = add(100,0)
p.catch(function(err){
    console.log(err);
});





















