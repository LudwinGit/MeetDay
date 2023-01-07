namespace MeetDay.Infraestructura.Output.Data.Postgresql.Queries
{
    public static class CatalogQueries
    {
        public static string CatalogDocument = 
        @"
            select id key, name value from catalog_documents where state = 'ACT'
        ";        
    }
}