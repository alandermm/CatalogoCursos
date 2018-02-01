using System.Linq;

namespace CatalogoCursos.Dados
{
    public class IniciarBanco
    {
        public static void Inicializar(CatalogoContext contexto){
            contexto.Database.EnsureCreated();

            if(contexto.Area.Any()){
                return;
            }

            var Area = new Area();

            
        }
    }
}