using CivLeagueJP.API.ValueHandlers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivLeagueJP.API.Models.Civ6
{
    [Table("Maps")]
    public class Map
    {
        public int Id { get; }
        public Match Match { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        [NotMapped]
        public virtual List<Terrain> Terrains { get; set; }
        [NotMapped]
        public virtual List<Feature> Features { get; set; }
        [NotMapped]
        public virtual List<Resource> Resources { get; set; }
        [NotMapped]
        public virtual List<Improvement> Improvements { get; set; }
        [NotMapped]
        public virtual List<Route> Routes { get; set; }
        [NotMapped]
        public virtual List<Pillage> Pillageds { get; set; }
        [NotMapped]
        public virtual List<Yield> Yields { get; set; }
    }

    [Table("Plots")]
    public abstract class PlotBase
    {
        public int Id { get; set; }
        public int[] Location { get; set; }
        public DateTime Date { get; set; }
    }

    [Table("Plots")]
    public class Terrain : PlotBase
    {
        public TerrainEnum TerrainType { get; set; }
    }

    [Table("Plots")]
    public class Feature : PlotBase
    {
        public FeatureEnum FeatureType { get; set; }
    }

    [Table("Plots")]
    public class Resource : PlotBase
    {
        public ResourceEnum ResourceType { get; set; }
    }

    [Table("Plots")]
    public class Improvement : PlotBase
    {
        public ImprovementEnum ImprovementType { get; set; }
    }

    [Table("Plots")]
    public class Route : PlotBase
    {
        public RouteEnum RouteType { get; set; }
    }

    [Table("Plots")]
    public class Pillage
    {
        public bool IfPillaged { get; set; }
    }

    [Table("Plots")]
    public class Yield
    {
        //Food, Production, Gold, Culture, Faith, Tourism
        public EFIntList Yields { get; set; }
    }

    public class Units
    {
        public int Id { get; set; }
        public Match Match { get; set; }
        public int Turn { get; set; }
        [NotMapped]
        public virtual EFIntArrayList Locations { get; set; }
        [NotMapped]
        public virtual EFIntList UnitTypes { get; set; }
        [NotMapped]
        public virtual EFIntList OperatedByIds { get; set; }
        [NotMapped]
        public virtual EFDoubleList HPs { get; set; }
        [NotMapped]
        public virtual EFIntArrayList Promotions { get; set; }
    }


    public enum TerrainEnum
    {
        grass,
        grass_hills,
        grass_mountain,
        plains,
        plains_hills,
        plains_mountain,
        desert,
        desert_hills,
        desert_mountain,
        tundra,
        tundra_hills,
        tundra_mountain,
        snow,
        snow_hills,
        snow_mountain,
        coast,
        ocean
    }

    public enum FeatureEnum
    {
        floodplains,
        ice,
        jungle,
        forest,
        oasis,
        marsh,
        barrier_reef,
        cliffs_dover,
        crater_lake,
        dead_sea,
        everest,
        galapagos,
        kilimanjaro,
        pantanal,
        piopiotahi,
        torres_del_paine,
        tsingy,
        yosemite,
        reef,
        delicate_arch,
        eye_of_the_sahara,
        lake_retba,
        matterhorn,
        roraima,
        ubsunur_hollow,
        zhangye_danxia,
        ha_long_bay,
        eyjafjallajokull,
        lysefjorden,
        giants_causeway,
        uluru
    }

    public enum ResourceEnum
    {
        aluminum,
        amber,
        antiquity_site,
        bananas,
        cattle,
        cinnamon,
        citrus,
        cloves,
        coal,
        cocoa,
        coffee,
        copper,
        cosmetics,
        cotton,
        crabs,
        deer,
        diamonds,
        dyes,
        fish,
        furs,
        gypsum,
        horses,
        incense,
        iron,
        ivory,
        jade,
        jeans,
        marble,
        mercury,
        niter,
        oil,
        olives,
        pearls,
        perfume,
        rice,
        salt,
        sheep,
        shipwreck,
        silk,
        silver,
        spices,
        stone,
        sugar,
        tea,
        tobacco,
        toys,
        truffles,
        turtles,
        uranium,
        whales,
        wheat,
        wine
    }

    public enum ImprovementEnum
    {
        airstrip,
        alcazar,
        barbarian_camp,
        beach_resort,
        camp,
        chateau,
        chemamull,
        city_park,
        colossal_head,
        farm,
        fishery,
        fishing_boats,
        fort,
        golf_course,
        goody_hut,
        great_wall,
        kampung,
        kurgan,
        lumber_mill,
        mekewap,
        mine,
        missile_silo,
        mission,
        monastery,
        offshore_oil_rig,
        oil_well,
        outback_station,
        pairidaeza,
        pasture,
        plantation,
        polder,
        pyramid,
        quarry,
        roman_fort,
        sphinx,
        stepwell,
        ziggurat
    }

    public enum RouteEnum
    {
        ancient_road,
        medieval_road,
        industrial_road,
        modern_road
    }



    public enum BuildingType
    {
        airport,
        alhambra,
        amphitheater,
        amundsen_scott_research_station,
        angkor_wat,
        apadana,
        aquarium,
        aquatics_center,
        arena,
        armory,
        bank,
        barracks,
        basilkoi_paides,
        big_ben,
        bolshoi_theatre,
        broadcast_center,
        broadway,
        casa_de_contratacion,
        castle,
        cathedral,
        chichen_itza,
        colosseum,
        colossus,
        cristro_redentor,
        dar_e_mehr,
        eiffel_tower,
        electronics_factory,
        estadio_do_maracana,
        factory,
        ferris_wheel,
        film_studio,
        food_market,
        forbidden_city,
        gov_citystates,
        gov_conquest,
        gov_culture,
        gov_faith,
        gov_military,
        gov_science,
        gov_spies,
        gov_tall,
        gov_wide,
        granary,
        great_library,
        great_lighthouse,
        great_zimbabwe,
        gurdwara,
        hagia_sophia,
        halicarnassus_mausoleum,
        hangar,
        hanging_gardens,
        hermitage,
        huey_teocalli,
        jebel_berkal,
        kilwa_kisiwani_,
        kotoku_in,
        large_rocket,
        library,
        lighthouse,
        madrasa,
        mahabodhi_temple,
        market,
        medium_rocket,
        meeting_house,
        military_academy,
        mont_st_michel,
        monument,
        mosque,
        museum_art,
        museum_artifact,
        oracle,
        ordu,
        oxford_university,
        pagoda,
        palace,
        petra,
        potala_palace,
        power_plant,
        prasat,
        pyramids,
        research_lab,
        ruhr_valley,
        seaport,
        sewer,
        shipyard,
        shopiing_mall,
        shrine,
        small_rocket,
        st_basils_cathedral,
        stable,
        stadium,
        star_fort,
        statue_liberty,
        stave_shurch,
        stock_exchange,
        stonehenge,
        stupa,
        sukiennice,
        sydney_opera_house,
        synagogue,
        taj_mahal,
        terracotta_army,
        tlachtli,
        tsikhe,
        university,
        venetian_arsenal,
        walls,
        wat,
        water_mill,
        workshop,
        zoo
    }

    public enum DistrictType
    {
        acropolis,
        aerodrome,
        aqueduct,
        bath,
        campus,
        city_center,
        commercial_hub,
        encampment,
        entertainment_complex,
        government,
        hansa,
        harbor,
        holy_site,
        ikanda,
        industrial_zone,
        lavra,
        mbanza,
        neighborhood,
        royal_navy_dockyard,
        seowon,
        spaceport,
        street_carnival,
        theater,
        water_entertainment_complex,
        water_street_carnival,
        wonder
    }


    public enum UnitType
    {
        aircraft_carrier,
        american_p51,
        american_rough_rider,
        antiair_gun,
        apostle,
        arbian_mamluk,
        archaeologist,
        archer,
        artillery,
        at_crew,
        aztec_eagle_warrior,
        barbarian_horse_archer,
        barbarian_horseman,
        barbarian_raider,
        barbarian_ram,
        battleship,
        biplane,
        bombard,
        bomber,
        brazilian_minas_geraes,
        builder,
        caravel,
        catapult,
        cavalry,
        chinese_crouching_tiger,
        cree_okihtcitaw,
        crossbowman,
        de_zeven_provincien,
        destroyer,
        digger,
        drone,
        egyptian_chariot_archer,
        english_redcoat,
        english_seadog,
        field_cannon,
        fighter,
        french_garde_imperiale,
        frigate,
        galley,
        georgian,khevsureti,
        german_uboat,
        great_admiral,
        great_artist,
        great_engineer,
        great_general,
        great_merchant,
        great_musician,
        great_prophet,
        great_scientist,
        great_writer,
        greek_hoplite,
        guru,
        heacy_chariot,
        helicopter,
        horseman,
        indian_varu,
        indonesian_jong,
        infantry,
        inquisitor,
        ironclad,
        japanese_samurai,
        jet_bomber,
        jet_fighter,
        khmer_domrey,
        knight,
        kongo_shield_bearer,
        korean_hwacha,
        macedonian_hetairoi,
        macedonian_hypaspist,
        machine_gun,
        mapuche_makon_raider,
        mechanized_infantry,
        medic,
        military_engineer,
        missle_cruiser,
        missionary,
        mobile_sam,
        modern_armor,
        modern_at,
        mongolian_keshig,
        musketman,
        naturalist,
        norwegian_berserker,
        norwegian_longship,
        nubian_pitati,
        nuclear_submarine,
        observation_balloon,
        persian_immortal,
        pike_and_shot,
        pikeman,
        polish_hussar,
        privateer,
        quadrireme,
        ranger,
        rocket_artillery,
        roman_legion,
        russian_cossack,
        scottish_highlander,
        scout,
        scythian_horse_archer,
        settler,
        siege_tower,
        slinger,
        spanish_conquistador,
        spearman,
        spec_ops,
        spy,
        submarine,
        sumerian_war_cart,
        supply_convoy,
        swordman,
        tank,
        trader,
        warrior,
        warrior_monk,
        zulu_impi
    }
}

