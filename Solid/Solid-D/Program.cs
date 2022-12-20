using System.Text.Json;

string origin = "ruta";
string dbPath = "path";

IInfo info = new InfoByFile(origin);

Monitor monitor = new Monitor(origin, info);
await monitor.Show();

FileDB fileDB = new FileDB(dbPath,origin, info);
await fileDB.Save();







public class Monitor
{
    private string _origin;
    private IInfo _info;

    public Monitor(string origin, IInfo info)
    {
        _origin = origin;
        _info = info;
    }

    public async Task Show()
    {
        //InfoByFile info = new InfoByFile(_origin);

        var posts = await _info.Get();
        foreach(var post in posts)
        {
            Console.WriteLine(post.Title);
        }
    }
}

public class FileDB
{
    private string _path;
    private string _origin;
    private IInfo _info;

    public FileDB(string path, string origin, IInfo info)
    {
        _path = path;
        _origin = origin;
        _info = info;

    }


    public async Task Save()
    {

        //InfoByFile info = new InfoByFile(_origin);
        var post = _info.Get();
        string json = JsonSerializer.Serialize(post);
        await File.WriteAllTextAsync(_path, json);
    }

}


public class InfoByFile : IInfo
{
    private string _path;

    public InfoByFile(string path)
    {
        _path = path;
    }
    public async Task<IEnumerable<Post>> Get()
    {
        var contentStream = new FileStream(_path, FileMode.Open, FileAccess.Read);
        IEnumerable<Post> posts = await JsonSerializer.DeserializeAsync<IEnumerable<Post>>(contentStream);
        return posts;
    }
}

public class InfoByRequest : IInfo
{
    private string _url;

    public InfoByRequest(string url)
    {
        _url = url;
    }

    public async Task<IEnumerable<Post>> Get()
    {
        HttpClient httpClient = new HttpClient();

        var response = await httpClient.GetAsync(_url);
        var stream = await response.Content.ReadAsStreamAsync();
        List<Post> post = await JsonSerializer.DeserializeAsync<List<Post>>(stream);
        return post;
    }
}


public interface IInfo
{
    public Task<IEnumerable<Post>> Get();
}

public class Post
{
    public int Id { get; set; }
    public int UserID { get; set; }
    public string Title { get; set; }
    public bool Completed { get; set; }
}


