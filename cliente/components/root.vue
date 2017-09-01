<template>
	<div id="Root" class="root-div">
		
	</div>
</template>

<script>
	import master from './master.vue'
	import constantes from './constants.js'


	export default{
		components:{
			tabs
		},
		data (){
			return{
			}
		},
		computed:{
			showDetailEntradas: function(){
				return this.showDetail && this.menuChoice == "Entrada";
			},
			showDetailPeliculas: function(){
				return this.showDetail && this.menuChoice == "Pelicula";
			},
		},
		methods:{
			setNew(newState){
				this.showDetail = true;
				this.enableButtons = false;
				this.read = false;	
				this.detailMode = constantes.STATE_NEW;
			},
			readIndex(index){
				this.itemIndex = index;
				this.showDetail = true;
				this.detailMode = constantes.STATE_READ;
				this.enableButtons = false;
			},
			updateIndex(index){
				this.itemIndex = index;
				this.showDetail = true;
				this.enableButtons = false;
				this.detailMode = constantes.STATE_UPDATE;
			},		
			changeTab(option){
				this.menuChoice = option;
				this.showDetail = false;
			}

		}
	}
</script>

<style></style>