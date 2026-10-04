$(document).ready(function () {


    let RegionBranch1 = ["Thaketa-1 Branch", "Thaketa-2 Branch", "Mingalar Taung Nyunt Branch", "Thingankyun Branch", "Khayan Branch"];
    let RegionBranch2 = ["East Dagon Branch", "North Dagon Branch", "Shwe Pyi Thar-1 Branch", "Shwe Pyi Thar-2 Branch", "Insein Branch", "Mayangone Branch"];
    let RegionBranch3 = ["North Okkalapa-1 Branch", "North Okkalapa-2 Branch", "Hlegu-1 Branch", "Hlegu-2 Branch", "Mingalardon Branch"];
    let RegionBranch4 = ["Mawlamyine-1 Branch", "Mawlamyine-2 Branch", "Mudon Branch", "Hpa-An Branch", "Paung Branch", "Dawei", "Chaungzon Branch"];
    let RegionBranch5 = ["Bago-1 Branch", "Bago-2 Branch", "Thanetpin Branch", "Kawa Branch", "Letpadan Branch", "Tharyarwaddy Branch"];
    let RegionBranch6 = ["Taungoo Branch", "Oktwin Branch", "Phyu Branch", "Kyauktaga Branch", "Lewe Branch", "Yedashe Branch"];
    let RegionBranch7 = ["Nattalin Branch", "Zigon Branch", "Gyobingauk Branch", "Minhla Branch", "Oakpho Branch", "Paungde Branch"];
    let RegionBranch8 = ["Thegon-1 Branch", "Thegon-2 Branch (Inn ma)", "Pyay-1 Branch", "Pyay-2 Branch", "Shwe Taung Branch", "Pauk Khaung Branch", "Padaung Branch"];
    let RegionBranch9 = ["Kanma Branch", "Aunglan Branch", "Taung Twin Gyi Branch", "Magway Branch", "Minbu Branch", "Natmauk Branch", "Myothit Branch"];
    let RegionBranch10 = ["Yamathin Branch", "Meiktila Branch", "Pyawbwe Branch", "Myingyan Branch", "Taungtha Branch", "Thazi Branch", "Wundwin Branch", "Naung Htiko Branch"];
    let RegionBranch11 = ["Kyaukse Branch", "Myittha Branch(Kume)", "Sintgaing Branch", "Sagaing Branch", "Monywa Branch", "Myinmu Branch"];

    let AllBranch = RegionBranch1.concat(RegionBranch2, RegionBranch3, RegionBranch4, RegionBranch5, RegionBranch6, RegionBranch7, RegionBranch8, RegionBranch9, RegionBranch10, RegionBranch11);

    for (var i = 0; i < AllBranch.length; i++) {
        $("#BranchNameClient").append("<option value='" + AllBranch[i] + "'>" + AllBranch[i] + "</option>");
    }

    if ($("#TypeOfCall").val() == "Complaint") {
        $("#complaint").show();
        $("#inquire").hide();
    }

    $("#TypeOfCall").on("change", function () {
        if ($("#TypeOfCall").val() == "Complaint") {
            $("#complaint").show();
            $("#inquire").hide();

        }
        else {
            $("#complaint").hide();
            $("#inquire").show();

         
        }
    });

    


    $("#TypyOfProduct").on("change", function () {

        if ($("#TypyOfProduct").val() == "Other") {
            $("#otherproducttype").show();
        }
        else {
            $("#otherproducttype").hide();
        }
    });

    $("#TypeOfBusiness").on("change", function () {
        if ($("#TypeOfBusiness").val() == "Other") {
            $("#otherbusiness").show();
        }
        else {
            $("#otherbusiness").hide();
        }
    });
    $(document).on("change", "#TypeOfCaller", function () {

        $("#CustomerSegment").html("");
        if ($("#TypeOfCaller:checked").val() == "Products") {
            $("#product").show();
            $("#typeofothercaller").hide();
        }
        else {
            $("#product").hide();

            
            

            $("#typeofothercaller").show();
        }
    });


  
    $("#RegionComplaint").on("change", function () {
        $("#BranchName").html("");
        $("#branchNm").show();
        $("#commentbox").hide();
        switch ($("#RegionComplaint").val()) {
            case "Region(1)":

                for (var i = 0; i < RegionBranch1.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch1[i] + "'>" + RegionBranch1[i] + "</option>");
                }
                break;
            case "Region(2)":
                for (var i = 0; i < RegionBranch2.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch2[i] + "'>" + RegionBranch2[i] + "</option>");
                }
                break;
            case "Region(3)":
                for (var i = 0; i < RegionBranch3.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch3[i] + "'>" + RegionBranch3[i] + "</option>");
                }
                break;
            case "Region(4)":
                for (var i = 0; i < RegionBranch4.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch4[i] + "'>" + RegionBranch4[i] + "</option>");
                }
                break;
            case "Region(5)":
                for (var i = 0; i < RegionBranch5.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch5[i] + "'>" + RegionBranch5[i] + "</option>");
                }
                break;
            case "Region(6)":
                for (var i = 0; i < RegionBranch6.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch6[i] + "'>" + RegionBranch6[i] + "</option>");
                }
                break;
            case "Region(7)":
                for (var i = 0; i < RegionBranch7.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch7[i] + "'>" + RegionBranch7[i] + "</option>");
                }
                break;
            case "Region(8)":
                for (var i = 0; i < RegionBranch8.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch8[i] + "'>" + RegionBranch8[i] + "</option>");
                }
                break;
            case "Region(9)":
                for (var i = 0; i < RegionBranch9.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch9[i] + "'>" + RegionBranch9[i] + "</option>");
                }
                break;
            case "Region(10)":
                for (var i = 0; i < RegionBranch10.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch10[i] + "'>" + RegionBranch10[i] + "</option>");
                }
                break;
            case "Region(11)":
                for (var i = 0; i < RegionBranch11.length; i++) {
                    $("#BranchName").append("<option value='" + RegionBranch11[i] + "'>" + RegionBranch11[i] + "</option>");
                }
                break;
            case "Other":
                $("#branchNm").hide();
                $("#commentbox").show();
                break;
        }
    });


    let RegionKachin = ["Bhamo Township", "Shwegu Township", "Momauk Township", "Mansi Township", "Mohnyin Township", "Mogaung Township", "Hpakant Township", "Myitkyina Township", "Waingmaw Township", "Injangyang Township", "Tanai Township", "Chipwi Township", "Hsawlaw Township", "Putao Township", "Sumprabum Township", "Machanbaw Township", "Kawnglanghpu Township", "Nogmung Township"];
    let RegionKayah = ["Bawlakhe Township", "Hpasawng Township", "Mese Township", "Loikaw Township", "Demoso Township", "Hpruso Township", "Shadaw Township"];
    let RegionKayin = ["Hpa-an Township", "Hlaignbwe Township", "Hpapun Township", "Thandang Township", "Kawkareik Township", "Kyain Seikgyi Township", "Myawaddy Township"];
    let RegionChin = ["Falam Township", "Haka Township", "Htantlang Township", "Tiddim Township", "Ton Zang Township", "Mindat Township", "Matupi Township", "Kanpetlet Township", "Paletwa Township"];
    let RegionMon = ["Mawlamyine Township", "Kyaikmaraw Township", "Chaungzon Township", "Thanbyuzayat Township", "Mudon Township", "Ye Township", "Thaton Township", "Paung Township", "Kyaikto Township", "Bilin Township"];
    let RegionRakhine = ["Kyaukpyu Township", "Manaung Township", "Ramree Township", "Ann Township", "Maungdaw Township", "Buthidaung Township", "Sittwe Township", "Ponnagyun Township", "Mrauk-U Township", "Kyauktaw Township", "Minbya Township", "Myebon Township", "Pauktaw Township", "Rathedaung Township", "Thandwe Township", "Toungup Township", "Gwa Township"];
    let RegionShan = ["Kengtung Township", "Mong Khet Township", "Mong La Township", "Mong Pauk Township", "Mong Yang Township", "Mong Hsat Township", "Mong Ping Township", "Mong Tong Township", "Mong Hpayak Township", "Mong Yawng Township", "Tachileik Township", "Kyaing Lap (Kenglap)", "Kunlong Township", "Hopang Township", "Kyaukme Township", "Nawnghkio Township", "Hsipaw Township", "Namtu Township", "Namhsan Township", "Mongmit Township", "Mabein Township", "Mantong Township", "Laukkaing Township", "Lashio Township", "Hseni Township", "Mongyai Township", "Tangyan Township", "Mu Se Township", "Namhkam Township", "Kutkai Township", "Mong Maw Township", "Pangwaun Township", "Metman Township", "Panghkan Township", "Namphan Township", "Langkho Township", "Mong Nai Township", "Mawkmai Township", "Mong Pan Township", "Loilen Township", "Lai-Hka Township", "Nansang Township", "Kunhing Township", "Kyethi Township", "Mong Kung Township", "Mong Hsu Township", "Taunggyi Township", "Nyaungshwe Township", "Hopong Township", "Hsi Hseng Township", "Kalaw Township", "Pingdaya Township", "Ywangan Township", "Lawksawk Township", "Pinlaung Township", "Pekon Township"];
    let RegionNaypyitawCouncil = ["Lewe Township", "Pyinmana Township", "Tatkon Township", "Ottarathiri Township", "Dekkhinathiri Township", "Pobbathiri Township", "Zabuthiri Township", "Zeyathiri Township"];
    let RegionSagaing = ["Hkamti Township", "Homalin Township", "Lahe Township", "Lay Shi Township (Lashe Township)", "Nanyun Township", "Kale Township (Kalemyo Township)", "Kalewa Township", "Mingin Township", "Banmauk Township", "Indaw Township", "Katha Township", "Kawlin Township", "Pinlebu Township", "Tigyaing Township", "Wuntho Township", "Mawlaik Township", "Paungbyin Township", "Ayadaw Township", "Budalin Township", "Chaung-U Township", "Kani Township", "Monywa Township", "Pale Township", "Salingyi Township", "Tabayin Township", "Yinmabin Township", "Myaung Township", "Myinmu Township", "Sagaing Township", "Kanbalu Township", "Khin-U Township", "Kyunhla Township", "Shwebo Township", "Taze Township", "Wetlet Township", "Ye-U Township", "Tamu Township"];
    let RegionMagway = ["Gangaw Township", "Tilin Township", "Saw Township", "Magway Township", "Yenangyaung Township", "Chauck Township", "Taungdwingyi Township", "Myothit Township", "Natmauk Township", "Minbu Township", "Pwintbyu Township", "Ngape Township", "Salin Township", "Sidoktaya Township", "Myaing Township", "Pakokku Township", "Pauk Township", "Seikphyu Township", "Yesagyo Township", "Aunglan Township", "Kamma Township", "Mindon Township", "Minhla Township", "Sinbaungwe Township", "Thayet Township"];
    let RegionMandalay = ["Kyaukse Township", "Myittha Township", "Sintgaing Township", "Tada-U Township", "Amarapura Township", "Aungmyethazan Township", "Chanayethazan Township", "Chanmyathazi Township", "Mahaaungmye Township", "Patheingyi Township", "Pyigyidagun Township", "Mahlaing Township", "Meiktila Township", "Thazi Township", "Wundwin Township", "Kyaukpadaung Township", "Myingyan Township", "Natogyi Township", "Nganzun Township", "Thaungtha Township", "Nyaung-U Township", "Madaya Township", "Mogok Township", "Pyinoolwin Township", "Singu Township", "Thabeikkyin Township", "Pyawbwe Township", "Yamethin Township"];
    let RegionBago = ["Bago Township", "Kawa Township", "Thanatpin Township", "Waw Township", "Daik-U Township", "Nyaunglebin Township", "Shwegyin Township", "Taungoo Township", "Oktwin Township", "Tantabin Township", "Yedashe Township", "Pyu Township", "Kyauktaga Township", "Kyaukkyi Township", "Pyay Township", "Pauk Kaung Township", "Thegon Township", "Shwedaung Township", "Padaung Township", "Paungde Township", "Nattalin Township", "Zigon Township", "Thayarwady Township", "Gyobingauk Township", "Letpadan Township", "Minhla Township", "Monyo Township", "Okpho Township"];
    let RegionYangon = ["Botataung Township", "Dagon Seikkan Township", "East Dagon Township", "North Dagon Township", "North Okkalapa Township", "Pazundaung Township", "South Dagon Township", "South Okkalapa Township", "Thingangyun Township", "Hlaing Township", "Hlaingthaya Township", "Insein Township", "Kamayut Township", "Mayangon Township", "Mingaladon Township", "Shwepyitha Township", "Yankin Township", "Dala Township", "Dawbon Township", "Mingala Taungnyunt Township", "Seikkyi Kanaungto Township", "Tamwe Township", "Thaketa Township", "Ahlon Township", "Bahan Township", "Dagon Township", "Kyauktada Township", "Kyimyindaing Township", "Lanmadaw Township", "Latha Township", "Pabedan Township", "Sanchaung Township", "Seikkan Township", "Cocokyun Township", "Hlegu Township", "Hmawbi Township", "Htantabin Township", "Kawhmu Township", "Kayan Township", "Kungyangon Township", "Kyauktan Township", "Taikkyi Township", "Thanlyin Township", "Thongwa Township", "Twante Township"];
    let RegionAyayawaddy = ["Hinthada Township", "Zalun Township", "Laymyethna Township", "Myanaung Township", "Kyangin Township", "Ingapu Township", "Labutta Township", "Mawlamyinegyun Township", "Ma-ubin Township", "Pantanaw Township", "Nyaungdon Township", "Danuphyu Township", "Myaungmya Township", "Einme Township", "Wakema Township", "Pathein Township", "Kangyidaunk Township", "Thabaung Township", "Ngapudaw Township", "Kyonpyaw Township", "Yekyi Township", "Kyaunggon Township", "Pyapon Township", "Bogale Township", "Kyaiklat Township", "Dedaye Township"];
    let RegionTanintharyi = ["Dawei Township", "Launglon Township", "Thayetchaung Township", "Yebyu Township", "Bokpyin Township", "Kawthoung Township", "Kyunsu Township", "Myeik Township", "Palaw Township", "Tanintharyi Township"];

    $("#Town").html("");
    for (var i = 0; i < RegionKachin.length; i++) {
        $("#Town").append("<option value='" + RegionKachin[i] + "'>" + RegionKachin[i] + "</option>");
    }

    $("#RegionProduct").on("change", function () {
        $("#Town").html("");
        
        switch ($("#RegionProduct").val()) {
            case "Kachin":
                for (var i = 0; i < RegionKachin.length; i++) {
                    $("#Town").append("<option value='" + RegionKachin[i] + "'>" + RegionKachin[i] + "</option>");
                }
                break;
            case "Kayah":
                for (var i = 0; i < RegionKayah.length; i++) {
                    $("#Town").append("<option value='" + RegionKayah[i] + "'>" + RegionKayah[i] + "</option>");
                }
                break;
            case "Kayin":
                for (var i = 0; i < RegionKayin.length; i++) {
                    $("#Town").append("<option value='" + RegionKayin[i] + "'>" + RegionKayin[i] + "</option>");
                }
                break;
            case "Chin":
                for (var i = 0; i < RegionChin.length; i++) {
                    $("#Town").append("<option value='" + RegionChin[i] + "'>" + RegionChin[i] + "</option>");
                }
                break;
            case "Mon":
                for (var i = 0; i < RegionMon.length; i++) {
                    $("#Town").append("<option value='" + RegionMon[i] + "'>" + RegionMon[i] + "</option>");
                }
                break;
            case "Rakhine":
                for (var i = 0; i < RegionRakhine.length; i++) {
                    $("#Town").append("<option value='" + RegionRakhine[i] + "'>" + RegionRakhine[i] + "</option>");
                }
                break;
            case "Shan":
                for (var i = 0; i < RegionShan.length; i++) {
                    $("#Town").append("<option value='" + RegionShan[i] + "'>" + RegionShan[i] + "</option>");
                }
                break;
            case "NaypyitawCouncil":
                for (var i = 0; i < RegionNaypyitawCouncil.length; i++) {
                    $("#Town").append("<option value='" + RegionNaypyitawCouncil[i] + "'>" + RegionNaypyitawCouncil[i] + "</option>");
                }
                break;
            case "Sagaing":
                for (var i = 0; i < RegionSagaing.length; i++) {
                    $("#Town").append("<option value='" + RegionSagaing[i] + "'>" + RegionSagaing[i] + "</option>");
                }
                break;
            case "Magway":
                for (var i = 0; i < RegionMagway.length; i++) {
                    $("#Town").append("<option value='" + RegionMagway[i] + "'>" + RegionMagway[i] + "</option>");
                }
                break;
            case "Mandalay":
                for (var i = 0; i < RegionMandalay.length; i++) {
                    $("#Town").append("<option value='" + RegionMandalay[i] + "'>" + RegionMandalay[i] + "</option>");
                }
                break;
            case "Bago":
                for (var i = 0; i < RegionBago.length; i++) {
                    $("#Town").append("<option value='" + RegionBago[i] + "'>" + RegionBago[i] + "</option>");
                }
                break;
            case "Yangon":
                for (var i = 0; i < RegionYangon.length; i++) {
                    $("#Town").append("<option value='" + RegionYangon[i] + "'>" + RegionYangon[i] + "</option>");
                }
                break;
            case "Ayayawaddy":
                for (var i = 0; i < RegionAyayawaddy.length; i++) {
                    $("#Town").append("<option value='" + RegionAyayawaddy[i] + "'>" + RegionAyayawaddy[i] + "</option>");
                }
                break;
            case "Tanintharyi":
                for (var i = 0; i < RegionTanintharyi.length; i++) {
                    $("#Town").append("<option value='" + RegionTanintharyi[i] + "'>" + RegionTanintharyi[i] + "</option>");
                }
                break;
             
        }
    });

});