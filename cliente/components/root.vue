<template>
	<div id="Root" class="container-fluid">
		<div id = "Menu">
			<ul class="nav nav-tabs" id="myTab" role="tablist">
			  <li class="nav-item">
				<a id='Documentos'  data-toggle="tab"  class="nav-link active" href=""  role="tab"  @click="currentView='Documentos'" v-on:click.prevent="">Documentos</a>
			  </li>
			  <li class="nav-item">
				 <a id="Plantillas" class="nav-link" data-toggle="tab" href="" role="tab"  @click="currentView='Plantillas'" v-on:click.prevent="">Plantillas</a>
			  </li>
			  <li class="nav-item">
				<a id="Perfiles" class="nav-link" data-toggle="tab" href="" role="tab"  @click="currentView='Perfiles'" v-on:click.prevent=""> Perfiles de usuarios</a>
			  </li>
			</ul>

		</div>
		<hr>
		<div class="row">
		<keep-alive>
			<component :is="currentView" class="col-12"></component>
			</keep-alive>

		</div>
	</div>
</template>



<script>
	import Documentos from './documentosMaster.vue'
	import Plantillas from  './plantillasMaster.vue'
	import Perfiles from './perfilesMaster.vue'
	import detail from './detail.vue'

	import constantes from './constants.js'


	export default{
		components:{
			detail,
			Documentos,
			Plantillas,
			Perfiles
		},
		data (){
			return{
				currentView: 'Documentos'
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