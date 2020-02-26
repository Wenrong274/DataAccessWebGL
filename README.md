# DataAccessWebGL #

Unity 在 WebGL 時存/讀檔案的方式，檔案是放在 IndexedDB。

`IndexedDB` 是有容量大小限制，所以需要注意存儲的檔案大小。

## About IndexedDB ##

[Working with quota on mobile browsers]

![img_1]

## Introduction ##

* File Path

`string.Format("{0}/{1}.dat", Application.persistentDataPath, FileName);`

* Save Method

``` csharp
DataAccess.Save(fileName, bytes);
```

* Load Method

``` csharp
byte[] bytes = DataAccess.Load(fileName);
```

* Example Scene

`root\Assets\WebGL\Example\Scenes\Example`

______________________________________________________________________


[img_1]:./doc/img/1.png
[Working with quota on mobile browsers]:https://www.html5rocks.com/en/tutorials/offline/quota-research/
