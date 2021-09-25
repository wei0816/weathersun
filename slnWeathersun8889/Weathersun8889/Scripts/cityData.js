var word = [
    {
        Area: 'TW', City: [
            { CName: '基隆市', EName: 'Keelung' },
            { CName: '臺北市', EName: 'Taipei' },
            { CName: '新北市', EName: 'New Taipei' },
            { CName: '桃園市', EName: 'Taoyuan' },
            { CName: '新竹市', EName: 'Hsinchu City' },
            { CName: '新竹縣', EName: 'Hsinchu County' },
            { CName: '苗栗縣', EName: 'Miaoli' },
            { CName: '臺中市', EName: 'Taichung' },
            { CName: '彰化縣', EName: 'Changhua' },
            { CName: '南投縣', EName: 'Nantou' },
            { CName: '雲林縣', EName: 'Yunlin' },
            { CName: '嘉義縣', EName: 'Chiayi County' },
            { CName: '嘉義市', EName: 'Chiayi' },
            { CName: '花蓮縣', EName: 'Hualien' },
            { CName: '宜蘭縣', EName: 'Yilan' },
            { CName: '臺東縣', EName: 'Taitung' },
            { CName: '澎湖縣', EName: 'Penghu' },
            { CName: '金門縣', EName: 'Kinmen ' },
            { CName: '連江縣', EName: 'Lianjiang' },
           
        ]
    }
];

var WeekForcastUrl = 'https://opendata.cwb.gov.tw/api/v1/rest/datastore/F-D0047-091?';

var WeekChinese = {
    "Mon": "一",
    "Tue": "二",
    "Wed": "三",
    "Thu": "四",
    "Fri": "五",
    "Sat": "六",
    "Sun": "日"
}


var weather_con = {
    "01": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_sunny.png", "晴天"],
    "02": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_sunny.png", "晴天"],
    "03": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_cloudy.png", "多雲"],
    "04": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_cloudy.png", "多雲"],
    "05": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_cloudy.png", "多雲"],
    "06": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_cloudy.png", "多雲"],
    "06": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "07": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "08": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "09": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "10": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "11": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "12": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "13": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "14": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "15": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "16": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "17": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "18": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_rain.png", "雨天"],
    "19": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_thunder.png", "多雲午後短暫雷陣雨"],
    "20": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_thunder.png", "多雲午後短暫雷陣雨"],
    "21": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_thunder.png", "多雲午後短暫雷陣雨"],
    "22": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_thunder.png", "多雲午後短暫雷陣雨"],
    "23": ["https://isdaniel.github.io/Yahoo-WeatherAPI/Images/weather_thunder.png", "多雲午後短暫雷陣雨"]
}
