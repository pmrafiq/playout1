namespace TAS.Common
{
    public static class Roles
    {
        public const string Playout = nameof(Playout);
        public const string Media = nameof(Media);
        public const string Preview = nameof(Preview);
        public const string UserAdmin = nameof(UserAdmin);
        public static string[] All = {Playout, Media, Preview, UserAdmin};
    }
}
