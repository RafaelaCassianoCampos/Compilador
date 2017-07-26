<?php 

	abstract class Automovel implements IVeiculo{

	public function acelerar($velocidade){

		echo "O veículo acelerou até " . $velocidade . "km/h <br/>";
	}

		public function frenar($velocidade){

		echo "O veículo frenou até " . $velocidade . "km/h <br/>";
	}

		public function trocarMarcha($marcha){

		echo "O veículo engatou a marcha " . $marcha . "<br/>";
	}
}

 ?>