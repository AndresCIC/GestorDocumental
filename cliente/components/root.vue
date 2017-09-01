<template>
	<div id="Root" class="container-fluid">
		<div id = "Menu">
			<ul class="nav nav-tabs" id="myTab" role="tablist">
			  <li class="nav-item">
				<a id='Documentos' role="tab" data-toggle="tab" href="#Documentos" class="nav-link active"  v-on:click="chooseMenu('Documentos')">Documentos</a>
			  </li>
			  <li class="nav-item">
				 <a id="Plantillas" class="nav-link" data-toggle="tab" href="#Plantillas" role="tab" v-on:click="chooseMenu('Plantillas')">Plantillas</a>
			  </li>
			  <li class="nav-item">
				<a id="Perfiles" class="nav-link" data-toggle="tab" href="#Perfiles" role="tab" v-on:click="chooseMenu('Perfiles')">Perfiles de usuarios</a>
			  </li>
			</ul>				

		</div>
		<hr>
		<div class="row">
			<master :menuChoice="menuChoice" class="col-12"></master>
			<detail :menuChoice="menuChoice" :currentObject="currentObject"  :previousObject="previousObject" class="col"></detail>

		</div>
	</div>
</template>



<script>
	import master from './master.vue'
	import detail from './detail.vue'
	import constantes from './constants.js'


	export default{
		components:{
			master, 
			detail
		},
		data (){
			return{
			}
		},
		computed:{

		},
		methods:{
			anchorClass(tipo){

			}
		}
	}
</script>

<style></style>