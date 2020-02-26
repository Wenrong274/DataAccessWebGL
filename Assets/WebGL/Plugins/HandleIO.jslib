var HandleIO = {
    WindowAlert: function (message) {
        window.alert(Pointer_stringify(message));
    },
    SyncFiles: function () {
        FS.syncfs(false, function (err) {
            // handle callback
        });
    },
        ReadFiles : function()
     {
         FS.syncfs(true,function (err) {
             // handle callback
         });
     }
};

mergeInto(LibraryManager.library, HandleIO);
