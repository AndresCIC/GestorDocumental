<template>
	<div id="Detail" class="detail-div">
		<div id ="FormularioPerfiles">
				<form>
					<div class="form-group">
						<label for="Nombre">Nombre:</label>
						<input :disabled="read" class="form-control" v-model="usuario.nombre" type="text" id="nombreInput" placeholder="Nombre"></input>
					</div>
					<div class="form-group">
						<label>Apellido:</label>
						<input :disabled="read" class="form-control" type="text" v-model="usuario.apellidos" id="apellidoInput" placeholder="Apellido"></input>
					</div>
					<div class="form-group">
						<label>Edad:</label>
						<input :disabled="read" class="form-control" type="number" v-model="usuario.edad" id="edadInput" placeholder="Edad"></input>
					</div>
					<div class="form-group">
						<button  id="acceptButton" class="btn btn-primary" v-on:click="buttonAccept">ACEPTAR</button>
						<button  id="limpiarButton" class="btn btn-primary" v-on:click="buttonClean">LIMPIAR</button>
						<button  id="resetButton" class="btn btn-primary" v-on:click="buttonReset">RESET</button>
					</div>
				</form>
			</div>
	</div>
	</template>

<script>
import { EventBus } from './eventBus.js';

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
			}
		},
		computed:{

		},
		methods:{
			
		}
	}
</script>

<style></style>