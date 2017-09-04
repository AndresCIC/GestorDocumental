<template>
	<div id="Detail" class="container-fluid">
		<form id ="FormularioDocumentos" class="mx-auto" style="width: 45%">
			<center>
				<div class="form-group">
					<button :disabled="this.isEditable" id="enableEditButton" class="btn btn-primary" v-on:click="buttonEnableEdit">Modificar</button>
					<button  id="cancelarButton" class="btn btn-primary" v-on:click="buttonCancelar">Cancelar</button>

				</div>
			</center>
			<div class="form-group">
				<label for="Nombre">Título:</label>
				<input :disabled="!isEditable" class="form-control" v-model="documento.Titulo" type="text" id="TituloInput" placeholder="Titulo"></input>
			</div>
			<div class="form-group">
				<label>Autor:</label>
				<input :disabled="!isEditable" class="form-control" type="text" v-model="documento.Autor" id="AutorInput" placeholder="Autor"></input>
			</div>
			<div class="form-group row">
				<div class="col-xs-6">
					<label>Fecha de creación:</label>
					
					<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.FechaCreacion" id="creacionInput" ></input>
					
				</div>
				<div class="col-xs-6">
					<label>Última modificación:</label>
					<input :disabled="!isEditable" class="form-control" type="date" v-model="documento.FechaUltimoModificado" id="ultimamodificacionInput"></input>
				</div>
			</div>
			<div class="form-group">
				<label>Tamaño:</label>
				<input :disabled="!isEditable" class="form-control" type="number" v-model="documento.Tamanio" id="tamanioInput" ></input>
			</div>
			<div class="form-group">
				<label>Tipo:</label>
				<select v-model="documento.Tipo" class="form-control" :disabled="!isEditable">
					<option value=0>Texto</option>
					<option value=1>Imagen</option>
					<option value=2>HTML</option>
					<option value=3>Hoja de cálculo</option>
				</select>
			</div>
			<div class="checkbox">
				<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="documento.SoloLectura" id="modificableInput" >Solo lectura</label>
				<label>	<input :disabled="!isEditable" class="checkbox" type="checkbox" v-model="documento.VersionFinal" id="ultimaversionInput" >Última versión</label>
			</div>
			<center>
				<div class="form-group">
					<button  id="acceptButton" :disabled="this.computeAcceptButton" class="btn btn-primary" v-on:click="buttonAccept">Aceptar</button>
					<button  id="borrarButton" :disabled="this.computeDeleteButton" class="btn btn-primary" v-on:click="buttonBorrar">Borrar</button>
				</div>
			</center>

		</form>
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
				},
				previousDocument:{
				},
				isEditable:false,
				isNew:true,
				state: constantes.STATE_NEW,
				currentId : "",
				menuChoice : "Documentos"


			}
		},
		computed:{
			computeAcceptButton: function(){
				if(!this.isEditable){
					return  true; 
				}
				else if(this.state == constantes.STATE_NEW){
					if(this.documento.Titulo==""|| this.documento.Autor==""){
						return  true; 
					}
					else if(this.documento.FechaCreacion == "" || this.documento.FechaUltimoModificado == ""){
						return  true; 
					}
					else if(this.documento.Tipo == "" || this.documento.Tamanio == ""){
						return  true; 
					}
					else{
						return false;
					}
				}
				else if(this.state == constantes.STATE_UPDATE){
					if(this.documento.Titulo != this.previousDocument.Titulo){
						return false;
					}
					else if(this.documento.Autor != this.previousDocument.Autor){
						return false;
					}
					else if(this.documento.FechaCreacion != this.previousDocument.FechaCreacion){
						return false;
					}
					else if(this.documento.FechaUltimoModificado != this.previousDocument.FechaUltimoModificado){
						return false;
					}
					else if(this.documento.Tipo != this.previousDocument.Tipo){
						return false;
					}
					else if(this.documento.SoloLectura != this.previousDocument.SoloLectura){
						return false;
					}
					else if(this.documento.VersionFinal != this.previousDocument.VersionFinal){
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
				this.previousDocument = $.extend({}, this.documento)
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

					
					$.ajax({url:baseURL + this.menuChoice,
						method:"POST",
						data: this.documento})	
					.done(this.afterPostHandler)
					.fail(function(){
						alert("Fallo en la creacion del elemento");
						//TODO: Gestionar los fallos
					})
					
					// TODO: Cuando este hecho, este alert sobra.
				}
				else if(this.state == constantes.STATE_UPDATE){
					// TODO: Se hace un PUT con el objeto
					$.ajax({url:constantes.BASE_URL + this.menuChoice + "/" + this.currentId,
						method:"PUT",
						data: this.documento})
					.done(this.putSubmitData)
				}
			},
			afterPostHandler(){
				alert("Elemento creado");
				// TODO: Se fuerza un get en el maestro y se cierra el detail.
				// Podemos llamar al metodo buttonCancelar.
			},
			putSubmitData(){
				alert("PUT realizado");
				this.previousDocument = $.extend({}, this.documento);

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
				this.documento.Titulo = "";
				this.documento.Autor = "";
				this.documento.FechaCreacion = "";
				this.documento.FechaUltimoModificado = "";
				this.documento.Tipo = "";
				this.documento.Tamanio = "";
				this.documento.VersionFinal = "";
				this.documento.SoloLectura = "";

				this.previousDocument.Titulo = "";
				this.previousDocument.Autor = "";
				this.previousDocument.FechaCreacion = "";
				this.previousDocument.FechaUltimoModificado = "";
				this.previousDocument.Tipo = "";
				this.previousDocument.Tamanio = "";
				this.previousDocument.VersionFinal = "";
				this.previousDocument.SoloLectura = "";
			},
			submitGetRequest(datos){
				this.currentId = datos.Id;

				this.documento = datos; 	
			}
			
		}, 
		mounted(){
			if(this.state == constantes.STATE_UPDATE){
				this.makeGetRequest();
			}
			else if(this.state == constantes.STATE_NEW){
				this.makeEmptyData();
				this.isEditable = true;
			}
		}
	}
</script>

<style></style>