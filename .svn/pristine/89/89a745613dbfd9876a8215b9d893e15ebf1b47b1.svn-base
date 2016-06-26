//$('.datepicker').datepicker();

$('.ITMXPerson , .ITMXBusiness , .data-customer , .data-customer button').hide();

//$('#btn_AcctNameEng_ghb_itmx').show();

		
		
		/********************** Block Left *****************************/
		var FirstNameEng = $('#FirstNameEng').val().substr(0, 32);
		var MiddleNameEng = $('#MiddleNameEng').val().substr(0, 32);
		var LastNameEng = $('#LastNameEng').val().substr(0, 32);

		var AcctNameEng = FirstNameEng + ' ' + MiddleNameEng + ' ' + LastNameEng;
		$('#AcctNameEng').val($.trim(AcctNameEng));

		var FirstNameThai = $('#FirstNameThai').val().substr(0, 32);
		var MiddleNameThai = $('#MiddleNameThai').val().substr(0, 32);
		var LastNameThai = $('#LastNameThai').val().substr(0, 32);
		
		var AcctNameThai = FirstNameThai + ' ' + MiddleNameThai + ' ' + LastNameThai;
		$('#FullNameThai').val($.trim(AcctNameThai));



		$('#btn_FullNameThai_ghb_itmx').on('click',function(){
			$('#ITMXDisplayName').val($('#FullNameThai').val());
		});

		$('#btn_AcctNameEngPerson_ghb_itmx').on('click',function(){
			$('#ITMXAcctName').val($('#AcctNameEng').val());
			$('#ITMXFirstName').val($('#FirstNameEng').val());
			$('#ITMXSecondName').val($('#MiddleNameEng').val());
			$('#ITMXLastName').val($('#LastNameEng').val());
		});
		$('#btn_AcctNameEngBusiness_ghb_itmx').on('click',function(){
			$('#ITMXAcctName').val($('#AcctNameEng').val());
		});

		$('#btn_MobileMailing_ghb_itmx').on('click',function(){
			$('#ITMXProxyValue').val($('#MobileMailing').val());
		});
		$('#btn_MobileHome_ghb_itmx').on('click',function(){
			$('#ITMXProxyValue').val($('#MobileHome').val());
		});
		$('#btn_MobileWork_ghb_itmx').on('click',function(){
			$('#ITMXProxyValue').val($('#MobileWork').val());
		});

/********************** Block Right *****************************/
		$('#ITMXProxyType').on('change',function(){
			$('#ITMXProxyValue').val('');
			if($(this).val() == "NATID") {
				$('#ITMXProxyValue').val($('#SSN').val());
				$('#btn_MobileMailing_ghb_itmx, #btn_MobileHome_ghb_itmx, #btn_MobileWork_ghb_itmx').hide();
			}else if($(this).val() == "MSISDN"){
				$('#ITMXProxyValue').val($('#Mobile').val());
				$('#btn_MobileMailing_ghb_itmx, #btn_MobileHome_ghb_itmx, #btn_MobileWork_ghb_itmx').show();
			}else{
				$('#ITMXProxyValue').val('');
				$('#btn_MobileMailing_ghb_itmx, #btn_MobileHome_ghb_itmx, #btn_MobileWork_ghb_itmx').hide();
			} ;
		})

		$('#ITMXDisplayNameL').on('change',function(){
			$('#ITMXDisplayName').val('');
			if($(this).val() == "English") {
				$('#ITMXDisplayName').val($('#AcctNameEng').val().substr(0, 50));
			}else if($(this).val() == "Thai"){
				$('#ITMXDisplayName').val($('#FullNameThai').val().substr(0, 50));
			}else{
				$('#ITMXDisplayName').val('');
			} ;
		});

		$('.radios-ah').on('click',function(){
			$('#senddata').show();
			if($(this).val() == "Person") {
				$('.ITMXPerson').show();
				$('.ITMXBusiness').hide();

				$('#btn_AcctNameEngPerson_ghb_itmx').show();
				$('#btn_AcctNameEngBusiness_ghb_itmx').hide();
				

				$('#ITMXBusinessName').val('');
				$('#ITMXBusinessRegisterDate').val('');
			}else if($(this).val() == "Business"){
				$('.ITMXPerson').hide();
				$('.ITMXBusiness').show();

				$('#btn_AcctNameEngPerson_ghb_itmx').hide();
				$('#btn_AcctNameEngBusiness_ghb_itmx').show();

				$('#ITMXFirstName').val('');
				$('#ITMXSecondName').val('');
				$('#ITMXLastName').val('');

			}else{
				$('.ITMXPerson').hide();
				$('.ITMXBusiness').hide();
			} ;
		});

		/* Demo */
		
		/*
		$( "#form1" ).submit(function() {
			$('.data-customer').show();
		});
		*/

		$('#singlebutton').on('click',function(){
			$('.data-customer').show();
		});