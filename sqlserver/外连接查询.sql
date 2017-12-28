  SELECT huowei_liu.commodity_code,   
         huowei_liu.stock_code,   
         huowei_liu.area_code,   
        
         huowei_liu.floor,   
         huowei_liu.shelfliu_code,   
         huowei_liu.shelfliu_name,   
         tw012.bale_number,   
         huowei_liu.parent_code,   
         tw012.parent_code,   
         huowei_liu.small_number,   
         huowei_liu.big_number,   
         huowei_liu.liu_ip1,   
         huowei_liu.ip1_property,   
         huowei_liu.liu_ip2,   
         huowei_liu.ip2_property,   
         huowei_liu.capacity,   
         huowei_liu.capacitycoeff,   
         huowei_liu.remark,   
         tw012.bale_spec  
    FROM 
         huowei_liu
    LEFT outer JOIN
    tw012
    on huowei_liu.commodity_code = tw012.bale_number
      

表的别名:   
       SELECT huowei_liu.stock_code,   
         huowei_liu.area_code,   
         huojia.consignment_areacode,   
         huojia.shelf_code,   
         huojia.shelf_property,   
         huowei_liu.floor,   
         huowei_liu.shelfliu_code,   
         huowei_liu.shelfliu_name,   
         huowei_liu.commodity_code,   
         cdmwu1.bale_name,   
         huowei_liu.parent_code,   
         cdmwu2.bale_name,   
         huowei_liu.small_number,   
         huowei_liu.big_number,   
         huowei_liu.liu_ip1,   
         huowei_liu.ip1_property,   
         huowei_liu.liu_ip2,   
         huowei_liu.ip2_property,   
         huowei_liu.capacity,   
         huowei_liu.capacitycoeff,   
         huowei_liu.remark  
    FROM huojia,   
         huowei_liu,   
         tw012 cdmwu1,   
         tw012 cdmwu2  
   WHERE ( huowei_liu.parent_code *= cdmwu2.bale_number) and  
         ( huowei_liu.shelf_code = huojia.shelf_code ) and  
         ( huowei_liu.commodity_code = cdmwu1.bale_number )    
