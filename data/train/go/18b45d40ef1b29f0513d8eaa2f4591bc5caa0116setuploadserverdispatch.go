// 设置上传机调度字段Act和Dispatchstatus，界面根据这两个字段来显示属性开关

package conf

import (
	"./conf"
	"github.com/labix.org/v2/mgo"
	"github.com/labix.org/v2/mgo/bson"
)

func SetUploadServerDispatch(ip string, act int, dispatch int) string {
	session, db := conf.Init("mgo.conf")

	defer session.Close()
	session.SetMode(mgo.Monotonic, true)

	table := conf.Read("upload", "table")
	collection := db.C(table)

	// 更新数据
	result := "{"
	err := collection.Update(bson.M{"ip": ip}, bson.M{"$set": bson.M{"act": act, "dispatchstatus": dispatch}})
	if err != nil {
		//panic(err)
		result = result + "\"result\":" + "\"false\"" + "}"
	} else {
		result = result + "\"result\":" + "\"true\"" + "}"
	}

	return result
}
