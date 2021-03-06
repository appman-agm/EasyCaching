# DefaultProtobufSerializer

DefaultProtobufSerializer is a serializer based on **protobuf-net**.

# How to Use?

## Install the package via Nuget

```
Install-Package EasyCaching.Serialization.Protobuf
```

## Use In EasyCaching.Redis

```
public class Startup
{
    //others...

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddDefaultRedisCache(option=>
        {                
            option.Endpoints.Add(new ServerEndPoint("127.0.0.1", 6379));
            option.Password = "";                                                  
        });
        //put after AddDefaultRedisCache
        //in order to replace DefaultBinaryFormatterSerializer
        services.AddDefaultProtobufSerializer();
    }
}
```

## Use In EasyCaching.Memcached

```
public class Startup
{
    //others...

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();

        services.AddDefaultMemcached(op=>
        {                
            op.AddServer("127.0.0.1",11211);
            //specify the Transcoder use json .
            op.Transcoder = "EasyCaching.Memcached.FormatterTranscoder,EasyCaching.Memcached" ;
            op.SerializationType = "EasyCaching.Serialization.Protobuf.DefaultProtobufSerializer,EasyCaching.Serialization.Protobuf";
        });
    }
}
```
