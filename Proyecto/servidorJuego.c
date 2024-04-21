#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <ctype.h>
#include <mysql.h>
#include <pthread.h>

int contador;
int conectados;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;

int i=0;
int sockets[100];

typedef struct {
	char nombre[20];
	int socket;
} Conectado;

typedef struct {
	Conectado conectados[100];
	int num;
} ListaConectados;

ListaConectados lista;

void DameConectados(ListaConectados* lista, char conectados[300])
{
	int i;
	char temp[300];
	
	//sprintf(conectados, "9-%d", lista->num);
	
	for (i = 0; i < lista->num; i++)
	{
		
		sprintf(temp, "%s", lista->conectados[i].nombre);
		sprintf(conectados,"%s%s/", conectados, temp);
	}
	printf("temp: %s ",temp);
}

int Eliminar(ListaConectados *lista, char nombre[20]) {
	//devuelve 0 si elimina y -1 si no esta en la lista
	int pos = DamePosicion(lista, nombre);
	if (pos == -1) return -1;
	else {
		for (int i = pos; i < lista->num-1; ++i) {
			lista->conectados[i] = lista->conectados[i+1];
			//strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			//lista->conectados[i].socket = lista->conectados[i+1].socket;
		}
		lista->num--;
		return 0;
	}
}
int DamePosicion(ListaConectados *lista, char nombre[20]) {
	//devuelve la posicion o -1 si no esta en la lista
	int i =0;
	int encontrado = 0;
	while ((i < lista->num) && !encontrado) {
		if (strcmp(lista->conectados[i].nombre, nombre) == 0) {
			encontrado = 1;
		}
		else 
			i++;
	}
	if (encontrado)
		return i;
	else 
		return -1;
}
int Ponga (ListaConectados *lista, char nombre[20], int socket) {
	//Te pone un conectado 
	if (lista->num == 100) return -1;
	else {
		strcpy(lista->conectados[lista->num].nombre, nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}
char* numeroVictorias(char nombre[20], char respuesta[512], char consulta[80], int err, MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	strcpy (consulta,"SELECT Wins FROM RankingGanadores WHERE Jugador = (SELECT ID From Jugadores WHERE nombre = '");
	strcat(consulta, nombre);
	strcat(consulta, "')");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL) {
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(respuesta, "0");
	}
	else {
		int res = atoi(row[0]);
		sprintf(respuesta, "%d", res);
	}
	return respuesta;
}
char* mejorJugador(char respuesta[512], char consulta[80], int err, MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	strcpy (consulta,"SELECT nombre FROM Jugadores WHERE ID = (SELECT Jugador FROM RankingGanadores WHERE Wins = (SELECT MAX(Wins) FROM RankingGanadores LIMIT 1) LIMIT 1) LIMIT 1");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	strcpy(respuesta, row[0]);
	return respuesta;
}


char* numeroMuertes(char nombre[20], char respuesta[512], char consulta[80], int err, MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	strcpy (consulta,"SELECT Muertes FROM Cementerio WHERE Jugador = (SELECT ID From Jugadores WHERE nombre = '");
	strcat(consulta, nombre);
	strcat(consulta, "')");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL) {
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(respuesta, "0");
	}
	else {
		int res = atoi(row[0]);
		sprintf(respuesta, "%d", res);
	}
	return respuesta;
}
char* maxTurnos(char respuesta[512], char consulta[80], int err, MYSQL *conn) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	strcpy (consulta,"SELECT ID FROM Partida WHERE Turnos = (SELECT MAX(Turnos) from Partida LIMIT 1)");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL) {
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(respuesta, "Error");
	}
	else {
		int res = atoi(row[0]);
		sprintf(respuesta, "%d", res);
	}
	return respuesta;
}

char* logueo(char nombre[20], char contra[20], char respuesta[512], MYSQL *conn, int err, char consulta[80]){
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	printf("Nombre: %s, Contra: %s\n", nombre, contra);
	strcpy (consulta, "SELECT nombre FROM Jugadores WHERE nombre='");
	strcat (consulta, nombre);
	strcat (consulta, "' AND contrasenya='");
	//concatenamos el nombre
	strcat (consulta, contra);
	strcat (consulta, "'");
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (row == NULL) {
		printf ("No se han obtenido datos en la consulta\n");
		strcpy(respuesta, "Error");
	}
	else {
		strcpy(respuesta, nombre);
	}
	return respuesta;
}

