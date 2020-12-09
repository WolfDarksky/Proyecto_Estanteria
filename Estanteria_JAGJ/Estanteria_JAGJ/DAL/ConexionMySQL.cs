using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estanteria_JAGJ.DAL
{
    public class ConexionMySQL
    {
        static MySqlConnection connMySQL1 = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;");
        
        // Conexion con MySQL de Prueba
        public static bool ConectionMySQL()
        {
            try
            {
                connMySQL1.Open();
                return true;
            }
            catch (Exception)
            {
                connMySQL1.Close();
                return true;
            }
        }

        public static void GuardarInfo_Estante(Models.EstanteModel _estanteModel)
        {
            using (MySqlConnection connMySQL = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;"))
            {
                try
                {
                    using (MySqlCommand commandMySQL = new MySqlCommand("AgregarInfo_Estante", connMySQL))
                    {
                        commandMySQL.CommandType = System.Data.CommandType.StoredProcedure;
                        commandMySQL.Parameters.Add(new MySqlParameter("descripcion", _estanteModel.Descripcion));
                        commandMySQL.Parameters.Add(new MySqlParameter("filas", _estanteModel.Filas));
                        commandMySQL.Parameters.Add(new MySqlParameter("columnas", _estanteModel.Columnas));
                        commandMySQL.Connection.Open();
                        commandMySQL.ExecuteNonQuery();
                        commandMySQL.Connection.Close();
                    }
                }
                catch (Exception)
                {
                    connMySQL.Close();
                    throw;
                }
            }
        }

        public static List<Models.EstanteModel> SeleccionarInfo_Estante(MySqlConnection _connMySQL = null)
        {
            List<Models.EstanteModel> lst;
            if (_connMySQL == null)
            {
                using (MySqlConnection connMySQL = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;"))
                {
                    lst = SeleccionarInfo(connMySQL);
                }
            }
            else
                 lst = SeleccionarInfo(_connMySQL);
            return lst;
        }

        private static List<Models.EstanteModel> SeleccionarInfo(MySqlConnection connMySQL)
        {
            try
            {
                using (MySqlCommand commandMySQL = new MySqlCommand("SeleccionarInfo_Estante", connMySQL))
                {
                    commandMySQL.CommandType = System.Data.CommandType.StoredProcedure;
                    commandMySQL.Connection.Open();
                    MySqlDataReader dr = commandMySQL.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                    List<Models.EstanteModel> lstEstantes = new List<Models.EstanteModel>();
                    while (dr.Read())
                    {
                        lstEstantes.Add(new Models.EstanteModel() { Codigo = Convert.ToInt32(dr["codigo"]), Descripcion = Convert.ToString(dr["descripcion"]), Filas = Convert.ToInt32(dr["filas"]), Columnas = Convert.ToInt32(dr["columnas"]) });
                    }
                    dr.Close();
                    commandMySQL.Connection.Close();
                    return lstEstantes;
                }
            }
            catch (Exception)
            {
                connMySQL.Close();
                throw;
            }
        }

        public static void GuardarInfo_AsignacionPosicion(Models.AsignaPosicionProd _asignaPosicionProdModel)
        {
            using (MySqlConnection connMySQL = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;"))
            {
                try
                {
                    using (MySqlCommand commandMySQL = new MySqlCommand("AgregarInfo_AsignaPosicionxProd", connMySQL))
                    {
                        commandMySQL.CommandType = System.Data.CommandType.StoredProcedure;
                        commandMySQL.Parameters.Add(new MySqlParameter("cod_estante", _asignaPosicionProdModel.CodEstante));
                        commandMySQL.Parameters.Add(new MySqlParameter("posicion", _asignaPosicionProdModel.Posicion));
                        commandMySQL.Parameters.Add(new MySqlParameter("nombre_prod", _asignaPosicionProdModel.NombreProd));
                        commandMySQL.Connection.Open();
                        commandMySQL.ExecuteNonQuery();
                        commandMySQL.Connection.Close();
                    }
                }
                catch (Exception)
                {
                    connMySQL.Close();
                    throw;
                }
            }
        }

        public static ObservableCollection<Models.AsignaPosicionProd> SeleccionarInfo_PosicionAsignada(int s_cod_estante)
        {
            ObservableCollection<Models.AsignaPosicionProd> lstPosicionAsignada = new ObservableCollection<Models.AsignaPosicionProd>();
            using (MySqlConnection connMySQL = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;"))
            {
                try
                {
                    using (MySqlCommand commandMySQL = new MySqlCommand("SeleccionarInfo_PosicionAsignada", connMySQL))
                    {
                        commandMySQL.CommandType = System.Data.CommandType.StoredProcedure;
                        commandMySQL.Connection.Open();
                        commandMySQL.Parameters.Add(new MySqlParameter("s_cod_estante", s_cod_estante));
                        MySqlDataReader dr = commandMySQL.ExecuteReader(System.Data.CommandBehavior.CloseConnection);

                        while (dr.Read())
                        {
                            lstPosicionAsignada.Add(new Models.AsignaPosicionProd() { Id = Convert.ToInt32(dr["id"]), CodEstante = Convert.ToInt32(dr["cod_estante"]), Posicion = Convert.ToString(dr["posicion"]), NombreProd = Convert.ToString(dr["nombre_prod"]), EsLiberado = Convert.ToBoolean(dr["es_liberado"]) }); //, FechaLiberado = Convert.ToDateTime(dr["fecha_liberado"]) 
                        }
                        dr.Close();
                        commandMySQL.Connection.Close();
                        return lstPosicionAsignada;
                    }
                }
                catch (Exception)
                {
                    connMySQL.Close();
                    throw;
                }
            }
        }

        public static void ActualizarInfo_PosicionAsignadaxLiberar(int id, DateTime fecha_liberada)
        {
            using (MySqlConnection connMySQL = new MySqlConnection("server=localhost; database=estanteria_jagj; uid=rootGlobal; pwd=123456;"))
            {
                try
                {
                    using (MySqlCommand commandMySQL = new MySqlCommand("ActualizarInfo_PosicionAsignadaLiberada", connMySQL))
                    {
                        commandMySQL.CommandType = System.Data.CommandType.StoredProcedure;
                        commandMySQL.Parameters.Add(new MySqlParameter("u_id", id));
                        commandMySQL.Parameters.Add(new MySqlParameter("u_fecha_liberada", fecha_liberada));
                        commandMySQL.Connection.Open();
                        commandMySQL.ExecuteNonQuery();
                        commandMySQL.Connection.Close();
                    }
                }
                catch (Exception)
                {
                    connMySQL.Close();
                    throw;
                }
            }
        }
    }
}
