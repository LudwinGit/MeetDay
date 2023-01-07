namespace MeetDay.Infraestructura.Output.Data.Postgresql.Queries
{
    public static class ManagementQueries
    {
        public static string DocumentsManagement =
        @"
        select 
            dm.catalogdocumentid key, 
            cd.name value
        from 
            document_management dm 
        join 
            catalog_documents  cd on dm.catalogdocumentid = cd.id
        where 
            dm.managementid  = :managementId
        ";
    }
}