char* registro(char nombre[20], char contra[20], char respuesta[512], MYSQL *conn, int err, char consulta[80]) {
	MYSQL_RES *resultado;
	MYSQL_ROW row;
	printf("Nombre: %s, Contra: %s\n", nombre, contra);
	strcpy (consulta,"SELECT COUNT(*) FROM Jugadores WHERE nombre = '");
	strcat (consulta, nombre);
	strcat (consulta, "'");
	// hacemos la consulta
	err=mysql_query (conn, consulta);
	if (err!=0) {
		printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit (1);
	}
	resultado = mysql_store_result (conn);
	row = mysql_fetch_row (resultado);
	if (atoi(row[0]) > 0)
	{
		strcpy(respuesta, "Jugador ya registrado");
		return respuesta;
	}
	else {
		strcpy (consulta,"SELECT COUNT(*) FROM Jugadores");
		
		// hacemos la consulta
		err=mysql_query (conn, consulta);
		
		if (err!=0) {
			printf ("Error al consultar datos de la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			exit (1);
		}
		
		//recogemos el resultado de la consulta
		MYSQL_RES* nJugadoresC;
		nJugadoresC = mysql_store_result (conn);
		row = mysql_fetch_row (nJugadoresC);
		
		if (row == NULL)
			printf ("No se han obtenido datos en la consulta\n");
		
		int nJugadores = atoi(row[0]);
		
		strcpy (consulta, "INSERT INTO Jugadores VALUES (");
		char buffer[20];
		sprintf(buffer, "%d", nJugadores+1);
		strcat(consulta, buffer);
		strcat (consulta, ",'");
		strcat (consulta, nombre);
		strcat (consulta, "','");
		strcat (consulta, contra);
		strcat (consulta, "');");
		err = mysql_query(conn, consulta);
		if (err!=0) {
			printf ("Error al introducir datos la base %u %s\n", mysql_errno(conn), mysql_error(conn));
			strcpy(respuesta, "Error al introducir los datos");
			return respuesta;
			exit (1);
		}
		else {				
			strcpy(respuesta, "Jugador registrado");
			
		}
		return respuesta;
	}
}




void *AtenderCliente(void *socket) {
	char peticion[512];
	char respuesta[512];
	char contestacion[512];
	int err, ret;
	char consulta [80];
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
	MYSQL *conn;
	//conexion con la base de datos
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
	
	int terminar = 0;
	while (terminar == 0) {
		memset(contestacion, 0, 512);
		memset(respuesta, 0, 512);
		//Ahora recibimos su nombre, que dejamos en buff
		ret = read(sock_conn, peticion, sizeof(peticion));
		printf("Recibido\n");
		//Tenemos que anadirle la marca de fin de string
		//para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		//escribimos nombre en la consola
		printf("Peticion: %s\n", peticion);
		//vamos a ver que quieren
		char *p = strtok(peticion, "/");
		int codigo = atoi(p);
		char nombre[20];
		if (codigo != 0 && codigo != 8 && codigo != 9) {
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		if (codigo == 0) 
			terminar = 1;
		else if (codigo == 1) {//registrar usuario
			p = strtok(NULL, "/");
			char contra[20];
			strcpy(contra, p);
			sprintf(respuesta,"1/%s",registro(nombre, contra, respuesta, conn, err, consulta) );
		}
		else if (codigo == 2) {//logueo
			p = strtok(NULL, "/");
			if (p != NULL) {
				char contra[20];
				strcpy(contra, p);
				sprintf(respuesta,"2/%s", logueo(nombre, contra, respuesta, conn, err, consulta));
				pthread_mutex_lock(&mutex);
				if (strcmp(respuesta, "Error") != 0)  {
					conectados++;
					Ponga(&lista, nombre, s);
					printf("Logeado: %s %d\n", lista.conectados[0].nombre, conectados);
					
					DameConectados(&lista, contestacion);
					printf("Contestacion: %s\n",contestacion );
					sprintf(respuesta, "2/%s", contestacion);
					write(sock_conn, respuesta, strlen(respuesta));
				}
				pthread_mutex_unlock(&mutex);
				//notificar a todos los clientes conectados
				char notificacion[512];
				sprintf(notificacion, "9/%d/%s", conectados, contestacion);
				int j;
				for (j=0; j< i; j++)
					write (sockets[j],notificacion, strlen(notificacion));
			}
			//si respuesta es diferente de error metemos el nombre en la lista de conectados
		}	
		else if (codigo == 3){ //decir max turnos
			printf("Codigo: %d\n", codigo);
			sprintf(respuesta,"3/%s", maxTurnos(respuesta, consulta, err, conn));
			
		}
		else if (codigo == 4) { //victorias de 
			printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
			sprintf(respuesta,"4/%s", numeroVictorias(nombre, respuesta, consulta, err, conn));
		}
		else if (codigo == 5) { //mejor jugador
			printf("Codigo: %d\n", codigo);
			sprintf(respuesta,"5/%s", mejorJugador(respuesta, consulta, err, conn));
		}	
		else if (codigo == 6) { //muertos
			
			printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
			sprintf(respuesta,"6/%s", numeroMuertes(nombre, respuesta, consulta, err, conn));
			
		}
		else if (codigo == 7){ //cerrar sesion
			pthread_mutex_lock(&mutex);
			printf("Codigo: %d Nombre: %s\n", codigo, nombre);
			int eli = Eliminar(&lista, nombre);
			contador--;
			DameConectados(&lista, contestacion);
			//sprintf(respuesta, "%s", contestacion);
			sprintf(respuesta, "7/%d" ,eli);
			write(sock_conn, respuesta, strlen(respuesta));
			pthread_mutex_unlock(&mutex);
		}
		else if (codigo == 8){ //contador de tareas
			sprintf(respuesta,"8/%d", contador);
		}
/*		else if (codigo == 9) {*/
/*			pthread_mutex_lock(&mutex);*/
/*			DameConectados(&lista, contestacion);*/
/*			sprintf(respuesta, "9/%s", contestacion);*/
/*			write(sock_conn, respuesta, strlen(respuesta));*/
/*			pthread_mutex_unlock(&mutex);*/
			
/*		}*/
		if (codigo != 0) {
			printf("Respuesta: %s\n", respuesta);
			//enviamos
			write(sock_conn, respuesta, strlen(respuesta));
		}
/*		if (codigo >= 1 && codigo <= 7) {*/
/*			pthread_mutex_lock(&mutex);*/
/*			contador++;*/
/*			pthread_mutex_unlock(&mutex);*/
			
/*		}*/
	}
}


int main(int argc, char *argv[]) {
	int *s;
	int sock_conn, sock_listen;
	s = (int *) socket;
	sock_conn = *s;
	MYSQL *conn;
	//conexion con la base de datos
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
	struct sockaddr_in serv_adr;
	//inicializacion
	//abrimos socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error al crear el socket");
	//Bindeamos el puerto
	memset(&serv_adr, 0, sizeof(serv_adr)); //inicializa a zero el serv_addr
	serv_adr.sin_family = AF_INET;
	//asocia el socket a cualqueira de las IP de la maquina
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	//escucharemos en el port 9050
	serv_adr.sin_port = htons(9100);
	// Reiniciamos el puerto de escucha
	const char *comando = "fuser -k 9100/tcp";
	
	// Ejecutar el comando
	int resultado = system(comando);
	
	// Verificar si la ejecucion fue exitosa
	
	if (resultado == -1) 
	{
		perror("Error al ejecutar el comando\n");
	} 
	else
	{
		printf("Puerto 9100 en TCP liberado.\n");
	}
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error al listen");
	contador=0;
	
	pthread_t thread;
	//atenderemos infinitas peticiones
	for (;;){
		printf("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexion\n");
		sockets[i] = sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		pthread_create(&thread, NULL, AtenderCliente, &sockets[i]);
		i++;
	}
	close(sock_conn);
	mysql_close (conn);
	exit(0);
}

