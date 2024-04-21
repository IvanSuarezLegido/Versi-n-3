// programa en C para introducir los datos en la base de datos
//Incluir esta libreria para poder hacer las llamadas en shiva2.upc.es
//#include <my_global.h>
#include <mysql.h>
#include <string.h>
#include <stdlib.h>
#include <stdio.h>
int main(int argc, char **argv) {
	MYSQL *conn;
	int err;
	char nombre [25];
	char contra [25];
	char IDs [3];
	int i;
	char consulta [80];
	//Creamos una conexion al servidor MYSQL
	conn = mysql_init(NULL);
	if (conn==NULL) {
		printf ("Error al crear la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//inicializar la conexiￃﾳn, entrando nuestras claves de acceso y
	//el nombre de la base de datos a la que queremos acceder
	conn = mysql_real_connect (conn, "localhost","root", "mysql", "juego",0, NULL, 0);
	if (conn==NULL) {
		printf ("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	//Introduciremos en la base de datos 4 personas,
	//cuyos datos pedimos al usuario
	for (i=0; i<4; i++) {
		printf ("Escribe Nombre y Contrasenya, separados por un espacio en blanco\n");
		err = scanf ("%s %s", nombre, contra);
		if (err!=2) {
			printf ("Error al introducir los datos \n");
			exit (1);
		}
		// Ahora construimos el string con el comando SQL
		// para insertar la persona en la base. Ese string es:
		// INSERT INTO Jugadores VALUES (ID, 'Nombre', 'Contraseña');
		strcpy (consulta, "INSERT INTO Jugadores VALUES (");
		//concatenamos el ID
		sprintf(IDs, "%d", i+1);
		strcat (consulta, IDs);
		strcat (consulta, ",'");
		//concatenamos el nombre
		strcat (consulta, nombre);
		strcat (consulta, "','");
		//concatenamos la contra
		strcat (consulta, contra);
		strcat (consulta, "');");
		printf("consulta = %s\n", consulta);
		// Ahora ya podemos realizar la insercion
		err = mysql_query(conn, consulta);
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
	}
	// cerrar la conexion con el servidor MYSQL
	mysql_close (conn);
	exit(0);
}
