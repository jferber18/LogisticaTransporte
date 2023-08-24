using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Model.Clases
{
    public class ModelConexion : GeneradorNombres
    {
        /// <param name="NombreSP">Nombre del procedimiento almacenado</param>
        /// <param name="Parametros">Lista de parámetros del tipo List SqlParamter </param>
        /// <param name="ConexionString">Cadena de conexión a la base de datos</param>
        /// <returns></returns>
        public DataTable EjecutarProcedimientoAlmacenado(string NombreSP, List<SqlParameter> Parametros, string ConnetionString)
        {
            try
            {
                ConnetionString = ConfigurationManager.ConnectionStrings[ConnetionString] != null ? ConfigurationManager.ConnectionStrings[ConnetionString].ToString() : ConnetionString;

                SqlConnection cn = new SqlConnection(ConnetionString);
                SqlDataAdapter da = null;
                SqlTransaction tr = null; //transaccion actual
                SqlCommand cmd;
                DataSet ds;
                cn.Open();//abrir conexion
                          //Ejecutar el procedimiento como una transacción
                tr = cn.BeginTransaction();
                cmd = cn.CreateCommand();
                cmd.Connection = cn;
                cmd.Transaction = tr;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = NombreSP;

                ds = new DataSet();
                try
                {
                    //Determinar si hay parámetros en el procedimiento
                    if (Parametros != null)
                    {
                        //Añadir cada parámetro al procedimiento
                        foreach (SqlParameter item in Parametros)
                        {
                            cmd.Parameters.Add(item);
                        }
                    }//if (Parametros != null)
                    //SqlAdapter utiliza el SqlCommand para llenar el Dataset
                    da = new SqlDataAdapter(cmd);
                    //ejecuta procedimiento y llena el dataset (En lugar de cmd.ExecuteNonQuery(), Este a su vez retorna la cantidad de filas afectadas.)
                    da.SelectCommand.CommandTimeout = 180;//Máximo 3 minutos
                    da.Fill(ds);
                    //Completar la transacción
                    tr.Commit();
                    tr.Dispose();
                    da.Dispose();
                }
                catch (Exception ex)
                {
                    tr.Rollback();//Devolver la ejecución de la transacción
                    throw (ex);
                }
                finally
                {
                    //Cerrar conexión con o sin error
                    if (cn.State.Equals(ConnectionState.Open))
                    {
                        da.Dispose();//destruir el DataAdapter
                        da = null;
                        tr.Dispose();//destruir la transaccion
                        tr = null;
                        cmd.Parameters.Clear();
                        cmd.Dispose(); //destruir el comando
                        cmd = null;
                        cn.Close(); //cerrar conexión
                        cn.Dispose(); //Eliminar conexión
                        cn = null;
                    }
                }
                //Agregado por Wiston Mazo  --- se agrega codigo que calcula cual es la ultima tabla de la coleccion y devuelve el indice de esta
                Int32 LastChild = ds.Tables.Count - 1;
                if (LastChild == -1)
                {
                    return new DataTable();
                }
                return ds.Tables[LastChild];//Devolver el DataTable
            }
            catch (Exception ex)
            {

                throw (ex);

            }//try

        }//EjecutarProcedimientoAlmacenado

    }//public class Conexion

    public class GeneradorNombres
    {
        /*Genera un nombre aleatorio de archivo con la misma extencion*/
        public static string GenerarNombre(string Prefijo)
        {
            Random Num = new Random();
            int num = Num.Next(1000, 9999);
            return Prefijo + DateTime.Now.ToString().Replace(@"/", "").Replace(":", "").Replace(" ", "") + num + mychar();
        }
        /*Genera 6 letras aleatorias*/
        public static string mychar()
        {
            Random Num = new Random();
            string _mychar = "";
            for (int i = 0; i < 6; i++)
            {
                int _number = Num.Next(0, 26);
                switch (_number)
                {
                    case 0:
                        _mychar += "q";
                        break;
                    case 1:
                        _mychar += "w";
                        break;
                    case 2:
                        _mychar += "e";
                        break;
                    case 3:
                        _mychar += "r";
                        break;
                    case 4:
                        _mychar += "t";
                        break;
                    case 5:
                        _mychar += "y";
                        break;
                    case 6:
                        _mychar += "u";
                        break;
                    case 7:
                        _mychar += "i";
                        break;
                    case 8:
                        _mychar += "o";
                        break;
                    case 9:
                        _mychar += "p";
                        break;
                    case 10:
                        _mychar += "a";
                        break;
                    case 11:
                        _mychar += "s";
                        break;
                    case 12:
                        _mychar += "d";
                        break;
                    case 13:
                        _mychar += "f";
                        break;
                    case 14:
                        _mychar += "g";
                        break;
                    case 15:
                        _mychar += "h";
                        break;
                    case 16:
                        _mychar += "j";
                        break;
                    case 17:
                        _mychar += "k";
                        break;
                    case 18:
                        _mychar += "l";
                        break;
                    case 19:
                        _mychar += "l";
                        break;
                    case 20:
                        _mychar += "z";
                        break;
                    case 21:
                        _mychar += "x";
                        break;
                    case 22:
                        _mychar += "c";
                        break;
                    case 23:
                        _mychar += "v";
                        break;
                    case 24:
                        _mychar += "b";
                        break;
                    case 25:
                        _mychar += "n";
                        break;
                    case 26:
                        _mychar += "m";
                        break;
                    default:
                        _mychar += "_";
                        break;
                }
            }
            return _mychar;
        }
    }
}
