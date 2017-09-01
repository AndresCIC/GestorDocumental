<template>
	<div id="Root" class="container-fluid">
		<div id = "Menu">
			<ul class="nav nav-tabs" id="myTab" role="tablist">
			  <li class="nav-item">
				<a id='Usuarios' role="tab" data-toggle="tab" href="#Documentos" class="nav-link active" :class ="anchorClass('Documentos')" v-on:click="chooseMenu('Documentos')">Documentos</a>
			  </li>
			  <li class="nav-item">
				 <a class="nav-link" data-toggle="tab" href="#Plantillas" role="tab" :class ="anchorClass('Plantillas')" v-on:click="chooseMenu('Plantillas')">Plantillas</a>
			  </li>
			  <li class="nav-item">
				<a class="nav-link" data-toggle="tab" href="#Perfiles" role="tab":class ="anchorClass('Perfiles')" v-on:click="chooseMenu('Perfiles')">Perfiles de usuarios</a>
			  </li>
			</ul>				

		</div>
		<hr>
		<div class="row">
			<master :menuChoice="menuChoice" class="col-8"></master>
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
			
		}
	}
</script>

<style></style>