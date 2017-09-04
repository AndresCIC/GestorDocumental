<template>
	<div id="Detail" class="detail-div">
		<div id ="FormularioDocumentos">
			<center>
				<div class="form-group">
					<button v-if="!this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit">Habilitar edición</button>
					<button v-else id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit">Deshabilitar edición</button>
				</div>
			</center>
			<div class="form-group">
				<label for="Nombre">Título:</label>
				<input :disabled="!isEditable" class="form-control" v-model="documento.titulo" type="text" id="tituloInput" placeholder="Titulo"></input>
			</div>
			<div class="form-group">
				<label>Autor:</label>
				<input :disabled="!isEditable" class="form-control" type="text" v-model="documento.autor" id="autorInput" placeholder="Autor"></input>
			</div>
			<div class="form-group">
				<div class="col-xs-6">
					<label>Fecha de creación:</label>
					<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.creacion" id="creacionInput" ></input>
				</div>
				<div class="col-xs-6">
					<label>Última modificación:</label>
					<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.ultimamodificacion" id="ultimamodificacionInput" ></input>
				</div>
			</div>
			<div class="form-group">
				<label>Tipo:</label>
				<select v-model="documento.tipo" class="form-control" :disabled="!isEditable">
					<option value=0>Texto</option>
					<option value=1>Imagen</option>
					<option value=2>HTML</option>
					<option value=3>Hoja de cálculo</option>
				</select>
			</div>
			<div class="checkbox">
				<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="documento.modificable" id="modificableInput" >Solo lectura</label>
				<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="documento.ultimaversion" id="ultimaversionInput" >Última versión</label>
			</div>
			<center>
				<div class="form-group">
					<button  id="acceptButton" :disabled="this.computeAcceptButton" class="btn btn-primary" v-on:click="buttonAccept">Aceptar</button>
					<button  id="cancelarButton" class="btn btn-primary" v-on:click="buttonCancelar">Cancelar</button>
					<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-primary" v-on:click="buttonBorrar">Borrar</button>
				</div>
			</center>

		</div>
	</div>
</template>

<script>
	import { EventBus } from './eventBus.js';
	import constantes from './constants.js';

	export default{
		created() {
			EventBus.$on('enableDetail', read => {
				this.read = read;
			});
		},	
		components:{
		},
		data (){
			return{
				documento:{
					titulo:"",
					autor:"",
					creacion:"",
					ultimamodificacion:"",
					tipo:"",
					modificable:"",
					ultimaversion:""
				},
				previousDocument:{
					titulo:"",
					autor:"",
					creacion:"",
					ultimamodificacion:"",
					tipo:"",
					modificable:"",
					ultimaversion:""
				},
				isEditable:false,
				isNew:true,
				state: constantes.STATE_UPDATE,
				currentId : 3,
				menuChoice : "Documentos"


			}
		},
		computed:{
			computeAcceptButton: function(){
				if(!this.isEditable){
					return  true; 
				}
				else if(this.state == constantes.STATE_NEW){
					if(this.documento.titulo==""|| this.documento.autor==""){
						return  true; 
					}
					else if(this.documento.creacion == "" || this.documento.ultimamodificacion == ""){
						return  true; 
					}
					else if(this.documento.tipo == ""){
						return  true; 
					}
					else{
						return false;
					}
				}
				else if(this.state == constantes.STATE_UPDATE){
					if(this.documento.titulo != this.previousDocument.titulo){
						return false;
					}
					else if(this.documento.autor != this.previousDocument.autor){
						return false;
					}
					else if(this.documento.creacion != this.previousDocument.creacion){
						return false;
					}
					else if(this.documento.ultimamodificacion != this.previousDocument.ultimamodificacion){
						return false;
					}
					else if(this.documento.tipo != this.previousDocument.tipo){
						return false;
					}
					else if(this.documento.modificable != this.previousDocument.modificable){
						return false;
					}
					else if(this.documento.ultimaversion != this.previousDocument.ultimaversion){
						return false;
					}
					else{return true;}
				}
			},
			computeDeleteButton: function(){
				if(!this.isEditable){
					return true;
				}
				else if(this.state == constantes.STATE_UPDATE){
					return false;
				}
				else {return true};
			}
		},
		methods:{
			buttonEnableEdit: function(){
				this.isEditable = !this.isEditable;
			},
			buttonBorrar: function(){
				if(confirm("¿Está seguro de que quiere borrar?")){
					//TODO: Peticion AJAX
					$.ajax({
						url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method: "DELETE"
					})
					.done(this.borradoHandler)
					.fail(function(){alert("Ha habido un error al borrar.");})
				}
			},
			buttonCancelar: function(){
				// TODO: Cancel method
				// Envia un eventbus o un emit al master para que cierre el detail

				// Habrá que poner una variable a "" o algo.

			},
			borradoHandler: function(){
				alert("Elemento borrado correctamente.");
				this.makeEmptyData();
			},
			buttonAccept: function(){
				if(this.state == constantes.STATE_NEW){
					// TODO: Crear el objeto datos

					/*
					$.ajax({url:baseURL + this.menuChoice,
						method:"POST",
						data: datos})	
					.done(this.afterPostHandler)
					.fail(function(){
						alert("Fallo en la creacion del elemento");
						//TODO: Gestionar los fallos
					})
					*/
					// TODO: Cuando este hecho, este alert sobra.
					alert("POST realizado");
				}
				else if(this.state == constantes.STATE_UPDATE){
					// TODO: Se hace un PUT con el objeto
					alert("PUT realizado");
				}
			},
			makeGetRequest(){
				$.ajax({
					url: constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
					method: "GET"
				})
				.done(this.submitGetRequest)
				.fail(function(){
					alert("Ha fallado la carga del objeto");
				})
			},
			makeEmptyData(){
				this.currentId = "";
				this.documento.titulo = "";
				this.documento.autor = "";
				this.documento.creacion = "";
				this.documento.ultimamodificacion = "";
				this.documento.tipo = "";
				this.documento.ultimaversion = "";
				this.documento.modificable = "";

				this.previousDocument.titulo = "";
				this.previousDocument.autor = "";
				this.previousDocument.creacion = "";
				this.previousDocument.ultimamodificacion = "";
				this.previousDocument.tipo = "";
				this.previousDocument.ultimaversion = "";
				this.previousDocument.modificable = "";
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;
				this.documento.titulo = datos.Titulo;
				this.documento.autor = datos.Autor;
				this.documento.creacion = datos.FechaCreacion;
				this.documento.ultimamodificacion = datos.FechaUltimoModificado;
				this.documento.tipo = datos.Tipo;
				this.documento.ultimaversion = datos.VersionFinal;
				this.documento.modificable = datos.SoloLectura;

				this.previousDocument.titulo = datos.Titulo;
				this.previousDocument.autor = datos.Autor;
				this.previousDocument.creacion = datos.FechaCreacion;
				this.previousDocument.ultimamodificacion = datos.FechaUltimoModificado;
				this.previousDocument.tipo = datos.Tipo;
				this.previousDocument.ultimaversion = datos.VersionFinal;
				this.previousDocument.modificable = datos.SoloLectura;
			}
			
		}, 
		mounted(){
			if(this.state == constantes.STATE_UPDATE){
				this.makeGetRequest();
			}
			else if(this.state == constantes.STATE_NEW){
				this.makeEmptyData();
			}
		}
	}
</script>

<style></style>